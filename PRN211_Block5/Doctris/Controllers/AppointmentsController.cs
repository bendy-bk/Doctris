using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doctris.Models;
using Doctris.Models.Authentication;

namespace Doctris.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly DoctrisContext _context;

        public AppointmentsController(DoctrisContext context)
        {
            _context = context;
        }
        [Authentication]
        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            //ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            List<Department> x = _context.Departments.ToList();
            ViewBag.List = x;
            var doctrisContext = _context.Appointments.Include(a => a.Department).Include(a => a.DoctorNavigation).Where(x=> x.IsActive.Equals(false));
            return View(await doctrisContext.ToListAsync());
        }
        [Authentication]
        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Department)
                .Include(a => a.DoctorNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [Authentication]
        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            ViewData["Doctor"] = new SelectList(_context.Users, "UserId", "UserName");
            return View();
        }
        [Authentication]
        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,Name,Email,Age,Gender,DepartmentId,Date,Doctor,IsActive")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();

                string? s = HttpContext.Session.GetString("UserName");
                var sql = from u in _context.Users
                          join urole in _context.UserRoles on u.UserId equals urole.UserId
                          join setting in _context.Settings on urole.RoleId equals setting.SettingId
                          select new
                          {
                              Username = u.UserName,
                              email = u.Email,
                              password = u.Password,
                              Role = setting.SettingName
                          };


                var checkRole = sql.Where(x => x.Username.Equals(s)).FirstOrDefault();
                if (checkRole.Role.Equals("employee"))
                {

                    ViewBag.Success = "Add Successfully";
                    return RedirectToAction("Homepage" , "Home");
                } else
                {
                    return RedirectToAction(nameof(Index));
                }

            }


            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", appointment.DepartmentId);
            ViewData["Doctor"] = new SelectList(_context.Users, "UserId", "UserId", appointment.Doctor);
            return View(appointment);
        }
        [Authentication]
        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", appointment.DepartmentId);
            ViewData["Doctor"] = new SelectList(_context.Users, "UserId", "UserName", appointment.Doctor);

            return View(appointment);
        }
        [Authentication]
        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,Name,Email,Age,Gender,DepartmentId,Date,Doctor,IsActive")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name", appointment.DepartmentId);
            ViewData["Doctor"] = new SelectList(_context.Users, "UserId", "UserName", appointment.Doctor);
            return View(appointment);
        }
        [Authentication]
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Department)
                .Include(a => a.DoctorNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [Authentication]
        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'DoctrisContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authentication]
        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
        [Authentication]
        public async Task<IActionResult> Apply(int id)
        { 
            if(_context.Appointments == null)
            {
                return Problem("Error");
            }

            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment != null)
            {
                appointment.IsActive = true;
                _context.Appointments.Update(appointment);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        }
}

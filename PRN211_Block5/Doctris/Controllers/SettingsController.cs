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
    public class SettingsController : Controller
    {
        private readonly DoctrisContext _context;

        
        public SettingsController(DoctrisContext context)
        {
            _context = context;
        }

        // GET: Settings

        [Authentication]
        public async Task<IActionResult> Index()
        {
              return _context.Settings != null ? 
                          View(await _context.Settings.ToListAsync()) :
                          Problem("Entity set 'DoctrisContext.Settings'  is null.");
        }

        [Authentication]
        // GET: Settings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }

        [Authentication]
        // GET: Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Create([Bind("SettingId,SettingType,SettingName,SettingDescription")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setting);
        }
        [Authentication]
        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings.FindAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,SettingType,SettingName,SettingDescription")] Setting setting)
        {
            if (id != setting.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingExists(setting.SettingId))
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
            return View(setting);
        }

        // GET: Settings/Delete/5
        [Authentication]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }
        [Authentication]
        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Settings == null)
            {
                return Problem("Entity set 'DoctrisContext.Settings'  is null.");
            }
            var setting = await _context.Settings.FindAsync(id);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authentication]
        private bool SettingExists(int id)
        {
          return (_context.Settings?.Any(e => e.SettingId == id)).GetValueOrDefault();
        }
    }
}

using Doctris.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Doctris.Controllers
{
    public class AccountController : Controller
    {
        private readonly DoctrisContext _doctrisContext = new DoctrisContext();

       
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null || HttpContext.Session.GetString("email") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Homepage", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {



                var sql = from u in _doctrisContext.Users
                          join urole in _doctrisContext.UserRoles on u.UserId equals urole.UserId
                          join setting in _doctrisContext.Settings on urole.RoleId equals setting.SettingId
                          select new
                          {
                              Username = u.UserName,
                              email = u.Email,
                              password = u.Password,
                              Role = setting.SettingName
                          };


                var checkuser = sql.Where(x => x.Username.Equals(user.UserName) && x.password.Equals(user.Password)).FirstOrDefault();  

                if (checkuser != null && checkuser.Role.Equals("admin"))
                {
                    HttpContext.Session.SetString("email", checkuser.email.ToString());
                    HttpContext.Session.SetString("UserName", checkuser.Username.ToString());
                    return RedirectToAction("Admin", "Home");
                }
                else if (checkuser != null && checkuser.Role.Equals("doctor"))
                {
                    HttpContext.Session.SetString("email", checkuser.email.ToString());
                    HttpContext.Session.SetString("UserName", checkuser.Username.ToString());
                    return RedirectToAction("Admin", "Home");
                }
                else if (checkuser != null)
                {
                    HttpContext.Session.SetString("email", checkuser.email.ToString());
                    HttpContext.Session.SetString("UserName", checkuser.Username.ToString());
                    return RedirectToAction("Homepage", "Home");
                }

            }
            ViewBag.errLogin = "Đăng nhập thất bại!, Kiểm tra lại username hoặc mật khẩu";
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login" , "Account");
        }


        public IActionResult Register()
        {
            return View();
        }




    }


}

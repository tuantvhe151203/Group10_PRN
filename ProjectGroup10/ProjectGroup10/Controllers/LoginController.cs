using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGroup10.Models;
using System.Linq;

namespace ProjectGroup10.Controllers
{
    public class LoginController : Controller
    {
        PRN2Context context = new PRN2Context();
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string name, string password)
        {
            if (name == null || password == null)
            {
                ViewBag.Map = "Null, please input your username & password";
                return View();
            }
            else
            {
                var User = context.Users.ToList();

                string nameu = "";
                int idu = 0;
                int idr = 0;
                int count = 0;
                foreach (User u in context.Users.ToList())
                {
                    if (u.UserName.Equals(name) && u.Password.Equals(password))
                    {
                        nameu = u.UserName;
                        idu = u.UserId;
                        idr = u.RoleId;
                        count++;
                    }
                }
                if (count == 0) { ViewBag.Map = "Null, please input your username & password"; return View(); }
                HttpContext.Session.SetString("username", nameu);
                HttpContext.Session.SetInt32("userid", idu);
                HttpContext.Session.SetInt32("roleid", idr);
                return RedirectToAction("Index", "Home");

            }



        }
    }
}

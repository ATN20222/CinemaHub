using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CinemaHub.Controllers
{
    //[Authorize(Roles = "!Admin")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Home"] = "active";

            if (User.IsInRole("Admin"))
                return View("Home_DashBoard");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        
    }
}
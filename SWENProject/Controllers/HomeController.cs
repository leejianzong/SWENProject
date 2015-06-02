using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWENProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Booking()
        {
            ViewBag.Message = "Your Booking page.";

            return View();
        }

        public ActionResult RoomAvailability()
        {
            ViewBag.Message = "Your Room Availability page.";

            return View();
        }

        public ActionResult Reporting()
        {
            ViewBag.Message = "Your Report page.";

            return View();
        }

        public ActionResult StaffManagement()
        {
            ViewBag.Message = "Your Staff Management page.";

            return View();
        }

        public ActionResult UserAccountAndLogin()
        {
            ViewBag.Message = "Your User Account And Login page.";

            return View();
        }
    }
}
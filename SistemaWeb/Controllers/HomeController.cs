using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
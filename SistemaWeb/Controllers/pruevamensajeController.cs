using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class pruevamensajeController : Controller
    {
        // GET: pruevamensaje
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string confirm_value)
        {
            if (confirm_value == "Yes")
            {
                ViewBag.Message = "You clicked YES!";
            }
            else
            {
                ViewBag.Message = "You clicked NO!";
            }

            return View();
        }

            }
}
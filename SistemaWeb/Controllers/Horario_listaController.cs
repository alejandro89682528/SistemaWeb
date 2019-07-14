using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Horario_listaController : Controller
    {
        // GET: Horario_lista
        
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View();
        }
    }
}
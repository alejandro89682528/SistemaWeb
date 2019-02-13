using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class horarioController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            return View();
        }
    }
}
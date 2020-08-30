using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;

namespace SistemaWeb.Controllers
{
    public class cofiguracionAñoController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: cofiguracionAño
        public ActionResult Index()
        {

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");

            return View();

        }

        [HttpPost]
        public ActionResult Index(string cod_carrera, string tipo_ciclo)
        {

            var idCarrera = Int32.Parse(cod_carrera);
            var semestre = Int32.Parse(tipo_ciclo);
            //ValidarHorario(idCarrera, semestre);

            return Index();
        }
    }
}
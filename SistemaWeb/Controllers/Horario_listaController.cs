using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class Horario_listaController : Controller
    {
        // GET: Horario_lista
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.año_estudio = new SelectList("12345");
            ViewBag.tipo_ciclo = new SelectList("12");
            return View();
        }
    }
}
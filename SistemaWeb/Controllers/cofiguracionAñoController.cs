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
            
            ViewBag.activo = new SelectList("SINO");

            return View(db.anolectivoes.ToListAsync());

        }
    }
}
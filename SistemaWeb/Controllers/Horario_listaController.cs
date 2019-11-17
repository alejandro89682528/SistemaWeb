using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

        public ActionResult BusquedaFilter(String nombre)
        {
            var Busquedamateria = from m in db.materias select m;
            if (!String.IsNullOrEmpty(nombre))
            {
                Busquedamateria = Busquedamateria.Where(j => j.nombre.Contains(nombre));
            }
            return View(Busquedamateria);
        }

        // GET: grupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo grupo = db.grupoes.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est", grupo.cod_asig);
            return View(grupo);
        }

        // POST: grupoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_grupo,nombre,capacidad,tipo_ciclo,cod_asig")] grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est", grupo.cod_asig);
            return View(grupo);
        }

    }
}
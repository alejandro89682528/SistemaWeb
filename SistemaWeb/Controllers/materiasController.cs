using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class materiasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: materias
        public ActionResult Index(String nombre)
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            var Busquedamateria = from m in db.materias select m;
            if (!String.IsNullOrEmpty(nombre))
            {
                Busquedamateria = Busquedamateria.Where(j => j.nombre.Contains(nombre));
            }
            return View(Busquedamateria);
            //return View(db.materias.ToList());

            /* return View(from materias in db.materias
                         orderby
                           materias.nombre
                         select new
                         {
                             cod_materia = materias.cod_materia,
                             nombre = materias.nombre
                         });*/
        }

        // GET: materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return PartialView(materia);
        }

        // GET: materias/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: materias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_materia,nombre")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.materias.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materia);
        }

        // GET: materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return PartialView(materia);
        }

        // POST: materias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_materia,nombre")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        // GET: materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return PartialView(materia);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materia materia = db.materias.Find(id);
            db.materias.Remove(materia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BusquedaFilter(String nombre)
        {
            var Busquedamateria = from m in db.materias select m;
            if(!String.IsNullOrEmpty(nombre))
            {
                Busquedamateria = Busquedamateria.Where(j => j.nombre.Contains(nombre));
            }
            return View(Busquedamateria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

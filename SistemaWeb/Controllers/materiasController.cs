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
    public class materiasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: materias
        public ActionResult Index()
        {
            return View(db.materias.ToList());
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

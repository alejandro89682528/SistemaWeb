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
    public class pensumsController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: pensums
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var pensums = db.pensums.Include(p => p.materia).Include(p => p.Plan);
            return View(pensums.ToList());
        }

        // GET: pensums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return PartialView(pensum);
        }

        // GET: pensums/Create
        public ActionResult Create()
        {
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre");
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre");
            return PartialView();
        }

        // POST: pensums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_asig,N_credito,ciclo,anio_est,prerrequisito1,prerrequisito2,cod_plan,cod_materia")] pensum pensum)
        {
            if (ModelState.IsValid)
            {
                db.pensums.Add(pensum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return View(pensum);
        }

        // GET: pensums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return PartialView(pensum);
        }

        // POST: pensums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_asig,N_credito,ciclo,anio_est,prerrequisito1,prerrequisito2,cod_plan,cod_materia")] pensum pensum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pensum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return View(pensum);
        }

        // GET: pensums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return PartialView(pensum);
        }

        // POST: pensums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pensum pensum = db.pensums.Find(id);
            db.pensums.Remove(pensum);
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

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
    public class tipoaulasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: tipoaulas
        public ActionResult Index()
        {
            
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View(db.tipoaulas.ToList());
        }

        // GET: tipoaulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoaula tipoaula = db.tipoaulas.Find(id);
            if (tipoaula == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipoaula);
        }

        // GET: tipoaulas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: tipoaulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_tipoaula,nombre_tipo")] tipoaula tipoaula)
        {
            if (ModelState.IsValid)
            {
                db.tipoaulas.Add(tipoaula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoaula);
        }

        // GET: tipoaulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoaula tipoaula = db.tipoaulas.Find(id);
            if (tipoaula == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipoaula);
        }

        // POST: tipoaulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_tipoaula,nombre_tipo")] tipoaula tipoaula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoaula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoaula);
        }

        // GET: tipoaulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoaula tipoaula = db.tipoaulas.Find(id);
            if (tipoaula == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipoaula);
        }

        // POST: tipoaulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoaula tipoaula = db.tipoaulas.Find(id);
            db.tipoaulas.Remove(tipoaula);
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

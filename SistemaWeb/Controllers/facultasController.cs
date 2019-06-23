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
    public class facultasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: facultas
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            return View(db.facultas.ToList());
        }

        // GET: facultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculta faculta = db.facultas.Find(id);
            if (faculta == null)
            {
                return HttpNotFound();
            }
            return PartialView(faculta);
        }

        // GET: facultas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: facultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_faculta,nombre,telefono,direccion")] faculta faculta)
        {
            if (ModelState.IsValid)
            {
                db.facultas.Add(faculta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculta);
        }

        // GET: facultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculta faculta = db.facultas.Find(id);
            if (faculta == null)
            {
                return HttpNotFound();
            }
            return PartialView(faculta);
        }

        // POST: facultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_faculta,nombre,telefono,direccion")] faculta faculta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculta);
        }

        // GET: facultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculta faculta = db.facultas.Find(id);
            if (faculta == null)
            {
                return HttpNotFound();
            }
            return PartialView(faculta);
        }

        // POST: facultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            faculta faculta = db.facultas.Find(id);
            db.facultas.Remove(faculta);
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

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
    public class anolectivoesController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: anolectivoes
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View(db.anolectivoes.ToList());
        }

        // GET: anolectivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = db.anolectivoes.Find(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // GET: anolectivoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: anolectivoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_ano,ano")] anolectivo anolectivo)
        {
            if (ModelState.IsValid)
            {
                db.anolectivoes.Add(anolectivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anolectivo);
        }

        // GET: anolectivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = db.anolectivoes.Find(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // POST: anolectivoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_ano,ano")] anolectivo anolectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anolectivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anolectivo);
        }

        // GET: anolectivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = db.anolectivoes.Find(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // POST: anolectivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anolectivo anolectivo = db.anolectivoes.Find(id);
            db.anolectivoes.Remove(anolectivo);
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

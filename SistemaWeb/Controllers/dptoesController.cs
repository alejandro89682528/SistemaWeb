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
    public class dptoesController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: dptoes
        public ActionResult Index()
        {
            var dptoes = db.dptoes.Include(d => d.faculta);
            return View(dptoes.ToList());
        }

        // GET: dptoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpto dpto = db.dptoes.Find(id);
            if (dpto == null)
            {
                return HttpNotFound();
            }
            return PartialView(dpto);
        }

        // GET: dptoes/Create
        public ActionResult Create()
        {
           ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre");           
            return PartialView();
        }

        // POST: dptoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_dpto,nombre,cod_faculta")] dpto dpto)
        {
            if (ModelState.IsValid)
            {
                db.dptoes.Add(dpto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
            return View(dpto);
        }

        // GET: dptoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpto dpto = db.dptoes.Find(id);
            if (dpto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
            return PartialView(dpto);
        }

        // POST: dptoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_dpto,nombre,cod_faculta")] dpto dpto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dpto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
            return View(dpto);
        }

        // GET: dptoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpto dpto = db.dptoes.Find(id);
            if (dpto == null)
            {
                return HttpNotFound();
            }
            return PartialView(dpto);
        }

        // POST: dptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dpto dpto = db.dptoes.Find(id);
            db.dptoes.Remove(dpto);
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

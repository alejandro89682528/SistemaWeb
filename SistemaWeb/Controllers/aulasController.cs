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
    public class aulasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: aulas
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var aulas = db.aulas.Include(a => a.dpto).Include(a => a.tipoaula);
            return View(aulas.ToList());
        }

        // GET: aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aula aula = db.aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return PartialView(aula);
        }

        // GET: aulas/Create
        public ActionResult Create()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_tipoaula = new SelectList(db.tipoaulas, "cod_tipoaula", "nombre_tipo");
            return PartialView();
        }

        // POST: aulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_aula,nombre,ubicasion,ac,capacidad,n_equipo,cod_tipoaula,cod_dpto")] aula aula)
        {
            if (ModelState.IsValid)
            {
                db.aulas.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", aula.cod_dpto);
            ViewBag.cod_tipoaula = new SelectList(db.tipoaulas, "cod_tipoaula", "nombre_tipo", aula.cod_tipoaula);
            return View(aula);
        }

        // GET: aulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aula aula = db.aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", aula.cod_dpto);
            ViewBag.cod_tipoaula = new SelectList(db.tipoaulas, "cod_tipoaula", "nombre_tipo", aula.cod_tipoaula);
            return PartialView(aula);
        }

        // POST: aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_aula,nombre,ubicasion,ac,capacidad,n_equipo,cod_tipoaula,cod_dpto")] aula aula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", aula.cod_dpto);
            ViewBag.cod_tipoaula = new SelectList(db.tipoaulas, "cod_tipoaula", "nombre_tipo", aula.cod_tipoaula);
            return View(aula);
        }

        // GET: aulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aula aula = db.aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return PartialView(aula);
        }

        // POST: aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aula aula = db.aulas.Find(id);
            db.aulas.Remove(aula);
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

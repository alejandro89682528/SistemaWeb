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
    public class grupoesController : Controller
    {
        
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: grupoes
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var grupoes = db.grupoes.Include(g => g.pensum);
            return View(grupoes.ToList());
        }

        // GET: grupoes/Details/5
        public ActionResult Details(int? id)
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
            return View(grupo);
        }

        // GET: grupoes/Create
        public ActionResult Create()
        {
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "Cod_materia");
            return View();
        }

        // POST: grupoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_grupo,nombre,capacidad,tipo_ciclo,cod_asig")] grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.grupoes.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "Cod_materia", grupo.cod_asig);
            return View(grupo);
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
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "Cod_materia", grupo.cod_asig);
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

        // GET: grupoes/Delete/5
        public ActionResult Delete(int? id)
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
            return View(grupo);
        }

        // POST: grupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grupo grupo = db.grupoes.Find(id);
            db.grupoes.Remove(grupo);
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

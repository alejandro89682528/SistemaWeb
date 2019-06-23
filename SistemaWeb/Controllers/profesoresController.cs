using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class profesoresController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: profesores
        public async Task<ActionResult> Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var profesores = db.profesores.Include(p => p.dpto);
            return View(await profesores.ToListAsync());            
        }

        // GET: profesores/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesore profesore = await db.profesores.FindAsync(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            return PartialView(profesore);
        }

        // GET: profesores/Create
        public ActionResult Create()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            return PartialView();
        }

        // POST: profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "inss,cedula,nombre,apellido,telefono,direccion,foto_ruta,cod_dpto")] profesore profesore)
        {
            if (ModelState.IsValid)
            {
                db.profesores.Add(profesore);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", profesore.cod_dpto);
            return PartialView(profesore);
        }

        // GET: profesores/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesore profesore = await db.profesores.FindAsync(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", profesore.cod_dpto);
            return PartialView(profesore);
        }

        // POST: profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "inss,cedula,nombre,apellido,telefono,direccion,foto_ruta,cod_dpto")] profesore profesore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesore).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", profesore.cod_dpto);
            return PartialView(profesore);
        }

        // GET: profesores/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesore profesore = await db.profesores.FindAsync(id);
            if (profesore == null)
            {
                return HttpNotFound();
            }
            return PartialView(profesore);
        }

        // POST: profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            profesore profesore = await db.profesores.FindAsync(id);
            db.profesores.Remove(profesore);
            await db.SaveChangesAsync();
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

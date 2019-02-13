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
    public class exportarcionsController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: exportarcions
        public async Task<ActionResult> Index()
        {
            return View(await db.exportarcions.ToListAsync());
        }

        // GET: exportarcions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exportarcion exportarcion = await db.exportarcions.FindAsync(id);
            if (exportarcion == null)
            {
                return HttpNotFound();
            }
            return PartialView(exportarcion);
        }

        // GET: exportarcions/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: exportarcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,inss,grupo,total_estudiante,anolectivo,tipo_ciclo,grupo_teorico,grupo_practico")] exportarcion exportarcion)
        {
            if (ModelState.IsValid)
            {
                db.exportarcions.Add(exportarcion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return PartialView(exportarcion);
        }

        // GET: exportarcions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exportarcion exportarcion = await db.exportarcions.FindAsync(id);
            if (exportarcion == null)
            {
                return HttpNotFound();
            }
            return PartialView(exportarcion);
        }

        // POST: exportarcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,inss,grupo,total_estudiante,anolectivo,tipo_ciclo,grupo_teorico,grupo_practico")] exportarcion exportarcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportarcion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(exportarcion);
        }

        // GET: exportarcions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exportarcion exportarcion = await db.exportarcions.FindAsync(id);
            if (exportarcion == null)
            {
                return HttpNotFound();
            }
            return PartialView(exportarcion);
        }

        // POST: exportarcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            exportarcion exportarcion = await db.exportarcions.FindAsync(id);
            db.exportarcions.Remove(exportarcion);
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

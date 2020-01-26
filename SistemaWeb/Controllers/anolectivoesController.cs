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
    public class anolectivoesController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: anolectivoes
        public async Task<ActionResult> Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

         
            ViewBag.activo = new SelectList("SINO");
            return View(await db.anolectivoes.ToListAsync());
        }

        // GET: anolectivoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = await db.anolectivoes.FindAsync(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // GET: anolectivoes/Create
        public ActionResult Create()
        {
            ViewBag.activo = new SelectList("SI","NO");
            return View();
        }

        // POST: anolectivoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cod_ano,ano")] anolectivo anolectivo)
        {
            if (ModelState.IsValid)
            {
                db.anolectivoes.Add(anolectivo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(anolectivo);
        }

        // GET: anolectivoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = await db.anolectivoes.FindAsync(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // POST: anolectivoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cod_ano,ano")] anolectivo anolectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anolectivo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(anolectivo);
        }

        // GET: anolectivoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anolectivo anolectivo = await db.anolectivoes.FindAsync(id);
            if (anolectivo == null)
            {
                return HttpNotFound();
            }
            return View(anolectivo);
        }

        // POST: anolectivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            anolectivo anolectivo = await db.anolectivoes.FindAsync(id);
            db.anolectivoes.Remove(anolectivo);
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

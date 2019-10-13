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
    public class diasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: dias
        public async Task<ActionResult> Index()
        {
            return View(await db.dias.ToListAsync());
        }

        // GET: dias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = await db.dias.FindAsync(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // GET: dias/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: dias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,dias")] dia dia)
        {
            if (ModelState.IsValid)
            {
                db.dias.Add(dia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return PartialView(dia);
        }

        // GET: dias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = await db.dias.FindAsync(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return PartialView(dia);
        }

        // POST: dias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,dias")] dia dia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(dia);
        }

        // GET: dias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = await db.dias.FindAsync(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return PartialView(dia);
        }

        // POST: dias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            dia dia = await db.dias.FindAsync(id);
            db.dias.Remove(dia);
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

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
    [Authorize(Roles = "Admin")]
    public class inportarcionsController : Controller
    {

        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: inportarcions
        public async Task<ActionResult> Index()
        {

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            var inportarcions = db.inportarcions.Include(i => i.carrera).Include(i => i.dpto).Include(i => i.materia).Include(i => i.profesore);
            return View(await inportarcions.ToListAsync());
        }

        // GET: inportarcions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inportarcion inportarcion = await db.inportarcions.FindAsync(id);
            if (inportarcion == null)
            {
                return HttpNotFound();
            }
            return View(inportarcion);
        }

        // GET: inportarcions/Create
        public ActionResult Create()
        {
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_asignatura = new SelectList(db.materias, "cod_materia", "nombre");
            ViewBag.inss = new SelectList(db.profesores, "inss", "nombre");
            return View();
        }

        // POST: inportarcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,inss,cod_dpto,cod_asignatura,cod_carrera,grupo,hora_grupo,tipo_ciclo,tipo_grupo")] inportarcion inportarcion)
        {
            if (ModelState.IsValid)
            {
                db.inportarcions.Add(inportarcion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre", inportarcion.cod_carrera);
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", inportarcion.cod_dpto);
            ViewBag.cod_asignatura = new SelectList(db.materias, "cod_materia", "nombre", inportarcion.cod_asignatura);
            ViewBag.inss = new SelectList(db.profesores, "inss", "nombre", inportarcion.inss);
            return View(inportarcion);
        }

        // GET: inportarcions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inportarcion inportarcion = await db.inportarcions.FindAsync(id);
            if (inportarcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre", inportarcion.cod_carrera);
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", inportarcion.cod_dpto);
            ViewBag.cod_asignatura = new SelectList(db.materias, "cod_materia", "nombre", inportarcion.cod_asignatura);
            ViewBag.inss = new SelectList(db.profesores, "inss", "nombre", inportarcion.inss);
            return View(inportarcion);
        }

        // POST: inportarcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,inss,cod_dpto,cod_asignatura,cod_carrera,grupo,hora_grupo,tipo_ciclo,tipo_grupo")] inportarcion inportarcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inportarcion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre", inportarcion.cod_carrera);
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", inportarcion.cod_dpto);
            ViewBag.cod_asignatura = new SelectList(db.materias, "cod_materia", "nombre", inportarcion.cod_asignatura);
            ViewBag.inss = new SelectList(db.profesores, "inss", "nombre", inportarcion.inss);
            return View(inportarcion);
        }

        // GET: inportarcions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inportarcion inportarcion = await db.inportarcions.FindAsync(id);
            if (inportarcion == null)
            {
                return HttpNotFound();
            }
            return View(inportarcion);
        }

        // POST: inportarcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            inportarcion inportarcion = await db.inportarcions.FindAsync(id);
            db.inportarcions.Remove(inportarcion);
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

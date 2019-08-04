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
    public class horariosController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        // GET: horarios
        public async Task<ActionResult> Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var horarios = db.horarios.Include(h => h.aula).Include(h => h.pensum).Include(h => h.periodo).Include(h => h.profesore);
            return View(await horarios.ToListAsync());
        }

        // GET: horarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = await db.horarios.FindAsync(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: horarios/Create
        public ActionResult Create()
        {
            ViewBag.cod_aula = new SelectList(db.aulas, "cod_aula", "nombre");
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est");
            ViewBag.cod_periodo = new SelectList(db.periodoes, "cod_periodo", "periodo1");
            ViewBag.inss = new SelectList(db.profesores, "inss", "cedula");
            return View();
        }

        // POST: horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cod_horario,cod_periodo,cod_dias,fecha_ini,cod_asig,cod_aula,cod_grupo,inss")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.horarios.Add(horario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cod_aula = new SelectList(db.aulas, "cod_aula", "nombre", horario.cod_aula);
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est", horario.cod_asig);
            ViewBag.cod_periodo = new SelectList(db.periodoes, "cod_periodo", "periodo1", horario.cod_periodo);
            ViewBag.inss = new SelectList(db.profesores, "inss", "cedula", horario.inss);
            return View(horario);
        }

        // GET: horarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = await db.horarios.FindAsync(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_aula = new SelectList(db.aulas, "cod_aula", "nombre", horario.cod_aula);
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est", horario.cod_asig);
            ViewBag.cod_periodo = new SelectList(db.periodoes, "cod_periodo", "periodo1", horario.cod_periodo);
            ViewBag.inss = new SelectList(db.profesores, "inss", "cedula", horario.inss);
            return View(horario);
        }

        // POST: horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cod_horario,cod_periodo,cod_dias,fecha_ini,cod_asig,cod_aula,cod_grupo,inss")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cod_aula = new SelectList(db.aulas, "cod_aula", "nombre", horario.cod_aula);
            ViewBag.cod_asig = new SelectList(db.pensums, "cod_asig", "anio_est", horario.cod_asig);
            ViewBag.cod_periodo = new SelectList(db.periodoes, "cod_periodo", "periodo1", horario.cod_periodo);
            ViewBag.inss = new SelectList(db.profesores, "inss", "cedula", horario.inss);
            return View(horario);
        }

        // GET: horarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = await db.horarios.FindAsync(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            horario horario = await db.horarios.FindAsync(id);
            db.horarios.Remove(horario);
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

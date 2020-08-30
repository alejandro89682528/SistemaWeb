using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class pensumsController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // GET: pensums

        public ActionResult busqueda()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre");


            return View();
        }
        public ActionResult Index(string cod_carrera, string cod_plan)
        {
            int carrera = Int32.Parse(cod_carrera);
            int plans = Int32.Parse(cod_plan);

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            var pensums = db.pensums.Include(p => p.materia).Include(p => p.Plan);
            pensums = pensums.Where(j => j.cod_plan.Equals(plans));
            
            var Busquepemsums = from m in db.pensums select m;
            if (plans != null)
            {
                Busquepemsums = Busquepemsums.Where(j => j.cod_plan.Equals(plans));
            }
            /*
           //consultar lista de horarios lunes
           SqlCommand cmd = new SqlCommand();
           DataTable pensums = new DataTable();
           SqlDataAdapter sqlDA; con.Open();
           //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
           cmd.CommandText = "select p.N_credito, p.ciclo, p.anio_est, p.prerrequisito1, p.prerrequisito2, p.cod_plan, p.cod_materia, p.total_horas from pensum p, plans pl, carrera c where p.cod_plan = pl.cod_plan and c.cod_carrera = pl.cod_carrera and p.cod_plan=" + plans + " and  pl.cod_carrera = "+ carrera +"";
           cmd.Connection = con;
           sqlDA = new SqlDataAdapter(cmd);
           sqlDA.Fill(pensums);
           con.Close();
           // return View(pensums.ToList());
           ViewBag.pensums = pensums;
          // return View(); */

            return View(pensums.ToList());
        }

        // GET: pensums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return PartialView(pensum);
        }

        // GET: pensums/Create
        public ActionResult Create()
        {
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre");
           // ViewBag.prerrequisito1 = new SelectList(db.materias, "nombre", "nombre");
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan",  "nombre");
            return PartialView();
        }

        // POST: pensums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_asig,N_credito,ciclo,anio_est,prerrequisito1,prerrequisito2,cod_plan,cod_materia, total_horas")] pensum pensum)
        {
            if (ModelState.IsValid)
            {
                db.pensums.Add(pensum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return View(pensum);
        }

        // GET: pensums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return PartialView(pensum);
        }

        // POST: pensums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_asig,N_credito,ciclo,anio_est,prerrequisito1,prerrequisito2,cod_plan,cod_materia,total_horas")] pensum pensum)
        { 
            if (ModelState.IsValid)
            {
                db.Entry(pensum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_materia = new SelectList(db.materias, "cod_materia", "nombre", pensum.cod_materia);
            ViewBag.cod_plan = new SelectList(db.Plans, "cod_plan", "nombre", pensum.cod_plan);
            return View(pensum);
        }

        // GET: pensums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pensum pensum = db.pensums.Find(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return PartialView(pensum);
        }

        // POST: pensums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pensum pensum = db.pensums.Find(id);
            db.pensums.Remove(pensum);
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

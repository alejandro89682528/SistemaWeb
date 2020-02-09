using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace SistemaWeb.Controllers
{

    //[Authorize(Roles = "Admin")]



    public class Horario_listaController : Controller
    {
      //  private lista_horario objlistaH;
        public object MessageBoxIcon { get; private set; }
        public object MessageBox { get; private set; }

        public Horario_listaController()
        {
        //    objlistaH = new lista_horario();

        }
        // GET: Horario_lista
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.año_estudio = new SelectList("12345");
            ViewBag.tipo_ciclo = new SelectList("12");

            return View();
        }
        /*
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        } */


            /*
        [HttpPost]
        public ActionResult Index(string cod_dpto, string cod_carrera, string tipo_ciclo, string año_estudio)
        {
            int depar = Int32.Parse(cod_dpto);
            int carrera = Int32.Parse(cod_carrera);
            int ciclo = Int32.Parse(tipo_ciclo);
            int año = Int32.Parse(año_estudio);
            // string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + cod_dpto);
            //var p = objlistaH.cod_dpto;
            //var idDept = Int32.Parse(depeto); 
            //ViewBag.Message = "ESTO ES UNA PRUEVA",p;
            //ViewData["Nombre"] = message;


            return View();
        } */

        [HttpPost]
        public ActionResult BusquedaFilter(string cod_dpto, string cod_carrera, string tipo_ciclo, string año_estudio)
        {

            int depar = Int32.Parse(cod_dpto);
            int carrera = Int32.Parse(cod_carrera);
            int ciclo = Int32.Parse(tipo_ciclo);
            int año = Int32.Parse(año_estudio);
            
            //consultar lista de 
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dia.dias  from horario h, grupo g, materia m, profesores p, dpto d, carrera c, periodo pe, aula a, Pensum pen, dia dia where h.cod_grupo=g.cod_grupo and h.inss=p.inss and h.cod_asig=pen.cod_asig and m.cod_materia=pen.cod_materia and pe.cod_periodo = h.cod_periodo and h.cod_aula = a.cod_aula and h.cod_dias=dia.id and c.cod_carrera = " + carrera +" and d.cod_dpto="+ depar + " and pen.ciclo="+ ciclo + " and pen.anio_est="+ año +";";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();
            
            //depar = objlistaH.cod_dpto;
            // string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + cod_dpto);
            // var p = objlistaH.cod_dpto;

            //var idDept.. = Int32.Parse(depeto); 
            //ViewBag.Message = "se a efectuado todos los canvios correctamente!" + p;
            //ViewData["Nombre"] = message;
            return View(dataTable);
        }
    }
}
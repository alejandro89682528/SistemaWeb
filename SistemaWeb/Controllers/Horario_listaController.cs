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
          //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias where c.cod_carrera = 2 and d.cod_dpto = 3 and pen.ciclo = 5 and pen.anio_est = 3 order by id;" ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();
            /* Corregido select
p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dia.dias  
from
horario h inner join grupo g on h.cod_grupo=g.cod_grupo inner join pensum pen on h.cod_asig=pen.cod_asig inner join materia m on m.cod_materia=pen.cod_materia
inner join  profesores p on h.inss=p.inss inner join dpto d on p.cod_dpto=d.cod_dpto inner join plan pl on pen.cod_plan=pl.cod_plan inner join carrera c on c.cod_carrera=pl.cod_carrera inner join periodo pe pe.cod_periodo=h.cod_periodo
 inner join aula a on h.cod_aula=a.cod_aula inner join  dia dd on dd.id=h.cod_dias
where
c.cod_carrera = " + carrera +" and d.cod_dpto="+ depar + " and pen.ciclo="+ ciclo + " and pen.anio_est="+ año +""; */
            //depar = objlistaH.cod_dpto;
            // string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + cod_dpto);
            // var p = objlistaH.cod_dpto;

            //var idDept.. = Int32.Parse(depeto); 
            ViewBag.Tabla =dataTable;
            //ViewData["Nombre"] = message;

            /*
             * 
             * @foreach (DataRow row in Model.Rows)
{
    Hacer algo ...
    < a > @row["campo1"].ToString() </ a >< br />
    < a > @row["campo2"].ToString() </ a >< br />
}
        */
            return View();
        }
    }
}
using Rotativa;
using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SistemaWeb.clases;

namespace SistemaWeb.Controllers
{
    public class EditHorarioProfesorController : Controller
    {

        //  private lista_horario objlistaH;
        public object MessageBoxIcon { get; private set; }
        public object MessageBox { get; private set; }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: EditHorarioProfesor
        public ActionResult Index()
        {


            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            //cod_dpto.DataBind();
            //cod_dpto.Items.insert(0, new ListItem ("todo", "0"));
            ViewBag.profesor = new SelectList(db.profesores, "inss", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            ViewBag.año_estudio = new SelectList(db.anolectivoes, "cod_ano", "ano");

            
            return View();
        }

        [HttpPost]
        public ActionResult EditProfesorHorario(horariogeneracion ph)
        {

            TempData["ph"] = ph;

            int depar = Int32.Parse(ph.cod_dpto);
            string dpart = ph.cod_dpto;
            string profe = ph.profesor;
            int ciclo = Int32.Parse(ph.tipo_ciclo);
            int año = Int32.Parse(ph.año_estudio);

            //consultar lista de horarios lunes
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + depar + " and p.inss = '" + profe + "' and g.tipo_ciclo = " + ciclo + " and an_lec.cod_ano= '" + año + "' order by id;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();

            //consultar lista de horarios martes
            SqlCommand cmd2 = new SqlCommand();
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDA2; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + depar + " and p.inss = '" + profe + "' and g.tipo_ciclo = " + ciclo + " and an_lec.cod_ano= '" + año + "' order by id;";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            sqlDA2 = new SqlDataAdapter(cmd2);
            sqlDA2.Fill(dataTable2);
            con.Close();

            //consultar lista de horarios miercoles
            SqlCommand cmd3 = new SqlCommand();
            DataTable dataTable3 = new DataTable();
            SqlDataAdapter sqlDA3; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + depar + " and p.inss = '" + profe + "' and g.tipo_ciclo = " + ciclo + " and an_lec.cod_ano= '" + año + "' order by id;";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;
            sqlDA3 = new SqlDataAdapter(cmd3);
            sqlDA3.Fill(dataTable3);
            con.Close();

            //consultar lista de horarios jueves
            SqlCommand cmd4 = new SqlCommand();
            DataTable dataTable4 = new DataTable();
            SqlDataAdapter sqlDA4; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + depar + " and p.inss = '" + profe + "' and g.tipo_ciclo = " + ciclo + " and an_lec.cod_ano= '" + año + "' order by id;";
            cmd4.CommandType = CommandType.Text;
            cmd4.Connection = con;
            sqlDA4 = new SqlDataAdapter(cmd4);
            sqlDA4.Fill(dataTable4);
            con.Close();

            //consultar lista de horarios viernes
            SqlCommand cmd5 = new SqlCommand();
            DataTable dataTable5 = new DataTable();
            SqlDataAdapter sqlDA5; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + depar + " and p.inss = '" + profe + "' and g.tipo_ciclo = " + ciclo + " and an_lec.cod_ano= '" + año + "' order by id;";
            cmd5.CommandType = CommandType.Text;
            cmd5.Connection = con;
            sqlDA5 = new SqlDataAdapter(cmd5);
            sqlDA5.Fill(dataTable5);
            con.Close();


            //consultar lista de horarios periodo
            SqlCommand cmd1 = new SqlCommand();
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDA1; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            sqlDA1 = new SqlDataAdapter(cmd1);
            sqlDA1.Fill(dataTable1);
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
            ViewBag.TablaL = dataTable;
            ViewBag.TablaM = dataTable2;
            ViewBag.TablaMI = dataTable3;
            ViewBag.TablaJ = dataTable4;
            ViewBag.TablaV = dataTable5;
            ViewBag.Tabla1 = dataTable1;
            ViewBag.depart = dpart;
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

        
        public ActionResult edit(string horario)
        {

            if(horario != null)
            {
                String lista = horario;
                /*if(Session["h"] !=null)
                {

                }
                else
                {
                    lista = new List<string>();
                }*/
                //lista.Add(horario);
                Session["h"] = lista;
            }
            // List

            SqlCommand cmd1 = new SqlCommand();
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDA1; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmd1.CommandText = "select id, dias from dia;";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            sqlDA1 = new SqlDataAdapter(cmd1);
            sqlDA1.Fill(dataTable1);
            con.Close();


            SqlCommand cmdl = new SqlCommand();
            DataTable dataTablel = new DataTable();
            SqlDataAdapter sqlDAl; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdl.CommandText = "select *from horario where cod_dias = 1;";
            cmdl.CommandType = CommandType.Text;
            cmdl.Connection = con;
            sqlDAl = new SqlDataAdapter(cmdl);
            sqlDAl.Fill(dataTablel);
            con.Close();

            SqlCommand cmdm = new SqlCommand();
            DataTable dataTablem = new DataTable();
            SqlDataAdapter sqlDAm; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdm.CommandText = "select *from horario where cod_dias = 2;";
            cmdm.CommandType = CommandType.Text;
            cmdm.Connection = con;
            sqlDAm = new SqlDataAdapter(cmdm);
            sqlDAm.Fill(dataTablem);
            con.Close();

            SqlCommand cmdmi = new SqlCommand();
            DataTable dataTablemi = new DataTable();
            SqlDataAdapter sqlDmi; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdmi.CommandText = "select *from horario where cod_dias = 3;";
            cmdmi.CommandType = CommandType.Text;
            cmdmi.Connection = con;
            sqlDmi = new SqlDataAdapter(cmdmi);
            sqlDmi.Fill(dataTablemi);
            con.Close();

            SqlCommand cmdj = new SqlCommand();
            DataTable dataTablej = new DataTable();
            SqlDataAdapter sqlDAj; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdj.CommandText = "select *from horario where cod_dias = 4;";
            cmdj.CommandType = CommandType.Text;
            cmdj.Connection = con;
            sqlDAj = new SqlDataAdapter(cmdj);
            sqlDAj.Fill(dataTablej);
            con.Close();

            SqlCommand cmdv = new SqlCommand();
            DataTable dataTablev = new DataTable();
            SqlDataAdapter sqlDAv; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdv.CommandText = "select *from horario where cod_dias = 5;";
            cmdv.CommandType = CommandType.Text;
            cmdv.Connection = con;
            sqlDAv = new SqlDataAdapter(cmdv);
            sqlDAv.Fill(dataTablev);
            con.Close();


            SqlCommand cmdp = new SqlCommand();
            DataTable dataTablep = new DataTable();
            SqlDataAdapter sqlDAp; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdp.CommandText = "select *from periodo;";
            cmdp.CommandType = CommandType.Text;
            cmdp.Connection = con;
            sqlDAp = new SqlDataAdapter(cmdp);
            sqlDAp.Fill(dataTablep);
            con.Close();
            int pl = 0;
            int pm = 0;
            int pmi = 0;
            int pj = 0;
            int pv = 0;

            while (pl < dataTablel.Rows.Count)
            {
                int periodoh = Convert.ToInt32(dataTablel.Rows[0].ItemArray[1].ToString());
                int periodo = Convert.ToInt32(dataTablep.Rows[0].ItemArray[0].ToString());
                

            }

            ViewBag.cod_periodo = new SelectList(db.periodoes, "cod_periodo", "periodo1");
            
            //ViewBag.id = new SelectList(db.dias, "id", "dias");
            ViewBag.profesor = new SelectList(db.profesores, "inss", "nombre");





            return View();
        }


        [HttpPost]
        public ActionResult edit(string cod_periodo, string id, string profesor)
        {

            var ph = TempData["ph"];
            TempData.Keep();

            int p = Int32.Parse(cod_periodo);
            int i = Int32.Parse(id);
            string pro = profesor;
            string ho = (Session["h"]).ToString();



            //
            return View();
        }


        }
}
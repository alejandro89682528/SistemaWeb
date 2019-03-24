using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class horarioController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cod_carrera, string tipo_ciclo)
        {
        
            var idCarrera = Int32.Parse(cod_carrera);
            var semestre = Int32.Parse(tipo_ciclo);
            ValidarHorario(idCarrera, semestre );

            return Index();
        }

        private void ValidarHorario(int idCarrera, int semestre)
        {
            //consultar lista de las clases coon su total de hora 
           /* SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            cmd.CommandText = "select * from dbo.plans p, pensum ps where p.cod_carrera='" + idCarrera + "';";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close(); */

            //int cod_carrera = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());


            //consultarn lista de datos de inportacion de cada de cada carrera 
            SqlCommand cmd1 = new SqlCommand();
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDA1; con.Open();
            cmd1.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo from pensum p, inportarcion i where  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = '"+ semestre +"' and cod_carrera='" + idCarrera + "' order by p.ciclo, i.grupo;";
           // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            sqlDA1 = new SqlDataAdapter(cmd1);
            sqlDA1.Fill(dataTable1);
            con.Close();

            // consulta para extraer  lista de periodo
           /* SqlCommand cmd2 = new SqlCommand();
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDA2; con.Open();
            cmd2.CommandText = "select * from periodo;";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            sqlDA2 = new SqlDataAdapter(cmd2);
            sqlDA2.Fill(dataTable2);
            con.Close(); */

            //consultar aulas de partamento seleccionado
           /*  SqlCommand cmd3 = new SqlCommand();
            DataTable dataTable3 = new DataTable();
            SqlDataAdapter sqlDA3; con.Open();
            cmd3.CommandText = "select * from aula where cod_dpto= '"+ cod_dpto + "';";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;
            sqlDA3 = new SqlDataAdapter(cmd3);
            sqlDA3.Fill(dataTable3);
            con.Close();
            */

            for (int i = 0; i <dataTable1.Rows.Count; i++)
            {
                String inss = dataTable1.Rows[i].ItemArray[1].ToString();
                int cod_dpto = Convert.ToInt32(dataTable1.Rows[i].ItemArray[2].ToString());
                int cod_asignatura = Convert.ToInt32(dataTable1.Rows[i].ItemArray[3].ToString());
                int cod_carrera = Convert.ToInt32(dataTable1.Rows[i].ItemArray[4].ToString());
                String grupo = dataTable1.Rows[i].ItemArray[5].ToString();
                String hora_grupo = dataTable1.Rows[i].ItemArray[6].ToString();
                //String ciclo = dataTable1.Rows[i].ItemArray[7].ToString();
                String tipo_grupo = dataTable1.Rows[i].ItemArray[8].ToString();



            }

            
            }
    }
}
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cod_carrera)
        {
        
            var idCarrera = Int32.Parse(cod_carrera);
           
            ValidarHorario(idCarrera);

            return Index();
        }

        private void ValidarHorario(int idCarrera)
        {
            //consultar lista de las clases coon su total de hora 
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            cmd.CommandText = "select * from dbo.plans p, pensum ps where p.cod_carrera='" + idCarrera + "';";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();

            //int cod_carrera = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());


            //consultarn lista de datos de inportacion de cada de cada carrera 
            SqlCommand cmd1 = new SqlCommand();
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDA1; con.Open();
            cmd1.CommandText = "select * from exportarcion where cod_carrera='" + idCarrera + "';";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            sqlDA1 = new SqlDataAdapter(cmd);
            sqlDA1.Fill(dataTable1);
            con.Close();
            int cod_dpto = Convert.ToInt32(dataTable.Rows[0].ItemArray[2].ToString());

            // consulta para extraer  lista de periodo
            SqlCommand cmd2 = new SqlCommand();
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDA2; con.Open();
            cmd2.CommandText = "select * from periodo;";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            sqlDA2 = new SqlDataAdapter(cmd2);
            sqlDA2.Fill(dataTable2);
            con.Close();

            //consultar aulas de partamento seleccionado
            SqlCommand cmd3 = new SqlCommand();
            DataTable dataTable3 = new DataTable();
            SqlDataAdapter sqlDA3; con.Open();
            cmd3.CommandText = "select * from aula where cod_dpto= '"+ cod_dpto + "';";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;
            sqlDA3 = new SqlDataAdapter(cmd3);
            sqlDA3.Fill(dataTable3);
            con.Close();


            for (int i = 0; i <dataTable.Rows.Count; i++)
            {

            }

            
            }
    }
}
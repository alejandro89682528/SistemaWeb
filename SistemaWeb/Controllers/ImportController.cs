using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using SistemaWeb.Contexto;
using System.Web;
using System.Collections;

namespace SistemaWeb.Controllers
{
    public class ImportController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //SqlConnection sistema_horarioEntities3 = new SqlConnection(ConfigurationManager.ConnectionStrings["sistema_horarioEntities3"].ConnectionString);
        ArrayList lista = new ArrayList();

        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        OleDbConnection Econ;

        public object MessageBoxIcon { get; private set; }
        public object MessageBox { get; private set; }

        //private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: Import
        public ActionResult Index()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_asignatura = new SelectList(db.materias, "cod_materia", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string cod_dpto, string tipo_ciclo, string confirm_value)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            var id = Int32.Parse(cod_dpto);
            var ciclo = tipo_ciclo;
            var confirmacion = confirm_value;
            InsertExceldata(filepath, filename, id, ciclo, confirmacion);

            return Index();
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(constr);

        }

        private void InsertExceldata(string fileepath, string filename, int id, String ciclo, String confirmacion )
        {


            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            //string query = string.Format("Select * from [{0}]", "Sheet1$"); Hoja1$
            string query = string.Format("Select * from [Hoja1$]");
            //string[] elemento = new string[] { "Select * from [Hoja1$]" };
            //lista.Add("Select * from [Hoja1$]");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];

            

            if (confirmacion == "Yes")
            {

                ViewBag.Message = "You clicked YES!";
            }
            else
            {
                ViewBag.Message = "You clicked NO!";
            }
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                String inss = dt.Rows[i].ItemArray[0].ToString();
                string asignatura = dt.Rows[i].ItemArray[1].ToString();
                string grupo = dt.Rows[i].ItemArray[2].ToString();
                int cantidad = Convert.ToInt32(dt.Rows[i].ItemArray[3].ToString());
                int anoestudio = Convert.ToInt32(dt.Rows[i].ItemArray[4].ToString());
                string tipogrupo = dt.Rows[i].ItemArray[5].ToString();

                SqlCommand cmd = new SqlCommand();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDA; con.Open();
                cmd.CommandText = "select * from dbo.materia where nombre='" + asignatura + "';";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(dataTable);
                con.Close();
               
                int cod_materia = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());

                SqlCommand cmd2;
                SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                con.Open();
                String sql = "";
                sql = "INSERT INTO exportarcion (inss, cod_dpto, cod_asignatura, grupo, cantidad, anolectivo, tipo_ciclo, tipo_grupo) VALUES ('" + inss + "', "+ id +", " + cod_materia + ", '" + grupo + "', " + cantidad + ", '" + anoestudio + "', '"+ ciclo +"', '" + tipogrupo + "')";
                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                cmd2 = new SqlCommand(sql, con);
                sqlDA2.InsertCommand = new SqlCommand(sql, con);
                sqlDA2.InsertCommand.ExecuteNonQuery();
                cmd2.Dispose();
               // ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
                //return View(dpto);
                con.Close();

            } 
                /*
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "exportarcion";
                objbulk.ColumnMappings.Add("inss", "inss");
                //objbulk.ColumnMappings.Add("cod_dpto", "cod_dpto");
                objbulk.ColumnMappings.Add("cod_asignatura", "cod_asignatura");
                objbulk.ColumnMappings.Add("grupo", "grupo");
                objbulk.ColumnMappings.Add("cantidad", "cantidad");
                objbulk.ColumnMappings.Add("anolectivo", "anolectivo");
                objbulk.ColumnMappings.Add("tipo_ciclo", "tipo_ciclo");
                objbulk.ColumnMappings.Add("tipo_grupo", "tipo_grupo");

                con.Open();
                objbulk.WriteToServer(dt);
               con.Close();

        */

            }
        }
    }

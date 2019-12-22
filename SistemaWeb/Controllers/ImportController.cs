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
    [Authorize(Roles = "Admin")]
    public class ImportController : Controller
    {
        //linea de coneccionn
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

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

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

        private void InsertExceldata(string fileepath, string filename, int id, String ciclo, String confirmacion)
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


            SqlCommand cmd6 = new SqlCommand();
            DataTable dataTable6 = new DataTable();
            SqlDataAdapter sqlDA6; con.Open();
            cmd6.CommandText = "select *from inportarcion where cod_dpto = '" + id + "'";
            cmd6.CommandType = CommandType.Text;
            cmd6.Connection = con;
            sqlDA6 = new SqlDataAdapter(cmd6);
            sqlDA6.Fill(dataTable6);
            con.Close();

            if (dataTable6.Rows.Count == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    String profesor = dt.Rows[i].ItemArray[0].ToString();
                    string asignatura = dt.Rows[i].ItemArray[1].ToString();
                    string carrera = dt.Rows[i].ItemArray[2].ToString();
                    string grupo = dt.Rows[i].ItemArray[3].ToString();
                    string hora_grupo = dt.Rows[i].ItemArray[4].ToString();
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

                    //consulta de profesores con nombre y apellido concatenado
                    /*  SELECT inss FROM profesores
                        WHERE nombre +' ' + apellido = 'francisco zepeda'; */

                    SqlCommand cmd1 = new SqlCommand();
                    DataTable dataTable1 = new DataTable();
                    SqlDataAdapter sqlDA1; con.Open();
                    cmd1.CommandText = "SELECT inss FROM profesores WHERE nombre +' ' + apellido = '" + profesor + "'; ";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con;
                    sqlDA1 = new SqlDataAdapter(cmd1);
                    sqlDA1.Fill(dataTable1);
                    con.Close();
                    string inss = dataTable1.Rows[0].ItemArray[0].ToString();

                    // consulta carrera

                    SqlCommand cmd3 = new SqlCommand();
                    DataTable dataTable3 = new DataTable();
                    SqlDataAdapter sqlDA3; con.Open();
                    cmd3.CommandText = "select cod_carrera from carrera where nombre = '" + carrera + "';";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con;
                    sqlDA3 = new SqlDataAdapter(cmd3);
                    sqlDA3.Fill(dataTable3);
                    con.Close();
                    int cod_carrera = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0].ToString());

                    //insercion
                    SqlCommand cmd2;
                    SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                    con.Open();
                    String sql = "";
                    sql = "INSERT INTO inportarcion (inss, cod_dpto, cod_asignatura, cod_carrera, grupo, hora_grupo, tipo_ciclo, tipo_grupo) VALUES ('" + inss + "', " + id + ", " + cod_materia + ", " + cod_carrera + ", '" + grupo + "', '" + hora_grupo + "', '" + ciclo + "', '" + tipogrupo + "')";
                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                    cmd2 = new SqlCommand(sql, con);
                    sqlDA2.InsertCommand = new SqlCommand(sql, con);
                    sqlDA2.InsertCommand.ExecuteNonQuery();
                    cmd2.Dispose();
                    // ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
                    //return View(dpto);
                    con.Close();

                }


            }
            if (dataTable6.Rows.Count != 0)
            {

                if (confirmacion == "Yes")
                {

                    //borrar
                    SqlCommand cmdI;
                    SqlDataAdapter sqlDAI = new SqlDataAdapter();
                    con.Open();
                    String sql1 = "";
                    sql1 = " DELETE FROM inportarcion WHERE cod_dpto = '" + id + "'";
                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                    cmdI = new SqlCommand(sql1, con);
                    sqlDAI.InsertCommand = new SqlCommand(sql1, con);
                    sqlDAI.InsertCommand.ExecuteNonQuery();
                    cmdI.Dispose();
                    con.Close();



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        String profesor = dt.Rows[i].ItemArray[0].ToString();
                        string asignatura = dt.Rows[i].ItemArray[1].ToString();
                        string carrera = dt.Rows[i].ItemArray[2].ToString();
                        string grupo = dt.Rows[i].ItemArray[3].ToString();
                        string hora_grupo = dt.Rows[i].ItemArray[4].ToString();
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

                        //consulta de profesores con nombre y apellido concatenado
                        /*  SELECT inss FROM profesores
                            WHERE nombre +' ' + apellido = 'francisco zepeda'; */

                        SqlCommand cmd1 = new SqlCommand();
                        DataTable dataTable1 = new DataTable();
                        SqlDataAdapter sqlDA1; con.Open();
                        cmd1.CommandText = "SELECT inss FROM profesores WHERE nombre +' ' + apellido = '" + profesor + "'; ";
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = con;
                        sqlDA1 = new SqlDataAdapter(cmd1);
                        sqlDA1.Fill(dataTable1);
                        con.Close();
                        string inss = dataTable1.Rows[0].ItemArray[0].ToString();

                        // consulta carrera

                        SqlCommand cmd3 = new SqlCommand();
                        DataTable dataTable3 = new DataTable();
                        SqlDataAdapter sqlDA3; con.Open();
                        cmd3.CommandText = "select cod_carrera from carrera where nombre = '" + carrera + "';";
                        cmd3.CommandType = CommandType.Text;
                        cmd3.Connection = con;
                        sqlDA3 = new SqlDataAdapter(cmd3);
                        sqlDA3.Fill(dataTable3);
                        con.Close();
                        int cod_carrera = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0].ToString());

                        //insercion
                        SqlCommand cmd2;
                        SqlDataAdapter sqlDA2 = new SqlDataAdapter();
                        con.Open();
                        String sql = "";
                        sql = "INSERT INTO inportarcion (inss, cod_dpto, cod_asignatura, cod_carrera, grupo, hora_grupo, tipo_ciclo, tipo_grupo) VALUES ('" + inss + "', " + id + ", " + cod_materia + ", " + cod_carrera + ", '" + grupo + "', '" + hora_grupo + "', '" + ciclo + "', '" + tipogrupo + "')";
                        //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                        cmd2 = new SqlCommand(sql, con);
                        sqlDA2.InsertCommand = new SqlCommand(sql, con);
                        sqlDA2.InsertCommand.ExecuteNonQuery();
                        cmd2.Dispose();
                        // ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
                        //return View(dpto);
                        con.Close();

                    }
                    ViewBag.Message = "se a efectuado todos los canvios correctamente!";

                }
                else
                {
                    ViewBag.Message = "no se a efectuado ningun canbio!";
                }
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

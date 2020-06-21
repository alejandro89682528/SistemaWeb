using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class RespaldoController : Controller
    {

        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J93P0Q;Database=sistema_horario; Integrated Security = True");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // GET: Respaldo
        public ActionResult Index()
        {


            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            // Backup destibation
            string backupDestination = "C:\\SQLBackUpFolder"; //aqui es donde se va a guardar el archivo
            // check if backup folder exist, otherwise create it.
            if (!System.IO.Directory.Exists(backupDestination))
            {
                System.IO.Directory.CreateDirectory("C:\\SQLBackUpFolder");
                con.Open();
                sqlcmd = new SqlCommand("backup database sistema_horario to disk='" + backupDestination + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".bak'", con); // las bases de datos en sql server se guardan on la extension .bak
                con.Close();
                ViewBag.Message = "El Backup sea realisado correctamente";
            }
            else
            {
                con.Open();
                sqlcmd = new SqlCommand("backup database sistema_horario to disk='" + backupDestination + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "El Backup sea realisado correctamente";
            }

            return PartialView();
        }

        public ActionResult contenedor()
        {



            return View();
        }

        public ActionResult restaurar()
        {



                return PartialView();
        }

        [HttpPost]
        public ActionResult restaurar(HttpPostedFileBase file, string confirm_value)
        {

            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            string basehora = "sistema_horario";
            string servidor = "DESKTOP-9J93P0Q\aleja";


            
            string sBackup = "RESTORE DATABASE " + basehora +
                             " FROM DISK = '" + filepath + "'" +
                             " WITH REPLACE";

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = servidor;
            // Es mejor abrir la conexión con la base Master
            csb.InitialCatalog = "master";
            csb.IntegratedSecurity = true;
            //csb.ConnectTimeout = 480; // el predeterminado es 15

            using (SqlConnection con1 = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con1.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con1);
                    cmdBackUp.ExecuteNonQuery();
                    ViewBag.Message = "Se ha restaurado la copia de la base de datos";
                                    //MessageBoxButtons.OK,
                                    //MessageBoxIcon.Information);

                    con1.Close();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error al restaurar la base de datos";
                                   // MessageBoxButtons.OK,
                                   // MessageBoxIcon.Error);
                }
            }


            return contenedor();
        }




    }
}
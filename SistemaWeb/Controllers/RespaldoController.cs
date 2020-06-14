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



                return View();
        }

        [HttpPost]
        public ActionResult restaurar(HttpPostedFileBase file)
        {

            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            

            return View();
        }




    }
}
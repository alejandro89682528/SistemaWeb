using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class bakucretaurarController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        OleDbConnection Econ;

        // GET: bakucretaurar
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
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
            csb.ConnectTimeout = 480; // el predeterminado es 15

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

                    con.Close();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error al restaurar la base de datos";
                    // MessageBoxButtons.OK,
                    // MessageBoxIcon.Error);
                }
            }

            return Index();

        }

    }
}
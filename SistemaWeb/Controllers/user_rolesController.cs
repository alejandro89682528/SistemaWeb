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
    public class user_rolesController : Controller
    {

        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // GET: user_roles
        public ActionResult Index()
        {
            SqlCommand cmd6 = new SqlCommand();
            DataTable dataTable6 = new DataTable();
            SqlDataAdapter sqlDA6; con.Open();
            cmd6.CommandText = "select *from AspNetUserRoles ";
            cmd6.CommandType = CommandType.Text;
            cmd6.Connection = con;
            sqlDA6 = new SqlDataAdapter(cmd6);
            sqlDA6.Fill(dataTable6);
            con.Close();
            return View(dataTable6.ToString());
        }
    }
}
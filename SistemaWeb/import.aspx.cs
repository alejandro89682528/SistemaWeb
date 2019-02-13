using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SistemaWeb
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Leer();
        }

        private void Leer()
        {
           // string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""";
            string connectionString = @"Provider =Microsoft.ACE.OLEDB.12.0; Data Source=C:\\LibroExcel.xlsx; Extended Properties=""Excel 12.0 Xml; HDR=YES;""";
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Personas$]", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
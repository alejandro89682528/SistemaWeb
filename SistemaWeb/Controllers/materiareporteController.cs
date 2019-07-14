using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;
using SistemaWeb.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class materiareporteController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: aulareporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export()
        {
            
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/reportes/CrystalReport1Materia.rpt")));
            rd.SetDataSource(db.materias.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "aplication/pdf", "listamateria.pdf");
            
        }
    }
}
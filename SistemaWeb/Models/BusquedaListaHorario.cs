using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWeb.Models
{
    public class BusquedaListaHorario
    {
        public String periodo { set; get; }

        public String Nombre_profesor { set; get; }

        public String Nombre_aula { set; get; }

        public String Grupo { set; get; }

        public String año_estudio { set; get; }
    }
}
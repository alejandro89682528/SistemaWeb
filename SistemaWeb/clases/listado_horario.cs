using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWeb.clases
{
    public class listado_horario
    {
        int depeto;
        int carrera;
        string ciclo;
        string año;

        public listado_horario(int depeto, int carrera, string ciclo, string año)
        {
            this.depeto = depeto;
            this.carrera = carrera;
            this.ciclo = ciclo;
            this.año = año;
        }

        public int Depeto { get; set; } 
        public int Carrera { get; set; }
        public string Ciclo { get; set; }
        public string Año { get; set; }
      
    }
}
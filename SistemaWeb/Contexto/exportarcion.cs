//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class exportarcion
    {
        public int id { get; set; }
        public string inss { get; set; }
        public Nullable<int> cod_dpto { get; set; }
        public Nullable<int> cod_asignatura { get; set; }
        public string grupo { get; set; }
        public int cantidad { get; set; }
        public string anolectivo { get; set; }
        public string tipo_ciclo { get; set; }
        public string tipo_grupo { get; set; }
    
        public virtual dpto dpto { get; set; }
        public virtual profesore profesore { get; set; }
    }
}

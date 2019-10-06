using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWeb.Models
{
    public class HorarioViewModel
    {
        private ApplicationDbContext Contexto;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        public HorarioViewModel()
        {
            Contexto = new ApplicationDbContext();
            Horario = new List<BusquedaListaHorario>();
        }

        public List<BusquedaListaHorario> Horario { get; set; }
        public void BusquedaHorario(int cod_dpto, int cod_carrera, int año_estudio, int tipo_ciclo)
        {
           /* var consulta = from h in db.horarios join p in db.pensums on
                           h.cod_asig equals p.cod_asig join d in db.dptoes on                            
                           where p.ciclo.Contains(tipo_ciclo)
                          where d.cod_dpto.Contains(cod_dpto)
                           
                           select new
                           {

                           }; */
        }
                           
                           
        }
    }

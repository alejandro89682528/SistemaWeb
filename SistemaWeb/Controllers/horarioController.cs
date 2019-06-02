using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class horarioController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cod_carrera, string tipo_ciclo)
        {
        
            var idCarrera = Int32.Parse(cod_carrera);
            var semestre = Int32.Parse(tipo_ciclo);
            ValidarHorario(idCarrera, semestre );

            return Index();
        }

        private void ValidarHorario(int idCarrera, int semestre)
        {
            //consultar lista de dias
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            cmd.CommandText = "select * from dia;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();

            //int cod_carrera = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());

            // seleccion de datos por tipo de grupo select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo from pensum p, inportarcion i where  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = 1 and i.cod_carrera=2 and i.tipo_grupo='Practico'  order by p.ciclo, i.grupo;

            //consultarn lista de datos de inportacion de cada de cada carrera
            SqlCommand cmd1 = new SqlCommand();
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDA1; con.Open();
            cmd1.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig from pensum p, inportarcion i where  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = '" + semestre + "' and cod_carrera='" + idCarrera + "' order by p.ciclo, i.grupo;";
            // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            sqlDA1 = new SqlDataAdapter(cmd1);
            sqlDA1.Fill(dataTable1);
            con.Close();
            int cod_dpto = Convert.ToInt32(dataTable1.Rows[0].ItemArray[3].ToString());
            /*
            //consultarn lista de datos de inportacion de cada de cada carrera de laboratorio
            SqlCommand cmd5 = new SqlCommand();
            DataTable dataTable5 = new DataTable();
            SqlDataAdapter sqlDA5; con.Open();
            cmd5.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig from pensum p, inportarcion i where  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = '" + semestre + "' and cod_carrera='" + idCarrera + "' and tipo_grupo='Practico' order by p.ciclo, i.grupo;";
            // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
            cmd5.CommandType = CommandType.Text;
            cmd5.Connection = con;
            sqlDA5 = new SqlDataAdapter(cmd5);
            sqlDA5.Fill(dataTable5);
            con.Close();
            //int cod_dpto = Convert.ToInt32(dataTable1.Rows[0].ItemArray[3].ToString());
            */
            // consulta para extraer  lista de periodo
            SqlCommand cmd2 = new SqlCommand();
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDA2; con.Open();
            cmd2.CommandText = "select * from periodo;";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            sqlDA2 = new SqlDataAdapter(cmd2);
            sqlDA2.Fill(dataTable2);
            con.Close();

            //consultar aulas de partamento seleccionado
            SqlCommand cmd3 = new SqlCommand();
            DataTable dataTable3 = new DataTable();
            SqlDataAdapter sqlDA3; con.Open();
            cmd3.CommandText = "select * from aula where cod_dpto= '" + cod_dpto + "';";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;
            sqlDA3 = new SqlDataAdapter(cmd3);
            sqlDA3.Fill(dataTable3);
            con.Close();


            //consultar total de la suma de horas 
            SqlCommand cmd4 = new SqlCommand();
            DataTable dataTable4 = new DataTable();
            SqlDataAdapter sqlDA4; con.Open();
            cmd4.CommandText = "select sum(hora_grupo) from inportarcion  where tipo_ciclo = '" + semestre + "' and cod_carrera='" + idCarrera + "';";
            cmd4.CommandType = CommandType.Text;
            cmd4.Connection = con;
            sqlDA4 = new SqlDataAdapter(cmd4);
            sqlDA4.Fill(dataTable4);
            con.Close();

            int total_hora = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0].ToString());

            // bariables aleatorias
            Random aulaaleatoria = new Random();
            Random diasaleatorios = new Random();

            //bariable de control de periodos
            int control_periodos = 0;
            //bariable de control de clases
            int i = 0;
            //int clases = clasesaleatorias.Next(0, dataTable1.Rows.Count + 1);
           /* //bariable de control de clases practicas
            int p = 0; */
            //bariable de control de aulas
            int A = 0;
            //int aulas = aulaaleatoria.Next(0, dataTable3.Rows.Count + 1);
            //bariable de control de semana
             
                
                //while para control de aulas 
                // while (A < dataTable3.Rows.Count)
                do
                {
                    //A++;

                    //for para la lista de clases
                    while (i < dataTable1.Rows.Count)
                    {
                        int D = diasaleatorios.Next(0, dataTable.Rows.Count);
                        int id_dias = Convert.ToInt32(dataTable.Rows[D].ItemArray[0].ToString());
                        String dias = dataTable.Rows[D].ItemArray[1].ToString();

                        int aulas = aulaaleatoria.Next(0, dataTable3.Rows.Count);
                        int cod_aulas = Convert.ToInt32(dataTable3.Rows[aulas].ItemArray[0].ToString());
                        String aula = dataTable3.Rows[aulas].ItemArray[1].ToString();


                        String ciclo = dataTable1.Rows[i].ItemArray[0].ToString();
                        int cod_asignatura = Convert.ToInt32(dataTable1.Rows[i].ItemArray[1].ToString());
                        String inss = dataTable1.Rows[i].ItemArray[2].ToString();
                        //int cod_dpto = Convert.ToInt32(dataTable1.Rows[i].ItemArray[3].ToString());                
                        int cod_carrera = Convert.ToInt32(dataTable1.Rows[i].ItemArray[4].ToString());
                        String grupo = dataTable1.Rows[i].ItemArray[5].ToString();
                        int hora_grupo = Convert.ToInt32(dataTable1.Rows[i].ItemArray[6].ToString());
                        //String hora_grupo = dataTable1.Rows[i].ItemArray[7].ToString();
                        String tipo_grupo = dataTable1.Rows[i].ItemArray[7].ToString();
                        int cod_pemsul = Convert.ToInt32(dataTable1.Rows[i].ItemArray[8].ToString());

                    //si y while pára controlar periodos

                    if (hora_grupo.Equals(0))
                    {
                        break;
                    }
                    if(hora_grupo.Equals(1))
                    {
                        //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                        while (control_periodos < dataTable2.Rows.Count)
                        {
                            int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                            String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                            // codigo de verificasion de aulas 

                            SqlCommand cmd6 = new SqlCommand();
                            DataTable dataTable6 = new DataTable();
                            SqlDataAdapter sqlDA6; con.Open();
                            cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulas + " and h.cod_periodo =" + id_periodo + ";";
                            cmd6.CommandType = CommandType.Text;
                            cmd6.Connection = con;
                            sqlDA6 = new SqlDataAdapter(cmd6);
                            sqlDA6.Fill(dataTable6);
                            con.Close();

                            if (dataTable6.Rows.Count == 0)
                            {
                                //insercion
                                SqlCommand cmdI;
                                SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                con.Open();
                                String sql = "";

                                sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss) VALUES ('" + cod_pemsul + "', " + cod_aulas + ", " + id_dias + ", '" + grupo + "', '" + id_periodo + "', '14/04/2019', '" + inss + "')";
                                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                cmdI = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand.ExecuteNonQuery();
                                cmdI.Dispose();
                                con.Close();
                                hora_grupo--;
                                total_hora--;

                                if ((control_periodos + 1) == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                                control_periodos++;
                                break;
                            }
                        }

                } else

                    {


                        //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                        while (control_periodos < dataTable2.Rows.Count)
                        {
                            int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                            String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                            // codigo de verificasion de aulas 

                            SqlCommand cmd6 = new SqlCommand();
                            DataTable dataTable6 = new DataTable();
                            SqlDataAdapter sqlDA6; con.Open();
                            cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulas + " and h.cod_periodo =" + id_periodo + ";";
                            cmd6.CommandType = CommandType.Text;
                            cmd6.Connection = con;
                            sqlDA6 = new SqlDataAdapter(cmd6);
                            sqlDA6.Fill(dataTable6);
                            con.Close();

                            if (dataTable6.Rows.Count == 0)
                            {
                                //insercion
                                SqlCommand cmdI;
                                SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                con.Open();
                                String sql = "";

                                sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss) VALUES ('" + cod_pemsul + "', " + cod_aulas + ", " + id_dias + ", '" + grupo + "', '" + id_periodo + "', '14/04/2019', '" + inss + "')";
                                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                cmdI = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand.ExecuteNonQuery();
                                cmdI.Dispose();
                                con.Close();
                                hora_grupo--;
                                total_hora--;


                               

                                if ((control_periodos % 2) != 0)
                                {
                                    control_periodos++;
                                    break;

                                }
                                if ((control_periodos + 1) == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                                control_periodos++;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                    

                    if ((i + 1) == dataTable1.Rows.Count)
                    {

                        //int clases_finalisar = control_periodos + 1;

                        i = 0;
                        break;

                    }

                    i++;

                    }

                } while (total_hora != 0);
                           

            }
        }
    }
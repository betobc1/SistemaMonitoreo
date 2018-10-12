using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SisMonitoreo.DataAccess
{
    public sealed class EstadoDA
    {
        

        public static List<Entities.Estados> VerFlujo(string stateid)
        {
            var lista = new List<Entities.Estados>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                using (var cmd = new SqlCommand("select workflowid as flujo from [EES.BBVA.2018v1].dbo.States where id = " +  stateid, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oEstado = new Entities.Estados();
                            oEstado.flujo = Convert.ToString(dr[dr.GetOrdinal("flujo")]);
                            lista.Add(oEstado);
                        }
                    }
                    return lista;
                }
            }
        }

        public static List<Entities.Estados> ListarEstados(string flujo)
        {
            var lista = new List<Entities.Estados>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                using (var cmd = new SqlCommand("select id as stateid,name from [EES.BBVA.2018v1].dbo.States where workflowid = " + flujo, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oEstado = new Entities.Estados();
                            oEstado.stateid = Convert.ToString(dr[dr.GetOrdinal("stateid")]);
                            oEstado.name = Convert.ToString(dr[dr.GetOrdinal("name")]);
                            lista.Add(oEstado);
                        }
                    }
                    return lista;
                }
            }

        }

        public static List<Entities.Estados> EstadoActual(string stateid)
        {
            var lista = new List<Entities.Estados>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                using (var cmd = new SqlCommand("select id as stateid,name from [EES.BBVA.2018v1].dbo.States where workflowid = " + stateid, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oEstado = new Entities.Estados();
                            oEstado.stateid = Convert.ToString(dr[dr.GetOrdinal("stateid")]);
                            oEstado.name = Convert.ToString(dr[dr.GetOrdinal("name")]);
                            lista.Add(oEstado);
                        }
                    }
                    return lista;
                }
            }

        }
    }
}

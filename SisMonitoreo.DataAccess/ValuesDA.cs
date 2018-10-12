using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SisMonitoreo.DataAccess
{
    public sealed class ValuesDA
    {
        public static List<Entities.Values> ListarValues(string ticketid)
        {
            var lista = new List<Entities.Values>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {

                string query = "select tv.Id as id,TicketId,f.Name as Field, case" + 
                " when f.Name = 'contratopdf' then 'http://118.247.29.138:8095/WEB' + Value " +
                " when f.Name = 'uploadpdfcronogama' then 'http://118.247.29.138:8095/WEB' + Value " +
                " when f.Name = 'links' then 'http://118.247.29.138:8095/WEB' + Value " +
                "Else Value End as Value,ClonedValueOrder " + 
                "from[EES.BBVA.2018v1].dbo.TicketValues tv " +
                "inner join[EES.BBVA.2018v1].dbo.Fields f on f.Id = tv.FieldId where TicketId = " + ticketid + " order by tv.id";
                using (var cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oValues = new Entities.Values();
                            oValues.id = Convert.ToString(dr[dr.GetOrdinal("id")]);
                            oValues.ticketid = Convert.ToString(dr[dr.GetOrdinal("ticketid")]);
                            oValues.field = Convert.ToString(dr[dr.GetOrdinal("Field")]);
                            oValues.value = Convert.ToString(dr[dr.GetOrdinal("value")]);
                            oValues.clonedvalueorder = Convert.ToString(dr[dr.GetOrdinal("clonedvalueorder")]);
                            lista.Add(oValues);
                        }
                    }
                    return lista;
                }
            }
        }
    }
}

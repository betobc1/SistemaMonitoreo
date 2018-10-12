using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SisMonitoreo.DataAccess
{
    public class HistoriesDA
    {
        public static List<Entities.Histories> ListarHistories(string ticketid)
        {
            var lista = new List<Entities.Histories>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
               
                using (var cmd = new SqlCommand("select th.Id,th.TicketId,st.Name as state,us.Name as usuario,th.RobotVirtualMachineId, "+
                                                "ro.Description as robot, sa.ActionDescription "+
                                                "from[EES.BBVA.2018v1].dbo.TicketHistories th "+
                                                "left join[EES.BBVA.2018v1].dbo.States st on st.Id = th.StateId "+
                                                "left join[EES.BBVA.2018v1].dbo.StateActions sa on sa.Id = th.StateActionId "+
                                                "left join[EES.BBVA.2018v1].dbo.Users us on us.Id = th.UserId "+
                                                "left join[EES.BBVA.2018v1].dbo.RobotVirtualMachines rvm on rvm.Id = th.RobotVirtualMachineId "+
                                                "left join[EES.BBVA.2018v1].dbo.Robots ro on ro.Id = rvm.RobotId "+
                                                "where TicketId = " + ticketid + "order by id desc ",cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oHist = new Entities.Histories();
                            oHist.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                            oHist.TicketId = Convert.ToString(dr[dr.GetOrdinal("TicketId")]);
                            oHist.state = Convert.ToString(dr[dr.GetOrdinal("state")]);
                            oHist.usuario = Convert.ToString(dr[dr.GetOrdinal("usuario")]);
                            oHist.RobotGuid = Convert.ToString(dr[dr.GetOrdinal("RobotVirtualMachineId")]);
                            oHist.Robot = Convert.ToString(dr[dr.GetOrdinal("robot")]);
                            oHist.AccionDesc = Convert.ToString(dr[dr.GetOrdinal("ActionDescription")]);   
                            lista.Add(oHist);
                        }
                    }
                    return lista;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SisMonitoreo.DataAccess
{
    public sealed class LogDA
    {
        public static List<Entities.Log> ListarLog(string ticketid)
        {
            var lista = new List<Entities.Log>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                using (var cmd = new SqlCommand("select ld.Id,ld.RobotVirtualMachineId,ro.Description as robot,ld.StateId,st.Name as state, " +
                                                "ld.TicketId,ld.Description,ld.Exception, ld.StackTrace, ld.Method, ld.CreationDate from[EES.BBVA.2018v1].dbo.LogDatas ld " +
                                                "left join[EES.BBVA.2018v1].dbo.RobotVirtualMachines rvm on rvm.Id = ld.RobotVirtualMachineId " +
                                                "left join[EES.BBVA.2018v1].dbo.Robots ro on ro.Id = rvm.RobotId " +
                                                "left join[EES.BBVA.2018v1].dbo.States st on st.Id = ld.StateId " +
                                                "where ld.TicketId = " + ticketid + " order by ld.id desc", cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oLog = new Entities.Log();
                            oLog.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                            oLog.robotvirtualmachineId = Convert.ToString(dr[dr.GetOrdinal("RobotVirtualMachineId")]);
                            oLog.robot = Convert.ToString(dr[dr.GetOrdinal("robot")]);
                            oLog.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                            oLog.state = Convert.ToString(dr[dr.GetOrdinal("state")]);
                            oLog.ticketid = Convert.ToString(dr[dr.GetOrdinal("TicketId")]);
                            oLog.description = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                            oLog.exception = Convert.ToString(dr[dr.GetOrdinal("Exception")]);
                            oLog.method = Convert.ToString(dr[dr.GetOrdinal("Method")]);
                            oLog.creationdate = Convert.ToString(dr[dr.GetOrdinal("CreationDate")]);
                            lista.Add(oLog);
                        }
                    }
                    return lista;
                }
            }
        }
    }
}

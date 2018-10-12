using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SisMonitoreo.DataAccess
{
    public sealed class TicketDA
    {
        static void Main() { }

        public static bool ActualizarEstadoTicket(string ticketid, string stateid)
        {
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                string query = "update [EES.BBVA.2018v1].[dbo].[Tickets] set StateId = " + stateid + 
                    ",UserId = NULL,RobotVirtualMachineId = NULL where Id = " + ticketid;
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message);
                }


            }
        }
        public static bool ActualizarGUID()
        {
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                // string query = "update [EES.BBVA.2018v1].[dbo].[Tickets] set StateId = " + stateid +
                //   ",UserId = NULL,RobotVirtualMachineId = NULL where Id = " + ticketid;

                string query = "update[EES.BBVA.2018v1].[dbo].[Tickets] set StateId = 1055, UserId = NULL, RobotVirtualMachineId = '97a2fdf5-4a02-47ea-9c01-2da320e2a806' where RobotVirtualMachineId = '29a70535-8a92-40ae-b0ab-38d66b43effa'";
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<Entities.Ticket> ListarTicket(string expediente)
        {
            var lista = new List<Entities.Ticket>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {

                string query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado'," +
                    "'Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                    ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Inicio'   " +
                    ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecucion'" +
                    ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                    "WHERE tk.[Description] = " + expediente;
                using (var cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oTicket = new Entities.Ticket();
                            oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                            oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                            oTicket.ticket = Convert.ToString(dr[dr.GetOrdinal("Ticket")]);
                            oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                            oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                            oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                            oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Name")]);
                            oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                            oTicket.parentid = Convert.ToString(dr[dr.GetOrdinal("ParentId")]);
                            oTicket.userid = Convert.ToString(dr[dr.GetOrdinal("UserId")]);
                            oTicket.guid = Convert.ToString(dr[dr.GetOrdinal("RobotVirtualMachineId")]);
                            oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Inicio")]);
                            oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecucion")]);
                            oTicket.mensaje = Convert.ToString(dr[dr.GetOrdinal("Error")]);
                            oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("CreationDate")]);
                            oTicket.modificacion = Convert.ToString(dr[dr.GetOrdinal("LastModified")]);
                            oTicket.prioridad = Convert.ToString(dr[dr.GetOrdinal("Priority")]);
                            lista.Add(oTicket);
                        }
                    }
                    return lista;
                }
            }
        }

        public static List<Entities.Ticket> ListarTicket()
        {
            var lista = new List<Entities.Ticket>();
            string query = "";
            using (var cn = new SqlConnection(conexion.Cadena))
            {

                    query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado'," +
                        "'Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                        ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Inicio'   " +
                        ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecucion'" +
                        ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                        "WHERE wf.[Id] in (9) " +
                        "AND CAST(tk.[CreationDate] AS DATE) >= CAST(GETDATE()-3 AS DATE) " +
                        "ORDER BY tk.id desc ";

                using (var cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oTicket = new Entities.Ticket();
                            oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                            oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                            oTicket.ticket = Convert.ToString(dr[dr.GetOrdinal("Ticket")]);
                            oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                            oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                            oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                            oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Name")]);
                            oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                            oTicket.parentid = Convert.ToString(dr[dr.GetOrdinal("ParentId")]);
                            oTicket.userid = Convert.ToString(dr[dr.GetOrdinal("UserId")]);
                            oTicket.guid = Convert.ToString(dr[dr.GetOrdinal("RobotVirtualMachineId")]);
                            oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Inicio")]);
                            oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecucion")]);
                            oTicket.mensaje = Convert.ToString(dr[dr.GetOrdinal("Error")]);
                            oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("CreationDate")]);
                            oTicket.modificacion = Convert.ToString(dr[dr.GetOrdinal("LastModified")]);
                            oTicket.prioridad = Convert.ToString(dr[dr.GetOrdinal("Priority")]);
                            lista.Add(oTicket);
                        }
                    }
                    return lista;
                }
            }
        }

        public static List<Entities.Ticket> ListarTicketWorkFlow(string workflowid)
        {
            var lista = new List<Entities.Ticket>();
            string query = "";
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                if (workflowid.Length > 0)
                {
                    query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado'," +
                        "'Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                        ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Inicio'   " +
                        ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecucion'" +
                        ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                        "WHERE wf.[Id] in (" + workflowid + ") " +
                        "AND CAST(tk.[CreationDate] AS DATE) >= CAST(GETDATE()-2 AS DATE) " +
                        "ORDER BY tk.id desc ";
                }
                else
                {
                    query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado'," +
                        "'Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                        ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Inicio'   " +
                        ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecucion'" +
                        ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                        "WHERE wf.[Id] in (8,9) " +
                        "AND CAST(tk.[CreationDate] AS DATE) >= CAST(GETDATE()-2 AS DATE) " +
                        "ORDER BY tk.id desc ";
                }


                using (var cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oTicket = new Entities.Ticket();
                            oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                            oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                            oTicket.ticket = Convert.ToString(dr[dr.GetOrdinal("Ticket")]);
                            oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                            oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                            oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                            oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Name")]);
                            oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                            oTicket.parentid = Convert.ToString(dr[dr.GetOrdinal("ParentId")]);
                            oTicket.userid = Convert.ToString(dr[dr.GetOrdinal("UserId")]);
                            oTicket.guid = Convert.ToString(dr[dr.GetOrdinal("RobotVirtualMachineId")]);
                            oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Inicio")]);
                            oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecucion")]);
                            oTicket.mensaje = Convert.ToString(dr[dr.GetOrdinal("Error")]);
                            oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("CreationDate")]);
                            oTicket.modificacion = Convert.ToString(dr[dr.GetOrdinal("LastModified")]);
                            oTicket.prioridad = Convert.ToString(dr[dr.GetOrdinal("Priority")]);
                            lista.Add(oTicket);
                        }
                    }
                    return lista;
                }
            }
        }
    }
}

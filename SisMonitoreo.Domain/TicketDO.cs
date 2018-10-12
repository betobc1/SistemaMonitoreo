using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisMonitoreo.Domain
{
    public class TicketDO
    {
        static void Main(string[] args){}
        
        public static List<Entities.Ticket> ListarTicket()
        {
            return DataAccess.TicketDA.ListarTicket();
        }

        public static List<Entities.Ticket> ListarTicketWorkFlow(string workflowid)
        {
            return DataAccess.TicketDA.ListarTicketWorkFlow(workflowid);
        }

        public static List<Entities.Ticket> ListarTicket(string expediente)
        {
            return DataAccess.TicketDA.ListarTicket(expediente);
        }

        public static bool ActualizarEstadoTicket(string ticketid, string stateid)
        {
            if (DataAccess.TicketDA.ActualizarEstadoTicket(ticketid, stateid))
            {
                return true;
            }
            else
	        {
                return false;
            }
            
        }
        public static bool ActualizarGUID()
        {
            if (DataAccess.TicketDA.ActualizarGUID())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

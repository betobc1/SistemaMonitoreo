using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Domain
{
    public class LogDO
    {
        public static List<Entities.Log> ListarLog(string ticketid)
        {
            return DataAccess.LogDA.ListarLog(ticketid);
        }
    }
}

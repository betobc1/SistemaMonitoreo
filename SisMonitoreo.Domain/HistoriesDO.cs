using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Domain
{
    public class HistoriesDO
    {
        public static List<Entities.Histories> ListarHistories(string ticketid)
        {
            return DataAccess.HistoriesDA.ListarHistories(ticketid);
        }
    }
}

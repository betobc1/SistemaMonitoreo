using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Domain
{
    public class ValuesDO
    {
        public static List<Entities.Values> ListarValues(string ticketid)
        {
            return DataAccess.ValuesDA.ListarValues(ticketid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Entities
{
    public class Histories
    {
        public string id { get; set; }
        public string TicketId { get; set; }     
        public string state { get; set; }
        public string usuario { get; set; }
        public string RobotGuid{ get; set; }
        public string Robot { get; set; }
        public string AccionDesc { get; set; }


    }
}

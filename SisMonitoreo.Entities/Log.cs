using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Entities
{
    public class Log
    {
        public string id { get; set; }
        public string robotvirtualmachineId { get; set; }
        public string robot { get; set; }
        public string stateid { get; set; }
        public string state { get; set; }
        public string ticketid { get; set; }
        public string description { get; set; }
        public string exception { get; set; }
        public string stackTrace { get; set; }
        public string method { get; set; }
        public string creationdate { get; set; }
    }
}

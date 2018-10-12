using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Entities
{
    public class Ticket
    {
        public string flujo { get; set; }
        public string ultimo_estado { get; set; }
        public string ticket { get; set; }
        public string id { get; set; }
        public string exp { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string stateid { get; set; }
        public string parentid { get; set; }
        public string userid { get; set; }
        public string guid { get; set; }
        public string inicio { get; set; }
        public string ejecucion { get; set; }
        public string mensaje { get; set; }
        public string creacion { get; set; }
        public string modificacion { get; set; }
        public string prioridad { get; set; }
    }
}

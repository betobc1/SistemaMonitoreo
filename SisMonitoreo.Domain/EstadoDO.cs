using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.Domain
{
    public class EstadoDO
    {
        public static List<Entities.Estados> ListarEstados(string stateid)
        {
            string flujo = DataAccess.EstadoDA.VerFlujo(stateid)[0].flujo;
            return DataAccess.EstadoDA.ListarEstados(flujo);
        }

        public static List<Entities.Estados> EstadoActual(string stateid)
        {
           
            return DataAccess.EstadoDA.EstadoActual(stateid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMonitoreo.DataAccess
{
    public sealed class conexion
    {
        public static string Cadena
        {
            get { return "Data Source=118.247.29.138\\SQLEXPRESS; Initial Catalog=EES.BBVA.2018v1; User ID = SA; Password=everis@2017;"; }
            //SqlConnection cn = new SqlConnection("Data Source=118.247.29.138\\SQLEXPRESS; Initial Catalog=EES.BBVA.2018v1; User ID = SA; Password=everis@2017;");
            //get { return @"Server=.;Database=PECH;User Id=SA; Password=12345678*;"; }
            //get { return @"Server=10.0.1.209;Database=PECH;User Id=SA; Password=sapech2009k1F72;"; }
        }
    }
}
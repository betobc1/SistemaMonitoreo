using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisMonitoreo
{
    public partial class frmVerPdf : Form
    {
        public static frmVerPdf f1;
        public frmVerPdf()
        {
            InitializeComponent();
            axAcroPDF1.src = "http://118.247.29.138:8095/WEB/Content/Upload_Files/a18367f4-d2fe-4336-a3de-af32dec6d524%20-%20Contrato.pdf";
        }
    }
}

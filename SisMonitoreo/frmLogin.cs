using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SisMonitoreo
{
    public partial class frmLogin : Form
    {
        public static String user;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Form MDIPrincipal = new MDIPrincipal();
            Form FrmDiario = new frmDiario();
            string Usuario = txtUsuario.Text;
            string Clave = txtClave.Text;


            if ((Usuario.Equals("admin")) && (Clave.Equals("admin")))
            {
                MDIPrincipal.Show();
                Form frmDiario = new frmDiario();
                frmDiario.MdiParent = MDIPrincipal;
                frmDiario.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmDiario.Show();
                this.Hide();
             
            }
            else if ((Usuario.Equals("tarjetas")) && (Clave.Equals("tarjetas")))
            {
                MDIPrincipal.Show();
                Form frmDiario = new frmDiario();
                frmDiario.MdiParent = MDIPrincipal;
                frmDiario.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmDiario.Show();
                this.Hide();
              
            }
            else if ((Usuario.Equals("prestamos")) && (Clave.Equals("prestamos")))
            {
                MDIPrincipal.Show();
                Form frmDiario = new frmDiario();
                frmDiario.MdiParent = MDIPrincipal;
                frmDiario.WindowState = System.Windows.Forms.FormWindowState.Maximized;
              
                frmDiario.Show();
                this.Hide();
               
            }
            else if ((Usuario.Equals("operador")) && (Clave.Equals("operador")))
            {
                MDIPrincipal.Show();
                Form frmDiario = new frmDiario();
                frmDiario.MdiParent = MDIPrincipal;
                frmDiario.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmDiario.Show();
                this.Hide();
            }
           
                
            
            else
            {
                MessageBox.Show("Usuario o Clave Incorrectos");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

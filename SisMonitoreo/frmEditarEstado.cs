using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisMonitoreo.Domain;

namespace SisMonitoreo
{
    public partial class frmEditarEstado : Form
    {
        public static frmEditarEstado f1;
        
        public frmEditarEstado()
        {
            InitializeComponent();
            frmEditarEstado.f1 = this;
            //cargarGridValues();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                cmbEstado.Enabled = true;
                string stateid = cmbEstado.SelectedValue.ToString();
                string ticketid = lblExpediente.Text;
                if (ticketid.Length > 0 || stateid.Length > 0)
                {
                    TicketDO.ActualizarEstadoTicket(ticketid, stateid);
                    btnEditar.Enabled = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnVerEstados_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            cmbEstado.Enabled = true;
        }

        private void dgvValues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string values = dgvValues.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (values.Length>4)
                {
                    if (values.Substring(0, 4) == "http")
                    {
                        MessageBox.Show("Desea cargar el documento seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        axAcroPDF1.src = values;
                    }
                    else
                    {
                        MessageBox.Show("El campo seleccionado no es un documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El campo seleccionado no es un documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmEditarEstado_Load(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

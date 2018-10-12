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
    public partial class frmDiario : Form
    {
        public frmDiario()
        {
            
            InitializeComponent();
            ListarDataTarjetas();
            ListarDataPrestamos();
            
            


        }

        private void ListarDataTarjetas()
        {
            try
            {
                //string workflowid = cmbFlujo.ValueMember.ToString();
                //dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow(workflowid);
                //dgvResultados.DataSource = TicketDO.ListarTicket();
                dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow("9");
                cargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ListarDataPrestamos()
        {
            try
            {
                //string workflowid = cmbFlujo.ValueMember.ToString();
                //dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow(workflowid);
                //dgvResultados.DataSource = TicketDO.ListarTicket();
                dgvResultados2.DataSource = TicketDO.ListarTicketWorkFlow("8");
                cargarGrid2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cargarGrid()
        {
            dgvResultados.Columns[0].HeaderText = "Flujo";
            dgvResultados.Columns[0].Width = 150;
            dgvResultados.Columns[1].HeaderText = "Último Estado";
            
            dgvResultados.Columns[1].Width = 280;
            dgvResultados.Columns[2].HeaderText = "Ticket";
            dgvResultados.Columns[2].Width = 60;
            dgvResultados.Columns[3].HeaderText = "ID";
            dgvResultados.Columns[3].Width = 50;
            dgvResultados.Columns[4].HeaderText = "Exp";
            dgvResultados.Columns[4].Width = 70;
            dgvResultados.Columns[5].HeaderText = "Descripción";
            dgvResultados.Columns[5].Width = 70;
            dgvResultados.Columns[6].HeaderText = "Estado";
            dgvResultados.Columns[6].Width = 280;
            dgvResultados.Columns[7].HeaderText = "StateID";
            dgvResultados.Columns[7].Width = 50;
            dgvResultados.Columns[8].HeaderText = "ParentID";
            dgvResultados.Columns[8].Width = 60;
            dgvResultados.Columns[9].HeaderText = "UserId";
            dgvResultados.Columns[9].Width = 40;
            dgvResultados.Columns[10].HeaderText = "GUID";
            dgvResultados.Columns[10].Width = 200;
            dgvResultados.Columns[11].HeaderText = "Creación";
            dgvResultados.Columns[11].Width = 60;
            dgvResultados.Columns[12].HeaderText = "Ejecución";
            dgvResultados.Columns[12].Width = 60;
            dgvResultados.Columns[13].HeaderText = "Mensaje";
            dgvResultados.Columns[13].Width = 280;
            dgvResultados.Columns[14].HeaderText = "Creación";
            dgvResultados.Columns[14].Width = 120;
            dgvResultados.Columns[15].HeaderText = "Modificación";
            dgvResultados.Columns[15].Width = 120;
            dgvResultados.Columns[16].HeaderText = "Prioridad";
            dgvResultados.Columns[16].Width = 60;
            

            try
            {
                int tam = Convert.ToInt32(dgvResultados.RowCount.ToString());
                for (int i = 0; i < tam; i++)
                {
                    string valor = dgvResultados.Rows[i].Cells[11].Value.ToString();
                    int hora = int.Parse(valor.Split(':')[0]);
                    int stateid = Convert.ToInt32(dgvResultados.Rows[i].Cells[7].Value.ToString());

                    if ((stateid == 1061) || (stateid == 1135))
                    {
                        dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else
                    {
                        if (hora < 30)
                        {
                            //dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            //dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            dgvResultados.Rows[i].Cells[7].Style.BackColor = Color.Green;
                            dgvResultados.Rows[i].Cells[7].Style.ForeColor = Color.White;
                        }
                        if ((hora >= 30) && (hora <= 60))
                        {
                            //dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dgvResultados.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                        }
                        if (hora > 60)
                        {
                            dgvResultados.Rows[i].Cells[7].Style.BackColor = Color.Red;
                            dgvResultados.Rows[i].Cells[7].Style.ForeColor = Color.White;
                            //dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    dgvResultados.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }
        private void cargarGrid2()
        {
            dgvResultados2.Columns[0].HeaderText = "Flujo";
            dgvResultados2.Columns[0].Width = 150;
            dgvResultados2.Columns[1].HeaderText = "Último Estado";
            dgvResultados2.Columns[1].Width = 280;
            dgvResultados2.Columns[2].HeaderText = "Ticket";
            dgvResultados2.Columns[2].Width = 60;
            dgvResultados2.Columns[3].HeaderText = "ID";
            dgvResultados2.Columns[3].Width = 50;
            dgvResultados2.Columns[4].HeaderText = "Exp";
            dgvResultados2.Columns[4].Width = 70;
            dgvResultados2.Columns[5].HeaderText = "Descripción";
            dgvResultados2.Columns[5].Width = 70;
            dgvResultados2.Columns[6].HeaderText = "Estado";
            dgvResultados2.Columns[6].Width = 280;
            dgvResultados2.Columns[7].HeaderText = "StateID";
            dgvResultados2.Columns[7].Width = 50;
            dgvResultados2.Columns[8].HeaderText = "ParentID";
            dgvResultados2.Columns[8].Width = 60;
            dgvResultados2.Columns[9].HeaderText = "UserId";
            dgvResultados2.Columns[9].Width = 40;
            dgvResultados2.Columns[10].HeaderText = "GUID";
            dgvResultados2.Columns[10].Width = 200;
            dgvResultados2.Columns[11].HeaderText = "Creación";
            dgvResultados2.Columns[11].Width = 60;
            dgvResultados2.Columns[12].HeaderText = "Ejecución";
            dgvResultados2.Columns[12].Width = 60;
            dgvResultados2.Columns[13].HeaderText = "Mensaje";
            dgvResultados2.Columns[13].Width = 280;
            dgvResultados2.Columns[14].HeaderText = "Creación";
            dgvResultados2.Columns[14].Width = 120;
            dgvResultados2.Columns[15].HeaderText = "Modificación";
            dgvResultados2.Columns[15].Width = 120;
            dgvResultados2.Columns[16].HeaderText = "Prioridad";
            dgvResultados2.Columns[16].Width = 60;
            try
            {
                int tam = Convert.ToInt32(dgvResultados2.RowCount.ToString());
                for (int i = 0; i < tam; i++)
                {
                    string valor = dgvResultados2.Rows[i].Cells[11].Value.ToString();
                    int hora = int.Parse(valor.Split(':')[0]);
                    int stateid = Convert.ToInt32(dgvResultados2.Rows[i].Cells[7].Value.ToString());

                    if ((stateid == 1050) || (stateid == 1136))
                    {
                        dgvResultados2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgvResultados2.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else
                    {
                        if (hora < 30)
                        {
                            //dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            //dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            dgvResultados2.Rows[i].Cells[7].Style.BackColor = Color.Green;
                            dgvResultados2.Rows[i].Cells[7].Style.ForeColor = Color.White;
                        }
                        if ((hora >= 30) && (hora <= 60))
                        {
                            //dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dgvResultados2.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                        }
                        if (hora > 60)
                        {
                            dgvResultados2.Rows[i].Cells[7].Style.BackColor = Color.Red;
                            dgvResultados2.Rows[i].Cells[7].Style.ForeColor = Color.White;
                            //dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    dgvResultados2.ClearSelection();


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //ListarData();
            ListarDataTarjetas();
            ListarDataPrestamos();
           // TicketDO.ActualizarGUID();
            timer1.Start();
            
        }

        private void dgvResultados_Scroll(object sender, ScrollEventArgs e)
        {
            //timer1.Stop();

        }

        private void txtExpediente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string expediente = txtExpediente.Text;
                //string workflowid = cmbFlujo.ValueMember.ToString();
                if (expediente.Length > 5)
                {
                    timer1.Stop();
                    dgvResultados.DataSource = TicketDO.ListarTicket(expediente);
                    cargarGrid();
                }
                else 
                {
                    //dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow(workflowid);
                    timer1.Start();
                    dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow("9");
                    cargarGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string statedid = dgvResultados.Rows[e.RowIndex].Cells[7].Value.ToString();
            string ticketid = dgvResultados.Rows[e.RowIndex].Cells[3].Value.ToString();
            Form f1 = new frmEditarEstado();
            frmEditarEstado.f1.Text = "Expediente: " + ticketid;
            frmEditarEstado.f1.lblExpediente.Text = ticketid;
            frmEditarEstado.f1.cmbEstado.Text = statedid.ToString();
            frmEditarEstado.f1.cmbEstado.DataSource = EstadoDO.ListarEstados(statedid);
            frmEditarEstado.f1.cmbEstado.ValueMember = "stateid";
            frmEditarEstado.f1.cmbEstado.DisplayMember = "name";

            frmEditarEstado.f1.dgvValues.DataSource = ValuesDO.ListarValues(ticketid);
            frmEditarEstado.f1.dgvValues.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvValues.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvValues.Columns[1].HeaderText = "Ticket";
            frmEditarEstado.f1.dgvValues.Columns[1].Width = 70;
            frmEditarEstado.f1.dgvValues.Columns[2].HeaderText = "Field";
            frmEditarEstado.f1.dgvValues.Columns[2].Width = 200;
            frmEditarEstado.f1.dgvValues.Columns[3].HeaderText = "Value";
            frmEditarEstado.f1.dgvValues.Columns[3].Width = 550;
            frmEditarEstado.f1.dgvValues.Columns[4].HeaderText = "Order";
            frmEditarEstado.f1.dgvValues.Columns[4].Width = 50;

            frmEditarEstado.f1.dgvLog.DataSource = LogDO.ListarLog(ticketid);
            frmEditarEstado.f1.dgvLog.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvLog.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[1].HeaderText = "GUID";
            frmEditarEstado.f1.dgvLog.Columns[1].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[2].HeaderText = "Robot";
            frmEditarEstado.f1.dgvLog.Columns[2].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[3].HeaderText = "StateId";
            frmEditarEstado.f1.dgvLog.Columns[3].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[4].HeaderText = "State";
            frmEditarEstado.f1.dgvLog.Columns[4].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[5].HeaderText = "TicketId";
            frmEditarEstado.f1.dgvLog.Columns[5].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[6].HeaderText = "Descripción";
            frmEditarEstado.f1.dgvLog.Columns[6].Width = 150;
            frmEditarEstado.f1.dgvLog.Columns[7].HeaderText = "Excepción";
            frmEditarEstado.f1.dgvLog.Columns[7].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[8].HeaderText = "Método";
            frmEditarEstado.f1.dgvLog.Columns[8].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[8].HeaderText = "Creación";
            frmEditarEstado.f1.dgvLog.Columns[8].Width = 100;

            frmEditarEstado.f1.dgvHist.DataSource = HistoriesDO.ListarHistories(ticketid);
            frmEditarEstado.f1.dgvHist.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvHist.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvHist.Columns[1].HeaderText = "TicketId";
            frmEditarEstado.f1.dgvHist.Columns[1].Width = 80;
            frmEditarEstado.f1.dgvHist.Columns[2].HeaderText = "Estado";
            frmEditarEstado.f1.dgvHist.Columns[2].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[3].HeaderText = "Usuario";
            frmEditarEstado.f1.dgvHist.Columns[3].Width = 150;
            frmEditarEstado.f1.dgvHist.Columns[4].HeaderText = "RobotGuid";
            frmEditarEstado.f1.dgvHist.Columns[4].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[5].HeaderText = "Robot";
            frmEditarEstado.f1.dgvHist.Columns[5].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[6].HeaderText = "Acción";
            frmEditarEstado.f1.dgvHist.Columns[6].Width = 150;
            f1.ShowDialog();
        }

        private void frmDiario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_EES_BBVA_2018v1DataSet.Workflows' table. You can move, or remove it, as needed.
            //this.workflowsTableAdapter.Fill(this._EES_BBVA_2018v1DataSet.Workflows);

        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvResultados2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvResultados2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string statedid = dgvResultados2.Rows[e.RowIndex].Cells[7].Value.ToString();
            string ticketid = dgvResultados2.Rows[e.RowIndex].Cells[3].Value.ToString();
            Form f1 = new frmEditarEstado();
            frmEditarEstado.f1.Text = "Expediente: " + ticketid;
            frmEditarEstado.f1.lblExpediente.Text = ticketid;
            frmEditarEstado.f1.cmbEstado.Text = statedid.ToString();
           // frmEditarEstado.f1.cmbEstado.DataSource = EstadoDO.ListarEstados(statedid);
            frmEditarEstado.f1.cmbEstado.DataSource = EstadoDO.ListarEstados(statedid);
            frmEditarEstado.f1.cmbEstado.ValueMember = "stateid";
            frmEditarEstado.f1.cmbEstado.DisplayMember = "name";
            
            frmEditarEstado.f1.dgvValues.DataSource = ValuesDO.ListarValues(ticketid);
            frmEditarEstado.f1.dgvValues.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvValues.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvValues.Columns[1].HeaderText = "Ticket";
            frmEditarEstado.f1.dgvValues.Columns[1].Width = 70;
            frmEditarEstado.f1.dgvValues.Columns[2].HeaderText = "Field";
            frmEditarEstado.f1.dgvValues.Columns[2].Width = 200;
            frmEditarEstado.f1.dgvValues.Columns[3].HeaderText = "Value";
            frmEditarEstado.f1.dgvValues.Columns[3].Width = 550;
            frmEditarEstado.f1.dgvValues.Columns[4].HeaderText = "Order";
            frmEditarEstado.f1.dgvValues.Columns[4].Width = 50;

            frmEditarEstado.f1.dgvLog.DataSource = LogDO.ListarLog(ticketid);
            frmEditarEstado.f1.dgvLog.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvLog.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[1].HeaderText = "GUID";
            frmEditarEstado.f1.dgvLog.Columns[1].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[2].HeaderText = "Robot";
            frmEditarEstado.f1.dgvLog.Columns[2].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[3].HeaderText = "StateId";
            frmEditarEstado.f1.dgvLog.Columns[3].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[4].HeaderText = "State";
            frmEditarEstado.f1.dgvLog.Columns[4].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[5].HeaderText = "TicketId";
            frmEditarEstado.f1.dgvLog.Columns[5].Width = 60;
            frmEditarEstado.f1.dgvLog.Columns[6].HeaderText = "Descripción";
            frmEditarEstado.f1.dgvLog.Columns[6].Width = 150;
            frmEditarEstado.f1.dgvLog.Columns[7].HeaderText = "Excepción";
            frmEditarEstado.f1.dgvLog.Columns[7].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[8].HeaderText = "Método";
            frmEditarEstado.f1.dgvLog.Columns[8].Width = 100;
            frmEditarEstado.f1.dgvLog.Columns[8].HeaderText = "Creación";
            frmEditarEstado.f1.dgvLog.Columns[8].Width = 100;

            frmEditarEstado.f1.dgvHist.DataSource = HistoriesDO.ListarHistories(ticketid);
            frmEditarEstado.f1.dgvHist.Columns[0].HeaderText = "Id";
            frmEditarEstado.f1.dgvHist.Columns[0].Width = 60;
            frmEditarEstado.f1.dgvHist.Columns[1].HeaderText = "TicketId";
            frmEditarEstado.f1.dgvHist.Columns[1].Width = 80;
            frmEditarEstado.f1.dgvHist.Columns[2].HeaderText = "Estado";
            frmEditarEstado.f1.dgvHist.Columns[2].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[3].HeaderText = "Usuario";
            frmEditarEstado.f1.dgvHist.Columns[3].Width = 150;
            frmEditarEstado.f1.dgvHist.Columns[4].HeaderText = "RobotGuid";
            frmEditarEstado.f1.dgvHist.Columns[4].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[5].HeaderText = "Robot";
            frmEditarEstado.f1.dgvHist.Columns[5].Width = 200;
            frmEditarEstado.f1.dgvHist.Columns[6].HeaderText = "Acción";
            frmEditarEstado.f1.dgvHist.Columns[6].Width = 150;
            f1.ShowDialog();
        }

        private void txtExpendiente2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string expediente = txtExpediente2.Text;
                //string workflowid = cmbFlujo.ValueMember.ToString();
                if (expediente.Length > 5)
                {
                    timer1.Stop();
                    dgvResultados2.DataSource = TicketDO.ListarTicket(expediente); 
                    cargarGrid2();
                }
                else
                {
                    //dgvResultados.DataSource = TicketDO.ListarTicketWorkFlow(workflowid);
                    timer1.Start();
                    dgvResultados2.DataSource = TicketDO.ListarTicketWorkFlow("8");
                    cargarGrid2();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            
            ListarDataPrestamos();
        }

        private void btnActualizaTar_Click(object sender, EventArgs e)
        {
            ListarDataTarjetas();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

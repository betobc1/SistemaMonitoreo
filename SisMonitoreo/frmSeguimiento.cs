using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using SisMonitoreo.DataAccess;

using Microsoft.Office.Interop;

namespace SisMonitoreo
{
    public partial class frmSeguimiento : Form
    {
        private Paginar p;
        int maximo_x_pagina = 25;
        public frmSeguimiento()
        {
            
            InitializeComponent();
            ListarData();
            cargarGrid();


        }

        private void ActivarControles(bool estado)
        {
            btnActualizar.Enabled = estado;
            btnAnterior.Enabled = estado;
            btnPrimero.Enabled = estado;
            btnSiguiente.Enabled = estado;
            btnUltimo.Enabled = estado;
            cmbMaximoPagina.Enabled = estado;
            lblRegistros.Visible = estado;
            lblNroPagina.Visible = estado;
        }

        //SqlConnection cn = new SqlConnection("Data Source=118.247.29.138\\SQLEXPRESS; Initial Catalog=EES.BBVA.2018v1; User ID = SA; Password=everis@2017;");
        

        private void ListarData()
        {
            try
            {
                
                string query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado','Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                    ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación'   " +
                    ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución'" +
                    ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',convert(varchar(10),tk.[CreationDate],103) as 'FechaCreacion',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                    "WHERE wf.[Id] in (8,9) " + 
                    "ORDER BY tk.id desc ";
                p = new Paginar(query, "DataMember1", maximo_x_pagina);
                dgvResultados.DataSource = p.cargar();
                dgvResultados.DataMember = "datamember1";
                actualizar();
                
                /*
                SqlCommand cmd = new SqlCommand("SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado','Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                    ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación'   " +
                    ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución'" +
                    ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                    "WHERE wf.[Id] in (8,9) AND CAST(tk.[CreationDate] AS DATE) = CAST('2018-08-20' AS DATE) ORDER BY tk.id desc ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(0,5,dt);
                dgvResultados.DataSource = dt;
                cargarGrid();
                cn.Close();
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ListarDataxFecha(string Inicio, string Fin )
        {
            //String Inicio = dtpInicio.Value.ToString("yyyy-mm-dd");
            //String Fin = dtpFin.Value.ToString("yyyy-mm-dd");


            // String ejempl = Convert.dt


            try
            {


                string query = "SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado','Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                    ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación'   " +
                    ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución'" +
                    ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',convert(varchar(10),tk.[CreationDate],103) as 'FechaCreacion',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                    "WHERE wf.[Id] in (8,9) and " +
                   "CONVERT(date, tk.CreationDate) between convert(date,'"+Inicio+ "')  and convert(date,'" + Fin+"') " +
                    "ORDER BY tk.id desc ";

                p = new Paginar(query, "DataMember1", maximo_x_pagina);
                dgvResultados.DataSource = p.cargar();
                dgvResultados.DataMember = "datamember1";
                actualizar();

              

                /*
                SqlCommand cmd = new SqlCommand("SELECT wf.[Name] as 'WorkFlow', (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado','Tarea: ' as 'Ticket',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name],tk.[StateId],tk.[ParentId],tk.[UserId],tk.[RobotVirtualMachineId]" +
                    ",case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación'   " +
                    ",concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución'" +
                    ",tv.[Value] as 'Error',convert(varchar(20),dateadd(hour,-5, tk.[CreationDate]), 100) as 'CreationDate',convert(varchar(20),dateadd(hour,-5, tk.[LastModified]), 100) as 'LastModified',tk.[Priority] FROM [EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN [EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN [EES.BBVA.2018v1].[dbo].[Workflows] wf on wf.[Id] = st.[WorkflowId] LEFT JOIN [EES.BBVA.2018v1].[dbo].[TicketValues] tv on (tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                    "WHERE wf.[Id] in (8,9) AND CAST(tk.[CreationDate] AS DATE) = CAST('2018-08-20' AS DATE) ORDER BY tk.id desc ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(0,5,dt);
                dgvResultados.DataSource = dt;
                cargarGrid();
                cn.Close();
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvResultados.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvResultados.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvResultados.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvResultados.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        //private void PopulateRows()
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        DataGridViewRow row =
        //            (DataGridViewRow)dgvResultados.RowTemplate.Clone();

        //        row.CreateCells(dgvResultados, string.Format("City{0}", i),
        //            string.Format("State{0}", i), string.Format("Country{0}", i));

        //        dgvResultados.Rows.Add(row);

        //    }
        //}
        private void actualizar()
        {
            lblRegistros.Text = "Hay " + p.countRow().ToString() + " Registros";
            lblNroPagina.Text = "Página " + p.numPag().ToString() + " de " + p.countPag().ToString();
            cmbMaximoPagina.Text = p.limitRow().ToString();
        }

        private void cargarGrid()
        {
            dgvResultados.Columns[0].HeaderText = "Flujo";
            dgvResultados.Columns[0].Width = 150;
            dgvResultados.Columns[1].HeaderText = "Último Estado";
            dgvResultados.Columns[1].Width = 50;
            dgvResultados.Columns[2].HeaderText = "Ticket";
            dgvResultados.Columns[2].Width = 50;
            dgvResultados.Columns[3].HeaderText = "ID";
            dgvResultados.Columns[3].Width = 50;
            dgvResultados.Columns[4].HeaderText = "Exp";
            dgvResultados.Columns[4].Width = 60;
            dgvResultados.Columns[5].HeaderText = "Descripción";
            dgvResultados.Columns[5].Width = 80;
            dgvResultados.Columns[6].HeaderText = "Estado";
            dgvResultados.Columns[6].Width = 290;
            dgvResultados.Columns[7].HeaderText = "StateID";
            dgvResultados.Columns[7].Width = 50;
            dgvResultados.Columns[8].HeaderText = "ParentID";
            dgvResultados.Columns[8].Width = 60;
            dgvResultados.Columns[9].HeaderText = "UserId";
            dgvResultados.Columns[9].Width = 40;
            dgvResultados.Columns[10].HeaderText = "GUID";
            dgvResultados.Columns[10].Width = 40;
            dgvResultados.Columns[11].HeaderText = "Creación";
            dgvResultados.Columns[11].Width = 60;
            dgvResultados.Columns[12].HeaderText = "Ejecución";
            dgvResultados.Columns[12].Width = 60;
            dgvResultados.Columns[13].HeaderText = "Mensaje";
            dgvResultados.Columns[13].Width = 100;
            dgvResultados.Columns[14].HeaderText = "Creación";
            dgvResultados.Columns[14].Width = 120;
            dgvResultados.Columns[15].HeaderText = "Modificación";
            dgvResultados.Columns[15].Width = 120;
            dgvResultados.Columns[16].HeaderText = "Fecha de Creación";
            dgvResultados.Columns[16].Width = 90;
            dgvResultados.Columns[17].HeaderText = "Prioridad";
            dgvResultados.Columns[17].Width = 60;
            try
            {
                int tam = Convert.ToInt32(dgvResultados.RowCount.ToString());
                for (int i = 0; i < tam-1; i++)
                {
                    
                  


                    string valor = dgvResultados.Rows[i].Cells[11].Value.ToString();
                    int hora = int.Parse(valor.Split(':')[0]);
                    int stateid = Convert.ToInt32(dgvResultados.Rows[i].Cells[7].Value.ToString());

                    if ((stateid == 1061) || (stateid == 1135))
                    {
                        dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        if (hora < 30)
                        {
                            dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        if ((hora >= 30) && (hora <= 60))
                        {
                            dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        if (hora > 60)
                        {
                            dgvResultados.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgvResultados.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }


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
            ListarData();
            actualizar();
            timer1.Start();
        }

        private void txtExpediente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(txtBusqueda.Text.Length));
                if (txtExpediente.Text.Length > 0)
                {
                    /*dgvCliente.DataSource = ClienteDO.ListarCliente(txtBusqueda.Text);
                    CargarGrid();*/
                    bool estado = false;
                    ActivarControles(estado);
                }
                else
                {
                    ListarData();
                    bool estado = true;
                    ActivarControles(estado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            p.actualizaTope(Convert.ToInt32(cmbMaximoPagina.Text));
            actualizar();
        }

        private void btnPrimero_Click_1(object sender, EventArgs e)
        {
            p.primeraPagina();
            actualizar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            p.atras();
            actualizar();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            p.adelante();
            actualizar();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            p.ultimaPagina();
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //p.actualizaTope(Convert.ToInt32(cmbMaximoPagina.Text));
            if (DateTime.Compare(dtpInicio.Value.Date, dtpFin.Value.Date) > 0)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin");
        
                dtpInicio.Focus();
                return;
            }
            //String Inicio = dtpInicio.Value.ToString("yyyy-mm-dd");
            //MessageBox.Show(Inicio);
            ///*   String Inicio = dtpInicio.Value.ToString("dd/MM*//yyyy");
            //   MessageBox.Show("La fecha es :" + Inicio);
            String Inicio = dtpInicio.Value.ToString("yyyy-MM-dd");
            //String Fin = dtpFin.Value.Date.ToShortDateString();
            String Fin = dtpFin.Value.ToString("yyyy-MM-dd");

           // MessageBox.Show("La fecha es: " + Inicio + " La fecha es: " + Fin);

            ListarDataxFecha(Inicio, Fin);

            //DataTable dt = (DataTable)dgvResultados.DataSource;
            //DataView dv = new DataView();
            //dv = dt.DefaultView;
            //dv.RowFilter = "dob >= '" + dtpInicio.Value.Date + "' and  dob <= '" + dtpFin.Value.Date + "'";
            ////String Inicio= dtpInicio.("yyyy-MM-dd hh:mm:ss")


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}

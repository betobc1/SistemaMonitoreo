using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisMonitoreo.DataAccess;
using SisMonitoreo.Domain;
using Microsoft.Office.Interop;
using System.Data.SqlClient;
using System.Windows;
using System.Web;
namespace SisMonitoreo
{
    public partial class frmReportes : Form
    {
        public static frmReportes f1;
        public frmReportes()
        {
            frmReportes.f1 = this;
            InitializeComponent();
            

        }
        //Métodos
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
                for (int i = 0; i < dgvReporte.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvReporte.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvReporte.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvReporte.Rows[i].Cells[j].Value.ToString();
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

        public static List<Entities.Reporte> ListarData(string Inicio, string Fin, string Tipo, string Estado)
        {
            var lista = new List<Entities.Reporte>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                if (Tipo == "" && Estado == "")
                {
                    string query = "SELECT wf.[Name] as 'WorkFlow' , (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name] as 'Estado Actual',tk.[StateId] " +
                    "  ,case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación' " +
                    "  ,concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución' " +
                    " ,convert(varchar(10), tk.[CreationDate], 103) as 'FechaCreacion' FROM[EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN[EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN[EES.BBVA.2018v1].[dbo].[Workflows] " +
                      " wf on wf.[Id] = st.[WorkflowId] LEFT JOIN[EES.BBVA.2018v1].[dbo].[TicketValues] " +
                      " tv on(tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                     " WHERE wf.[Id] in (8,9) and " +

                    " CONVERT(date, tk.CreationDate) between convert(date,'" + Inicio + "')  and convert(date,'" + Fin + "') --and " +
                     "--wf.[Name] = '" + Tipo + "'  " +
                     " --st.[Name] = '" + Estado + "' " +
                     " ORDER BY tk.id desc";
                    using (var cmd = new SqlCommand(query, cn))
                    {
                        cn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var oTicket = new Entities.Reporte();
                                oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                                oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                                oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                                oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                                oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                                oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Estado Actual")]);
                                oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                                oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Creación")]);
                                oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecución")]);
                                oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("FechaCreacion")]);

                                lista.Add(oTicket);
                            }
                        }
                        return lista;
                    }
                }
                else
                {
                    if (Tipo != "" && Estado == "")
                    {
                        string query = "SELECT wf.[Name] as 'WorkFlow' , (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name] as 'Estado Actual',tk.[StateId] " +
                           "  ,case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación' " +
                           "  ,concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución' " +
                           " ,convert(varchar(10), tk.[CreationDate], 103) as 'FechaCreacion' FROM[EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN[EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN[EES.BBVA.2018v1].[dbo].[Workflows] " +
                             " wf on wf.[Id] = st.[WorkflowId] LEFT JOIN[EES.BBVA.2018v1].[dbo].[TicketValues] " +
                             " tv on(tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                            " WHERE wf.[Id] in (8,9) and " +

                           " CONVERT(date, tk.CreationDate) between convert(date,'" + Inicio + "')  and convert(date,'" + Fin + "') and " +
                            "wf.[Name] = '" + Tipo + "' -- and " +
                            " --st.[Name] = '" + Estado + "' " +
                            " ORDER BY tk.id desc";
                        using (var cmd = new SqlCommand(query, cn))
                        {
                            cn.Open();
                            using (var dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    var oTicket = new Entities.Reporte();
                                    oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                                    oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                                    oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                                    oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                                    oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                                    oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Estado Actual")]);
                                    oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                                    oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Creación")]);
                                    oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecución")]);
                                    oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("FechaCreacion")]);

                                    lista.Add(oTicket);
                                }
                            }
                            return lista;
                        }
                    }
                    else
                    {
                        string query = "SELECT wf.[Name] as 'WorkFlow' , (SELECT [Name] FROM [EES.BBVA.2018v1].[dbo].[States] WHERE [Id] = (SELECT [StateId] FROM [EES.BBVA.2018v1].[dbo].[StateActions] WHERE [Id] = (SELECT [StateActionId] FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] WHERE [Id] = (SELECT MAX(th.[Id]) FROM [EES.BBVA.2018v1].[dbo].[TicketHistories] th WHERE th.[TicketId] = tk.[Id] AND th.[HistoryType] = 2)))) as 'Ultimo Estado',tk.[Id],'Exped: ' as 'Exp',tk.[Description],st.[Name] as 'Estado Actual',tk.[StateId] " +
                           "  ,case when((tk.StateId = 1061) or(tk.StateId = 1135))  then concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), dateadd(hour, -5, tk.[LastModified])) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), dateadd(hour, -5, tk.[LastModified])) % 60) Else concat(datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[CreationDate]), getdate()) % 60) End as 'Creación' " +
                           "  ,concat(datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) / 60, ':', datediff(SECOND, dateadd(hour, -5, tk.[LastModified]), getdate()) % 60) as 'Ejecución' " +
                           " ,convert(varchar(10), tk.[CreationDate], 103) as 'FechaCreacion' FROM[EES.BBVA.2018v1].[dbo].[Tickets] tk INNER JOIN[EES.BBVA.2018v1].[dbo].[States] st on st.[Id] = tk.[StateId] INNER JOIN[EES.BBVA.2018v1].[dbo].[Workflows] " +
                             " wf on wf.[Id] = st.[WorkflowId] LEFT JOIN[EES.BBVA.2018v1].[dbo].[TicketValues] " +
                             " tv on(tv.[TicketId] = tk.[Id] AND tv.[FieldId] = 34) " +
                            " WHERE wf.[Id] in (8,9) and " +

                           " CONVERT(date, tk.CreationDate) between convert(date,'" + Inicio + "')  and convert(date,'" + Fin + "') and " +
                            "wf.[Name] = '" + Tipo + "'  and " +
                            " st.[Name] = '" + Estado + "' " +
                            " ORDER BY tk.id desc";
                        using (var cmd = new SqlCommand(query, cn))
                        {
                            cn.Open();
                            using (var dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    var oTicket = new Entities.Reporte();
                                    oTicket.flujo = Convert.ToString(dr[dr.GetOrdinal("WorkFlow")]);
                                    oTicket.ultimo_estado = Convert.ToString(dr[dr.GetOrdinal("Ultimo Estado")]);
                                    oTicket.id = Convert.ToString(dr[dr.GetOrdinal("Id")]);
                                    oTicket.exp = Convert.ToString(dr[dr.GetOrdinal("Exp")]);
                                    oTicket.descripcion = Convert.ToString(dr[dr.GetOrdinal("Description")]);
                                    oTicket.estado = Convert.ToString(dr[dr.GetOrdinal("Estado Actual")]);
                                    oTicket.stateid = Convert.ToString(dr[dr.GetOrdinal("StateId")]);
                                    oTicket.inicio = Convert.ToString(dr[dr.GetOrdinal("Creación")]);
                                    oTicket.ejecucion = Convert.ToString(dr[dr.GetOrdinal("Ejecución")]);
                                    oTicket.creacion = Convert.ToString(dr[dr.GetOrdinal("FechaCreacion")]);

                                    lista.Add(oTicket);
                                }
                            }
                            return lista;
                        }
                    }
                }
            }
        }

        private void cargarGrid()
        {
            dgvReporte.Columns[0].HeaderText = "Flujo";
            dgvReporte.Columns[0].Width = 150;
            dgvReporte.Columns[1].HeaderText = "Último Estado";
            dgvReporte.Columns[1].Width = 290;
            dgvReporte.Columns[2].HeaderText = "ID";
            dgvReporte.Columns[2].Width = 50;
            dgvReporte.Columns[3].HeaderText = "Exp";
            dgvReporte.Columns[3].Width = 60;
            dgvReporte.Columns[4].HeaderText = "Descripción";
            dgvReporte.Columns[4].Width = 80;
            dgvReporte.Columns[5].HeaderText = "Estado Actual";
            dgvReporte.Columns[5].Width = 290;
            dgvReporte.Columns[6].HeaderText = "StateID";
            dgvReporte.Columns[6].Width = 50;
            dgvReporte.Columns[7].HeaderText = "Creación";
            dgvReporte.Columns[7].Width = 60;
            dgvReporte.Columns[8].HeaderText = "Ejecución";
            dgvReporte.Columns[8].Width = 60;         
            dgvReporte.Columns[9].HeaderText = "Fecha de Creación";
            dgvReporte.Columns[9].Width = 90;



           
           

        }

        private void ValidarFechas()
        {
            if (DateTime.Compare(dtpDesde.Value.Date, dtpHasta.Value.Date) > 0)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin");

                dtpDesde.Focus();
                return;
            }
        }

        public static List<Entities.Estados> ListarEstados(string flujo)
        {
            var lista = new List<Entities.Estados>();
            using (var cn = new SqlConnection(conexion.Cadena))
            {
                using (var cmd = new SqlCommand(//"select id as stateid,name from [EES.BBVA.2018v1].dbo.States where workflowid = " + flujo, cn))
                    "select 1000 as stateid, '' as name from[EES.BBVA.2018v1].[dbo].[States] union select id as stateid,name from[EES.BBVA.2018v1].dbo.States where workflowid = "+ flujo, cn))
                         {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oEstado = new Entities.Estados();
                            oEstado.stateid = Convert.ToString(dr[dr.GetOrdinal("stateid")]);
                            oEstado.name = Convert.ToString(dr[dr.GetOrdinal("name")]);
                            lista.Add(oEstado);
                        }
                    }
                    return lista;
                }
            }

        }
        //EVentos
        private void button1_Click(object sender, EventArgs e)
        {
            String tipo = cmbTipo.Text;

            String Inicio = dtpDesde.Value.ToString("yyyy-MM-dd");
            String Fin = dtpHasta.Value.ToString("yyyy-MM-dd");
            ValidarFechas();
            String estado = cmbEstado.Text;
            
            dgvReporte.DataSource = ListarData(Inicio, Fin, tipo, estado);
            cargarGrid();



        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void dgvReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tipo = cmbTipo.Text;
            String flujo = "";
            if (tipo == "CT - FM | Tarjeta de Crédito")
            {
                flujo = "9";
            }
            else
            {

                if (tipo == "CT - FM | Prestamos")
                {
                    flujo = "8";
                }
            }

            
            cmbEstado.DataSource = ListarEstados(flujo);
            cmbEstado.ValueMember = "stateid";
            cmbEstado.DisplayMember = "name";
           
        }
    }
}

namespace SisMonitoreo
{
    partial class frmDiario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._EES_BBVA_2018v1DataSet = new SisMonitoreo._EES_BBVA_2018v1DataSet();
            this.workflowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workflowsTableAdapter = new SisMonitoreo._EES_BBVA_2018v1DataSetTableAdapters.WorkflowsTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExpediente2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvResultados2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbNavegar = new System.Windows.Forms.GroupBox();
            this.txtExpediente = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnActualizaPtest = new System.Windows.Forms.Button();
            this.btnActualizaTar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._EES_BBVA_2018v1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workflowsBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbNavegar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _EES_BBVA_2018v1DataSet
            // 
            this._EES_BBVA_2018v1DataSet.DataSetName = "_EES_BBVA_2018v1DataSet";
            this._EES_BBVA_2018v1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // workflowsBindingSource
            // 
            this.workflowsBindingSource.DataMember = "Workflows";
            this.workflowsBindingSource.DataSource = this._EES_BBVA_2018v1DataSet;
            // 
            // workflowsTableAdapter
            // 
            this.workflowsTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1596, 601);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1588, 575);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Prestamos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1582, 569);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.btnActualizaPtest);
            this.groupBox2.Controls.Add(this.txtExpediente2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1590, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // txtExpediente2
            // 
            this.txtExpediente2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpediente2.Location = new System.Drawing.Point(87, 13);
            this.txtExpediente2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExpediente2.Name = "txtExpediente2";
            this.txtExpediente2.Size = new System.Drawing.Size(178, 23);
            this.txtExpediente2.TabIndex = 6;
            this.txtExpediente2.TextChanged += new System.EventHandler(this.txtExpendiente2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Expediente:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvResultados2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox3.Size = new System.Drawing.Size(1590, 541);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registros";
            // 
            // dgvResultados2
            // 
            this.dgvResultados2.AllowUserToAddRows = false;
            this.dgvResultados2.AllowUserToDeleteRows = false;
            this.dgvResultados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados2.Location = new System.Drawing.Point(12, 25);
            this.dgvResultados2.Name = "dgvResultados2";
            this.dgvResultados2.ReadOnly = true;
            this.dgvResultados2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResultados2.Size = new System.Drawing.Size(1566, 504);
            this.dgvResultados2.TabIndex = 0;
            this.dgvResultados2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados2_CellContentClick);
            this.dgvResultados2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados2_CellContentDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1588, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tarjetas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.gbNavegar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1582, 569);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // gbNavegar
            // 
            this.gbNavegar.Controls.Add(this.label2);
            this.gbNavegar.Controls.Add(this.textBox3);
            this.gbNavegar.Controls.Add(this.textBox2);
            this.gbNavegar.Controls.Add(this.textBox1);
            this.gbNavegar.Controls.Add(this.btnActualizaTar);
            this.gbNavegar.Controls.Add(this.txtExpediente);
            this.gbNavegar.Controls.Add(this.lblRegistros);
            this.gbNavegar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNavegar.Location = new System.Drawing.Point(3, 2);
            this.gbNavegar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNavegar.Name = "gbNavegar";
            this.gbNavegar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNavegar.Size = new System.Drawing.Size(1590, 50);
            this.gbNavegar.TabIndex = 5;
            this.gbNavegar.TabStop = false;
            // 
            // txtExpediente
            // 
            this.txtExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpediente.Location = new System.Drawing.Point(87, 13);
            this.txtExpediente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.Size = new System.Drawing.Size(178, 23);
            this.txtExpediente.TabIndex = 6;
            this.txtExpediente.TextChanged += new System.EventHandler(this.txtExpediente_TextChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(9, 18);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(74, 13);
            this.lblRegistros.TabIndex = 12;
            this.lblRegistros.Text = "Expediente:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvResultados);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(1590, 541);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registros";
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados.Location = new System.Drawing.Point(12, 25);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResultados.Size = new System.Drawing.Size(1566, 504);
            this.dgvResultados.TabIndex = 0;
            this.dgvResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellContentClick);
            this.dgvResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellDoubleClick);
            this.dgvResultados.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvResultados_Scroll);
            // 
            // btnActualizaPtest
            // 
            this.btnActualizaPtest.Location = new System.Drawing.Point(1499, 13);
            this.btnActualizaPtest.Name = "btnActualizaPtest";
            this.btnActualizaPtest.Size = new System.Drawing.Size(75, 23);
            this.btnActualizaPtest.TabIndex = 13;
            this.btnActualizaPtest.Text = "Actualizar";
            this.btnActualizaPtest.UseVisualStyleBackColor = true;
            this.btnActualizaPtest.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // btnActualizaTar
            // 
            this.btnActualizaTar.Location = new System.Drawing.Point(1501, 13);
            this.btnActualizaTar.Name = "btnActualizaTar";
            this.btnActualizaTar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizaTar.TabIndex = 13;
            this.btnActualizaTar.Text = "Actualiza";
            this.btnActualizaTar.UseVisualStyleBackColor = true;
            this.btnActualizaTar.Click += new System.EventHandler(this.btnActualizaTar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1071, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tiempo de Expediente:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(1388, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = ">60min";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.Location = new System.Drawing.Point(1291, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(91, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = ">30min y <60min";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Green;
            this.textBox3.Location = new System.Drawing.Point(1193, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(91, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "<30min";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1078, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tiempo de Expediente:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Green;
            this.textBox4.Location = new System.Drawing.Point(1200, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(91, 20);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "<30min";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Yellow;
            this.textBox5.Location = new System.Drawing.Point(1298, 15);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(91, 20);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = ">30min y <60min";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Red;
            this.textBox6.Location = new System.Drawing.Point(1395, 15);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(91, 20);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = ">60min";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 601);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDiario";
            this.Text = "Seguimiento Diario";
            this.Load += new System.EventHandler(this.frmDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this._EES_BBVA_2018v1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workflowsBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbNavegar.ResumeLayout(false);
            this.gbNavegar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private _EES_BBVA_2018v1DataSet _EES_BBVA_2018v1DataSet;
        private System.Windows.Forms.BindingSource workflowsBindingSource;
        private _EES_BBVA_2018v1DataSetTableAdapters.WorkflowsTableAdapter workflowsTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExpediente2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvResultados2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbNavegar;
        private System.Windows.Forms.TextBox txtExpediente;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnActualizaPtest;
        private System.Windows.Forms.Button btnActualizaTar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}
namespace QLVT_PT
{
    partial class formDonDatHangChuaNhap
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
            System.Windows.Forms.Label masoDDHLabel;
            System.Windows.Forms.Label mAKHOLabel;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            this.bdsDDHChuaNhap = new System.Windows.Forms.BindingSource(this.components);
            this.DS1 = new QLVT_PT.DS1();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cTDDHDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsCTDDHChuaNhap = new System.Windows.Forms.BindingSource(this.components);
            this.dDHChuaNhapGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dDHChuaNhapTableAdapter = new QLVT_PT.DS1TableAdapters.DDHChuaNhapTableAdapter();
            this.tableAdapterManager = new QLVT_PT.DS1TableAdapters.TableAdapterManager();
            this.cTDDHTableAdapter = new QLVT_PT.DS1TableAdapters.CTDDHTableAdapter();
            this.txtMAKHO = new System.Windows.Forms.TextBox();
            masoDDHLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDDHChuaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTDDHDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDHChuaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDHChuaNhapGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // masoDDHLabel
            // 
            masoDDHLabel.AutoSize = true;
            masoDDHLabel.Location = new System.Drawing.Point(19, 24);
            masoDDHLabel.Name = "masoDDHLabel";
            masoDDHLabel.Size = new System.Drawing.Size(86, 16);
            masoDDHLabel.TabIndex = 2;
            masoDDHLabel.Text = "Mã đơn hàng:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.cTDDHDataGridView);
            this.panelControl1.Controls.Add(this.dDHChuaNhapGridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(843, 539);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(mAKHOLabel);
            this.panelControl2.Controls.Add(this.txtMAKHO);
            this.panelControl2.Controls.Add(masoDDHLabel);
            this.panelControl2.Controls.Add(this.txtMaDDH);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(578, 222);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(263, 315);
            this.panelControl2.TabIndex = 2;
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDDHChuaNhap, "MasoDDH", true));
            this.txtMaDDH.Location = new System.Drawing.Point(135, 21);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.Size = new System.Drawing.Size(100, 23);
            this.txtMaDDH.TabIndex = 3;
            // 
            // bdsDDHChuaNhap
            // 
            this.bdsDDHChuaNhap.DataMember = "DDHChuaNhap";
            this.bdsDDHChuaNhap.DataSource = this.DS1;
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(80, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(178, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cTDDHDataGridView
            // 
            this.cTDDHDataGridView.AutoGenerateColumns = false;
            this.cTDDHDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cTDDHDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.cTDDHDataGridView.DataSource = this.bdsCTDDHChuaNhap;
            this.cTDDHDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.cTDDHDataGridView.Location = new System.Drawing.Point(2, 222);
            this.cTDDHDataGridView.Name = "cTDDHDataGridView";
            this.cTDDHDataGridView.RowHeadersWidth = 51;
            this.cTDDHDataGridView.RowTemplate.Height = 24;
            this.cTDDHDataGridView.Size = new System.Drawing.Size(576, 315);
            this.cTDDHDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MasoDDH";
            this.dataGridViewTextBoxColumn1.HeaderText = "MasoDDH";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MAVT";
            this.dataGridViewTextBoxColumn2.HeaderText = "MAVT";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SOLUONG";
            this.dataGridViewTextBoxColumn3.HeaderText = "SOLUONG";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DONGIA";
            this.dataGridViewTextBoxColumn4.HeaderText = "DONGIA";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // bdsCTDDHChuaNhap
            // 
            this.bdsCTDDHChuaNhap.DataMember = "FK_CTDDH_DatHang1";
            this.bdsCTDDHChuaNhap.DataSource = this.bdsDDHChuaNhap;
            // 
            // dDHChuaNhapGridControl
            // 
            this.dDHChuaNhapGridControl.DataSource = this.bdsDDHChuaNhap;
            this.dDHChuaNhapGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.dDHChuaNhapGridControl.Location = new System.Drawing.Point(2, 2);
            this.dDHChuaNhapGridControl.MainView = this.gridView1;
            this.dDHChuaNhapGridControl.Name = "dDHChuaNhapGridControl";
            this.dDHChuaNhapGridControl.Size = new System.Drawing.Size(839, 220);
            this.dDHChuaNhapGridControl.TabIndex = 0;
            this.dDHChuaNhapGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH,
            this.colNGAY,
            this.colNhaCC,
            this.colMANV,
            this.colMAKHO});
            this.gridView1.GridControl = this.dDHChuaNhapGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colMasoDDH
            // 
            this.colMasoDDH.FieldName = "MasoDDH";
            this.colMasoDDH.MinWidth = 25;
            this.colMasoDDH.Name = "colMasoDDH";
            this.colMasoDDH.Visible = true;
            this.colMasoDDH.VisibleIndex = 0;
            this.colMasoDDH.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colNhaCC
            // 
            this.colNhaCC.FieldName = "NhaCC";
            this.colNhaCC.MinWidth = 25;
            this.colNhaCC.Name = "colNhaCC";
            this.colNhaCC.Visible = true;
            this.colNhaCC.VisibleIndex = 2;
            this.colNhaCC.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 25;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            this.colMAKHO.Width = 94;
            // 
            // dDHChuaNhapTableAdapter
            // 
            this.dDHChuaNhapTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = this.cTDDHTableAdapter;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.DDHChuaNhapTableAdapter = this.dDHChuaNhapTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_PT.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(52, 79);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(53, 16);
            mAKHOLabel.TabIndex = 4;
            mAKHOLabel.Text = "Mã kho:";
            // 
            // txtMAKHO
            // 
            this.txtMAKHO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDDHChuaNhap, "MAKHO", true));
            this.txtMAKHO.Location = new System.Drawing.Point(135, 76);
            this.txtMAKHO.Name = "txtMAKHO";
            this.txtMAKHO.Size = new System.Drawing.Size(100, 23);
            this.txtMAKHO.TabIndex = 5;
            // 
            // formDonDatHangChuaNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 539);
            this.Controls.Add(this.panelControl1);
            this.Name = "formDonDatHangChuaNhap";
            this.Text = "Chọn đơn đặt";
            this.Load += new System.EventHandler(this.formDonDatHangChuaNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDDHChuaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTDDHDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDHChuaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDHChuaNhapGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DS1 DS1;
        private System.Windows.Forms.BindingSource bdsDDHChuaNhap;
        private DS1TableAdapters.DDHChuaNhapTableAdapter dDHChuaNhapTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl dDHChuaNhapGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DS1TableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTDDHChuaNhap;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView cTDDHDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtMaDDH;
        private System.Windows.Forms.TextBox txtMAKHO;
    }
}
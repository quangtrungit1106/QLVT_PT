namespace QLVT_PT
{
    partial class formPhieuXuat
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
            System.Windows.Forms.Label MAPXLabel;
            System.Windows.Forms.Label nGAYLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label tENKHOLabel;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label dONGIALabel;
            System.Windows.Forms.Label mAVTLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPhieuXuat));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenChiNhanh = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS1 = new QLVT_PT.DS1();
            this.bdsPhieuXuat = new System.Windows.Forms.BindingSource(this.components);
            this.PhieuXuatTableAdapter = new QLVT_PT.DS1TableAdapters.PhieuXuatTableAdapter();
            this.tableAdapterManager = new QLVT_PT.DS1TableAdapters.TableAdapterManager();
            this.cTPXTableAdapter = new QLVT_PT.DS1TableAdapters.CTPXTableAdapter();
            this.bdsCTPX = new System.Windows.Forms.BindingSource(this.components);
            this.gcPhieuXuat = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVattuCTPX = new System.Windows.Forms.ComboBox();
            this.bdsVattu = new System.Windows.Forms.BindingSource(this.components);
            this.txtMAVT = new System.Windows.Forms.TextBox();
            this.txtDONGIA = new DevExpress.XtraEditors.TextEdit();
            this.txtSOLUONG = new DevExpress.XtraEditors.TextEdit();
            this.lbHOTENKH1 = new System.Windows.Forms.Label();
            this.cmbTenKho = new System.Windows.Forms.ComboBox();
            this.bdsDSKHO = new System.Windows.Forms.BindingSource(this.components);
            this.txtHOTENKH = new System.Windows.Forms.TextBox();
            this.cmbNhanVienNhap = new System.Windows.Forms.ComboBox();
            this.bdsDSNV = new System.Windows.Forms.BindingSource(this.components);
            this.txtMAKHO = new System.Windows.Forms.TextBox();
            this.txtMANV = new System.Windows.Forms.TextBox();
            this.dtNGAY = new DevExpress.XtraEditors.DateEdit();
            this.txtMAPX = new System.Windows.Forms.TextBox();
            this.dgvCTPX = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vattuTableAdapter = new QLVT_PT.DS1TableAdapters.VattuTableAdapter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGhiVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndoVT = new System.Windows.Forms.ToolStripMenuItem();
            this.dSNVTableAdapter = new QLVT_PT.DS1TableAdapters.DSNVTableAdapter();
            this.dSKHOTableAdapter = new QLVT_PT.DS1TableAdapters.DSKHOTableAdapter();
            this.btnSuaVT = new System.Windows.Forms.ToolStripMenuItem();
            MAPXLabel = new System.Windows.Forms.Label();
            nGAYLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            hOTENLabel = new System.Windows.Forms.Label();
            tENKHOLabel = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            dONGIALabel = new System.Windows.Forms.Label();
            mAVTLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVattu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDONGIA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSKHO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNGAY.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNGAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPX)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MAPXLabel
            // 
            MAPXLabel.AutoSize = true;
            MAPXLabel.Location = new System.Drawing.Point(12, 23);
            MAPXLabel.Name = "MAPXLabel";
            MAPXLabel.Size = new System.Drawing.Size(91, 16);
            MAPXLabel.TabIndex = 0;
            MAPXLabel.Text = "Mã Phiếu Xuất";
            // 
            // nGAYLabel
            // 
            nGAYLabel.AutoSize = true;
            nGAYLabel.Location = new System.Drawing.Point(36, 64);
            nGAYLabel.Name = "nGAYLabel";
            nGAYLabel.Size = new System.Drawing.Size(67, 16);
            nGAYLabel.TabIndex = 2;
            nGAYLabel.Text = "Ngày nhập";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(490, 110);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(83, 16);
            mANVLabel.TabIndex = 6;
            mANVLabel.Text = "Mã nhân viên";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(525, 161);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(48, 16);
            mAKHOLabel.TabIndex = 8;
            mAKHOLabel.Text = "Mã kho";
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(8, 110);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(95, 16);
            hOTENLabel.TabIndex = 10;
            hOTENLabel.Text = "Nhân viên nhập";
            // 
            // tENKHOLabel
            // 
            tENKHOLabel.AutoSize = true;
            tENKHOLabel.Location = new System.Drawing.Point(50, 161);
            tENKHOLabel.Name = "tENKHOLabel";
            tENKHOLabel.Size = new System.Drawing.Size(53, 16);
            tENKHOLabel.TabIndex = 15;
            tENKHOLabel.Text = "Tên kho";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Location = new System.Drawing.Point(45, 250);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(58, 16);
            sOLUONGLabel.TabIndex = 19;
            sOLUONGLabel.Text = "Số lượng";
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Location = new System.Drawing.Point(490, 250);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(51, 16);
            dONGIALabel.TabIndex = 20;
            dONGIALabel.Text = "Đơn giá";
            // 
            // mAVTLabel1
            // 
            mAVTLabel1.AutoSize = true;
            mAVTLabel1.Location = new System.Drawing.Point(512, 212);
            mAVTLabel1.Name = "mAVTLabel1";
            mAVTLabel1.Size = new System.Drawing.Size(61, 16);
            mAVTLabel1.TabIndex = 21;
            mAVTLabel1.Text = "Mã vật tư";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnGhi,
            this.btnUndo,
            this.btnReload,
            this.btnThoat,
            this.btnChuyenChiNhanh});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 10;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 0);
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 11;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(60, 0);
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 12;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.LargeImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(60, 0);
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 13;
            this.btnGhi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.Image")));
            this.btnGhi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.LargeImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(60, 0);
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 14;
            this.btnUndo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.Image")));
            this.btnUndo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.LargeImage")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(70, 0);
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 15;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.LargeImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(80, 0);
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 16;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1516, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 672);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1516, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 621);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1516, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 621);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Hiệu chỉnh";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 9;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnChuyenChiNhanh
            // 
            this.btnChuyenChiNhanh.Caption = "Chuyển chi nhánh";
            this.btnChuyenChiNhanh.Id = 17;
            this.btnChuyenChiNhanh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChuyenChiNhanh.ImageOptions.Image")));
            this.btnChuyenChiNhanh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChuyenChiNhanh.ImageOptions.LargeImage")));
            this.btnChuyenChiNhanh.Name = "btnChuyenChiNhanh";
            this.btnChuyenChiNhanh.Size = new System.Drawing.Size(120, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbChiNhanh);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 51);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1516, 100);
            this.panelControl1.TabIndex = 5;
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(265, 36);
            this.cmbChiNhanh.Margin = new System.Windows.Forms.Padding(5);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(369, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsPhieuXuat
            // 
            this.bdsPhieuXuat.DataMember = "PhieuXuat";
            this.bdsPhieuXuat.DataSource = this.DS1;
            // 
            // PhieuXuatTableAdapter
            // 
            this.PhieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = this.cTPXTableAdapter;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.DDHChuaNhapTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = this.PhieuXuatTableAdapter;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_PT.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cTPXTableAdapter
            // 
            this.cTPXTableAdapter.ClearBeforeFill = true;
            // 
            // bdsCTPX
            // 
            this.bdsCTPX.DataMember = "FK_CTPX_PX";
            this.bdsCTPX.DataSource = this.bdsPhieuXuat;
            // 
            // gcPhieuXuat
            // 
            this.gcPhieuXuat.DataSource = this.bdsPhieuXuat;
            this.gcPhieuXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPhieuXuat.Location = new System.Drawing.Point(0, 151);
            this.gcPhieuXuat.MainView = this.gridView1;
            this.gcPhieuXuat.MenuManager = this.barManager1;
            this.gcPhieuXuat.Name = "gcPhieuXuat";
            this.gcPhieuXuat.Size = new System.Drawing.Size(1516, 220);
            this.gcPhieuXuat.TabIndex = 11;
            this.gcPhieuXuat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcPhieuXuat.Click += new System.EventHandler(this.gcPhieuXuat_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX,
            this.colNGAY,
            this.colHOTENKH,
            this.colMANV,
            this.colMAKHO});
            this.gridView1.GridControl = this.gcPhieuXuat;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colMAPX
            // 
            this.colMAPX.Caption = "Mã Phiếu Xuất";
            this.colMAPX.FieldName = "MAPX";
            this.colMAPX.MinWidth = 25;
            this.colMAPX.Name = "colMAPX";
            this.colMAPX.OptionsColumn.ReadOnly = true;
            this.colMAPX.Visible = true;
            this.colMAPX.VisibleIndex = 0;
            this.colMAPX.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.Caption = "Ngày nhập";
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.OptionsColumn.ReadOnly = true;
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colHOTENKH
            // 
            this.colHOTENKH.Caption = "Khách hàng";
            this.colHOTENKH.FieldName = "HOTENKH";
            this.colHOTENKH.MinWidth = 25;
            this.colHOTENKH.Name = "colHOTENKH";
            this.colHOTENKH.OptionsColumn.ReadOnly = true;
            this.colHOTENKH.Visible = true;
            this.colHOTENKH.VisibleIndex = 2;
            this.colHOTENKH.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.Caption = "Mã nhân viên";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.OptionsColumn.ReadOnly = true;
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // colMAKHO
            // 
            this.colMAKHO.Caption = "Mã kho";
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 25;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.OptionsColumn.ReadOnly = true;
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            this.colMAKHO.Width = 94;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.cmbVattuCTPX);
            this.panelControl2.Controls.Add(mAVTLabel1);
            this.panelControl2.Controls.Add(this.txtMAVT);
            this.panelControl2.Controls.Add(dONGIALabel);
            this.panelControl2.Controls.Add(this.txtDONGIA);
            this.panelControl2.Controls.Add(sOLUONGLabel);
            this.panelControl2.Controls.Add(this.txtSOLUONG);
            this.panelControl2.Controls.Add(this.lbHOTENKH1);
            this.panelControl2.Controls.Add(tENKHOLabel);
            this.panelControl2.Controls.Add(this.cmbTenKho);
            this.panelControl2.Controls.Add(this.txtHOTENKH);
            this.panelControl2.Controls.Add(hOTENLabel);
            this.panelControl2.Controls.Add(this.cmbNhanVienNhap);
            this.panelControl2.Controls.Add(mAKHOLabel);
            this.panelControl2.Controls.Add(this.txtMAKHO);
            this.panelControl2.Controls.Add(mANVLabel);
            this.panelControl2.Controls.Add(this.txtMANV);
            this.panelControl2.Controls.Add(nGAYLabel);
            this.panelControl2.Controls.Add(this.dtNGAY);
            this.panelControl2.Controls.Add(MAPXLabel);
            this.panelControl2.Controls.Add(this.txtMAPX);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 371);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(793, 301);
            this.panelControl2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên vật tư";
            // 
            // cmbVattuCTPX
            // 
            this.cmbVattuCTPX.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsCTPX, "MAVT", true));
            this.cmbVattuCTPX.DataSource = this.bdsVattu;
            this.cmbVattuCTPX.DisplayMember = "TENVT";
            this.cmbVattuCTPX.Enabled = false;
            this.cmbVattuCTPX.FormattingEnabled = true;
            this.cmbVattuCTPX.Location = new System.Drawing.Point(137, 208);
            this.cmbVattuCTPX.Name = "cmbVattuCTPX";
            this.cmbVattuCTPX.Size = new System.Drawing.Size(289, 24);
            this.cmbVattuCTPX.TabIndex = 23;
            this.cmbVattuCTPX.ValueMember = "MAVT";
            this.cmbVattuCTPX.SelectedIndexChanged += new System.EventHandler(this.cmbVattuCTPX_SelectedIndexChanged);
            // 
            // bdsVattu
            // 
            this.bdsVattu.DataMember = "Vattu";
            this.bdsVattu.DataSource = this.DS1;
            // 
            // txtMAVT
            // 
            this.txtMAVT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCTPX, "MAVT", true));
            this.txtMAVT.Enabled = false;
            this.txtMAVT.Location = new System.Drawing.Point(604, 208);
            this.txtMAVT.Name = "txtMAVT";
            this.txtMAVT.Size = new System.Drawing.Size(128, 23);
            this.txtMAVT.TabIndex = 22;
            // 
            // txtDONGIA
            // 
            this.txtDONGIA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTPX, "DONGIA", true));
            this.txtDONGIA.Enabled = false;
            this.txtDONGIA.Location = new System.Drawing.Point(563, 247);
            this.txtDONGIA.MenuManager = this.barManager1;
            this.txtDONGIA.Name = "txtDONGIA";
            this.txtDONGIA.Size = new System.Drawing.Size(169, 22);
            this.txtDONGIA.TabIndex = 21;
            // 
            // txtSOLUONG
            // 
            this.txtSOLUONG.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTPX, "SOLUONG", true));
            this.txtSOLUONG.Enabled = false;
            this.txtSOLUONG.Location = new System.Drawing.Point(137, 247);
            this.txtSOLUONG.MenuManager = this.barManager1;
            this.txtSOLUONG.Name = "txtSOLUONG";
            this.txtSOLUONG.Size = new System.Drawing.Size(125, 22);
            this.txtSOLUONG.TabIndex = 20;
            // 
            // lbHOTENKH1
            // 
            this.lbHOTENKH1.AutoSize = true;
            this.lbHOTENKH1.Location = new System.Drawing.Point(387, 23);
            this.lbHOTENKH1.Name = "lbHOTENKH1";
            this.lbHOTENKH1.Size = new System.Drawing.Size(120, 16);
            this.lbHOTENKH1.TabIndex = 17;
            this.lbHOTENKH1.Text = "Khách hàng";
            // 
            // cmbTenKho
            // 
            this.cmbTenKho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSKHO, "TENKHO", true));
            this.cmbTenKho.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPhieuXuat, "MAKHO", true));
            this.cmbTenKho.DataSource = this.bdsDSKHO;
            this.cmbTenKho.DisplayMember = "TENKHO";
            this.cmbTenKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenKho.FormattingEnabled = true;
            this.cmbTenKho.Location = new System.Drawing.Point(137, 158);
            this.cmbTenKho.Name = "cmbTenKho";
            this.cmbTenKho.Size = new System.Drawing.Size(289, 24);
            this.cmbTenKho.TabIndex = 16;
            this.cmbTenKho.ValueMember = "MAKHO";
            this.cmbTenKho.SelectedIndexChanged += new System.EventHandler(this.cmbTenKho_SelectedIndexChanged);
            // 
            // bdsDSKHO
            // 
            this.bdsDSKHO.DataMember = "DSKHO";
            this.bdsDSKHO.DataSource = this.DS1;
            // 
            // txtHOTENKH
            // 
            this.txtHOTENKH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPhieuXuat, "HOTENKH", true));
            this.txtHOTENKH.Location = new System.Drawing.Point(563, 20);
            this.txtHOTENKH.Name = "txtHOTENKH";
            this.txtHOTENKH.Size = new System.Drawing.Size(169, 23);
            this.txtHOTENKH.TabIndex = 15;
            // 
            // cmbNhanVienNhap
            // 
            this.cmbNhanVienNhap.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDSNV, "HOTEN", true));
            this.cmbNhanVienNhap.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPhieuXuat, "MANV", true));
            this.cmbNhanVienNhap.DataSource = this.bdsDSNV;
            this.cmbNhanVienNhap.DisplayMember = "HOTEN";
            this.cmbNhanVienNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVienNhap.FormattingEnabled = true;
            this.cmbNhanVienNhap.Location = new System.Drawing.Point(137, 107);
            this.cmbNhanVienNhap.Name = "cmbNhanVienNhap";
            this.cmbNhanVienNhap.Size = new System.Drawing.Size(289, 24);
            this.cmbNhanVienNhap.TabIndex = 11;
            this.cmbNhanVienNhap.ValueMember = "MANV";
            this.cmbNhanVienNhap.SelectedIndexChanged += new System.EventHandler(this.hOTENComboBox_SelectedIndexChanged);
            // 
            // bdsDSNV
            // 
            this.bdsDSNV.DataMember = "DSNV";
            this.bdsDSNV.DataSource = this.DS1;
            // 
            // txtMAKHO
            // 
            this.txtMAKHO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPhieuXuat, "MAKHO", true));
            this.txtMAKHO.Location = new System.Drawing.Point(604, 158);
            this.txtMAKHO.Name = "txtMAKHO";
            this.txtMAKHO.Size = new System.Drawing.Size(128, 23);
            this.txtMAKHO.TabIndex = 9;
            // 
            // txtMANV
            // 
            this.txtMANV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPhieuXuat, "MANV", true));
            this.txtMANV.Location = new System.Drawing.Point(604, 107);
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(128, 23);
            this.txtMANV.TabIndex = 7;
            // 
            // dtNGAY
            // 
            this.dtNGAY.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsPhieuXuat, "NGAY", true));
            this.dtNGAY.EditValue = null;
            this.dtNGAY.Location = new System.Drawing.Point(137, 61);
            this.dtNGAY.MenuManager = this.barManager1;
            this.dtNGAY.Name = "dtNGAY";
            this.dtNGAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNGAY.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNGAY.Size = new System.Drawing.Size(125, 22);
            this.dtNGAY.TabIndex = 3;
            // 
            // txtMAPX
            // 
            this.txtMAPX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPhieuXuat, "MAPX", true));
            this.txtMAPX.Location = new System.Drawing.Point(137, 20);
            this.txtMAPX.Name = "txtMAPX";
            this.txtMAPX.Size = new System.Drawing.Size(125, 23);
            this.txtMAPX.TabIndex = 1;
            // 
            // dgvCTPX
            // 
            this.dgvCTPX.AllowUserToAddRows = false;
            this.dgvCTPX.AllowUserToDeleteRows = false;
            this.dgvCTPX.AutoGenerateColumns = false;
            this.dgvCTPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvCTPX.DataSource = this.bdsCTPX;
            this.dgvCTPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTPX.Location = new System.Drawing.Point(793, 371);
            this.dgvCTPX.Name = "dgvCTPX";
            this.dgvCTPX.RowHeadersWidth = 51;
            this.dgvCTPX.RowTemplate.Height = 24;
            this.dgvCTPX.Size = new System.Drawing.Size(723, 301);
            this.dgvCTPX.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MAPX";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã Phiếu Xuất";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MAVT";
            this.dataGridViewTextBoxColumn2.DataSource = this.bdsVattu;
            this.dataGridViewTextBoxColumn2.DisplayMember = "TENVT";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên vật tư";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ValueMember = "MAVT";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SOLUONG";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DONGIA";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // vattuTableAdapter
            // 
            this.vattuTableAdapter.ClearBeforeFill = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemVT,
            this.btnXoaVT,
            this.btnSuaVT,
            this.btnGhiVT,
            this.btnUndoVT});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 152);
            // 
            // btnThemVT
            // 
            this.btnThemVT.Name = "btnThemVT";
            this.btnThemVT.Size = new System.Drawing.Size(210, 24);
            this.btnThemVT.Text = "Thêm vật tư";
            this.btnThemVT.Click += new System.EventHandler(this.btnThemVT_Click);
            // 
            // btnXoaVT
            // 
            this.btnXoaVT.Name = "btnXoaVT";
            this.btnXoaVT.Size = new System.Drawing.Size(210, 24);
            this.btnXoaVT.Text = "Xóa vật tư";
            this.btnXoaVT.Click += new System.EventHandler(this.btnXoaVT_Click);
            // 
            // btnGhiVT
            // 
            this.btnGhiVT.Name = "btnGhiVT";
            this.btnGhiVT.Size = new System.Drawing.Size(210, 24);
            this.btnGhiVT.Text = "Ghi vật tư";
            this.btnGhiVT.Click += new System.EventHandler(this.btnGhiVT_Click);
            // 
            // btnUndoVT
            // 
            this.btnUndoVT.Name = "btnUndoVT";
            this.btnUndoVT.Size = new System.Drawing.Size(210, 24);
            this.btnUndoVT.Text = "Undo";
            this.btnUndoVT.Click += new System.EventHandler(this.btnUndoVT_Click);
            // 
            // dSNVTableAdapter
            // 
            this.dSNVTableAdapter.ClearBeforeFill = true;
            // 
            // dSKHOTableAdapter
            // 
            this.dSKHOTableAdapter.ClearBeforeFill = true;
            // 
            // btnSuaVT
            // 
            this.btnSuaVT.Name = "btnSuaVT";
            this.btnSuaVT.Size = new System.Drawing.Size(210, 24);
            this.btnSuaVT.Text = "Sửa vật tư";
            this.btnSuaVT.Click += new System.EventHandler(this.btnSuaVT_Click);
            // 
            // formPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1516, 692);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.dgvCTPX);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.gcPhieuXuat);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formPhieuXuat";
            this.Text = "formPhieuXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVattu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDONGIA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSKHO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNGAY.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNGAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPX)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnChuyenChiNhanh;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsPhieuXuat;
        private DS1 DS1;
        private DS1TableAdapters.PhieuXuatTableAdapter PhieuXuatTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DS1TableAdapters.CTPXTableAdapter cTPXTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPX;
        private DevExpress.XtraGrid.GridControl gcPhieuXuat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private System.Windows.Forms.DataGridView dgvCTPX;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.BindingSource bdsVattu;
        private DS1TableAdapters.VattuTableAdapter vattuTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnThemVT;
        private System.Windows.Forms.ToolStripMenuItem btnXoaVT;
        private System.Windows.Forms.ToolStripMenuItem btnGhiVT;
        private System.Windows.Forms.TextBox txtMAPX;
        private DevExpress.XtraEditors.DateEdit dtNGAY;
        private System.Windows.Forms.TextBox txtMAKHO;
        private System.Windows.Forms.TextBox txtMANV;
        private System.Windows.Forms.BindingSource bdsDSNV;
        private DS1TableAdapters.DSNVTableAdapter dSNVTableAdapter;
        private System.Windows.Forms.ComboBox cmbNhanVienNhap;
        private System.Windows.Forms.TextBox txtHOTENKH;
        private System.Windows.Forms.BindingSource bdsDSKHO;
        private DS1TableAdapters.DSKHOTableAdapter dSKHOTableAdapter;
        private System.Windows.Forms.ComboBox cmbTenKho;
        private System.Windows.Forms.Label lbHOTENKH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripMenuItem btnUndoVT;
        private DevExpress.XtraEditors.TextEdit txtSOLUONG;
        private DevExpress.XtraEditors.TextEdit txtDONGIA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVattuCTPX;
        private System.Windows.Forms.TextBox txtMAVT;
        private System.Windows.Forms.ToolStripMenuItem btnSuaVT;
    }
}
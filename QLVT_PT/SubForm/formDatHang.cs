using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_PT.SubForm
{
    public partial class formDatHang : Form
    {
        int vitri = -1;
        public formDatHang()
        {
            InitializeComponent();
        }
        public void enableButtons()
        {
            this.txtMaDDH.ReadOnly = true;
            this.dateDH.ReadOnly = true;
            this.txtNCC.ReadOnly = true;
            this.boxKho.Enabled = false;
            this.boxNhanVien.Enabled = false;

            this.gcDatHang.Enabled = true;
            if (Program.role == "CONGTY")
            {
                this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnGhi.Enabled = false;
                this.cmbChiNhanh.Enabled = true;
            }
            else
            {
                this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnGhi.Enabled = true;
                if (vitri == -1)
                {
                    this.btnQuayLai.Enabled = false;
                }
                this.cmbChiNhanh.Enabled = false;
            }

            
        }
        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDatHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS1);

        }

        private void formDatHang_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = Program.bindingSource; //sao chép bds đã load ở đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.brand;

            dS1.EnforceConstraints = false;

            this.dSKHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSKHOTableAdapter.Fill(this.dS1.DSKHO);

            this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSNVTableAdapter.Fill(this.dS1.DSNV);

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS1.Vattu);
           
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS1.DatHang);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);


            enableButtons();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = false;
            this.btnGhi.Enabled = this.btnQuayLai.Enabled = true;
            this.gcDatHang.Enabled = false;
            this.txtMaDDH.ReadOnly = false;
            this.dateDH.ReadOnly = false;
            this.txtNCC.ReadOnly = false;
            this.boxKho.Enabled = true;
            this.boxNhanVien.Enabled = false;


            this.txtMaDDH.Text = "";
            this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
            this.txtNCC.Text = "";

            this.boxNhanVien.Text = Program.userName;
        }

        private void btnChinhSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = false;
            this.btnGhi.Enabled = this.btnQuayLai.Enabled = true;
            this.gcDatHang.Enabled = false;
            this.txtMaDDH.ReadOnly = true;
            this.dateDH.ReadOnly = false;
            this.txtNCC.ReadOnly = false;
            this.boxKho.Enabled = true;
            this.boxNhanVien.Enabled = false;


            
            this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
            

            this.boxNhanVien.Text = Program.userName;
        }
    }
}

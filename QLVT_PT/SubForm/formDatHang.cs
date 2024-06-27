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
        BindingSource bds = null;
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
            this.txtMaNV.Enabled = false;
            //this.gcCTDDH.Enabled = true;

            this.gcDatHang.Enabled = true;
            if (Program.role == "CONGTY")
            {
                this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnGhi.Enabled = false;
                this.cmbChiNhanh.Enabled = true;
            }
            else
            {
                this.btnThem.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = false;
                if (vitri == -1)
                {
                    this.btnQuayLai.Enabled = false;
                }
                if(this.bdsDatHang.Count == 0)
                {
                    this.btnXoa.Enabled = false;
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
            this.dateDH.ReadOnly = true;
            this.txtNCC.ReadOnly = false;
            this.boxKho.Enabled = true;
            this.txtMaNV.ReadOnly = false;

            this.bdsDatHang.AddNew();

         //  this.gcCTDDH.Enabled = false;

            this.txtMaDDH.Text = "";
            this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
            this.txtNCC.Text = "";

            this.txtMaNV.Text = Program.userName;
        }

        private void btnChinhSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = false;
            this.btnGhi.Enabled = this.btnQuayLai.Enabled = true;
            this.gcDatHang.Enabled = false;
            this.txtMaDDH.ReadOnly = true;
            this.dateDH.ReadOnly = true;
            this.txtNCC.ReadOnly = false;
            this.boxKho.Enabled = true;
            this.txtMaNV.Enabled = false;

         //   this.gcCTDDH.Enabled = false;

            this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
            this.txtMaNV.Text = Program.userName;
        }
        private bool kiemTraThongTin()
        {
            // Kiểm tra mã đơn đặt hàng 
            if (this.txtMaDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (this.txtMaDDH.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Mã đơn đặt hàng không được có khoảng trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            // Kiểm tra nhà cung cấp
            if (this.txtNCC.Text.Trim() == "")
            {
                MessageBox.Show("Nhà cung cấp không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            // Kiểm tra mã kho
            this.boxKho.Text = this.boxKho.Text.Substring(this.boxKho.Text.Length - 4);
            if (this.boxKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (this.boxKho.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Mã kho không được có khoảng trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!kiemTraThongTin())
            {
                return;
            }

            try
            {
                bdsDatHang.EndEdit();
                bdsDatHang.ResetCurrentItem();
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Update(this.dS1.DatHang);

                bdsCTDDH.EndEdit();
                bdsCTDDH.ResetCurrentItem();
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Update(this.dS1.CTDDH);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi đơn đặt hàng: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            enableButtons();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vitri = -1;
                enableButtons();
                this.datHangTableAdapter.Fill(this.dS1.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void boxKho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themVatTu_Click(object sender, EventArgs e)
        {
           
            this.cTDDHBindingSource.AddNew();
         
        }

     
    }
}

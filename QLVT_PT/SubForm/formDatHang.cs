using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_PT.SubForm
{
    public partial class formDatHang : Form
    {
        bool dangthem = false;
        int vitri = -1;
        Dictionary<int, String> undoMap = new Dictionary<int, String>();

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
            this.dgvCTDDH.ReadOnly = true;
            this.gcDatHang.Enabled = true;
            contextMenuStrip1.Enabled = false;
            dangthem = false;
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

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS1.PhieuNhap);

            enableButtons();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri++;
            undoMap[vitri] = "them, " + this.txtMaDDH.Text;
            dangthem = true;
            this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = false;
            this.btnGhi.Enabled = this.btnQuayLai.Enabled = true;
            this.gcDatHang.Enabled = false;
            this.txtMaDDH.ReadOnly = false;
            this.dateDH.ReadOnly = true;
            this.txtNCC.ReadOnly = false;
            this.boxKho.Enabled = true;
            this.txtMaNV.ReadOnly = false;
            this.bdsDatHang.AddNew();
            this.txtMaDDH.Text = "";
            this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
            this.txtNCC.Text = "";
            this.txtMaNV.Text = Program.userName;
        }

        private void btnChinhSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(this.bdsPhieuNhap.Count > 0)
            {
                MessageBox.Show("Không thể chính sửa đơn đặt hàng đã nhập", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                vitri++;
                undoMap[vitri] = "chinhsua, " + this.txtMaDDH.Text;
                this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = false;
                this.btnGhi.Enabled = this.btnQuayLai.Enabled = true;
                this.gcDatHang.Enabled = false;
                this.txtMaDDH.ReadOnly = true;
                this.dateDH.ReadOnly = true;
                this.txtNCC.ReadOnly = false;
                this.boxKho.Enabled = true;
                this.txtMaNV.Enabled = false;
                contextMenuStrip1.Enabled = true; 
                this.dgvCTDDH.ReadOnly = false;
                this.maDDH_CTDDH.ReadOnly = true;
                this.dateDH.Text = DateTime.Now.ToString("MM/dd/yyyy");
                this.txtMaNV.Text = Program.userName;
            }          
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

            if(dangthem == true)
            {
                string statement = "EXEC sp_KiemTraMaDDH " + txtMaDDH.Text;
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                int checkmapn = Program.myReader.GetInt32(0);
                if (checkmapn == 1)
                {
                    MessageBox.Show("Mã đơn đặt hàng đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    txtMaDDH.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();
            }
            try
            {
                bds = this.bdsCTDDH;
                bdsDatHang.EndEdit();
                bdsDatHang.ResetCurrentItem();
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Update(this.dS1.DatHang);
                bdsCTDDH.EndEdit();
                bdsCTDDH.ResetCurrentItem();
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Update(this.dS1.CTDDH);
                
                if(dangthem == true)
                {
                    undoMap[vitri] = "EXEC sp_XoaDonDatHang " + this.txtMaDDH.Text.Trim();
                }
                else
                {
                    undoMap[vitri] = "chinhsua,CTDDH";
                }
                
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

      

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsPhieuNhap.Count > 0)
            {
                MessageBox.Show("Bạn không thể xóa đơn đặt hàng đã được nhập hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maddh = txtMaDDH.Text;
                try
                {
                    string statement = "EXEC sp_XoaDonDatHang " + txtMaDDH.Text;
                    Program.myReader = null;
                    Program.myReader = Program.ExecSqlDataReader(statement);
                    this.datHangTableAdapter.Fill(this.dS1.DatHang);
                    this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                    Program.myReader.Close();
                    vitri++;
                    undoMap[vitri] = "";
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu nhập. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.datHangTableAdapter.Fill(this.dS1.DatHang);
                    this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                    bdsDatHang.Position = bdsDatHang.Find("MasoDDH", maddh);
                    return;
                }
            }
        }

        private void themVatTu_Click(object sender, EventArgs e)
        {

            this.bdsCTDDH.AddNew();
        }
        private void xoaVatTu_Click(object sender, EventArgs e)
        {
            bdsCTDDH.RemoveCurrent();

        }

        private void btnQuayLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String[] checkUndo = undoMap[vitri].Split(',');
            if (checkUndo[0] == "them" || checkUndo[0] == "chinhsua")
            {
                if(checkUndo[1] == "CTDDH")
                {
                    this.bdsCTDDH = bds;
                    this.cTDDHTableAdapter.Update(this.dS1.CTDDH);
                    vitri--;
                    enableButtons();
                    return;
                }
                this.datHangTableAdapter.Fill(this.dS1.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                bdsDatHang.Position = bdsDatHang.Find("MasoDDH", checkUndo[1]);
                vitri--;
                enableButtons();
                return;             
            }
            try
            {
                String cauTruyVan = undoMap[vitri];
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                Program.myReader.Close();

                this.datHangTableAdapter.Fill(this.dS1.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                vitri--;
                enableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Quay Lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

      
    }
}

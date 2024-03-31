using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_PT
{
    public partial class formPhieuNhap : Form
    {
        int vitri = 0;
        bool them = false;
        int checkmapn = -1;
        public formPhieuNhap()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuNhap.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);
        }

        private void formPhieuNhap_Load(object sender, EventArgs e)
        {
            

            DS1.EnforceConstraints = false;

            this.dSKHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSKHOTableAdapter.Fill(this.DS1.DSKHO);

            this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSNVTableAdapter.Fill(this.DS1.DSNV);

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS1.Vattu);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS1.CTPN);

            cmbChiNhanh.DataSource = Program.bindingSource; //sao chép bds đã load ở đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.brand;
            if (Program.role == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnChuyenChiNhanh.Enabled = false;
                cmbChiNhanh.Enabled = true; //bật tắt theo phân quyền
                panelControl2.Enabled = false;
                contextMenuStrip1.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnSua.Enabled = true;
                btnGhi.Enabled = btnUndo.Enabled = false;
                cmbChiNhanh.Enabled = false;
                panelControl2.Enabled = false;
                if (bdsPhieuNhap.Count == 0) btnXoa.Enabled = false;
            }
        }

        private void hOTENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNhanVienNhap.SelectedValue != null)
                txtMANV.Text=cmbNhanVienNhap.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void cmbTenKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTenKho.SelectedValue != null)
                txtMAKHO.Text=cmbTenKho.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsPhieuNhap.Position;
            panelControl2.Enabled = true;
            bdsPhieuNhap.AddNew();
            txtMAPN.Enabled = true;
            txtMANV.Enabled = false;
            txtMAKHO.Enabled = false;
            dtNGAY.Enabled = false;
            dtNGAY.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbNhanVienNhap.Enabled = false;
            txtMANV.Text = Program.userName;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcPhieuNhap.Enabled = false;
            them=true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mapn = "";
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu nhập này vì đã có mặt hàng nhập về", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa phiếu nhập này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mapn = ((DataRowView)bdsPhieuNhap[bdsPhieuNhap.Position])["MAPN"].ToString();
                    bdsPhieuNhap.RemoveCurrent();     
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS1.PhieuNhap);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu nhập. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);
                    bdsPhieuNhap.Position = bdsPhieuNhap.Find("MAPN", mapn);
                    return;
                }
            }

            if (bdsPhieuNhap.Count == 0) btnXoa.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsPhieuNhap.Position;
            panelControl2.Enabled = true;
            txtMAPN.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcPhieuNhap.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtNGAY.Text.Trim() == "")
            {
                MessageBox.Show("Ngày nhập phiếu không được thiếu!", "", MessageBoxButtons.OK);
                dtNGAY.Focus();
                return;
            }

            //Mã pn không được trùng trên các phân mảnh nếu dùng nút thêm
            if (them == true)
            {
                string statement = "EXEC sp_KiemTraMAPN " + txtMAPN.Text;
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                checkmapn = Program.myReader.GetInt32(0);
                if (checkmapn == 1)
                {
                    MessageBox.Show("Mã phiếu nhập đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    txtMAPN.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();

                //Mã đơn đặt hàng phải có trên phân mảnh hiện tại
            }
            

            try
            {
                bdsPhieuNhap.EndEdit();
                bdsPhieuNhap.ResetCurrentItem();
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Update(this.DS1.PhieuNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi phiếu nhập: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            gcPhieuNhap.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            panelControl2.Enabled = false;
            them = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsPhieuNhap.CancelEdit();
            if (btnThem.Enabled == false) bdsPhieuNhap.Position = vitri;
            panelControl2.Enabled = false;
            gcPhieuNhap.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            them = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload:" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.serverName = cmbChiNhanh.SelectedValue.ToString();

            if (cmbChiNhanh.SelectedIndex != Program.brand)
            {
                Program.loginName = Program.remoteLogin;
                Program.loginPassword = Program.remotePassword;
            }
            else
            {
                Program.loginName = Program.currentLogin;
                Program.loginPassword = Program.currentPassword;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.dSKHOTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dSKHOTableAdapter.Fill(this.DS1.DSKHO);

                //this.dDHChuaNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.dDHChuaNhapTableAdapter.Fill(this.DS1.DDHChuaNhap);

                this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dSNVTableAdapter.Fill(this.DS1.DSNV);

                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);

                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS1.CTPN);
            }
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            bdsCTPN.AddNew();
            ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAPN"] = txtMAPN.Text;
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            string mavt = "";
            if (MessageBox.Show("Bạn có thực sự muốn xóa vật tư này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mavt = ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"].ToString();
                    bdsCTPN.RemoveCurrent();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS1.CTPN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa vật tư. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.cTPNTableAdapter.Fill(this.DS1.CTPN);
                    bdsCTPN.Position = bdsCTPN.Find("MAVT", mavt);
                    return;
                }
            }

            if (bdsPhieuNhap.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhiVT_Click(object sender, EventArgs e)
        {
            if (((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"] == DBNull.Value)
            {
                MessageBox.Show("Tên vật tư không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            if (((DataRowView)bdsCTPN[bdsCTPN.Position])["SOLUONG"] == DBNull.Value)
            {
                MessageBox.Show("Số lượng không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            if (((DataRowView)bdsCTPN[bdsCTPN.Position])["DONGIA"] == DBNull.Value)
            {
                MessageBox.Show("Đơn giá không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                object soluongObj = ((DataRowView)bdsCTPN[bdsCTPN.Position])["SOLUONG"];
                if (soluongObj != DBNull.Value)
                {
                    if (int.TryParse(soluongObj.ToString(), out int soluong))
                    {
                        string mavt = ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"].ToString();
                        string statement = "EXEC sp_KiemTraSoLuongCTPN '" + txtMasoDDH.Text + "', '" + mavt + "', " + soluong;
                        Program.myReader = null;
                        Program.myReader = Program.ExecSqlDataReader(statement);
                        if (Program.myReader == null)
                            return;
                        Program.myReader.Read();
                        if (Program.myReader.GetInt32(0) == 0)
                        {
                            MessageBox.Show("Số lượng vật tư này lớn hơn so với lúc đặt, vui lòng chỉnh lại", "", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            return;
                        }
                        Program.myReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Số lượng không hợp lệ", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng không được bỏ trống", "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                bdsCTPN.EndEdit();
                bdsCTPN.ResetCurrentItem();
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Update(this.DS1.CTPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư vào phiếu nhập: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
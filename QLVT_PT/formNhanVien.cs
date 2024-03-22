﻿using DevExpress.CodeParser;
using DevExpress.XtraEditors;
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
using static DevExpress.CodeParser.CodeStyle.Formatting.Rules.LineBreaks;

namespace QLVT_PT
{
    public partial class formNhanVien : Form
    {
        int vitri = 0;
        string macn = "";
        int checkmanv = -1;
        int checkcmnd = -1;
        bool them = false;
        bool sua = false;
        private SqlConnection connPublisher1 = new SqlConnection();
        public static BindingSource bindingSource1 = new BindingSource();
        public formNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);

        }

        private void formNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS1.ChiNhanh' table. You can move, or remove it, as needed.
            
            DS1.EnforceConstraints = false;

            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.DS1.ChiNhanh);

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS1.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);

            macn = ((DataRowView)bdsCN[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bindingSource; //sao chép bds đã load ở đăng nhập
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.brand;
            if (Program.role == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnChuyenChiNhanh.Enabled = false;
                cmbChiNhanh.Enabled = true; //bật tắt theo phân quyền
                panelControl2.Enabled = false;
            }
            else
            {
                if (Program.role == "USER") btnChuyenChiNhanh.Enabled = false;
                else btnChuyenChiNhanh.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnSua.Enabled = true;
                btnGhi.Enabled = btnUndo.Enabled = false;
                cmbChiNhanh.Enabled = false;
                panelControl2.Enabled = false;
                if (bdsNV.Count == 0) btnChuyenChiNhanh.Enabled = btnXoa.Enabled = false;
            }

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            panelControl2.Enabled = true;
            bdsNV.AddNew();
            txtMANV.Enabled = true;
            txtMACN.Text = macn;
            dtNGAYSINH.EditValue = "";
            trangThaiXoaCheckBox.Checked = false;
            trangThaiXoaCheckBox.Enabled = false;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
            them = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());  //giữ lại kiểm tra khi bị lỗi xóa
                    bdsNV.RemoveCurrent();     //xóa trên màn hình
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS1.NhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }

            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            panelControl2.Enabled = true;
            txtMANV.Enabled = false;
            trangThaiXoaCheckBox.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
            txtCMND.Enabled = false;
            sua = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtMANV.Focus();
                return;
            }
            if (txtHO.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }
            if (txtTEN.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }
            if (dtNGAYSINH.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                dtNGAYSINH.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtLUONG.Text.Trim() == "")
            {
                MessageBox.Show("Lương nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtLUONG.Focus();
                return;
            }
            if (int.Parse(txtLUONG.Text.Trim().Replace(",", "")) < 4000000)
            {
                MessageBox.Show("Lương nhân viên phải lớn hơn 4.000.000", "", MessageBoxButtons.OK);
                txtLUONG.Focus();
                return;
            }
            if (txtDIACHI.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được bỏ trống", "", MessageBoxButtons.OK);
                txtDIACHI.Focus();
                return;
            }

            //Mã nv không được trùng trên các phân mảnh nếu dùng nút thêm
            if (them == true)
            {
                string statement = "EXEC sp_KiemTraMANV " + txtMANV.Text;
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                checkmanv = Program.myReader.GetInt32(0);
                if (checkmanv == 1)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    txtMANV.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();

                string statement1 = "EXEC sp_KiemTraCMND '" + txtCMND.Text +"'";
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement1);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                checkcmnd = Program.myReader.GetInt32(0);
                if (checkcmnd == 1)
                {
                    MessageBox.Show("Số CMND đã tồn tại, vui lòng nhập số CMND khác", "", MessageBoxButtons.OK);
                    txtCMND.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();
            }

            //Kiểm tra khi sửa trạng thái xóa của nhân viên, nếu nhân viên đó đang làm ở site khác
            if (sua == true && trangThaiXoaCheckBox.Checked == false)
            {
                string statement = "EXEC sp_KiemTraTrangThaiXoa '" + txtCMND.Text +"', '0'";
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                if(Program.myReader.GetInt32(0) == 1)
                {
                    MessageBox.Show("Nhân viên này hiện đang làm việc tại chi nhánh còn lại! \nKhông thể sửa trạng thái xóa!", "", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();
            }

            try
            {
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.DS1.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            gcNhanVien.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            panelControl2.Enabled = false;
            them = false;
            sua = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = vitri;
            panelControl2.Enabled = false;
            gcNhanVien.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            them = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
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
                //this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.chiNhanhTableAdapter.Fill(this.DS1.ChiNhanh);
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS1.DatHang);
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);
                //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }

        private void btnChuyenChiNhanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (trangThaiXoaCheckBox.Checked == true)
            {
                MessageBox.Show("Nhân viên này không còn làm ở chi nhánh hiện tại!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                //vitri = bdsNV.Position;
                //panelControl2.Enabled = false;
                //btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
                //btnGhi.Enabled = btnUndo.Enabled = true;
                //gcNhanVien.Enabled = false;
                if (MessageBox.Show("Bạn có muốn chuyển nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string statement;
                    if(bdsDH.Count > 0 || bdsPN.Count > 0 || bdsPX.Count > 0)
                    {
                        vitri=bdsNV.Position;
                        statement = "EXEC sp_ChuyenChiNhanh '" + txtMANV.Text + "', N'"
                            + txtHO.Text + "', N'" + txtTEN.Text + "', '" + txtCMND.Text + "', N'" 
                            + txtDIACHI.Text +"', '" + dtNGAYSINH.Text + "', '" + int.Parse(txtLUONG.Text.Replace(",", "")) + "', '1'";
                    }
                    else
                    {
                        vitri = 0;
                        statement = "EXEC sp_ChuyenChiNhanh '" + txtMANV.Text + "', N'"
                            + txtHO.Text + "', N'" + txtTEN.Text + "', '" + txtCMND.Text + "', N'"
                            + txtDIACHI.Text + "', '" + dtNGAYSINH.Text + "', '" + int.Parse(txtLUONG.Text.Replace(",", "")) + "', '0'";
                    }
                    Program.myReader = null;
                    Program.myReader = Program.ExecSqlDataReader(statement);
                    if (Program.myReader == null)
                        return;
                    Program.myReader.Read();
                    if (Program.myReader.GetInt32(0) == 1)
                    {
                        MessageBox.Show("Chuyển nhân viên thành công!", "", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        try
                        {
                            this.nhanVienTableAdapter.Fill(this.DS1.NhanVien);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi Reload:" + ex.Message, "", MessageBoxButtons.OK);
                            return;
                        }
                        bdsNV.Position = vitri;
                        if (bdsNV.Count == 0) btnChuyenChiNhanh.Enabled = false;
                        return;
                    }
                    Program.myReader.Close();

                    //DROP LOGIN
                    //string statement = "EXEC sp_DropLogin '" + txtMANV.Text "'"
                    //Program.myReader = null;
                    //Program.myReader = Program.ExecSqlDataReader(statement1);
                    //if (Program.myReader == null)
                    //    return;
                    //Program.myReader.Read();
                    //checkcmnd = Program.myReader.GetInt32(0);
                    //if (checkcmnd == 1)
                    //{
                    //    MessageBox.Show("Số CMND đã tồn tại, vui lòng nhập số CMND khác", "", MessageBoxButtons.OK);
                    //    txtCMND.Focus();
                    //    Program.myReader.Close();
                    //    return;
                    //}
                    Program.myReader.Close();
                }
                return;
            }
        }
    }
}

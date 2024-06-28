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
        bool dangChinhSua = false;
        Stack<object> stack = new Stack<object>();



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
            dangChinhSua = false;
            if (Program.role == "CONGTY")
            {
                this.btnThem.Enabled = this.btnXoa.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnGhi.Enabled = false;
                this.cmbChiNhanh.Enabled = true;
            }
            else
            {
                this.btnThem.Enabled = this.btnChinhSua.Enabled = this.btnQuayLai.Enabled = this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = false;
                if (stack == null || stack.Count == 0)
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
            dangthem = true;
            stack.Push(bdsDatHang.Position);
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
                dangChinhSua = true;
                String maddh = this.txtMaDDH.Text.Trim();
                List<object> oldCTDDH = new List<object>();
                foreach (DataGridViewRow row in dgvCTDDH.Rows)
                {
                    List<object> new_row = new List<object>();
                    new_row.Add(row.Cells["vatTu_CTDDH"].Value.ToString());
                    new_row.Add(row.Cells["soLuong_CTDDH"].Value.ToString());
                    new_row.Add(row.Cells["donGia_CTDDH"].Value.ToString());
                    oldCTDDH.Add(new_row);

                }

                String cautruyvan = "DELETE FROM CTDDH WHERE MasoDDH = '" + this.txtMaDDH.Text.Trim() +"'; " ;
                if (oldCTDDH.Count != 0)
                {
                    foreach (List<object> row in oldCTDDH)
                    {
                        cautruyvan += "\nINSERT INTO CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA) " +
                                      "VALUES";
                        cautruyvan += "('" + maddh.Trim() + "', '" + row[0].ToString().Trim() + "', " + row[1].ToString().Trim() + ", " + row[2].ToString().Trim() + "); ";
                    }
                    
                }
                stack.Push(maddh.Trim());
                stack.Push(cautruyvan);


                stack.Push(bdsDatHang.Position);
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
            if (dangthem == true)
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
                if (dangthem == true)
                {
                    stack.Pop();
                    String cautruyvan = "EXEC sp_XoaDonDatHang " + this.txtMaDDH.Text.Trim();
                    stack.Push(0);
                    stack.Push(cautruyvan);
                }
                if(dangChinhSua == true)
                {
                    stack.Pop();
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
                stack.Clear();
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
                    // Lấy data cũ để khôi phục 
                    List<object> oldCTDDH = new List<object>();
                    foreach (DataGridViewRow row in dgvCTDDH.Rows)
                    {
                        List<object> new_row = new List<object>();
                        new_row.Add(row.Cells["vatTu_CTDDH"].Value.ToString());
                        new_row.Add(row.Cells["soLuong_CTDDH"].Value.ToString());
                        new_row.Add(row.Cells["donGia_CTDDH"].Value.ToString());  
                        oldCTDDH.Add(new_row);
                        
                    }
                    String maKho = this.boxKho.Text.Trim();
                    maKho = maKho.Substring(maKho.Length - 4);
                    String cautruyvan = "INSERT INTO DatHang (MasoDDH, NGAY, NhaCC, MANV, MAKHO) " +
                                        "VALUES('"+maddh.Trim() + "','" +
                                                this.dateDH.Text + "','" +
                                                this.txtNCC.Text + "'," +
                                                this.txtMaNV.Text + ",'" +
                                                maKho + "'" +"); ";
                    if(oldCTDDH.Count != 0)
                    {
                        foreach(List<object> row in oldCTDDH)
                        {
                        cautruyvan += "\nINSERT INTO CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA) " +
                                      "VALUES";
                        cautruyvan += "('" + maddh.Trim() + "', '" + row[0].ToString().Trim() + "', " + row[1].ToString().Trim() + ", " + row[2].ToString().Trim() + "); ";
                        }
                    }


                    string statement = "EXEC sp_XoaDonDatHang " + txtMaDDH.Text;
                    Program.myReader = null;
                    Program.myReader = Program.ExecSqlDataReader(statement);
                    this.datHangTableAdapter.Fill(this.dS1.DatHang);
                    this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                    Program.myReader.Close();
                    stack.Push(maddh.Trim());
                    stack.Push(cautruyvan);
                    enableButtons();
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
            if (dangthem == true || dangChinhSua == true)
            {
                this.datHangTableAdapter.Fill(this.dS1.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                bdsDatHang.Position = Convert.ToInt32(stack.Pop()); 
                if(dangChinhSua == true)
                {
                    stack.Pop();
                    stack.Pop();
                }
                enableButtons();

                return;
            }
            try
            {
                String cauTruyVan = stack.Pop().ToString();
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                Program.myReader.Close();
                this.datHangTableAdapter.Fill(this.dS1.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS1.CTDDH);
                object temp = stack.Pop();
                if (temp is string)
                {
                    bdsDatHang.Position = bdsDatHang.Find("MasoDDH", temp);
                }
                else
                {
                    bdsDatHang.Position = Convert.ToInt32(temp);
                }
                enableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Quay Lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            }
        }
    }
}

using DevExpress.Charts.Native;
using DevExpress.CodeParser;
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

namespace QLVT_PT
{
    public partial class formPhieuNhap : Form
    {
        int vitri = 0;
        bool them = false;
        bool themVT = false;
        int checkmapn = -1;
        DataRow[] rows;        

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
            }
            else
            {
                btnThem.Enabled = btnReload.Enabled = true;
                if (txtMANV.Text.Equals(Program.userName))
                {
                    btnXoa.Enabled = btnSua.Enabled = true;
                }
                else
                {
                    btnXoa.Enabled = btnSua.Enabled = false;
                }
                btnGhi.Enabled = btnUndo.Enabled = false;
                cmbChiNhanh.Enabled = false;
                panelControl2.Enabled = false;
                if (bdsPhieuNhap.Count == 0)
                {
                    btnXoa.Enabled = btnSua.Enabled = false;                    
                }
                if (bdsCTPN.Count == 0)
                {
                    btnXoaVT.Enabled = btnGhiVT.Enabled = false;
                }                
            }
            dgvCTPN.ReadOnly = true;
            contextMenuStrip1.Enabled = false;
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
            txtMasoDDH.Enabled = false;
            btnChonDonDat.Enabled = true;
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
            if (bdsPhieuNhap.Count == 0)
            {
                btnXoa.Enabled = btnSua.Enabled = false;                
                return;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsPhieuNhap.Position;
            panelControl2.Enabled = true;
            txtMAPN.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcPhieuNhap.Enabled = false;
            txtMasoDDH.Enabled = btnChonDonDat.Enabled = false;
            txtMANV.Enabled = cmbNhanVienNhap.Enabled = false;
            dtNGAY.Enabled = false;
            txtMAKHO.Enabled = false;
            dgvCTPN.ReadOnly = false;
            contextMenuStrip1.Enabled = true;
            if (bdsCTPN.Count > 0)
            {
                btnThemVT.Enabled = btnXoaVT.Enabled = btnGhiVT.Enabled = true;
            }
            else
            {
                btnThemVT.Enabled = true;
                btnXoaVT.Enabled = btnGhiVT.Enabled = false;
            }
            DS1.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.FillBy(this.DS1.Vattu, txtMasoDDH.Text);
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
                this.cTPNTableAdapter.Fill(this.DS1.CTPN);
                DS1.EnforceConstraints = false;
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi phiếu nhập: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            if(them == true)
            {
                if (MessageBox.Show("Bạn có muốn lấy các vật tư từ đơn đặt đã chọn cho phiếu nhập?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ImportCTPNFromSelectedDDH(this.rows);
                }
                rows = null;
            }            

            contextMenuStrip1.Enabled = true;
            gcPhieuNhap.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            panelControl2.Enabled = false;
            them = false;
            if (bdsCTPN.Count > 0)
            {
                btnThemVT.Enabled = btnGhiVT.Enabled = btnXoaVT.Enabled = true;
            }
            else
            {
                btnThemVT.Enabled = true;
                btnGhiVT.Enabled = btnXoaVT.Enabled = false;
            }            
            dgvCTPN.ReadOnly = true;
            contextMenuStrip1.Enabled = false;            
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
            rows = null;                        
            dgvCTPN.ReadOnly = true;
            contextMenuStrip1.Enabled = false;
            try
            {                
                this.cTPNTableAdapter.Fill(this.DS1.CTPN);
                DS1.EnforceConstraints = false;
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload:" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);
                this.cTPNTableAdapter.Fill(this.DS1.CTPN);
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
            themVT = true;
            bdsCTPN.AddNew();
            ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAPN"] = txtMAPN.Text;
            btnXoaVT.Enabled = btnThemVT.Enabled = false;
            btnGhiVT.Enabled = true;
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            
            int vitri = bdsCTPN.Position;
            string mavt = "";
            if (MessageBox.Show("Bạn có thực sự muốn xóa vật tư này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                mavt = ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"].ToString();
                if (UpdateSoLuongTonVattu(mavt, Convert.ToInt32(((DataRowView)bdsCTPN[bdsCTPN.Position])["SOLUONG"]), false) == false)
                {                    
                    this.cTPNTableAdapter.Fill(this.DS1.CTPN);
                    bdsCTPN.Position = vitri;
                    return;
                }
                else
                {
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.DS1.Vattu);
                }
                try
                {                                       
                    bdsCTPN.RemoveCurrent();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS1.CTPN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa vật tư. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.cTPNTableAdapter.Fill(this.DS1.CTPN);
                    bdsCTPN.Position = vitri;
                    return;
                }
            }

            if (bdsCTPN.Count == 0)
            {
                btnThemVT.Enabled = true;
                btnXoaVT.Enabled = btnGhiVT.Enabled = false;
                return;
            }
        }

        private void btnGhiVT_Click(object sender, EventArgs e)
        {
            string mavt_cu = "";
            int soluong_cu = 0;
            DataRowView currentView = (DataRowView)bdsCTPN[bdsCTPN.Position];

            if (currentView["MAVT"] == DBNull.Value)
            {
                MessageBox.Show("Tên vật tư không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            if (currentView["DONGIA"] == DBNull.Value)
            {
                MessageBox.Show("Đơn giá không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                object soluongObj = currentView["SOLUONG"];
                if (soluongObj != DBNull.Value)
                {
                    if (int.TryParse(soluongObj.ToString(), out int soluong))
                    {
                        string statement = "EXEC sp_KiemTraSoLuongCTPN '" + txtMasoDDH.Text + "', '" + currentView["MAVT"].ToString() + "', " + soluong;
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

            // Print current values
            Console.WriteLine("Current Values:");
            Console.WriteLine($"MAVT: {currentView["MAVT"]}");
            Console.WriteLine($"SOLUONG: {currentView["SOLUONG"]}");
            Console.WriteLine($"DONGIA: {currentView["DONGIA"]}");

            // Print original values if available
            if (currentView.Row.RowState == DataRowState.Modified && currentView.Row.HasVersion(DataRowVersion.Original))
            {
                mavt_cu = currentView.Row["MAVT", DataRowVersion.Original].ToString();
                soluong_cu = Convert.ToInt32(currentView.Row["SOLUONG", DataRowVersion.Original]);
                Console.WriteLine("Original Values:");
                Console.WriteLine($"MAVT: {mavt_cu}");
                Console.WriteLine($"SOLUONG: {soluong_cu}");
                Console.WriteLine($"DONGIA: {currentView.Row["DONGIA", DataRowVersion.Original]}");
            }
            else
            {
                Console.WriteLine("No original values available.");
            }
                        
            try
            {   if(mavt_cu.Equals(currentView["MAVT"].ToString()) && soluong_cu == Convert.ToInt32(currentView["SOLUONG"]))
                {                    
                    return;
                }             
                if(mavt_cu != "" || soluong_cu!=0)
                {                   
                    if(UpdateSoLuongTonVattu(mavt_cu, soluong_cu, false) == true)
                    {
                        UpdateSoLuongTonVattu(currentView["MAVT"].ToString(), Convert.ToInt32(currentView["SOLUONG"]), true);
                        this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.vattuTableAdapter.Update(DS1.Vattu);
                    }
                    else
                    {
                        return;
                    }
                }
                if(mavt_cu == "" && soluong_cu == 0 && themVT==true)
                {
                    UpdateSoLuongTonVattu(currentView["MAVT"].ToString(), Convert.ToInt32(currentView["SOLUONG"]), true);
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(DS1.Vattu);
                    themVT = false;
                }
                
                
                bdsCTPN.EndEdit();
                bdsCTPN.ResetCurrentItem();
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Update(this.DS1.CTPN);
                             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư vào chi tiết phiếu nhập: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btnThemVT.Enabled = btnXoaVT.Enabled = btnGhiVT.Enabled = true;
        }


        private void btnChonDonDat_Click(object sender, EventArgs e)
        {            
            if (txtMAPN.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập trước khi chọn đơn đặt!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                using (formDonDatHangChuaNhap form = new formDonDatHangChuaNhap())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.dataRows == null || form.dataRows.Length == 0)
                        {
                            MessageBox.Show("Dữ liệu đơn đặt hàng trống hoặc không hợp lệ!", "", MessageBoxButtons.OK);
                            return;
                        }
                        txtMasoDDH.Text = form.SelectedMADDH;
                        if (txtMAKHO.Text.Trim() == "")
                        {
                            txtMAKHO.Text = form.SelectedMAKHO;
                        }
                        this.rows = form.dataRows;
                        return;
                    }
                }
            }
        }

        private bool UpdateSoLuongTonVattu(String mavt, int soluong, Boolean status)
        {
            DataRow data = DS1.Vattu.Select($"MAVT='{mavt}'").FirstOrDefault();
            if (data != null)
            {
                try
                {
                    int currentSoluongTon;
                    currentSoluongTon = Convert.ToInt32(data["SOLUONGTON"]);

                    int newSoluongTon;
                    if (status) // Increase
                    {
                        newSoluongTon = currentSoluongTon + soluong;
                    }
                    else // Decrease
                    {
                        if (currentSoluongTon < soluong)
                        {
                            MessageBox.Show("Số lượng tồn hiện tại của vật tư bé hơn số lượng bạn muốn trừ!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        newSoluongTon = currentSoluongTon - soluong;
                    }

                    data["SOLUONGTON"] = newSoluongTon;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi khi sửa số lượng tồn vật tư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void ImportCTPNFromSelectedDDH(DataRow[] rows)
        {
            try
            {
                foreach (DataRow row in rows)
                {
                    bdsCTPN.AddNew();                    
                    ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAPN"] = txtMAPN.Text;
                    ((DataRowView)bdsCTPN[bdsCTPN.Position])["MAVT"] = row["MAVT"];
                    ((DataRowView)bdsCTPN[bdsCTPN.Position])["SOLUONG"] = row["SOLUONG"];
                    ((DataRowView)bdsCTPN[bdsCTPN.Position])["DONGIA"] = row["DONGIA"];                    
                    bdsCTPN.EndEdit();
                    bdsCTPN.ResetCurrentItem();
                    UpdateSoLuongTonVattu(Convert.ToString(row["MAVT"]), Convert.ToInt32(row["SOLUONG"]), true);
                }
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Update(this.DS1.Vattu);
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Update(this.DS1.CTPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void gcPhieuNhap_Click(object sender, EventArgs e)
        {
            if(txtMANV.Text.Equals(Program.userName))
            {
                btnXoa.Enabled = btnSua.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = btnSua.Enabled = false;
            }            
        }        
    }
}
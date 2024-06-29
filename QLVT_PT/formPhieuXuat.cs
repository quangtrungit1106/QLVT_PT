using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLVT_PT
{
    public partial class formPhieuXuat : Form
    {
        int vitri = 0;
        int vitricTPX = -1;
        bool them = false;
        bool ThemVT = false;
        bool SuaVT = false;
        int checkmapx = -1;
        int soluongcu = 0;
        DataRow[] rows;        

        public formPhieuXuat()
        {
            InitializeComponent();
        }                

        private void PhieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuXuat.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);
        }        

        private void formPhieuXuat_Load(object sender, EventArgs e)
        {
            

            DS1.EnforceConstraints = false;

            this.dSKHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSKHOTableAdapter.Fill(this.DS1.DSKHO);

            this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dSNVTableAdapter.Fill(this.DS1.DSNV);

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS1.Vattu);

            this.PhieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.PhieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);
            
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS1.CTPX);            

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
                if (bdsPhieuXuat.Count == 0)
                {
                    btnXoa.Enabled = btnSua.Enabled = false;                    
                }
                if (bdsCTPX.Count == 0)
                {
                    btnXoaVT.Enabled = btnGhiVT.Enabled = false;
                }                
            }
            dgvCTPX.ReadOnly = true;
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
            vitri = bdsPhieuXuat.Position;
            panelControl2.Enabled = true;
            bdsPhieuXuat.AddNew();
            txtMAPX.Enabled = true;
            txtMANV.Enabled = false;
            txtMAKHO.Enabled = false;
            txtHOTENKH.Enabled = true;
            dtNGAY.Enabled = false;
            dtNGAY.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbNhanVienNhap.Enabled = false;
            txtMANV.Text = Program.userName;            

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcPhieuXuat.Enabled = false;
            them=true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            string mapx = "";
            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa Phiếu Xuất này vì đã có mặt hàng nhập về", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa Phiếu Xuất này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mapx = ((DataRowView)bdsPhieuXuat[bdsPhieuXuat.Position])["MAPX"].ToString();
                    bdsPhieuXuat.RemoveCurrent();     
                    this.PhieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.PhieuXuatTableAdapter.Update(this.DS1.PhieuXuat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa Phiếu Xuất. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.PhieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);
                    bdsPhieuXuat.Position = bdsPhieuXuat.Find("MAPX", mapx);
                    return;
                }                               
            }            
            if (bdsPhieuXuat.Count == 0)
            {
                btnXoa.Enabled = btnSua.Enabled = false;                
                return;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsPhieuXuat.Position;
            panelControl2.Enabled = true;
            txtMAPX.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcPhieuXuat.Enabled = false;
            txtHOTENKH.Enabled = false;
            txtMANV.Enabled = cmbNhanVienNhap.Enabled = false;
            dtNGAY.Enabled = false;
            txtMAKHO.Enabled = false;
            cmbTenKho.Enabled = true;
            contextMenuStrip1.Enabled = true;
            if (bdsCTPX.Count > 0)
            {
                btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = true;
                btnGhiVT.Enabled = btnUndoVT.Enabled = false;
            }
            else
            {
                btnThemVT.Enabled = true;
                btnXoaVT.Enabled = btnGhiVT.Enabled = btnUndoVT.Enabled = btnSuaVT.Enabled = false;
            }
            DS1.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.FillBy(this.DS1.Vattu, txtHOTENKH.Text);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtNGAY.Text.Trim() == "")
            {
                MessageBox.Show("Ngày nhập phiếu không được thiếu!", "", MessageBoxButtons.OK);
                dtNGAY.Focus();
                return;
            }

            //Mã px không được trùng trên các phân mảnh nếu dùng nút thêm
            if (them == true)
            {
                string statement = "EXEC sp_KiemTraMAPX " + txtMAPX.Text;
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                checkmapx = Program.myReader.GetInt32(0);
                if (checkmapx == 1)
                {
                    MessageBox.Show("Mã Phiếu Xuất đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();

                //Mã đơn đặt hàng phải có trên phân mảnh hiện tại
            }


            try
            {
                bdsPhieuXuat.EndEdit();
                bdsPhieuXuat.ResetCurrentItem();
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
                this.PhieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.PhieuXuatTableAdapter.Update(this.DS1.PhieuXuat);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS1.CTPX);                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi Phiếu Xuất: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            if(them == true)
            {
                if (MessageBox.Show("Bạn có muốn lấy các vật tư từ đơn đặt đã chọn cho Phiếu Xuất?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ImportcTPXFromSelectedDDH(this.rows);
                }
                rows = null;
            }            

            contextMenuStrip1.Enabled = true;
            gcPhieuXuat.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            panelControl2.Enabled = false;
            them = false;                                    
            contextMenuStrip1.Enabled = false;            
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsPhieuXuat.CancelEdit();
            if (btnThem.Enabled == false) bdsPhieuXuat.Position = vitri;
            panelControl2.Enabled = false;
            gcPhieuXuat.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = btnChuyenChiNhanh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            them = false;
            rows = null;                                    
            contextMenuStrip1.Enabled = false;
            try
            {
                DS1.EnforceConstraints = false;
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS1.CTPX);                                
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
                this.PhieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);
                this.cTPXTableAdapter.Fill(this.DS1.CTPX);
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

                this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dSNVTableAdapter.Fill(this.DS1.DSNV);

                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS1.Vattu);

                this.PhieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.PhieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS1.CTPX);
            }
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {                                    
            bdsCTPX.AddNew();            
            ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAPX"] = txtMAPX.Text;                                   
            btnXoaVT.Enabled = btnThemVT.Enabled = btnSuaVT.Enabled = false;
            btnGhiVT.Enabled = btnUndoVT.Enabled = true;
            dgvCTPX.Enabled = false;
            cmbVattuCTPX.Enabled = txtSOLUONG.Enabled = txtDONGIA.Enabled = true;
            cmbTenKho.Enabled = false;
            ThemVT = true;
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            
            int vitri = bdsCTPX.Position;
            string mavt = "";
            if (MessageBox.Show("Bạn có thực sự muốn xóa vật tư này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                mavt = ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAVT"].ToString();
                if (UpdateSoLuongTonVattu(mavt, Convert.ToInt32(((DataRowView)bdsCTPX[bdsCTPX.Position])["SOLUONG"]), false) == false)
                {                    
                    this.cTPXTableAdapter.Fill(this.DS1.CTPX);
                    bdsCTPX.Position = vitri;
                    return;
                }
                else
                {
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.DS1.Vattu);
                }
                try
                {                                       
                    bdsCTPX.RemoveCurrent();
                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.DS1.CTPX);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa vật tư. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.cTPXTableAdapter.Fill(this.DS1.CTPX);
                    bdsCTPX.Position = vitri;
                    return;
                }
            }

            if (bdsCTPX.Count == 0)
            {
                btnThemVT.Enabled = true;
                btnXoaVT.Enabled = btnGhiVT.Enabled = btnSuaVT.Enabled = false;
                return;
            }
        }

        private void btnGhiVT_Click(object sender, EventArgs e)
        {                        
            if (txtMAVT.Text.Trim()=="")
            {
                MessageBox.Show("Tên vật tư không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            if (txtDONGIA.Text.Trim()=="")
            {
                MessageBox.Show("Đơn giá không được thiếu", "", MessageBoxButtons.OK);
                return;
            }
            try
            {                
                    if (int.TryParse(txtSOLUONG.Text, out int soluong))
                    {
                        string statement = "EXEC sp_KiemTraSoLuongcTPX '" + txtHOTENKH.Text + "', '" + txtMAVT.Text + "', " + soluong;
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }            
                        
            try
            {   if(ThemVT==true)
                {
                    UpdateSoLuongTonVattu(txtMAVT.Text, Convert.ToInt32(txtSOLUONG.Text), true);
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(DS1.Vattu);
                    ThemVT = false;
                }
                if(SuaVT==true)
                {
                    Console.WriteLine(soluongcu);
                    Console.WriteLine(Convert.ToInt32(txtSOLUONG.Text));
                        if (soluongcu > Convert.ToInt32(txtSOLUONG.Text))
                        {
                            int sl = soluongcu - Convert.ToInt32(txtSOLUONG.Text);
                            if(UpdateSoLuongTonVattu(txtMAVT.Text, sl, false) == false) return;                            
                            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.vattuTableAdapter.Update(DS1.Vattu);
                        }
                        else if (soluongcu < Convert.ToInt32(txtSOLUONG.Text))
                        {
                            int sl = Convert.ToInt32(txtSOLUONG.Text) - soluongcu;
                            UpdateSoLuongTonVattu(txtMAVT.Text, sl, true);
                            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.vattuTableAdapter.Update(DS1.Vattu);
                        }                                                                        
                    SuaVT = false;
                }                

                bdsCTPX.EndEdit();
                bdsCTPX.ResetCurrentItem();
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Update(this.DS1.CTPX);                             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư vào chi tiết Phiếu Xuất: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = true;
            btnGhiVT.Enabled = btnUndoVT.Enabled = false;
            dgvCTPX.Enabled = true;
            cmbVattuCTPX.Enabled = txtSOLUONG.Enabled = txtDONGIA.Enabled = false;
            cmbTenKho.Enabled = true;
        }


        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {            
            if (txtMAPX.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã Phiếu Xuất trước khi chọn đơn đặt!", "", MessageBoxButtons.OK);
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
                        txtHOTENKH.Text = form.SelectedMADDH;
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

        private void ImportcTPXFromSelectedDDH(DataRow[] rows)
        {
            try
            {
                foreach (DataRow row in rows)
                {
                    bdsCTPX.AddNew();                    
                    ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAPX"] = txtMAPX.Text;
                    ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAVT"] = row["MAVT"];
                    ((DataRowView)bdsCTPX[bdsCTPX.Position])["SOLUONG"] = row["SOLUONG"];
                    ((DataRowView)bdsCTPX[bdsCTPX.Position])["DONGIA"] = row["DONGIA"];                    
                    bdsCTPX.EndEdit();
                    bdsCTPX.ResetCurrentItem();
                    UpdateSoLuongTonVattu(Convert.ToString(row["MAVT"]), Convert.ToInt32(row["SOLUONG"]), true);
                }
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Update(this.DS1.Vattu);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Update(this.DS1.CTPX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void gcPhieuXuat_Click(object sender, EventArgs e)
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

        private void btnUndoVT_Click(object sender, EventArgs e)
        {
            if(bdsCTPX.Count > 0)
            {
                btnThemVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = true;
                btnGhiVT.Enabled = btnUndoVT.Enabled = false;
            }
            else
            {
                btnThemVT.Enabled = true;
                btnGhiVT.Enabled = btnUndoVT.Enabled = btnXoaVT.Enabled = btnSuaVT.Enabled = false;
            }
            dgvCTPX.Enabled = true;
            cmbVattuCTPX.Enabled = txtSOLUONG.Enabled = txtDONGIA.Enabled = false;
            ThemVT = SuaVT = false;
            cmbTenKho.Enabled = true;
            try
            {
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS1.CTPX);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload CTPX khi undo!", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void cmbVattuCTPX_SelectedIndexChanged(object sender, EventArgs e)
        {                        
            try
            {
                if (cmbVattuCTPX.SelectedValue != null)
                    txtMAVT.Text = cmbVattuCTPX.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnSuaVT_Click(object sender, EventArgs e)
        {
            soluongcu = Convert.ToInt32(txtSOLUONG.Text);
            Console.WriteLine(soluongcu);
            dgvCTPX.Enabled=false;
            cmbVattuCTPX.Enabled = false;
            cmbTenKho.Enabled = false;
            txtSOLUONG.Enabled = txtDONGIA.Enabled = true;
            btnThemVT.Enabled = btnSuaVT.Enabled = btnXoaVT.Enabled = false;
            btnUndoVT.Enabled = btnGhiVT.Enabled = true;
            SuaVT = true;
        }
    }
}
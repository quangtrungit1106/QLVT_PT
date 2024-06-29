using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLVT_PT
{
    public partial class formVatTu : Form
    {
        bool dangThemVT = false;
        Dictionary<int, String> undoMap = new Dictionary<int, String>();
        int vitri = -1;
        public formVatTu()
        {
            InitializeComponent();
        }
        public void enableButtons()
        {
            this.btnThem.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnGhi.Enabled = false;
            this.btnQuayLai.Enabled = false;
            this.btnChinhSua.Enabled = true;
            this.panelThongTin.Enabled = true;
            this.gcVatTu.Enabled = true;
            dangThemVT = false;
            this.txtMaVT.ReadOnly = true;
            this.txtDVT.ReadOnly = true;
            this.txtSLT.ReadOnly = true;
            this.txtTenVT.ReadOnly = true;

            if (vitri != -1)
            {
                this.btnQuayLai.Enabled = true;
            }
            if (Program.role == "CONGTY")
            {
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnChinhSua.Enabled = false;
                this.btnGhi.Enabled = false;
                this.btnQuayLai.Enabled = false;
                this.panelThongTin.Enabled = false;


            }

        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVatTu.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);

        }

        private void formVatTu_Load(object sender, EventArgs e)
        {
            
            DS1.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS1.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS1.Vattu);

            // TODO: This line of code loads data into the 'DS1.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS1.CTDDH);
            // TODO: This line of code loads data into the 'DS1.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS1.CTPN);
            // TODO: This line of code loads data into the 'DS1.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS1.CTPX);

            enableButtons();
        }

       

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri++;
            undoMap[vitri] = "them,"+this.txtMaVT.Text+","+this.txtTenVT.Text+","+this.txtDVT.Text+","+this.txtSLT.Text;
            this.btnQuayLai.Enabled = true;
            this.txtMaVT.ReadOnly = false;
            this.txtDVT.ReadOnly = false;
            this.txtSLT.ReadOnly = false;
            this.txtTenVT.ReadOnly = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnGhi.Enabled = true;
            this.btnChinhSua.Enabled = false;
            dangThemVT = true;
            this.gcVatTu.Enabled = false;
            this.txtMaVT.Text = "";
            this.txtTenVT.Text = "";
            this.txtDVT.Text = "";
            this.txtSLT.Text = "1";
        }

        private void vattuGridControl_Click(object sender, EventArgs e)
        {

        }
        private bool kiemTraThongTinThayDoi()
        {
            // Kiem tra txtMaVT
            if (this.txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Không bỏ trống Mã vật tư", "Thông báo", MessageBoxButtons.OK);
                this.txtMaVT.Focus();
                return false;
            }
            if (this.txtMaVT.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Mã vật tư không được có khoảng trống", "Thông báo", MessageBoxButtons.OK);
                this.txtMaVT.Focus();
                return false;
            }
            // Kiem tra txtTenVT
            if (this.txtTenVT.Text.Trim() == "")
            {
                MessageBox.Show("Không bỏ trống tên vật tư", "Thông báo", MessageBoxButtons.OK);
                this.txtTenVT.Focus();
                return false;
            }
            // Kiem tra txtDVT
            if (this.txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Không bỏ trống Đơn vị tính", "Thông báo", MessageBoxButtons.OK);
                this.txtDVT.Focus();
                return false;
            }
            // Kiem tra txtSLT
            if (this.txtSLT.Text.Trim() == "")
            {
                MessageBox.Show("Không bỏ trống số lượng tồn", "Thông báo", MessageBoxButtons.OK);
                this.txtSLT.Focus();
                return false;
            }
            if (Regex.IsMatch(this.txtSLT.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số lượng tồn chỉ chấp nhận các chữ số", "Thông báo", MessageBoxButtons.OK);
                this.txtSLT.Focus();
                return false;
            }
            return true;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kiemTraThongTinThayDoi())
            {
                // Ghi them vat tu
                if (dangThemVT)
                {
                    int viTriMaVatTu = -1;
                    viTriMaVatTu = bdsVatTu.Find("MAVT", txtMaVT.Text);
                    if (viTriMaVatTu == -1)
                    {
                        try
                        {
                            String cauTruyVan =
                                "INSERT INTO VATTU (MAVT, TENVT, DVT, SOLUONGTON) " +
                                "VALUES ('" + this.txtMaVT.Text.Trim() + "',N'" +
                                        this.txtTenVT.Text.Trim() + "',N'" +
                                        this.txtDVT.Text.Trim() + "'," +
                                        this.txtSLT.Text + ");";
                            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

                            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                            Program.myReader.Close();
                            
                            // Cau lenh hoan tac
                            undoMap[vitri] = "DELETE FROM VATTU WHERE MaVT = '"+ this.txtMaVT.Text.Trim() +"';";
                            this.vattuTableAdapter.Fill(this.DS1.Vattu);
                            enableButtons();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Thêm Vật Tư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã vật tư này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                // Ghi Sửa vật tư
                else
                {
                    try
                    {
                        /*Lay du lieu truoc khi chon btnGHI - phuc vu btnHOANTAC*/
                        String maVatTu = txtMaVT.Text.Trim();// Trim() de loai bo khoang trang thua
                        DataRowView drv = ((DataRowView)bdsVatTu[bdsVatTu.Position]);
                        String tenVatTu = drv["TENVT"].ToString();
                        String donViTinh = drv["DVT"].ToString();
                        String soLuongTon = (drv["SOLUONGTON"].ToString());

                        String cauTruyVan ="UPDATE VATTU " +
                                "SET " +
                                "TENVT = N'" + this.txtTenVT.Text.Trim() + "'," +
                                "DVT = N'" + this.txtDVT.Text.Trim() + "'," +
                                "SOLUONGTON = " + this.txtSLT.Text + " " +
                                "WHERE MAVT = '" + this.txtMaVT.Text.Trim() + "'";
                        SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

                        Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                        Program.myReader.Close();
                        
                        vitri++;
                        // Cau lenh hoan tac
                        undoMap[vitri] = "UPDATE VATTU " +
                                "SET " +
                                "TENVT = N'" + tenVatTu + "'," +
                                "DVT = N'" + donViTinh + "'," +
                                "SOLUONGTON = " + soLuongTon + " " +
                                "WHERE MAVT = '" + this.txtMaVT.Text.Trim() + "'";
                        this.vattuTableAdapter.Fill(this.DS1.Vattu);
                        enableButtons();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Chỉnh Sửa Vật Tư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if(vitri != -1)
            {
                this.btnQuayLai.Enabled = true;
            }
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vitri = -1;
                enableButtons();
                this.vattuTableAdapter.Fill(this.DS1.Vattu);   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnQuayLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String [] checkUndo = undoMap[vitri].Split(',');
            if (checkUndo[0] == "them" || checkUndo[0] == "chinhsua")
            {
                this.txtMaVT.ReadOnly = true;
                this.txtDVT.ReadOnly = true;
                this.txtSLT.ReadOnly = true;
                this.txtTenVT.ReadOnly = true;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = false;
                this.btnChinhSua.Enabled = true;
                dangThemVT = false;
                this.gcVatTu.Enabled = true;
                if (checkUndo[0] == "them")
                {
                    this.txtMaVT.Text = checkUndo[1];
                    this.txtTenVT.Text = checkUndo[2];
                    this.txtDVT.Text = checkUndo[3];
                    this.txtSLT.Text = checkUndo[4];
                }
                vitri--;
                if(vitri == -1)
                {
                    this.btnQuayLai.Enabled = false;
                }
            }
            else
            {
                try
                {
                    String cauTruyVan = undoMap[vitri];
                    SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    Program.myReader.Close();
                    this.vattuTableAdapter.Fill(this.DS1.Vattu);
                    enableButtons();
                    vitri--;
                    if (vitri == -1)
                    {
                        this.btnQuayLai.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Quay Lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsVatTu.Count == 0)
            {
                btnXoa.Enabled = false;
            }

            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            try
            {
              
                string cauTruyVan = "sp_KiemTraXoaVatTu";
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAVT", this.txtMaVT.Text.Trim());
                if (Program.conn.State == System.Data.ConnectionState.Closed)
                {
                    Program.conn.Open();
                }
                SqlDataReader reader = sqlCommand.ExecuteReader();

                int totalOrderCount = 0;

                if (reader.Read())
                {
                    totalOrderCount = reader.GetInt32(0); // Lấy giá trị từ cột đầu tiên
                }

                reader.Close();
                Program.conn.Close();

                if (totalOrderCount > 0)
                {
                    MessageBox.Show("Vật tư này đã được lập hóa đơn ở Chi nhánh khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                String cauTruyVan = "DELETE FROM VATTU WHERE MaVT = '" + this.txtMaVT.Text.Trim() + "'; ";
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                Program.myReader.Close();

                vitri++;
                undoMap[vitri] = "INSERT INTO VATTU (MAVT, TENVT, DVT, SOLUONGTON)" +
                                "VALUES ('" + this.txtMaVT.Text.Trim() + "',N'" +
                                        this.txtTenVT.Text.Trim() + "',N'" +
                                        this.txtDVT.Text.Trim() + "'," +
                                        this.txtSLT.Text + ");";
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
                enableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Xóa Vật Tư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChinhSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri++;
            undoMap[vitri] = "chinhsua";
            this.btnQuayLai.Enabled = true;
            this.btnGhi.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.txtDVT.ReadOnly = false;
            this.txtSLT.ReadOnly = false;
            this.txtTenVT.ReadOnly = false;
        }

        private void btnInDSVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport_InDanhSachVatTu rpt = new XtraReport_InDanhSachVatTu();
            rpt.lbNgayIn.Text = "Ngày in: " + DateTime.Now.ToString("HH:mm dd/MM/yyyy");
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
     
}
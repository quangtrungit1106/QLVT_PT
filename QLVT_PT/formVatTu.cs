using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class formVatTu : DevExpress.XtraEditors.XtraForm
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
            this.btnGhi.Enabled = true;
            this.btnQuayLai.Enabled = false;
            this.btnChinhSua.Enabled = true;
            this.panelThongTin.Enabled = true;
            this.vattuGridControl.Enabled = true;
            dangThemVT = false;
            this.txtMaVT.ReadOnly = true;
            this.txtMaVT.Text = "";
            this.txtTenVT.Text = "";
            this.txtDVT.Text = "";
            this.txtSLT.Text = "";

            if (vitri != -1)
            {
                this.btnQuayLai.Enabled = true;
            }
            if (Program.role == "CONGTY")
            {
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
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
            this.txtMaVT.ReadOnly = false;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnChinhSua.Enabled = false;
            dangThemVT = true;
            this.vattuGridControl.Enabled = false;
            this.txtMaVT.Text = "";
            this.txtTenVT.Text = "";
            this.txtDVT.Text = "";
            this.txtSLT.Text = "";
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
                                "INSERT INTO VATTU (MAVT, TENVT, DVT, SOLUONGTON)" +
                                "VALUES ('" + this.txtMaVT.Text.Trim() + "','" +
                                        this.txtTenVT.Text.Trim() + "','" +
                                        this.txtDVT.Text.Trim() + "'," +
                                        this.txtSLT.Text + ");";
                            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

                            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                            Program.myReader.Close();
                            this.btnXoa.Enabled = true;
                            this.btnChinhSua.Enabled = true;
                            dangThemVT = false;
                            this.vattuGridControl.Enabled = true;
                            this.vattuTableAdapter.Fill(this.DS1.Vattu);
                            
                            vitri++;
                            // Cau lenh hoan tac
                            undoMap[vitri] = "DELETE FROM VATTU WHERE MaVT = '"+ this.txtMaVT.Text.Trim() +"';";
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
            try
            {
                String cauTruyVan = undoMap[vitri];
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                Program.myReader.Close();
                this.vattuTableAdapter.Fill(this.DS1.Vattu);
                enableButtons();
                vitri--;
                if(vitri == -1)
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
     
}
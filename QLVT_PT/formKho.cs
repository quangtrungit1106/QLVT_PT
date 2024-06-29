using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class formKho : Form
    {
        int viTri = 0;
        string maCN = "";
        int checkMaKho = -1;
        bool them = false;
        bool sua = false;
        public formKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);
        }

        private void formKho_Load(object sender, EventArgs e)
        {

            DS1.EnforceConstraints = false;

            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.DS1.ChiNhanh);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS1.Kho);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS1.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS1.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS1.PhieuXuat);

            if (Program.role == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnUndo.Enabled =  false;
                
                panelControl2.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnSua.Enabled = true;
                btnGhi.Enabled = btnUndo.Enabled = false;
                panelControl2.Enabled = false;
            }
            maCN = ((DataRowView)bdsCN[0])["MACN"].ToString();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsKho.Position;
            panelControl2.Enabled = true;
            bdsKho.AddNew();
            txtMaKho.Enabled = true;
            txtTenKho.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMACN.Text = maCN.ToString();

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcKho.Enabled = false;
            them = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho này vì đã lập đơn hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho này vì đã lập phiếu nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho này vì đã lập phiếu xuất", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa kho này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maKho = "";
                try
                {
                    maKho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();  //giữ lại kiểm tra khi bị lỗi xóa
                    bdsKho.RemoveCurrent();     //xóa trên màn hình
                    this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khoTableAdapter.Update(this.DS1.Kho);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa kho. Bạn hãy thử xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.khoTableAdapter.Fill(this.DS1.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", maKho);
                    return;
                }
            }

            if (bdsKho.Count == 0) btnXoa.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsKho.Position;
            panelControl2.Enabled = true;
            txtMaKho.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcKho.Enabled = false;
            sua = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được để trống!", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Tên kho không được để trống!", "", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }

            //Mã kho không được trùng trên các phân mảnh nếu dùng nút thêm
            if (them == true)
            {
                string statement = "EXEC sp_KiemTraMAKHO " + txtMaKho.Text;
                Program.myReader = null;
                Program.myReader = Program.ExecSqlDataReader(statement);
                if (Program.myReader == null)
                    return;
                Program.myReader.Read();
                checkMaKho = Program.myReader.GetInt32(0);
                if (checkMaKho == 1)
                {
                    MessageBox.Show("Mã kho đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    txtMaKho.Focus();
                    Program.myReader.Close();
                    return;
                }
                Program.myReader.Close();

            }

            try
            {
                
                bdsKho.EndEdit();
                bdsKho.ResetCurrentItem();
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Update(this.DS1.Kho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            gcKho.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            panelControl2.Enabled = false;
            them = false;
            sua = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKho.CancelEdit();
            if (btnThem.Enabled == false) bdsKho.Position = viTri;
            panelControl2.Enabled = false;
            gcKho.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled =  true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            them = false;
            sua = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khoTableAdapter.Fill(this.DS1.Kho);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gcKho_Click(object sender, EventArgs e)
        {

        }

        private void nhanVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

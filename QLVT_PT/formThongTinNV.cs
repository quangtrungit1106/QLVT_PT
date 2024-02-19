using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QLVT_PT
{
    public partial class formThongTinNV : DevExpress.XtraEditors.XtraForm
    {
        public formThongTinNV()
        {
            InitializeComponent();
        }

        private void chinhSuaHoTen_Click(object sender, EventArgs e)
        {
            textHoNV.ReadOnly = false;
            textTenNV.ReadOnly = false;
            btnLuu.Enabled = true;

        }

        private void chinhSuaCCCD_Click(object sender, EventArgs e)
        {
            textSoCCCD.ReadOnly = false;
            btnLuu.Enabled = true;
        }

        private void chinhSuaDiaChi_Click(object sender, EventArgs e)
        {
            textDiaChiNV.ReadOnly = false;
            btnLuu.Enabled = true;
        }

        private void chinhSuaNgaySinhNV_Click(object sender, EventArgs e)
        {
            dateNgaySinhNV.ReadOnly = false;
            btnLuu.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormThongTinNV_Load(object sender, EventArgs e)
        {

            String statement = "EXEC sp_LayThongTinNV '" + Program.userName + "'";// exec sp_LayThongTinNV
            Program.myReader = Program.ExecSqlDataReader(statement);
            if (Program.myReader == null)
                return;
            // đọc một dòng của myReader - điều này là hiển nhiên vì kết quả chỉ có 1 dùng duy nhất
            Program.myReader.Read();

            this.textChiNhanh.Text = "CHI NHÁNH " + (Program.brand + 1);
            this.textMaNV.Text = Program.userName;
            this.textHoNV.Text = Program.myReader.GetString(0);
            this.textTenNV.Text = Program.myReader.GetString(1);
            this.textSoCCCD.Text = Program.myReader.GetString(2);
            this.textDiaChiNV.Text = Program.myReader.GetString(3);
            this.dateNgaySinhNV.DateTime = Program.myReader.GetDateTime(4);
            Program.myReader.Close();
        }

        private void dateNgaySinhNV_EditValueChanged(object sender, EventArgs e)
        {

        }
        private bool kiemTraThongTinThayDoi()
        {
            /*kiem tra textHoNV*/
            this.textHoNV.Text = this.textHoNV.Text.Trim();
            if (this.textHoNV.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ", "Thông báo", MessageBoxButtons.OK);
                this.textHoNV.Focus();
                return false;
            }


            /*kiem tra textTenNV*/
            this.textTenNV.Text = this.textTenNV.Text.Trim();
            if (this.textTenNV.Text == "")
            {
                MessageBox.Show("Không bỏ trống tên", "Thông báo", MessageBoxButtons.OK);
                this.textTenNV.Focus();
                return false;
            }
            if (this.textTenNV.Text.Contains(" "))
            {
                MessageBox.Show("Tên không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                this.textTenNV.Focus();
                return false;
            }
            /*kiem tra textSoCCCD*/
            this.textSoCCCD.Text = this.textSoCCCD.Text.Trim();
            if (this.textSoCCCD.Text == "")
            {
                MessageBox.Show("Không bỏ trống CCCD", "Thông báo", MessageBoxButtons.OK);
                this.textSoCCCD.Focus();
                return false;
            }

            if (Regex.IsMatch(this.textSoCCCD.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số CCCD chỉ chấp nhận chữ số", "Thông báo", MessageBoxButtons.OK);
                this.textSoCCCD.Focus();
                return false;
            }

            /*kiem tra textDiaChiNV*/
            this.textDiaChiNV.Text = this.textDiaChiNV.Text.Trim();
            if (this.textDiaChiNV.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                this.textDiaChiNV.Focus();
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraThongTinThayDoi())
            {
                this.textDiaChiNV.ReadOnly = true;
                this.textHoNV.ReadOnly = true;
                this.textTenNV.ReadOnly = true;
                this.textSoCCCD.ReadOnly = true;
                this.dateNgaySinhNV.ReadOnly = true;
                this.btnLuu.Enabled = false;
                String cauTruyVan =
                       "UPDATE NHANVIEN " +
                       "SET " +
                       "HO = N'" + this.textHoNV.Text + "', " +
                       "TEN = N'" + this.textTenNV.Text + "', " +
                       "SOCMND = '" + this.textSoCCCD.Text + "', " +
                       "DIACHI = N'" + this.textDiaChiNV.Text + "', " +
                       "NGAYSINH = '" + this.dateNgaySinhNV.DateTime + "' " +
                       "WHERE " +
                       "MaNV = '" + this.textMaNV.Text + "'; ";
                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                Program.myReader.Close();
            }
        }
    }
}
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
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLVT_PT
{
    public partial class formTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        private string matKhau = "";
        private string maNV = "";
        private string vaiTro = "";
        public formTaoTaiKhoan()
        {
            InitializeComponent();
        }
        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra textMaNV*/
            this.textMaNV.Text = this.textMaNV.Text.Trim();
            if (this.textMaNV.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                this.textTaiKhoan.Focus();
                return false;
            }
            if (this.textMaNV.Text.Contains(" "))
            {
                MessageBox.Show("Mã nhân viên không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                this.textTaiKhoan.Focus();
                return false;
            }
            String statement = "EXEC sp_LayThongTinNV '" + this.textMaNV.Text + "'";// exec sp_LayThongTinNV
            Program.myReader = null;
            Program.myReader = Program.ExecSqlDataReader(statement);
            if (!Program.myReader.HasRows)
            {
                Program.myReader.Close();
                MessageBox.Show("Mã nhân viên không đúng", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            Program.myReader.Close();
            /*kiem tra textHoNV*/
            this.textTaiKhoan.Text = this.textTaiKhoan.Text.Trim();
            if (this.textTaiKhoan.Text == "")
            {
                MessageBox.Show("Không bỏ trống tên", "Thông báo", MessageBoxButtons.OK);
                this.textTaiKhoan.Focus();
                return false;
            }
            if (this.textTaiKhoan.Text.Contains(" "))
            {
                MessageBox.Show("Tên không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                this.textTaiKhoan.Focus();
                return false;
            }


            /*kiem tra textMatKhau*/
            this.textMatKhau.Text = this.textMatKhau.Text.Trim();
            if (this.textMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                this.textMatKhau.Focus();
                return false;
            }
            if (this.textTaiKhoan.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                this.textTaiKhoan.Focus();
                return false;
            }
            /*kiem tra textNhapLaiMatKhau*/
            this.textXacNhanMK.Text = this.textXacNhanMK.Text.Trim();
            if (this.textXacNhanMK.Text == "")
            {
                MessageBox.Show("Nhập lại mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                this.textXacNhanMK.Focus();
                return false;
            }
            if (this.textTaiKhoan.Text.Contains(" "))
            {
                MessageBox.Show("Nhập lại mật khẩu không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                this.textXacNhanMK.Focus();
                return false;
            }
            if(this.textMatKhau.Text != this.textXacNhanMK.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK);
                this.textXacNhanMK.Focus();
                return false;
            }
            return true;
        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;

            // Kiểm tra xem CheckEdit đã được kiểm tra hay không
            if (checkEdit.Checked)
            {
                // Nếu được kiểm tra, hiển thị mật khẩu rõ ràng
                textMatKhau.Properties.PasswordChar = '\0'; // Thiết lập PasswordChar về null để hiển thị rõ ràng
            }
            else
            {
                // Nếu không được kiểm tra, hiển thị mật khẩu bằng dấu *
                textMatKhau.Properties.PasswordChar = '*'; // Thiết lập PasswordChar về '*' để ẩn mật khẩu
            }
        }

        private void showConfirmPass_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;

            // Kiểm tra xem CheckEdit đã được kiểm tra hay không
            if (checkEdit.Checked)
            {
                // Nếu được kiểm tra, hiển thị mật khẩu rõ ràng
                textXacNhanMK.Properties.PasswordChar = '\0'; // Thiết lập PasswordChar về null để hiển thị rõ ràng
            }
            else
            {
                // Nếu không được kiểm tra, hiển thị mật khẩu bằng dấu *
                textXacNhanMK.Properties.PasswordChar = '*'; // Thiết lập PasswordChar về '*' để ẩn mật khẩu
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
               vaiTro = cmbVaiTro.SelectedItem.ToString();
        }
        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            cmbVaiTro.Items.Clear();
            if (Program.role == "CONGTY")
            {
                cmbVaiTro.Items.Add("CONGTY");
            }
            else
            {
                cmbVaiTro.Items.Add("CHINHANH");
                cmbVaiTro.Items.Add("USER");
            }
            cmbVaiTro.SelectedIndex = 0;
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuDauVao())
            {
                String cauTruyVan =
                        "EXEC sp_TaoTaiKhoan '" + this.textTaiKhoan.Text + "' , '" + this.textMatKhau.Text + "', '"
                        + this.textMaNV.Text + "', '" + vaiTro + "'";

                SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                    /*khong co ket qua tra ve thi ket thuc luon*/
                    if (Program.myReader == null)
                    {
                        return;
                    }

                    MessageBox.Show("Đăng kí tài khoản thành công\n\n", "Thông Báo", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
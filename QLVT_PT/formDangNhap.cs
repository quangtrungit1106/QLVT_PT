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

namespace QLVT_PT
{
    public partial class formDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection connPublisher = new SqlConnection();
        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // adapter dùng để đưa dữ liệu từ view sang database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùng adapter thì mới đổ vào data table được
            da.Fill(dt);


            connPublisher.Close();
            Program.bindingSource.DataSource = dt;


            boxChiNhanh.DataSource = Program.bindingSource;
            boxChiNhanh.DisplayMember = "TENCN";
            boxChiNhanh.ValueMember = "TENSERVER";
        }
        public formDangNhap()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoiDatabaseGoc() == 0)
                return;
            //Lấy 2 cái đầu tiên của danh sách
            layDanhSachPhanManh("SELECT * FROM view_DanhSachPhanManh");
            boxChiNhanh.SelectedIndex = 0;
            Program.serverName = boxChiNhanh.SelectedValue.ToString();
        }
        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            // Chuyển đổi sender thành CheckEdit
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

        /**
         * Step 1: Kiểm tra tài khoản & mật khẩu xem có bị trống không ?
         * Step 2: gán loginName & loginPassword với tài khoản mật khẩu được nhập
         * loginName và loginPassword dùng để đăng nhập vào phân mảnh này
         * Step 3: cập nhật currentLogin & currentPassword
         * Step 4: chạy stored procedure DANG NHAP de lay thong tin nguoi dung
         * Step 5: gán giá trị Mã nhân viên - họ tên - vai trò ở góc màn hình
         * Step 6: ẩn form hiện tại & hiện các nút chức năng còn lại
         */
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /* Step 1*/
            if (textTaiKhoan.Text.Trim() == "" || textMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản & mật khẩu không thể bỏ trống", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            /* Step 2*/
            Program.loginName = textTaiKhoan.Text.Trim();
            Program.loginPassword = textMatKhau.Text.Trim();
            
            if (Program.KetNoi() == 0)
                return;
            /* Step 3*/
            Program.brand = boxChiNhanh.SelectedIndex;
            Program.currentLogin = Program.loginName;
            Program.currentPassword = Program.loginPassword;


            /* Step 4*/
            String statement = "EXEC sp_DangNhap '" + Program.loginName + "'";// exec sp_DangNhap 'TP'
            Program.myReader = Program.ExecSqlDataReader(statement);
            if (Program.myReader == null)
                return;
            // đọc một dòng của myReader - điều này là hiển nhiên vì kết quả chỉ có 1 dùng duy nhất
            Program.myReader.Read();


            /* Step 5*/
            Program.userName = Program.myReader.GetString(0);// lấy userName
            if (Convert.IsDBNull(Program.userName))
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập \n Hãy thử tài khoản khác", "Thông Báo", MessageBoxButtons.OK);
            }



            Program.staff = Program.myReader.GetString(1);
            Program.role = Program.myReader.GetString(2);

            Program.myReader.Close();
            //Program.conn.Close();

            Program.FormChinh.MANV.Text = "MÃ NHÂN VIÊN: " + Program.userName;
            Program.FormChinh.HOTEN.Text = "HỌ TÊN: " + Program.staff;
            Program.FormChinh.MAVAITRO.Text = "VAI TRÒ: " + Program.role;

            this.Close();
            /* Step 6*/
            Program.FormChinh.enableButtons();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.serverName = boxChiNhanh.SelectedValue.ToString();
                
            }
            catch (Exception)
            {

            }
        }
    }
}
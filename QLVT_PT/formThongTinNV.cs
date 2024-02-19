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
            textHoNV.Properties.HideSelection = false;

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String cauTruyVan =
                   "UPDATE NHANVIEN "+
                   "SET "+
                   "HO = N'" + this.textHoNV.Text +"', "+
                   "TEN = N'"+ this.textTenNV.Text +"', "+
                   "SOCMND = '"+ this.textSoCCCD.Text +"', " +
                   "DIACHI = N'"+this.textDiaChiNV.Text +"', "+
                   "NGAYSINH = '"+this.dateNgaySinhNV.DateTime+"' "+
                   "WHERE "+
                   "MaNV = '"+ this.textMaNV.Text +"'; ";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);

            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
            Program.myReader.Close();


            textDiaChiNV.ReadOnly = true;
            textHoNV.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textSoCCCD.ReadOnly = true;
            dateNgaySinhNV.ReadOnly = true;
            btnLuu.Enabled = true;
        }
    }
}
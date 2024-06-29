using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_PT
{
    public partial class FormRpt_HoatDongNhanVien : Form
    {
        public FormRpt_HoatDongNhanVien()
        {
            InitializeComponent();
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
                this.dSNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dSNVTableAdapter.Fill(this.DS1.DSNV);
            }
        }        

        private void FormRpt_HoatDongNhanVien_Load(object sender, EventArgs e)
        {
            DS1.EnforceConstraints = false;

            this.dSNVTableAdapter.Connection.ConnectionString=Program.connstr;
            this.dSNVTableAdapter.Fill(DS1.DSNV);

            cmbChiNhanh.DataSource = Program.bindingSource;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.brand;
            if (Program.role == "CONGTY")
            {               
                cmbChiNhanh.Enabled = true;
            }
            else
            {                
                cmbChiNhanh.Enabled = false;                
            }
            txtMANV.Enabled = false;
        }
       
        private void hOTENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMANV.Text = cmbChiNhanh.SelectedValue.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "", MessageBoxButtons.OK);
                return;
            }
            if (dtTuNgay.Text.Trim() == "" || dtDenNgay.Text.Trim()=="")
            {
                MessageBox.Show("Vui lòng chọn thời gian!", "", MessageBoxButtons.OK);
                return;
            }
            XtraReport_HoatDongNhanVien rpt = new XtraReport_HoatDongNhanVien(Convert.ToInt32(txtMANV.Text), dtTuNgay.Text, dtDenNgay.Text);
            rpt.lbTuNgay.Text = dtTuNgay.Text;
            rpt.lbDenNgay.Text = dtDenNgay.Text;
            rpt.lbHoTen.Text = cmbHoTen.Text.Substring(0,cmbHoTen.Text.IndexOf('-')).Trim();
            rpt.lbNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");              
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }                
    }
}

﻿using DevExpress.XtraEditors;
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
    public partial class FormRpt_TongHopNhapXuat : Form
    {
        public FormRpt_TongHopNhapXuat()
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
        }        

        private void FormRpt_TongHopNhapXuat_Load(object sender, EventArgs e)
        {            
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
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if (dtTuNgay.Text.Trim() == "" || dtDenNgay.Text.Trim()=="")
            {
                MessageBox.Show("Vui lòng chọn thời gian!", "", MessageBoxButtons.OK);
                return;
            }
            XtraReport_TongHopNhapXuatVatTu rpt = new XtraReport_TongHopNhapXuatVatTu(dtTuNgay.Text, dtDenNgay.Text);
            rpt.lbTuNgay.Text = dtTuNgay.Text;
            rpt.lbDenNgay.Text = dtDenNgay.Text;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }                
    }
}

using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using QLVT_PT.SubForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_PT
{
    public partial class formChinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public formChinh()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        /************************************************************
        * CheckExists:
        * Để tránh việc người dùng ấn vào 1 form đến 2 lần chúng ta 
        * cần sử dụng hàm này để kiểm tra xem cái form hiện tại đã 
        * có trong bộ nhớ chưa
        * Nếu có trả về "f"
        * Nếu không trả về "null"
        ************************************************************/
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in Application.OpenForms)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public void enableButtons()
        {

            btnDangNhap.Enabled = false;
            btnDangXuat.Enabled = true;

            pageNhapXuat.Visible = true;
            pageBaoCao.Visible = true;
            btnTaoTaiKhoan.Enabled = true;
            btnThongTinNV.Enabled = true;   

            if (Program.role == "USER")
            {
                btnTaoTaiKhoan.Enabled = false;
            }

            //pageTaiKhoan.Visible = true;


        }
        /************************************************************
         * Dispose: giải phóng các form khỏi bộ nhớ. Ví dụ form nhân viên,...
         * Close: đóng hoàn toàn chương trình lại
         ************************************************************/
        private void logout()
        {
            foreach (Form f in this.MdiChildren)
                f.Dispose();
        }

        /************************************************************
        * Kiểm tra xem form đăng nhập đã có trong hệ thống chưa?
        * Step 1: Nếu có thì chạy form đăng nhập
        * Step 2: Nếu không thì khởi tạo một form đăng nhập mới rồi 
        * ném vào đưa vào xtraTabbedMdiManager
        * 
        * f.MdiParent = this; cái form này có form cha là this - tức form chính
        ************************************************************/
        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = CheckExists(typeof(formDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formDangNhap form = new formDangNhap();
                form.MdiParent = this;
                form.Show();
            }
          
        }
        private void FormChinh_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();

            btnDangNhap.Enabled = true;
            btnDangXuat.Enabled = false;
            btnTaoTaiKhoan.Enabled = false;
            btnThongTinNV.Enabled = false;

            pageNhapXuat.Visible = false;
            pageBaoCao.Visible = false;
            //pageTaiKhoan.Visible = false;

            Form f = this.CheckExists(typeof(formDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formDangNhap form = new formDangNhap();
                form.MdiParent = this;
                form.Show();
            }

            Program.FormChinh.MANV.Text = "MÃ NHÂN VIÊN:";
            Program.FormChinh.HOTEN.Text = "HỌ TÊN:";
            Program.FormChinh.MAVAITRO.Text = "VAI TRÒ:";
        }

        private void btnTaoTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formTaoTaiKhoan));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formTaoTaiKhoan form = new formTaoTaiKhoan();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnThongTinNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formThongTinCaNhan));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formThongTinCaNhan form = new formThongTinCaNhan();
                form.MdiParent = this;
                form.Show();
            }
            
        }

        private void btnVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formVatTu form = new formVatTu();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formKho));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formKho form = new formKho();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formNhanVien form = new formNhanVien();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formPhieuNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formPhieuNhap form = new formPhieuNhap();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnHDNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(FormRpt_HoatDongNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormRpt_HoatDongNhanVien form = new FormRpt_HoatDongNhanVien();
                form.MdiParent = this;
                form.Show();
            }                                               
        }

        private void btnDonDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
            Form f = this.CheckExists(typeof(formDatHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                formDatHang form = new formDatHang();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDSDatHangChuaNhap_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraReport_DonDatHangChuaNhap rpt = new XtraReport_DonDatHangChuaNhap();
            rpt.lbNgayIn.Text = "Ngày in: " + DateTime.Now.ToString("HH:mm dd/MM/yyyy");

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}

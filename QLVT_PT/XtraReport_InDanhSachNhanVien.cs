using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_PT
{
    public partial class XtraReport_InDanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {        
        public XtraReport_InDanhSachNhanVien()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();            
        }
    }
}
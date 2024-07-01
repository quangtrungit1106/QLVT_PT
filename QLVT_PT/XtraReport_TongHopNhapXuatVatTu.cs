using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_PT
{
    public partial class XtraReport_TongHopNhapXuatVatTu : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_TongHopNhapXuatVatTu(string tungay, string denngay)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = tungay;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = denngay;
            this.sqlDataSource1.Fill();
        }

    }
}

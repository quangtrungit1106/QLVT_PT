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
    public partial class formDonDatHangChuaNhap : Form
    {
        public string SelectedMADDH { get; private set; }
        public string SelectedMAKHO { get; private set; }

        public DataRow[] dataRows { get; private set; }
        public formDonDatHangChuaNhap()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDDHChuaNhap.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);

        }

        private void formDonDatHangChuaNhap_Load(object sender, EventArgs e)
        {
            this.DS1.EnforceConstraints = false;            

            this.dDHChuaNhapTableAdapter.Connection.ConnectionString = Program.connstr;            
            this.dDHChuaNhapTableAdapter.Fill(this.DS1.DDHChuaNhap);            

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS1.CTDDH);    
            txtMaDDH.Enabled = txtMAKHO.Enabled= false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.bdsDDHChuaNhap.Current != null)
            {                
                SelectedMADDH = txtMaDDH.Text;
                SelectedMAKHO = txtMAKHO.Text;
                dataRows = DS1.CTDDH.Select($"MasoDDH='{txtMaDDH.Text}'");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }        
    }
}

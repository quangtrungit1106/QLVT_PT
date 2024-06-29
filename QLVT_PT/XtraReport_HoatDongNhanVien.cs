using DevExpress.DataAccess.Wizard.Presenters;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLVT_PT
{
    public partial class XtraReport_HoatDongNhanVien : DevExpress.XtraReports.UI.XtraReport
    {                
        public XtraReport_HoatDongNhanVien(int manv, string tungay, string denngay)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;            
            this.sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = tungay;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = denngay;
            this.sqlDataSource1.Fill();           
            if (CalculateTotalAmount() == true)
            {
                BeforePrint += XtraReport_HoatDongNhanVien_BeforePrint;
            }
            else
            {
                MessageBox.Show("Nhân viên không hoạt động trong thời gian này!", "", MessageBoxButtons.OK);                
            }            
        }

        private bool CalculateTotalAmount()
        {
            long totalAmount = 0;            
            foreach (var row in this.sqlDataSource1.Result["sp_HoatDongNhanVien"])
            {
                totalAmount += Convert.ToInt64(row["TRIGIA"]);
            }            
            lbTongCong.Text = totalAmount.ToString();
            return (totalAmount==0) ? false : true;
        }

        private void XtraReport_HoatDongNhanVien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Console.WriteLine(lbTongCong.Text);
            string tienchu = "(" + NumberToText(Convert.ToInt64(lbTongCong.Text)) + ")";
            lbTienChu.Text = tienchu;            
            Console.WriteLine(lbTienChu.Text);
        }

        public string NumberToText(long inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            long number = Convert.ToInt64(sNumber);            

            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng" : "");
        }            
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Report
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            double tiendv = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("select sum(tongtiendv) from tbldichvuthem"));
            double tienphong = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("select sum(tongtiendat) from tblctdatphong"));
            textBox1.Text= DataProvider.Instance.ExecuteScalar("select count(makh) from tblkhachhang").ToString();
            textBox2.Text= DataProvider.Instance.ExecuteScalar("select count(manv) from tblnhanvien").ToString();
            textBox3.Text= DataProvider.Instance.ExecuteScalar("select count(mahd) from tblhoadon").ToString();
            textBox4.Text = tienphong.ToString();
            textBox5.Text = tiendv.ToString();
            textBox6.Text = (tienphong + tiendv).ToString();
        }
    }
}

using QLKS.Data_Access_Layer;
using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmhoadon : Form
    {
        public frmhoadon()
        {
            InitializeComponent();
            LoadBillInfo();
            disable_edit();
        }
        #region methods
        void LoadBillInfo()
        {
            dgvcthd.DataSource = BillDAO.Instance.GetBillInfo();
        }
        void disable_edit()
        {
            txtmahd.ReadOnly = true;
            txtmakh.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txtmapd.ReadOnly = true;
            txtamount.ReadOnly = true;
            txtmapd.ReadOnly = true;
            txtStatus.ReadOnly = true;
        }
        void payBill(string mahd)
        {
            BillDTO transfer = new BillDTO(mahd);
            if (BillDAO.Instance.payBill(transfer) >= 1)
            {
                MessageBox.Show("Đã thanh toán hóa đơn");
                LoadBillInfo();
            }
            else
                MessageBox.Show("Không thể thanh toán hóa đơn");
        }
        #endregion
        #region events
        private void dgvcthd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvcthd.Rows.Count - 1 && e.ColumnIndex >= 0)
            {
                txtmahd.Text = dgvcthd.Rows[e.RowIndex].Cells["mahd"].Value.ToString();
                txtmakh.Text = dgvcthd.Rows[e.RowIndex].Cells["makh"].Value.ToString();
                txtmanv.Text = dgvcthd.Rows[e.RowIndex].Cells["manv"].Value.ToString();
                txtmapd.Text = dgvcthd.Rows[e.RowIndex].Cells["mapd"].Value.ToString();
                txtStatus.Text = dgvcthd.Rows[e.RowIndex].Cells["tinhtrang"].Value.ToString();
                txtamount.Text = dgvcthd.Rows[e.RowIndex].Cells["tongtien"].Value.ToString();
                lbldate.Text = dgvcthd.Rows[e.RowIndex].Cells["ngaythanhtoan"].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvcthd.Rows[dgvcthd.CurrentCell.RowIndex].Cells["tinhtrang"].Value.ToString() == "Ðã thanh toán")
                MessageBox.Show("Không thể thanh toán lại hóa đơn đã được thanh toán");
            else
                payBill(txtmahd.Text);
        }
        #endregion

        private void frmhoadon_Load(object sender, EventArgs e)
        {
            dgvcthd.DataSource = BillDAO.Instance.GetBillInfo();
        }
    }
}

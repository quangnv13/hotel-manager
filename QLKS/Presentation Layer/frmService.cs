using QLKS.Data_Access_Layer;
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
    public partial class frmService : Form
    {
        public frmService()
        {
            InitializeComponent();
            loadService();
        }
        void loadService()
        {
            dgvDv.DataSource= ServicesDAO.Instance.getService();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex<=dgvDv.Rows.Count-1 &&e.ColumnIndex>=0)
            {
                txtMadv.Text = dgvDv.Rows[e.RowIndex].Cells["madv"].Value.ToString();
                txtTendv.Text = dgvDv.Rows[e.RowIndex].Cells["tendv"].Value.ToString();
                txtGia.Text = dgvDv.Rows[e.RowIndex].Cells["gia"].Value.ToString();
                txtDvtinh.Text = dgvDv.Rows[e.RowIndex].Cells["donvitinh"].Value.ToString();
            }
        }
    }
}

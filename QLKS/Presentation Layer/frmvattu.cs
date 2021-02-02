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
    public partial class frmvattu : Form
    {
        public frmvattu()
        {
            InitializeComponent();
            disable_edit();
            loadListSupplies();
        }
        #region properties
        #endregion
        #region methods
        void loadListSupplies()
        {
            dgvSupplies.DataSource=SuppliesDAO.Instance.getListSupplies();
        }
        void disable_edit()
        {
            txtmavt.ReadOnly = true;
            txttenvt.ReadOnly = true;
            txtlp.ReadOnly = true;
            txtsoluong.ReadOnly = true;
        }
        void enable_edit()
        {
            txtmavt.ReadOnly = false;
            txttenvt.ReadOnly = false;
            txtlp.ReadOnly = false;
            txtsoluong.ReadOnly = false;
        }
        void reset_textbox()
        {
            txtmavt.Text = "";
            txttenvt.Text = "";
            txtlp.Text = "";
            txtsoluong.Text = "";
        }
        #endregion
        #region events
        private void dgvSupplies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvSupplies.Rows.Count - 1 && e.ColumnIndex >= 0)
            {
                txtmavt.Text = dgvSupplies.Rows[e.RowIndex].Cells["mavattu"].Value.ToString();
                txttenvt.Text = dgvSupplies.Rows[e.RowIndex].Cells["tenvattu"].Value.ToString();
                txtlp.Text = dgvSupplies.Rows[e.RowIndex].Cells["maloai"].Value.ToString();
                txtsoluong.Text = dgvSupplies.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable_edit();
            reset_textbox();
            dgvSupplies.CurrentCell = dgvSupplies.Rows[dgvSupplies.Rows.Count].Cells[0];
            dgvSupplies.CurrentRow.Selected = true;
        }
        #endregion
    }
}

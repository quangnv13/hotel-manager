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

namespace QLKS.Presentation_Layer
{
    public partial class frmAddService : Form
    {
        public frmAddService()
        {
            InitializeComponent();
            loadCombobox();
            loadListServices();
        }
        void loadCombobox()
        {
            cbxmadv.DataSource = ServicesDAO.Instance.getService();
            cbxmadv.DisplayMember = "madv";
            cbxmapd.DataSource = ServicesDAO.Instance.getListServices();
            cbxmapd.DisplayMember = "mapd";
        }
        void loadListServices()
        {
            dgvdvthem.DataSource = ServicesDAO.Instance.getListServices();
        }
        void addService(string mapd,string madv,int sl,int tien)
        {
            ServicesDTO transfer = new ServicesDTO(mapd, madv, sl, tien);
            if (ServicesDAO.Instance.addService(transfer) >= 1)
            {
                MessageBox.Show("Đã thêm dịch vụ");
                loadListServices();
            }
            else
                MessageBox.Show("Lỗi ! Không thêm được dịch vụ");
        }
        #region events
        private void dgvdvthem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex<=dgvdvthem.Rows.Count-1&&e.ColumnIndex>=0)
            {
                cbxmapd.Text = dgvdvthem.Rows[e.RowIndex].Cells["mapd"].Value.ToString();
                cbxmadv.Text = dgvdvthem.Rows[e.RowIndex].Cells["madv"].Value.ToString();
                txtsl.Text = dgvdvthem.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
                txttong.Text = dgvdvthem.Rows[e.RowIndex].Cells["tongtiendv"].Value.ToString();
            }
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text != "")
            {
                int sl;
                int gia;
                sl = Convert.ToInt32(txtsl.Text);
                ServicesDTO transfer = new ServicesDTO(cbxmadv.Text);
                gia = Convert.ToInt32(ServicesDAO.Instance.getServicePrice(transfer));
                txttong.Text = (sl * gia).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addService(cbxmapd.Text, cbxmadv.Text, Convert.ToInt32(txtsl.Text), Convert.ToInt32(txttong.Text));
        }
        #endregion
    }
}

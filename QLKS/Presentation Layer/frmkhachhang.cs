using QLKS.Data_Access_Object;
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
    public partial class frmkhachhang : Form
    {
        public frmkhachhang()
        {
            InitializeComponent();
            loadkh();
            disable_edit();
        }
        bool add;
        #region methods
        public void loadkh()
        {
            dgvkh.DataSource = CustomerDAO.Instance.getkh();
        }
        public void disable_edit()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = !true;

            txtCmnd.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtGhichu.ReadOnly = true;
            txtMkh.ReadOnly = true;
            dtpNgaysinh.Enabled = false;
            txtSodt.ReadOnly = true;
            txtTenkh.ReadOnly = true;
            rdNam.Enabled = false;
            rdNu.Enabled = false;

            dgvkh.ReadOnly = true;
        }
        public void enable_edit()
        {
            btnThem.Enabled = !true;
            btnSua.Enabled = !true;
            btnXoa.Enabled = !true;
            btnSave.Enabled = true;

            txtCmnd.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txtGhichu.ReadOnly = false;
            txtMkh.ReadOnly = false;
            dtpNgaysinh.Enabled = true;
            txtSodt.ReadOnly = false;
            txtTenkh.ReadOnly = false;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
        }
        void messOK()
        {
            MessageBox.Show("Thành công");
        }
        void messF()
        {
            MessageBox.Show("Thất bại kiểm tra lại");
        }
        void reset()
        {
            txtMkh.ResetText();
            txtTenkh.ResetText();
            txtCmnd.ResetText();
            txtDiachi.ResetText();
            txtGhichu.ResetText();
            txtSodt.ResetText();
        }
        void insertKH(string makh,string tenkh,string gioitinh,string ngaysinh,string cmnd,string diachi,string sdt,string ghichu)
        {
            CustomerDTO transfer = new CustomerDTO(makh, tenkh, gioitinh, ngaysinh, cmnd, diachi, sdt, ghichu);
            if (CustomerDAO.Instance.insertKH(transfer) >= 1)
            {
                messOK();
                loadkh();
                reset();
                disable_edit();
            }
            else
            {
                messF();
                reset();
                disable_edit();
            }
        }
        void updateKH(string makh,string tenkh,string gioitinh,string ngaysinh,string cmnd,string diachi,string sdt,string ghichu)
        {
            CustomerDTO transfer = new CustomerDTO(makh, tenkh, gioitinh, ngaysinh, cmnd, diachi, sdt, ghichu);
            if (CustomerDAO.Instance.updateKH(transfer) >= 1)
            {
                messOK();
                loadkh();
                reset();
                disable_edit();
            }
            else
            {
                messF();
                reset();
                disable_edit();
            }
        }
        void delete(string makh)
        {
            CustomerDTO transfer = new CustomerDTO(makh);
            if(CustomerDAO.Instance.deleteKH(transfer)>=1)
            {
                messOK();
                loadkh();
                reset();
                disable_edit();
            }
            else
            {
                messF();
                disable_edit();
            }
        }
        string checkGioitinh()
        {
            string gioitinh="Không xác định";
            if (rdNam.Checked == true)
                gioitinh = "Nam";
            if (rdNu.Checked == true)
                gioitinh = "Nữ";
            return gioitinh;
        }
        #endregion
        private void dgvkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex <= CustomerDAO.Instance.getkh().Rows.Count - 1)
            {
                txtMkh.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["makh"].ToString();
                txtTenkh.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["tenkh"].ToString();
                dtpNgaysinh.Value = Convert.ToDateTime(CustomerDAO.Instance.getkh().Rows[e.RowIndex]["ngaysinh"]);
                txtCmnd.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["cmnd"].ToString();
                txtDiachi.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["diachi"].ToString();
                txtSodt.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["sdt"].ToString();
                txtGhichu.Text = CustomerDAO.Instance.getkh().Rows[e.RowIndex]["ghichu"].ToString();

                switch (CustomerDAO.Instance.getkh().Rows[e.RowIndex]["gioitinh"].ToString())
                {
                    case "Nam":
                        rdNam.Checked = true;
                        break;
                    case "Nữ":
                        rdNu.Checked = true;
                        break;
                }
            }
            else
                reset();
        }
        #region events
        private void btnThem_Click(object sender, EventArgs e)
        {
            add =true;
            enable_edit();
            dgvkh.CurrentCell = dgvkh.Rows[dgvkh.Rows.Count - 1].Cells[0];
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            add = false;
            enable_edit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(add==true)
            {
                insertKH(txtMkh.Text, txtTenkh.Text, checkGioitinh(), dtpNgaysinh.Value.ToString(), txtCmnd.Text, txtDiachi.Text, txtSodt.Text, txtGhichu.Text);
            }
            else
            {
                updateKH(txtMkh.Text, txtTenkh.Text, checkGioitinh(), dtpNgaysinh.Value.ToString(), txtCmnd.Text, txtDiachi.Text, txtSodt.Text, txtGhichu.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            delete(txtMkh.Text);    
        }
        #endregion
    }
}

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
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
            loadnv();
            disable_edit();
        }
        #region properties
        bool add;
        #endregion
        #region methods
        public void loadnv()
        {
            try
            {
                dgvnv.DataSource = EmployeesDAO.Instance.getnv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải danh sách nhân viên");
                MessageBox.Show(ex.ToString());
            }
        }
        void disable_edit()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btn_Save.Enabled = false;

            txtChucVu.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtManv.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            txtSdt.ReadOnly = true;
            txtTennv.ReadOnly = true;
            cbxGioitinh.Enabled = false;
            dgvnv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvnv.ReadOnly = true;
        }
        void enable_edit()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btn_Save.Enabled = true;

            txtChucVu.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            dtpNgaySinh.Enabled = true;
            txtSdt.ReadOnly = false;
            txtTennv.ReadOnly = false;
            cbxGioitinh.Enabled = true;
            cbxGioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void reset_textbox()
        {
            txtChucVu.Text = "";
            txtDiachi.Text = "";
            txtManv.Text = "";
            dtpNgaySinh.ResetText();
            txtSdt.Text = "";
            txtTennv.Text = "";
            txtTimkiem.Text = "";
            cbxGioitinh.SelectedIndex = -1;
        }
        void getManv(string findManv)
        {
            int i = 0;
            foreach(DataRow item in EmployeesDAO.Instance.getnv().Rows)
            {
                if(findManv==EmployeesDAO.Instance.getnv().Rows[i]["manv"].ToString())
                {
                    dgvnv.CurrentCell = dgvnv.Rows[i].Cells[0];
                }
                i++;
            } 
        }
        void addNV()
        {
            EmployeesDTO transfer = new EmployeesDTO(txtManv.Text, txtTennv.Text, cbxGioitinh.SelectedItem.ToString(), dtpNgaySinh.Value.ToString(), txtSdt.Text, txtDiachi.Text, txtChucVu.Text);
            if (EmployeesDAO.Instance.insertNV(transfer) >= 1)
            {
                loadnv();
                MessageBox.Show("Thành công");
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        void updateNV()
        {
            EmployeesDTO transfer = new EmployeesDTO(txtManv.Text, txtTennv.Text, cbxGioitinh.SelectedItem.ToString(), dtpNgaySinh.Value.ToString(), txtSdt.Text, txtDiachi.Text, txtChucVu.Text);
            if (EmployeesDAO.Instance.updateNV(transfer) >= 1)
            {
                loadnv();
                MessageBox.Show("Thành công");
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        void deleteNV()
        {
            EmployeesDTO transfer = new EmployeesDTO(txtManv.Text, txtTennv.Text, cbxGioitinh.SelectedItem.ToString(), dtpNgaySinh.Value.ToString(), txtSdt.Text, txtDiachi.Text, txtChucVu.Text);
            if (EmployeesDAO.Instance.deteleNV(transfer) >= 1)
            {
                loadnv();
                MessageBox.Show("Đã xóa nhân viên");
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        void checkManv(string manv)
        {
            int i = 0;
            foreach(DataRow item in dgvnv.Rows)
            {
                if(item["manv"].ToString()==manv)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại");
                }
                i++;
            }
        }
        #endregion
        #region Events
        private void dgvnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex <= EmployeesDAO.Instance.getnv().Rows.Count-1)
            {
                txtManv.Text = EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["manv"].ToString();
                txtTennv.Text = EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["tennv"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["ngaysinh"]);
                txtSdt.Text = EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["sdt"].ToString();
                txtDiachi.Text = EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["diachi"].ToString();
                txtChucVu.Text = EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["chucvu"].ToString();
                switch (EmployeesDAO.Instance.getnv().Rows[e.RowIndex]["gioitinh"].ToString())
                {
                    case "Nam":
                        cbxGioitinh.SelectedIndex=0;
                        break;
                    case "Nữ":
                        cbxGioitinh.SelectedIndex=1;
                        break;
                }
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            getManv(txtTimkiem.Text);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtManv.ReadOnly = false;
            enable_edit();
            reset_textbox();
            dgvnv.CurrentCell = dgvnv.Rows[dgvnv.Rows.Count - 1].Cells[0];
            add = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (add == true)
            {
                addNV();
                reset_textbox();
                disable_edit();
            }
            else
            {
                updateNV();
                reset_textbox();
                disable_edit();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enable_edit();
            add = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteNV();
        }
        #endregion
    }
}

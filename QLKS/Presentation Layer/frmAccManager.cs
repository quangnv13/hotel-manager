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
    public partial class frmAccManager : Form
    {
        public frmAccManager()
        {
            InitializeComponent();
            loadTblAcc();
            disable_edit();
            loadDataCheckbox();
        }
        bool add;
        #region methods
        void loadTblAcc()
        {
            dgvAcc.DataSource = AccountDAO.Instance.getTbluser();
        }
        void disable_edit()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;

            cbxManv.Enabled = false;
            txtPass.ReadOnly = true;
            txtUserName.ReadOnly = true;
            cbxPermission.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvAcc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAcc.ReadOnly = true;
            cbxPermission.Enabled = false;
        }
        void enable_edit()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnSave.Enabled = true;

            cbxManv.Enabled = true;
            txtPass.ReadOnly = false;
            txtUserName.ReadOnly = false;
            cbxPermission.Enabled = true;
        }
        void findUserName(string key)
        {
            int i = 0;
            foreach (DataRow item in AccountDAO.Instance.getTbluser().Rows)
            {
                if (txtTimkiem.Text == item["username"].ToString())
                {
                    dgvAcc.CurrentCell = dgvAcc.Rows[i].Cells[0];
                }
                i++;
            }
        }
        int insertUser(string username,string manv,string pass,string permission)
        {
            AccountDTO transfer = new AccountDTO(username, manv, pass, permission);
            return AccountDAO.Instance.insertUser(transfer);
        }
        int updateUser(string username,string manv,string pass,string permission)
        {
            AccountDTO transfer = new AccountDTO(username, manv, pass, permission);
            return AccountDAO.Instance.updateUser(transfer);
        }
        int deleteUserName(string username)
        {
            AccountDTO transfer = new AccountDTO(username);
            return AccountDAO.Instance.deleteUser(transfer);
        }
        void loadDataCheckbox()
        {
            cbxManv.DataSource = EmployeesDAO.Instance.getnv();
            cbxManv.DisplayMember = "manv";
            cbxPermission.DataSource = AccountDAO.Instance.getTbluser();
            cbxPermission.DisplayMember = "permission";
        }
        #endregion

        #region events
        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex<=AccountDAO.Instance.getTbluser().Rows.Count-1 && e.ColumnIndex>=0)
            {
                txtUserName.Text = AccountDAO.Instance.getTbluser().Rows[e.RowIndex]["username"].ToString();
                cbxManv.SelectedIndex = e.RowIndex;
                txtPass.Text = AccountDAO.Instance.getTbluser().Rows[e.RowIndex]["password"].ToString();
                cbxPermission.SelectedIndex = e.RowIndex;
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            findUserName(txtTimkiem.Text);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            dgvAcc.CurrentCell = dgvAcc.Rows[dgvAcc.Rows.Count - 1].Cells[0];
            add = true;
            enable_edit();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            add = false;
            enable_edit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (add == true)
            {
                if (insertUser(txtUserName.Text, cbxManv.Text, txtPass.Text, cbxPermission.Text) >= 1)
                {
                    MessageBox.Show("Thành Công");
                    loadTblAcc();
                    disable_edit();
                }
                else
                    MessageBox.Show("Thất bại kiểm tra lại");
            }
            else
            {
                if (updateUser(txtUserName.Text, cbxManv.Text, txtPass.Text, cbxPermission.Text) >= 1)
                {
                    MessageBox.Show("Thành Công");
                    loadTblAcc();
                    disable_edit();
                }
                else
                    MessageBox.Show("Thất bại kiểm tra lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (deleteUserName(txtUserName.Text) >= 1)
            {
                MessageBox.Show("Thành Công");
                loadTblAcc();
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        #endregion
    }
}

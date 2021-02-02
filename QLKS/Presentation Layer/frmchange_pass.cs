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
    public partial class frmchange_pass : Form
    {
        public frmchange_pass()
        {
            InitializeComponent();
        }
        #region methods
        string loadOldPass()
        {
            return AccountDAO.pass;
        }
        bool reNewPass()
        {
            bool confirm = false;
            if (txtMkm.Text == txtMkm2.Text)
                confirm = true;
            else
                MessageBox.Show("Mật khẩu mới chưa trùng nhau");
            return confirm;
        }
        void change_Pass()
        {
            if (txtMkc.Text == loadOldPass())
            {
                if (reNewPass() == true)
                {
                    if (loadOldPass() != txtMkm.Text)
                    {
                        AccountDTO transfer = new AccountDTO(lblUserName.Text, txtMkm.Text);
                        if (AccountDAO.Instance.ChangePass(transfer) == true)
                        {
                            MessageBox.Show("Đã thay đổi mật khẩu");
                            txtMkc.ResetText();
                            txtMkm.ResetText();
                            txtMkm2.ResetText();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ và mới giống nhau");
                        txtMkc.ResetText();
                        txtMkm.ResetText();
                        txtMkm2.ResetText();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu cũ");
                txtMkc.ResetText();
                txtMkm.ResetText();
                txtMkm2.ResetText();
            }
        }
        #endregion
        #region events
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmchange_pass_Load(object sender, EventArgs e)
        {
            lblUserName.Text = AccountDAO.uname;
        }
        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            change_Pass();
        }
        #endregion
    }
}

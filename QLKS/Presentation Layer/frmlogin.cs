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
    public partial class frmlogin : Form
    {
        
        public frmlogin()
        {
            InitializeComponent();
        }
        #region properties
        frmmain fm = new frmmain();
        string username;
        string password;
        int locked=0;
        int num_countdown = 11;
        #endregion
        #region events
        private void button1_Click(object sender, EventArgs e)
        {
            username = txtid.Text;
            password = txtpass.Text;
            AccountDTO transfer = new AccountDTO(username, password);
            if (AccountDAO.Instance.login(transfer) == true)
            {
                MessageBox.Show("Bạn đã đăng nhập với tài khoản " + username);
                txtid.Text = "";
                txtpass.Text = "";
                fm.Show();
                this.Hide();
            }
            else
            {
                locked++;
                MessageBox.Show("Sai tài khoản hoặc mặt khẩu");
            }
            if (locked == 3)
            {
                MessageBox.Show("Bạn đã nhập sai tài khoản 3 lần");
                timer_locked.Enabled = true;
                timer_locked.Start();
                timer_locked.Interval = 1000;
            }
        }
        private void timer_locked_Tick(object sender, EventArgs e)
        {
            num_countdown--;
            if (num_countdown >= 0)
            {
                txtid.Enabled = false;
                txtpass.Enabled = false;
                txtpass.Text = "";
                button1.Enabled = false;
                txtid.Text = "Bạn phải chờ " + num_countdown + "s để đăng nhập lại";
            }
            else
            {
                txtid.Enabled = true;
                txtpass.Enabled = true;
                button1.Enabled = true;
                txtid.Text = "";
                timer_locked.Stop();
                timer_locked.Enabled = false;
                num_countdown = 11;
                locked = 0;
            }
        }
        #endregion
    }
}

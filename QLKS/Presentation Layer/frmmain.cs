using QLKS.Data_Access_Object;
using QLKS.DTO;
using QLKS.Presentation_Layer;
using QLKS.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
            flpRoom.AutoScroll = true;
            loaddsp();
            loadthongke();
        }
        #region properties
        frmAddService fadv = new frmAddService();
        frmReport frp = new frmReport();
        frmkhachhang fkh = new frmkhachhang();
        frmnhanvien fnv = new frmnhanvien();
        frmvattu fvt = new frmvattu();
        frmchange_pass fcp = new frmchange_pass();
        frmdatphong fdp = new frmdatphong();
        frmhoadon fhd = new frmhoadon();
        frmphong fp = new frmphong();
        frminfo fif = new frminfo();
        frmAccManager fAM = new frmAccManager();
        frmService fsv = new frmService();
        #endregion
        #region methods
        public void loaddsp()
        {
            List<RoomDTO> list_Room = RoomDAO.Instance.loaddsp();    
            foreach (RoomDTO item in list_Room)
            {
                Button btn_Room = new Button()
                {
                    Width = RoomDAO.btn_width,
                    Height = RoomDAO.btn_height,
                };
                btn_Room.BackgroundImageLayout = ImageLayout.None;
                switch (item.Trangthai)
                {
                    case "Đang rảnh":
                        btn_Room.BackgroundImage = icon.Images[0];
                        break;
                    case "Đã đặt":
                        btn_Room.BackgroundImage = icon.Images[1];
                        break;
                }
                btn_Room.Text = item.Maphong;
                btn_Room.TextAlign = ContentAlignment.BottomCenter;
                btn_Room.Click += btn_Room_Click;
                flpRoom.AutoScroll = true;
                flpRoom.Controls.Add(btn_Room);
            }
        }
        public void loadthongke()
        {
            lblsophongcon.Text = RoomDAO.Instance.loadphongtrong();
            lblsophongdadat.Text = RoomDAO.Instance.loadphongdadat();
            lblsophongco.Text = RoomDAO.Instance.loadsophong();
        }
        bool checkPermission()
        {
            bool confirm = false;
            switch (AccountDAO.Instance.getPermision(AccountDAO.uname))
            {
                case "Admin":
                    confirm = true;
                    break;
                case "Nhân viên":
                    confirm = false;
                    break;
            }
            return confirm;
        }
        #endregion
        #region events
        private void btn_Room_Click(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string trangthai=DataProvider.Instance.ExecuteQuery("select trangthai from tbltrangthaiphong where maphong='"+btn.Text+"'").Rows[0]["trangthai"].ToString();
            if (trangthai=="Đang rảnh")
            {
                RoomDAO.Maphong = btn.Text;
                fdp.ShowDialog();
            }
            else
                MessageBox.Show("Phòng này đã đặt");
        }
        private void Timerdate_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.Hour.ToString();
        }
        private void vậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fkh.ShowDialog();
        }
        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkPermission() == true)
                fnv.ShowDialog();
            else
                MessageBox.Show("Bạn không có quyền admin");
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogin flog = new frmlogin();
            flog.Show();
            this.Close();
        }

        private void đăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fcp.ShowDialog();
        }

        private void đặtPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            fdp.ShowDialog();
        }


        private void tạoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fhd.ShowDialog();
        }

        private void phòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fp.ShowDialog();
        }

        private void vậtTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fvt.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fhd.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fif.ShowDialog();
        }
        private void frmmain_Load(object sender, EventArgs e)
        {
            label3.Text= label3.Text + AccountDAO.Instance.getPermision(AccountDAO.uname);
        }
        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkPermission() == true)
                fAM.ShowDialog();
            else
                MessageBox.Show("Bạn không có quyền admin");
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsv.ShowDialog();
        }
        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frp.ShowDialog();
        }
        private void thêmDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fadv.ShowDialog();
        }
        private void timerUpdateStatusRoom_Tick(object sender, EventArgs e)
        {
            int hour;
            hour = DateTime.Now.Hour;
            if (hour == 0)
                RoomDAO.Instance.autoUpdateStatusRoom();
        }
        #endregion
    }
}

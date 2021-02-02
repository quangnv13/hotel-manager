using QLKS.Data_Access_Layer;
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
    public partial class frmdatphong : Form
    {
        public frmdatphong()
        {
            InitializeComponent();
            loadCombobox();
            loadPhongTrong();
            loadDsDatPhong();
            disable_edit();
            loadListEmptyDatPhong();
        }
        #region methods
        void resetForm()
        {
            txtmapd.ResetText();
            txtMpd.ResetText();
            txtTien.ResetText();
            cbxmap.ResetText();
            cbxMakh.ResetText();
        }
        void loadCombobox()
        {
            cbxmap.DataSource = RoomDAO.Instance.getEmptyRoom();
            cbxmap.DisplayMember = "maphong";
            cbxMakh.DataSource = CustomerDAO.Instance.getkh();
            cbxMakh.DisplayMember = "makh";
        }
        void disable_edit()
        {
            btnHuy.Enabled = false;
            btnDatphong.Enabled = false;
            btnReset.Enabled = false;
            btnAdd.Enabled = true;

            datetimeden.Enabled = false;
            datetimedi.Enabled = false;
            txtManv.ReadOnly = true;
            txtmapd.ReadOnly = !true;
            cbxmap.Enabled = true;
            txtMpd.ReadOnly = true;
            txtTien.ReadOnly = true;
            cbxMakh.Enabled = false;
        }
        void enable_edit()
        {
            btnHuy.Enabled = !false;
            btnDatphong.Enabled = !false;
            btnReset.Enabled = !false;
            btnAdd.Enabled = !true;

            datetimeden.Enabled = false;
            datetimedi.Enabled = !false;
            txtManv.ReadOnly = true;
            txtmapd.ReadOnly = true;
            //txtMpd.ReadOnly = !true;
            txtTien.ReadOnly = !true;
            cbxMakh.Enabled = !false;
            cbxmap.Enabled = false;
        }
        void loadListEmptyDatPhong()
        {
            dgvListEmptyDatPhong.DataSource = SelectRoomDAO.Instance.getListEmptyDatPhong();
            dgvListEmptyDatPhong.ReadOnly = true;
        }
        void loadPhongTrong()
        {
           dgvdsphong.DataSource= RoomDAO.Instance.getEmptyRoom();
        }
        void loadDsDatPhong()
        {
            dgvdsdatphong.DataSource = SelectRoomDAO.Instance.getListDatPhong();
        }
        void messOK()
        {
            MessageBox.Show("Thành công");
        }
        void messWR()
        {
            MessageBox.Show("Thất bại kiểm tra lại");
        }
        void createDatPhong(string mapd,string maphong)
        {
            SelectRoomDTO transfer = new SelectRoomDTO(mapd, maphong);
            try
            {
                if (SelectRoomDAO.Instance.createDatPhong(transfer) >= 1)
                {
                    messOK();
                    loadDsDatPhong();
                    enable_edit();
                    loadPhongTrong();
                }
                else
                    messWR();
            }
            catch
            {
                MessageBox.Show("Mã phiếu đặt đã tồn tại");
            }
        }
        void cancelDatPhong(string mapd)
        {
            SelectRoomDTO transfer = new SelectRoomDTO(mapd);
            if (SelectRoomDAO.Instance.cancelDatPhong(transfer) >= 1)
            {
                loadPhongTrong();
                messOK();
                loadDsDatPhong();
                disable_edit();
            }
            else
                messWR();
        }
        int autoCompleteAmount()
        {
            int s1,s2,s;
            string str1, str2;
            RoomDTO transfer = new RoomDTO(cbxmap.Text);
            s1 = Convert.ToInt32(RoomDAO.Instance.getRoomPrice(transfer));
            str1 = (datetimedi.Value.Date - datetimeden.Value.Date).ToString();
            str2=str1.Substring(0, str1.IndexOf("."));
            s2 = Convert.ToInt32(str2);
            s = s1 * s2;
            return s;
        }
        void insertInfoDatPhong(string mapd,string makh,string ngayden,string ngaydi,int tongtien,string username)
        {
            SelectRoomDTO transfer = new SelectRoomDTO(mapd, makh, ngayden, ngaydi, tongtien, username);
            if (SelectRoomDAO.Instance.insertInfoDatPhong(transfer) >= 1)
            {
                loadPhongTrong();
                messOK();
                loadDsDatPhong();
                disable_edit();
            }
            else
                messWR();
        }
        void updateInfoDatPhong(string mapd)
        {
            SelectRoomDTO transfer = new SelectRoomDTO(mapd);
            if (SelectRoomDAO.Instance.updateInfoDatPhong(transfer) >= 1)
            {
                messOK();
                loadDsDatPhong();
                disable_edit();
            }
            else
                messWR();
        }
        void createBill(int tongtien,string mapd,string makh,string manv)
        {
            BillDTO transfer = new BillDTO(tongtien, mapd, makh, manv);
            if(BillDAO.Instance.createBill(transfer)>=1)
                MessageBox.Show("Đã tạo hóa đơn tự động");
            else
                MessageBox.Show("Không tạo được hóa đơn ! Kiểm tra lại");
        }
        string getManv(string username)
        {
            AccountDTO transfer = new AccountDTO(username);
            return AccountDAO.Instance.getManv(transfer);
        }
        #endregion


        #region events
        private void dgvListEmptyDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex<=dgvListEmptyDatPhong.Rows.Count-1 && e.ColumnIndex>=0)
            {
                txtmapd.Text = dgvListEmptyDatPhong.Rows[e.RowIndex].Cells["mapd"].Value.ToString();
                enable_edit();
                cbxmap.ResetText();
                cbxmap.SelectedText = dgvListEmptyDatPhong.Rows[e.RowIndex].Cells["maphong"].Value.ToString();
                if (datetimedi.Value < datetimeden.Value)
                {
                    label2.Text = "Ngày đi không hợp lệ";
                    btnDatphong.Enabled = false;
                }
                else
                {
                    btnDatphong.Enabled = true;
                }
            }
        }
        private void txtmapd_TextChanged(object sender, EventArgs e)
        {
            txtMpd.Text = txtmapd.Text;
        }
        private void txtMpd_TextChanged(object sender, EventArgs e)
        {
            txtmapd.Text = txtMpd.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            createDatPhong(txtmapd.Text, cbxmap.Text);
            loadListEmptyDatPhong();
            btnAdd.Enabled = true;
            if (datetimedi.Value < datetimeden.Value)
            {
                label2.Text = "Ngày đi không hợp lệ";
                btnDatphong.Enabled = false;
            }
            else
            {
                btnDatphong.Enabled = true;
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            cancelDatPhong(txtMpd.Text);
            loadListEmptyDatPhong();
            resetForm();
        }
        private void btnDatphong_Click(object sender, EventArgs e)
        {
            insertInfoDatPhong(txtMpd.Text, cbxMakh.Text, datetimeden.Value.ToString(), datetimedi.Value.ToString(), Convert.ToInt32(txtTien.Text), txtManv.Text);
            loadListEmptyDatPhong();
            resetForm();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            resetForm();
            disable_edit();
            btnAdd.Enabled = true;
        }

        private void datetimedi_ValueChanged(object sender, EventArgs e)
        {
            if (datetimedi.Value < datetimeden.Value)
            {
                label2.Text = "Ngày đi không hợp lệ";
                btnDatphong.Enabled = false;
            }
            else
            {
                btnDatphong.Enabled = true;
                label2.ResetText();
                txtTien.Text = autoCompleteAmount().ToString();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["trangthai"].Value.ToString() == "Đã nhận")
            {
                MessageBox.Show("Phiếu đã được nhận không thể xóa");
            }
            else
                cancelDatPhong(dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["mapd"].Value.ToString());
            resetForm();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["trangthai"].Value.ToString() != "Đã nhận")
            {
                int tien;
                tien = Convert.ToInt32(dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["tongtiendat"].Value);
                string mapd, makh, manv;
                mapd = dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["mapd"].Value.ToString();
                updateInfoDatPhong(mapd);
                makh = dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["makh"].Value.ToString();
                manv = dgvdsdatphong.Rows[dgvdsdatphong.CurrentCell.RowIndex].Cells["username"].Value.ToString();
                createBill(tien, mapd, makh, manv);
            }
            else
                MessageBox.Show("Phiếu đặt đã được nhận không thể nhận lại");
            resetForm();
        }
        private void frmdatphong_Load(object sender, EventArgs e)
        {
            txtManv.Text=getManv(AccountDAO.uname);
            cbxmap.SelectedIndex = -1;
            cbxmap.Text = RoomDAO.Maphong;
        }
        private void frmdatphong_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
        #endregion
    }
}

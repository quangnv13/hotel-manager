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
    public partial class frmphong : Form
    {
        public frmphong()
        {
            InitializeComponent();
            loaddsp();
            disable_edit_RoomInfo();
            disable_edit_RoomType();
            loadListRoomType();
            loadCombobox();
        }
        bool add;
        #region methods
        void loaddsp()
        {
            dgvphong.DataSource = RoomDAO.Instance.loadlistroom();
        }
        void disable_edit_RoomInfo()
        {
            btnAdd1.Enabled = true;
            btnDel.Enabled = false;
            btnSave1.Enabled = false;
            btnUpdate1.Enabled = false;

            txtMaphong.ReadOnly = true;
            cbLoaiPhong.Enabled = false;
        }
        void disable_edit_RoomType()
        {
            btnAdd2.Enabled = true;
            btnDel2.Enabled = false;
            btnSave2.Enabled = false;
            btnUpdate2.Enabled = false;

            txtMaloai.ReadOnly = true;
            txtgia.ReadOnly = true;
        }
        void enable_edit_RoomInfo()
        {
            btnAdd1.Enabled = !true;
            btnDel.Enabled = false;
            btnSave1.Enabled = !false;
            btnUpdate1.Enabled = !false;

            txtMaphong.ReadOnly = false;
            cbLoaiPhong.Enabled = true;
        }
        void enable_edit_RoomType()
        {
            btnAdd2.Enabled = !true;
            btnDel2.Enabled = false;
            btnSave2.Enabled = !false;
            btnUpdate2.Enabled = !false;

            txtMaloai.ReadOnly = false;
            txtgia.ReadOnly = false;
        }
        void loadCombobox()
        {
            cbLoaiPhong.DataSource = RoomDAO.Instance.loadlistroom();
            cbLoaiPhong.DisplayMember = "Mã loại";
            cbLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void loadListRoomType()
        {
            dgvloaiphong.DataSource = RoomDAO.Instance.getRoomType();
        }
        void insertRoomType(string maloai,int gia)
        {
            RoomDTO transfer = new RoomDTO(maloai, gia);
            if (RoomDAO.Instance.insertRoomType(transfer) >= 1)
            {
                MessageBox.Show("Thành công");
                loadListRoomType();
                disable_edit_RoomType();
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        void updateRoomType(string maloai,int gia)
        {
            RoomDTO transfer = new RoomDTO(maloai, gia);
            if (RoomDAO.Instance.insertRoomType(transfer) >= 1)
            {
                MessageBox.Show("Thành công");
                loadListRoomType();
                disable_edit_RoomType();
            }
            else
                MessageBox.Show("Thất bại kiểm tra lại");
        }
        void deleteRoomType(string maloai,int gia)
        {
            RoomDTO transfer = new RoomDTO(maloai, gia);
            if (RoomDAO.Instance.deleteRoomType(transfer) >= 1)
            {
                MessageBox.Show("Đã xóa");
                loadListRoomType();
                disable_edit_RoomType();
            }
            else
                MessageBox.Show("Không xóa được");
        }
        #endregion
        #region events
        private void dgvphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.ColumnIndex>=0 && e.RowIndex<=RoomDAO.Instance.loadlistroom().Rows.Count-1)
            {
                txtMaphong.Text = RoomDAO.Instance.loadlistroom().Rows[e.RowIndex]["Mã phòng"].ToString();
                switch(RoomDAO.Instance.loadlistroom().Rows[e.RowIndex]["Mã loại"].ToString())
                {
                    case "A":
                        cbLoaiPhong.Text = "A";
                        break;
                    case "B":
                        cbLoaiPhong.Text = "B";
                        break;
                    case "C":
                        cbLoaiPhong.Text = "C";
                        break;
                    case "VIP":
                        cbLoaiPhong.Text = "VIP";
                        break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            enable_edit_RoomType();
            add = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enable_edit_RoomType();
            add = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteRoomType(txtMaloai.Text, Convert.ToInt32(txtgia.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (add == true)
                insertRoomType(txtMaloai.Text, Convert.ToInt32(txtgia.Text));
            else
                updateRoomType(txtMaloai.Text, Convert.ToInt32(txtgia.Text));
        }


        private void dgvloaiphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvloaiphong.Rows.Count - 1 && e.ColumnIndex >= 0)
            {
                txtMaloai.Text = dgvloaiphong.Rows[e.RowIndex].Cells["maloai"].Value.ToString();
                txtgia.Text = dgvloaiphong.Rows[e.RowIndex].Cells["gia"].Value.ToString();
                btnAdd2.Enabled = true;
                btnDel2.Enabled = true;
                btnUpdate1.Enabled = true;
            }
        }

        private void dgvphong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvphong.Rows.Count - 1 && e.ColumnIndex >= 0)
            {
                txtMaphong.Text = dgvphong.Rows[e.RowIndex].Cells["Mã phòng"].Value.ToString();
                cbLoaiPhong.SelectedIndex = e.RowIndex;
                enable_edit_RoomInfo();
                btnAdd1.Enabled = true;
                btnDel.Enabled = true;
                btnUpdate1.Enabled = true;
            }
        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            enable_edit_RoomInfo();
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataProvider.Instance.ExecuteNonQuery("insert into tblphong values('" + txtMaphong.Text + "','" + cbLoaiPhong.Text + "')") >= 0)
                {
                    MessageBox.Show("Thêm phòng thành công");
                    loaddsp();
                    disable_edit_RoomInfo();
                }
                else
                    MessageBox.Show("Thất bại kiểm tra lại");
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
        #endregion
    }
}

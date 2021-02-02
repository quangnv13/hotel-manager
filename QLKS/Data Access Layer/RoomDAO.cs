using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Data_Access_Object
{
    class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoomDAO();
                return RoomDAO.instance;
            }
            private set { RoomDAO.instance = value; }
        }
        private RoomDAO() { }
        public static int btn_width=70;
        public static int btn_height=90;
        public static string Maphong;
        #region methods
        public List<RoomDTO> loaddsp()
        {
            List<RoomDTO> Room = new List<RoomDTO>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("get_ListRoom");
            foreach (DataRow item in dt.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                Room.Add(room);
            }
            return Room;
        }
        public DataTable loadlistroom()
        {
            return DataProvider.Instance.ExecuteQuery("get_all_info_ListRoom");
        }
        public DataTable getEmptyRoom()
        {
            return DataProvider.Instance.ExecuteQuery("getEmptyRoom");
        }
        public string loadphongtrong()
        {
            return "Số phòng trống : " + DataProvider.Instance.ExecuteQuery("select * from tbltrangthaiphong where trangthai=N'Đang rảnh'").Rows.Count;
        }
        public string loadphongdadat()
        {
            return "Số phòng đã đặt : " + DataProvider.Instance.ExecuteQuery("select * from tbltrangthaiphong where trangthai=N'Đã đặt'").Rows.Count;
        }
        public string loadsophong()
        {
            return "Số phòng có: " + DataProvider.Instance.ExecuteQuery("select * from tbltrangthaiphong").Rows.Count;
        }
        public string getRoomPrice(RoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Maphong };
            return DataProvider.Instance.ExecuteQuery("getRoomPrice @maphong", parameters).Rows[0][0].ToString();
        }
        public DataTable getRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("getRoomType");
        }
        public int insertRoomType(RoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Maloai, transfer.Gia };
            return DataProvider.Instance.ExecuteNonQuery("insertRoomType @maloai , @gia", parameters);
        }
        public int updateRoomType(RoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Gia };
            return DataProvider.Instance.ExecuteNonQuery("updateRoomType @gia",parameters);
        }
        public int deleteRoomType(RoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Maloai,transfer.Gia };
            return DataProvider.Instance.ExecuteNonQuery("deleteRoomType @maloai , @gia", parameters);
        }
        public void autoUpdateStatusRoom()
        {
            DataProvider.Instance.ExecuteQuery("updateStatusRoomAuto");
        }
        #endregion
    }
}

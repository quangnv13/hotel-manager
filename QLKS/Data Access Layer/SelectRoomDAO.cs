using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Data_Access_Layer
{
    public class SelectRoomDAO
    {
        private static SelectRoomDAO instance;

        public static SelectRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SelectRoomDAO();
                return SelectRoomDAO.instance; 
            }
            private set { SelectRoomDAO.instance = value; }
        }
        private SelectRoomDAO() { }
        public DataTable getListDatPhong()
        {
            return DataProvider.Instance.ExecuteQuery("getListDatPhong");
        }
        public int createDatPhong(SelectRoomDTO transfer)
        {
            object[]parameters=new object[]{transfer.Mapd,transfer.Maphong};
            return DataProvider.Instance.ExecuteNonQuery("createDatPhong @mapd , @maphong", parameters);
        }
        public DataTable getListEmptyDatPhong()
        {
            return DataProvider.Instance.ExecuteQuery("getListEmptyDatPhong");
        }
        public int cancelDatPhong(SelectRoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mapd };
            return DataProvider.Instance.ExecuteNonQuery("cancelDatPhong @mapd", parameters);
        }
        public int insertInfoDatPhong(SelectRoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mapd, transfer.Makh, transfer.Ngayden, transfer.Ngaydi, transfer.Tongtiendat, transfer.Username };
            return DataProvider.Instance.ExecuteNonQuery("insertInfoDatPhong @mapd , @makh , @ngayden , @ngaydi , @tongtiendat , @username", parameters);
        }
        public int updateInfoDatPhong(SelectRoomDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mapd };
            return DataProvider.Instance.ExecuteNonQuery("updateDetailDatPhong @mapd",parameters);
        }
        public int cancelDatPhongWithStt(SelectRoomDTO transfer)
        {
            return 1;
        }
    }
}

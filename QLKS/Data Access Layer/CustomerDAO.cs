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
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null) instance = new CustomerDAO();
                return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }
        private CustomerDAO() { }
        public DataTable getkh()
        {
            return DataProvider.Instance.ExecuteQuery("select * from tblkhachhang");
        }
        public int insertKH(CustomerDTO transfer)
        {
            object[] parameters = new object[] { transfer.Makh, transfer.Tenkh, transfer.Gioitinh, transfer.Ngaysinh, transfer.Cmnd, transfer.Diachi, transfer.Sdt, transfer.Ghichu };
            return DataProvider.Instance.ExecuteNonQuery("insertKH @makh , @tenkh , @gioitinh , @ngaysinh , @cmnd , @diachi , @sdt , @ghichu",parameters);
        }
        public int updateKH(CustomerDTO transfer)
        {
            object[] parameters = new object[] { transfer.Makh, transfer.Tenkh, transfer.Gioitinh, transfer.Ngaysinh, transfer.Cmnd, transfer.Diachi, transfer.Sdt, transfer.Ghichu };
            return DataProvider.Instance.ExecuteNonQuery("updateKH @makh , @tenkh , @gioitinh , @ngaysinh , @cmnd , @diachi , @sdt , @ghichu",parameters);
        }
        public int deleteKH(CustomerDTO transfer)
        {
            object[] parameters = new object[] { transfer.Makh };
            return DataProvider.Instance.ExecuteNonQuery("deleteKH @makh",parameters);
        }
    }
}

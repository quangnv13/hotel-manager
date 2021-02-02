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
    public class EmployeesDAO
    {
        private static EmployeesDAO instance;

        public static EmployeesDAO Instance
        {
            get 
            {
                if (instance == null)
                    instance = new EmployeesDAO(); 
                return EmployeesDAO.instance; 
            }
            private set { EmployeesDAO.instance = value; }
        }
        private EmployeesDAO() { }
        #region methods
        public DataTable getnv()
        {
            return DataProvider.Instance.ExecuteQuery("select * from tblnhanvien");
        }
        public int updateNV(EmployeesDTO transfer)
        {
            object[]parameters= new object[]{transfer.Manv,transfer.Tennv,transfer.Gioitinh,transfer.Ngaysinh,transfer.Sdt,transfer.Diachi,transfer.Chucvu};
            return DataProvider.Instance.ExecuteNonQuery("updateNV @manv , @tennv , @gioitinh , @ngaysinh , @sdt , @diachi , @chucvu",parameters);
        }
        public int insertNV(EmployeesDTO transfer)
        {
            object[] parameters = new object[] { transfer.Manv, transfer.Tennv, transfer.Gioitinh, transfer.Ngaysinh, transfer.Sdt, transfer.Diachi, transfer.Chucvu };
            return DataProvider.Instance.ExecuteNonQuery("insertNV @manv , @tennv , @gioitinh , @ngaysinh , @sdt , @diachi , @chucvu", parameters);
        }
        public int deteleNV(EmployeesDTO transfer)
        {
            object[] parameters = new object[] { transfer.Manv };
            return DataProvider.Instance.ExecuteNonQuery("deleteNV @manv", parameters);
        }
        #endregion
    }
}

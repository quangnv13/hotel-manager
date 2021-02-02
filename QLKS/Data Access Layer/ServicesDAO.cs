using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Data_Access_Layer
{
    public class ServicesDAO
    {
        private static ServicesDAO instance;

        public static ServicesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServicesDAO();
                return ServicesDAO.instance;
            }
            private set { ServicesDAO.instance = value; }
        }
        private ServicesDAO() { }
        public DataTable getService()
        {
            return DataProvider.Instance.ExecuteQuery("select * from tbldichvu");
        }
        public DataTable getListServices()
        {
            return DataProvider.Instance.ExecuteQuery("select * from tblctdatphong");
        }
        public string getServicePrice(ServicesDTO transfer)
        {
            object[] paremeters = new object[] { transfer.Madv };
            return DataProvider.Instance.ExecuteQuery("getServicePrice @madv",paremeters).Rows[0][0].ToString();
        }
        public int addService(ServicesDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mapd, transfer.Madv, transfer.Sl, transfer.Tien };
            return DataProvider.Instance.ExecuteNonQuery("insertService @mapd , @madv , @sl , @tien",parameters);
        }
    }
}

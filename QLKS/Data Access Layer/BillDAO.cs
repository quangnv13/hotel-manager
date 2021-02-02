using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Data_Access_Layer
{
    public class BillDAO
    {
        private static BillDAO instance;


        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        public DataTable GetBillInfo()
        {
            return DataProvider.Instance.ExecuteQuery("get_List_Bill");
        }
        public int createBill(BillDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mapd, transfer.Makh, transfer.Manv ,transfer.Tongtien};
            return DataProvider.Instance.ExecuteNonQuery("createBill @mapd , @makh , @manv , @tongtien", parameters);
        }
        public int payBill(BillDTO transfer)
        {
            object[] parameters = new object[] { transfer.Mahd };
            return DataProvider.Instance.ExecuteNonQuery("payBill @mahd", parameters);
        }
    }
}

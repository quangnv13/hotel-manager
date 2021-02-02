using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Data_Access_Layer
{
    public class SuppliesDAO
    {
        private static SuppliesDAO instance;

        public static SuppliesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SuppliesDAO();
                return SuppliesDAO.instance;
            }
            private set { SuppliesDAO.instance = value; }
        }
        private SuppliesDAO() { }
        #region methods
        public DataTable getListSupplies()
        {
            return DataProvider.Instance.ExecuteQuery("getListSupplies");
        }
        #endregion
    }
}

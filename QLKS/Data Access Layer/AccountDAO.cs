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
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();  
            return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }
        public static string uname;
        public static string pass;
        #region methods
        public bool login(AccountDTO transfer)
        {
            bool confirm = false;
            if (DataProvider.Instance.ExecuteQuery("CONFIRM_LOGIN @username , @password", new object[] { transfer.Username, transfer.Password }).Rows.Count > 0)
            {
                confirm = true;
                uname = transfer.Username;
                pass = transfer.Password;
            }
            return confirm;
        }
        public bool ChangePass(AccountDTO transfer)
        {
            bool confirm = false;
            if (DataProvider.Instance.ExecuteNonQuery("Change_Pass @username , @password", new object[] { transfer.Username, transfer.Password }) > 0)
            {
                confirm = true;
                uname = transfer.Username;
                pass = transfer.Password;
            }
            return confirm;
        }
        public string getManv(AccountDTO transfer)
        {
            object[] parameters = new object[] {transfer.Username};
            return DataProvider.Instance.ExecuteQuery("getManv @username", parameters).Rows[0][0].ToString();
        }
        public string getPermision(string username)
        {
            return DataProvider.Instance.ExecuteQuery("getPermission @username", new object[] { username }).Rows[0]["permission"].ToString();
        }
        public DataTable getTbluser()
        {
            return DataProvider.Instance.ExecuteQuery("getListAccount");
        }
        public int insertUser(AccountDTO transfer)
        {
            object[] parameters = new Object[] { transfer.Username, transfer.Manv, transfer.Password, transfer.Permission };
            return DataProvider.Instance.ExecuteNonQuery("insertUserName @username , @manv , @password , @permission", parameters);
        }
        public int updateUser(AccountDTO transfer)
        {
            object[] parameters = new Object[] { transfer.Username, transfer.Manv, transfer.Password, transfer.Permission };
            return DataProvider.Instance.ExecuteNonQuery("updateUserName @username , @manv , @password , @permission", parameters);
        }
        public int deleteUser(AccountDTO transfer)
        {
            object[] parameters = new Object[] { transfer.Username, transfer.Manv, transfer.Password, transfer.Permission };
            return DataProvider.Instance.ExecuteNonQuery("deleteUserName @username", parameters);
        }
        #endregion
    }
}

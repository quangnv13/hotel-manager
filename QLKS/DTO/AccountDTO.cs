using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class AccountDTO
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private string password;


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string permission;

        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public AccountDTO(string username,string manv,string password,string permission)
        {
            this.Username = username;
            this.Manv = manv;
            this.Password = password;
            this.Permission = permission;
        }

        public AccountDTO(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public AccountDTO(string username)
        {
            this.Username = username;
        }
    }
}

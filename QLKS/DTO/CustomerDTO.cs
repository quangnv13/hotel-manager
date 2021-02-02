using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class CustomerDTO
    {
        private string makh;

        public string Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        private string tenkh;

        public string Tenkh
        {
            get { return tenkh; }
            set { tenkh = value; }
        }

        private string gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        private string ngaysinh;

        public string Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private string cmnd;

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public CustomerDTO(string makh,string tenkh,string gioitinh,string ngaysinh,string cmnd,string diachi,string sdt,string ghichu)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Gioitinh = gioitinh;
            this.Ngaysinh = ngaysinh;
            this.Cmnd = cmnd;
            this.Diachi = diachi;
            this.Sdt = sdt;
            this.Ghichu = ghichu;
        }

        public CustomerDTO(string makh)
        {
            this.Makh = makh;
        }
    }
}

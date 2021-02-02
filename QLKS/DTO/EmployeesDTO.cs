using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class EmployeesDTO
    {
        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private string tennv;

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
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

        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        #region methods
        public EmployeesDTO(string manv, string tennv, string gioitinh,string ngaysinh, string sdt, string diachi, string chucvu)
        {
            this.Manv = manv;
            this.Tennv = tennv;
            this.Gioitinh = gioitinh;
            this.Ngaysinh =ngaysinh;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Chucvu = chucvu;
        }
        #endregion
    }

}

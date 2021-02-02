using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class BillDTO
    {
        private string mahd;

        public string Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }

        private int tongtien;

        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        private string ngaythanhtoan;

        public string Ngaythanhtoan
        {
            get { return ngaythanhtoan; }
            set { ngaythanhtoan = value; }
        }

        private string mapd;

        public string Mapd
        {
            get { return mapd; }
            set { mapd = value; }
        }

        private string makh;

        public string Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private string tinhtrang;

        public string Tinhtrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        public BillDTO(string mahd)
        {
            this.Mahd = mahd;
        }
        public BillDTO(int tongtien,string mapd,string makh,string manv)
        {
            this.Tongtien = tongtien;
            this.Mapd = mapd;
            this.Makh = makh;
            this.Manv = manv;
        }
    }
}

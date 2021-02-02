using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class ServicesDTO
    {
        private string mapd;

        public string Mapd
        {
            get { return mapd; }
            set { mapd = value; }
        }

        private string madv;

        public string Madv
        {
            get { return madv; }
            set { madv = value; }
        }

        private int sl;

        public int Sl
        {
            get { return sl; }
            set { sl = value; }
        }

        private int tien;

        public int Tien
        {
            get { return tien; }
            set { tien = value; }
        }

        public ServicesDTO(string mapd,string madv,int sl,int tien)
        {
            this.Mapd = mapd;
            this.Madv = madv;
            this.Sl = sl;
            this.Tien = tien;
        }
        public ServicesDTO(string madv)
        {
            this.Madv = madv;
        }
    }
}

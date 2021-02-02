using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class SelectRoomDTO
    {
        private string mapd;

        public string Mapd
        {
            get { return mapd; }
            set { mapd = value; }
        }

        private string maphong;

        public string Maphong
        {
            get { return maphong; }
            set { maphong = value; }
        }

        private string makh;

        public string Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        private string ngayden;

        public string Ngayden
        {
            get { return ngayden; }
            set { ngayden = value; }
        }

        private string ngaydi;

        public string Ngaydi
        {
            get { return ngaydi; }
            set { ngaydi = value; }
        }

        private int tongtiendat;

        public int Tongtiendat
        {
            get { return tongtiendat; }
            set { tongtiendat = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public SelectRoomDTO(string mapd)
        {
            this.Mapd = mapd;
        }
        public SelectRoomDTO(string mapd,string maphong)
        {
            this.Mapd = mapd;
            this.Maphong = maphong;
        }
        public SelectRoomDTO(string mapd,string makh,string ngayden,string ngaydi,int tongtiendat,string username)
        {
            this.Mapd = mapd;
            this.Makh = makh;
            this.Ngayden = ngayden;
            this.Ngaydi = ngaydi;
            this.Tongtiendat = tongtiendat;
            this.Username = username;
        }
    }
}

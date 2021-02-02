using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class RoomDTO
    {
        #region properties
        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private string maloai;

        public string Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        private int gia;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private string maphong;

        public string Maphong
        {
            get { return maphong; }
            set { maphong = value; }
        }
        #endregion
        #region methods
        public RoomDTO(string maphong,string maloai,string trangthai)
        {
            this.Maphong = maphong;
            this.Maloai = maloai;
            this.Trangthai = trangthai;
        }
        public RoomDTO(DataRow row)
        {
            this.Maphong = row["maphong"].ToString();
            this.Trangthai = row["trangthai"].ToString();
        }
        public RoomDTO(string maphong)
        {
            this.Maphong=maphong;
        }
        public RoomDTO(string maloai,int gia)
        {
            this.Maloai = maloai;
            this.Gia = gia;
        }
        #endregion
    }
}

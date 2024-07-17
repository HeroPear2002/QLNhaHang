using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAnDTO
    {
        int iDMonAn;
        string tenMonAn;
        int soLuong;
        double giaMon;
        double thanhTien;
        string tenBan;
        int iDGoiMon;

        public MonAnDTO(int iDMonAn, string tenMonAn, int soLuong, double giaMon, double thanhTien, string tenBan, int iDGoiMon)
        {
            this.IDMonAn = iDMonAn;
            this.TenMonAn = tenMonAn;
            this.SoLuong = soLuong;
            this.GiaMon = giaMon;
            this.ThanhTien = thanhTien;
            this.TenBan = tenBan;
            this.IDGoiMon = iDGoiMon;
        }
        public MonAnDTO(DataRow row)
        {
            this.IDMonAn = int.Parse(row["IDMonAn"].ToString());
            this.TenMonAn = row["TenMon"].ToString();
            this.SoLuong = int.Parse(row["SoLuong"].ToString());
            this.GiaMon = Convert.ToDouble(row["Gia"].ToString());
            this.ThanhTien = Convert.ToDouble(row["thanhtien"].ToString());
            this.TenBan = row["TenBan"].ToString();
            this.IDGoiMon = int.Parse(row["IDGoiMon"].ToString());
        }
        public int IDMonAn { get => iDMonAn; set => iDMonAn = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double GiaMon { get => giaMon; set => giaMon = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TenBan { get => tenBan; set => tenBan = value; }
        public int IDGoiMon { get => iDGoiMon; set => iDGoiMon = value; }
    }
    public class MONANCBDTO
    {
        int iDMonAn;
        string tenMonAn;
        double gia;

        public MONANCBDTO(int iDMonAn, string tenMonAn, double gia)
        {
            this.IDMonAn = iDMonAn;
            this.TenMonAn = tenMonAn;
            this.Gia = gia;
        }
        public MONANCBDTO(DataRow row)
        {
            this.IDMonAn = int.Parse(row["IDMonAn"].ToString());
            this.TenMonAn = row["TenMon"].ToString();
            this.Gia = Convert.ToDouble(row["Gia"].ToString());
        }
        public int IDMonAn { get => iDMonAn; set => iDMonAn = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public double Gia { get => gia; set => gia = value; }
    }
}

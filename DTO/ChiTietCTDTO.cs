using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietCTDTO
    {
        int iDChiTietCT;
        string tenThucPham;
        float dinhLuong;

        public ChiTietCTDTO(int iDChiTietCT, string tenThucPham, float dinhLuong)
        {
            this.IDChiTietCT = iDChiTietCT;
            this.TenThucPham = tenThucPham;
            this.DinhLuong = dinhLuong;
        }
        public ChiTietCTDTO(DataRow row)
        {
            this.IDChiTietCT = int.Parse(row["IDChiTietCT"].ToString());
            this.TenThucPham = row["TenThucPham"].ToString();
            this.DinhLuong = float.Parse(row["DinhLuong"].ToString());
        }
        public int IDChiTietCT { get => iDChiTietCT; set => iDChiTietCT = value; }
        public string TenThucPham { get => tenThucPham; set => tenThucPham = value; }
        public float DinhLuong { get => dinhLuong; set => dinhLuong = value; }
    }
    public class CongThucDTO
    {
        int iDCongThuc;
        string tenCongThuc;

        public CongThucDTO(int iDCongThuc, string tenCongThuc)
        {
            this.IDCongThuc = iDCongThuc;
            this.TenCongThuc = tenCongThuc;
        }
        public CongThucDTO(DataRow row)
        {
            this.IDCongThuc = int.Parse(row["IDCongThuc"].ToString());
            this.TenCongThuc = row["TenCongThuc"].ToString();
        }
        public int IDCongThuc { get => iDCongThuc; set => iDCongThuc = value; }
        public string TenCongThuc { get => tenCongThuc; set => tenCongThuc = value; }
    }
}

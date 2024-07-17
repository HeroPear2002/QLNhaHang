using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CapNhatDTO
    {
        int soLuong;
        int iDCongThuc;

        public CapNhatDTO(int soLuong, int iDCongThuc)
        {
            this.SoLuong = soLuong;
            this.IDCongThuc = iDCongThuc;
        }
        public CapNhatDTO(DataRow row)
        {
            this.SoLuong = int.Parse(row["SoLuong"].ToString());
            this.IDCongThuc = int.Parse(row["IDCongThuc"].ToString());
        }

        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int IDCongThuc { get => iDCongThuc; set => iDCongThuc = value; }
    }
    public class CongThucMonAn
    {
        int iDThucPham;
        float dinhLuong;

        public CongThucMonAn(int iDThucPham, float dinhLuong)
        {
            this.IDThucPham = iDThucPham;
            this.DinhLuong = dinhLuong;
        }
        public CongThucMonAn(DataRow row)
        {
            this.IDThucPham = int.Parse(row["IDThucPham"].ToString());
            this.DinhLuong = float.Parse(row["DinhLuong"].ToString());
        }
        public int IDThucPham { get => iDThucPham; set => iDThucPham = value; }
        public float DinhLuong { get => dinhLuong; set => dinhLuong = value; }
    }
    public class CapNhatNhapHangDTO
    {
        int iDNhapHang;
        float tonKho;
        DateTime ngayNhap;

        public CapNhatNhapHangDTO(int iDNhapHang, int iDThucPham, float tonKho, DateTime ngayNhap)
        {
            this.IDNhapHang = iDNhapHang;
            this.TonKho = tonKho;
            this.NgayNhap = ngayNhap;
        }
        public CapNhatNhapHangDTO(DataRow row)
        {
            this.IDNhapHang = int.Parse(row["IDNhapHang"].ToString());
            this.TonKho = float.Parse(row["TonKho"].ToString());
            this.NgayNhap = DateTime.Parse(row["NgayNhap"].ToString());
        }
        public float TonKho { get => tonKho; set => tonKho = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int IDNhapHang { get => iDNhapHang; set => iDNhapHang = value; }
    }
}

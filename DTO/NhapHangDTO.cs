using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhapHangDTO
    {
        int iDNhapHang;
        string tenThucPham;
        string donViTinh;
        float soLuongNhap;
        DateTime ngayNhap;
        float luongTon;
        int isTrangThai;

        public NhapHangDTO(int iDNhapHang, string tenThucPham, string donViTinh, float soLuongNhap, DateTime ngayNhap, float luongTon, int isTrangThai)
        {
            this.IDNhapHang = iDNhapHang;
            this.TenThucPham = tenThucPham;
            this.DonViTinh = donViTinh;
            this.SoLuongNhap = soLuongNhap;
            this.NgayNhap = ngayNhap;
            this.LuongTon = luongTon;
            this.IsTrangThai = isTrangThai;
        }
        public NhapHangDTO(DataRow row)
        {
            this.IDNhapHang = int.Parse(row["IDNhapHang"].ToString());
            this.TenThucPham = row["TenThucPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.SoLuongNhap = float.Parse(row["DinhLuong"].ToString());
            this.NgayNhap = Convert.ToDateTime(row["NgayNhap"].ToString());
            this.LuongTon = float.Parse(row["TonKho"].ToString());
            this.IsTrangThai = int.Parse(row["IsTrangThai"].ToString());
        }
        public int IDNhapHang { get => iDNhapHang; set => iDNhapHang = value; }
        public string TenThucPham { get => tenThucPham; set => tenThucPham = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float LuongTon { get => luongTon; set => luongTon = value; }
        public int IsTrangThai { get => isTrangThai; set => isTrangThai = value; }
    }

}

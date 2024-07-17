using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XuatHangDTO
    {
        int iDXuatHang;
        string tenThucPham;
        string donViTinh;
        float soLuongXuat;
        DateTime ngayXuat;
        string lyDoXuatHang;

        public XuatHangDTO(int iDXuatHang, string tenThucPham, string donViTinh, float soLuongXuat, DateTime ngayXuat, string lyDoXuatHang)
        {
            this.IDXuatHang = iDXuatHang;
            this.TenThucPham = tenThucPham;
            this.DonViTinh = donViTinh;
            this.SoLuongXuat = soLuongXuat;
            this.NgayXuat = ngayXuat;
            this.LyDoXuatHang = lyDoXuatHang;
        }
        public XuatHangDTO(DataRow row)
        {
            this.IDXuatHang = int.Parse(row["IDXuatHang"].ToString());
            this.TenThucPham = row["TenThucPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.SoLuongXuat = float.Parse(row["DinhLuong"].ToString());
            this.NgayXuat = Convert.ToDateTime(row["NgayXuat"].ToString());
            this.LyDoXuatHang = row["LyDoXuatHang"].ToString();
        }
        public int IDXuatHang { get => iDXuatHang; set => iDXuatHang = value; }
        public string TenThucPham { get => tenThucPham; set => tenThucPham = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float SoLuongXuat { get => soLuongXuat; set => soLuongXuat = value; }
        public DateTime NgayXuat { get => ngayXuat; set => ngayXuat = value; }
        public string LyDoXuatHang { get => lyDoXuatHang; set => lyDoXuatHang = value; }
    }
}

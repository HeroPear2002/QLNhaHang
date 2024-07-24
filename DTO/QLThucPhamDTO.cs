using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class QLThucPhamDTO
	{
		int iDThucPham;
		string tenThucPham;
		string donViTinh;
		int hanSuDung;

		public QLThucPhamDTO(int iDThucPham, string tenThucPham, string donViTinh, int hanSuDung)
		{
			this.IDThucPham = iDThucPham;
			this.TenThucPham = tenThucPham;
			this.DonViTinh = donViTinh;
			this.HanSuDung = hanSuDung;
		}
		public QLThucPhamDTO(DataRow row)
		{
			this.IDThucPham = (int)row["IDThucPham"];
			this.TenThucPham = row["TenThucPham"].ToString();
			this.DonViTinh = row["DonViTinh"].ToString();
			this.HanSuDung = (int)row["HanSuDung"];
		}

		public int IDThucPham { get => iDThucPham; set => iDThucPham = value; }
		public string TenThucPham { get => tenThucPham; set => tenThucPham = value; }
		public string DonViTinh { get => donViTinh; set => donViTinh = value; }
		public int HanSuDung { get => hanSuDung; set => hanSuDung = value; }
	}
}

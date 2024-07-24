using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class QLThucPhamDAO
	{
		private static QLThucPhamDAO instance;

		public static QLThucPhamDAO Instance { get { if (instance == null) instance = new QLThucPhamDAO(); return instance; } set => instance = value; }

		public QLThucPhamDAO() { }

		public List<QLThucPhamDTO> GetList()
		{
			string query = "select * from tb_ThucPham ";
			DataTable data = Dataprovider.Instance.ExecuteQuery(query);
			List<QLThucPhamDTO> lsv = new List<QLThucPhamDTO>();
			foreach (DataRow item in data.Rows)
			{
				QLThucPhamDTO DTO = new QLThucPhamDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public bool Insert(string tenthucpham, string donvitinh, int hansudung)
		{
			string query = "insert tb_ThucPham(TenThucPham,DonViTinh,HanSuDung) values ( @1 , @2 , @3 )";
			int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenthucpham, donvitinh, hansudung });
			return data > 0;
		}
		public bool Update(int idthucpham, string tenthucpham, string donvitinh, int hansudung)
		{
			string query = "update tb_ThucPham set TenThucPham = @1 , DonViTinh = @2 , HanSuDung = @3 where IDThucPham = @4 ";
			int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenthucpham, donvitinh, hansudung, idthucpham });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "delete tb_ThucPham where IDThucPham = @1 ";
			int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}

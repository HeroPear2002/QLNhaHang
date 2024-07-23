using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhapHangDAO
    {
        private static NhapHangDAO instance;

        public static NhapHangDAO Instance
        {
            get { if (instance == null) instance = new NhapHangDAO(); return instance; }
            set => instance = value;
        }
        public NhapHangDAO() { }

        public List<NhapHangDTO> GetList()
        {
            string query = "select IDNhapHang, TenThucPham, DonViTinh, DinhLuong, NgayNhap, TonKho, IsTrangThai  from tb_NhapHang nh join tb_ThucPham tp on nh.IDThucPham = tp.IDThucPham";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<NhapHangDTO> lsv = new List<NhapHangDTO>();
            foreach (DataRow item in data.Rows)
            {
                NhapHangDTO DTO = new NhapHangDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public bool Insert(int idthucpham, float soluongnhap, DateTime ngaynhap)
        {
            string query = "insert tb_NhapHang(IDThucPham,DinhLuong,NgayNhap,TonKho,IsTrangThai) values ( @1 , @2 , @3 , @4 , 1)";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idthucpham, soluongnhap, ngaynhap, soluongnhap });
            return data > 0;
        }
        public bool Update(int idnhaphang, int idthucpham, float soluongnhap, DateTime ngaynhap, float tonkho, int istrangthai)
        {
            string query = "update tb_NhapHang set IDThucPham = @1 , DinhLuong = @2 , NgayNhap = @3 , TonKho = @4 , IsTrangThai  = @5 where IDNhapHang = @6 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idthucpham, soluongnhap, ngaynhap, tonkho, istrangthai, idnhaphang });
            return data > 0;
        }
        public bool Delete(int id)
        {
            string query = "delete tb_NhapHang where IDNhapHang = @1 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data > 0;
        }
        public void updatethucpham()
        {
            string query = "select HanSuDung from tb_ThucPham where IDThucPham = @1 ";
            string query0 = "select IDThucPham from tb_ThucPham";
            string query1 = "select Sum(TonKho) from tb_NhapHang where day( @1 ) - day(NgayNhap) > @2 and IDThucPham = @3 and IsTrangThai = 1";
            string query2 = "insert tb_XuatHang(IDThucPham, DinhLuong, NgayXuat, IDLyDo) values ( @1 , @2 , @3 , 2)";
            string query3 = "update tb_NhapHang set TonKho = 0 where day( @1 ) - day(NgayNhap) > @2 and IDThucPham = @3 and IsTrangThai = 1";
            DataTable IDThucPham = Dataprovider.Instance.ExecuteQuery(query0);
            foreach (DataRow row in IDThucPham.Rows)
            {
                int idthucpham = Convert.ToInt32(row[0]);
                DateTime now = DateTime.Now;
                int hansudung = Convert.ToInt32(Dataprovider.Instance.ExecuteScalar(query, new object[] { idthucpham }));
                object tonkhot = Dataprovider.Instance.ExecuteScalar(query1, new object[] { now, hansudung, idthucpham }).ToString();
                float tonkho = 0;
                if (tonkhot.ToString() != "" && tonkhot.ToString() != "0")
                {
                    tonkho = float.Parse(tonkhot.ToString());
                    int insetXuat = Dataprovider.Instance.ExecuteNonQuery(query2, new object[] { idthucpham, tonkho, now });
                    int updateNhap = Dataprovider.Instance.ExecuteNonQuery(query3, new object[] { now, hansudung, idthucpham });
                }
                
            }
        }
		public DataTable TenFile()
		{
			string query = "Select TenFile from tb_File";
			DataTable data = Dataprovider.Instance.ExecuteQuery(query);
			return data;
		}
		public bool insertFile(string tenfile)
		{
			string query = "insert tb_File(TenFile) Values ( @1 )";
			int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenfile });
			return data > 0;
		}
		public int TenThucPham(string tenthucpham)
		{
			string query = "Select IDThucPham from tb_ThucPham where TenThucPham = @1 ";
			object data = new object();
			data = Dataprovider.Instance.ExecuteScalar(query, new object[] { tenthucpham });
			return (int)data;
		}
    }
}

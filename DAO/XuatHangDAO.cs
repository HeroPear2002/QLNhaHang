using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class XuatHangDAO
    {
        
        private static XuatHangDAO instance;

        public static XuatHangDAO Instance
        {
            get { if (instance == null) instance = new XuatHangDAO(); return instance; }
            set => instance = value;
        }
        public XuatHangDAO() { }

        public List<XuatHangDTO> GetList()
        {
            string query = "select xh.IDXuatHang, TenThucPham, DonViTinh, DinhLuong, NgayXuat, LyDoXuatHang  from tb_XuatHang xh join tb_ThucPham tp on xh.IDThucPham = tp.IDThucPham join tb_LyDoXH ld on ld.IDLyDo = xh.IDLyDo";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<XuatHangDTO> lsv = new List<XuatHangDTO>();
            foreach (DataRow item in data.Rows)
            {
                XuatHangDTO DTO = new XuatHangDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public bool Insert(int idthucpham, float soluongXuat, DateTime ngayXuat, int idlydo)
        {
            string query = "insert tb_XuatHang(IDThucPham,DinhLuong,NgayXuat,IDLyDo) values ( @1 , @2 , @3 , @4 )";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idthucpham, soluongXuat, ngayXuat, idlydo });
            return data > 0;
        }
        public bool Update(int idXuathang, int idthucpham, float soluongXuat, DateTime ngayXuat, int idlydo)
        {
            string query = "update tb_XuatHang set IDThucPham = @1 , DinhLuong = @2 , NgayXuat = @3 , IDLyDo = @4 where IDXuatHang = @5 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idthucpham, soluongXuat, ngayXuat, idlydo, idXuathang });
            return data > 0;
        }
        public bool Delete(int id)
        {
            string query = "delete tb_XuatHang where IDXuatHang = @1 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data > 0;
        }
    }
}

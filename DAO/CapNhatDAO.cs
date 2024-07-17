using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CapNhatDAO
    {
        private static CapNhatDAO instance;

        public static CapNhatDAO Instance
        {
            get { if (instance == null) instance = new CapNhatDAO(); return instance; }
            set => instance = value;
        }
        public CapNhatDAO() { }

        public int GetCT(int idmonan)
        {
            string query = "select IDCongThuc from tb_MonAn where IDMonAn = @1 ";
            object data = Dataprovider.Instance.ExecuteScalar(query, new object[] { idmonan });
            return int.Parse(data.ToString());
        }
        public List<CongThucMonAn> LisIDTP(int idcongthuc)
        {
            List<CongThucMonAn> lisCT = new List<CongThucMonAn>();
            string query = "Select IDThucPham, DinhLuong from tb_CongThucMonAn ctma join tb_ChiTietCT ctct on ctma.IDCongThuc = ctct.IDCongThuc where ctct.IDCongThuc = @1 ";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(query, new object[] { idcongthuc });
            foreach (DataRow row in data.Rows)
            {
                CongThucMonAn dto = new CongThucMonAn(row);
                lisCT.Add(dto);
            }
            return lisCT;
        }
        public List<CapNhatNhapHangDTO> LisTonKho(int idthucpham)
        {
            List<CapNhatNhapHangDTO> lisCT = new List<CapNhatNhapHangDTO>();
            string query = "select IDNhapHang, TonKho, NgayNhap from tb_NhapHang where IsTrangThai = 1 and IDThucPham = @1 Order by NgayNhap ";
            DataTable data = new DataTable();
            data = Dataprovider.Instance.ExecuteQuery(query, new object[] { idthucpham });
            foreach (DataRow row in data.Rows)
            {
                CapNhatNhapHangDTO dto = new CapNhatNhapHangDTO(row);
                lisCT.Add(dto);
            }
            return lisCT;
        }
        public bool updateNhapHang(float tonkho, int idnhaphang)
        {
            string query = "update tb_NhapHang set TonKho = @1 where IDNhapHang = @2 ";
            string query1 = "update tb_NhapHang set IsTrangThai = 0 where TonKho = 0 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tonkho, idnhaphang });
            int up = Dataprovider.Instance.ExecuteNonQuery(query1);
            return data>0;
        }
        public bool insertXuat(int idthucpham, float dinhluong, DateTime ngayxuat)
        {
            string query = "insert tb_XuatHang(IDThucPham, DinhLuong, NgayXuat, IDLyDo) values ( @1 , @2 , @3 , 1)";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idthucpham, dinhluong, ngayxuat });
            return data > 0;
        }
    }
}

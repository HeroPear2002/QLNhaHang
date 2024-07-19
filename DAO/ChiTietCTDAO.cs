using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietCTDAO
    {
        private static ChiTietCTDAO instance;

        public static ChiTietCTDAO Instance
        {
            get { if (instance == null) instance = new ChiTietCTDAO(); return instance; }
            set => instance = value;
        }
        public ChiTietCTDAO() { }
        public List<CongThucDTO> ListCT()
        {
            string query = "Select IDCongThuc , TenCongThuc from tb_CongThucMonAn";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<CongThucDTO> lsv = new List<CongThucDTO>();
            foreach (DataRow item in data.Rows)
            {
                CongThucDTO DTO = new CongThucDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public bool InsertCT(string tencongthuc, int idmonan)
        {
            string query = "insert tb_CongThucMonAn(TenCongThuc, IDMonAn) values ( @1 , @2 )";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tencongthuc, idmonan });
            return data > 0;
        }
        public bool DeleteCT(int idcongthuc)
        {
            string query1 = "Delete tb_ChiTietCT where IDCongThuc = @1 ";
            string query2 = "Delete tb_CongThucMonAn where IDCongThuc = @1 ";
            int data1 = Dataprovider.Instance.ExecuteNonQuery(query1, new object[] { idcongthuc });
            int data2 = Dataprovider.Instance.ExecuteNonQuery(query2, new object[] { idcongthuc });
            return data2 > 0;
        }
        public List<ChiTietCTDTO> ListChiTiet(int idcongthuc)
        {
            string query = "Select IDChiTietCT, TenThucPham, DinhLuong from tb_ChiTietCT ctct join tb_ThucPham tp on ctct.IDThucPham = tp.IDThucPham where IDCongThuc = @1 ";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query, new object[] { idcongthuc });
            List<ChiTietCTDTO> lsv = new List<ChiTietCTDTO>();
            foreach (DataRow item in data.Rows)
            {
                ChiTietCTDTO DTO = new ChiTietCTDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public DataTable Tabledata(int idcongthuc)
        {
            string query = "Select IDChiTietCT, TenThucPham, DinhLuong from tb_ChiTietCT ctct join tb_ThucPham tp on ctct.IDThucPham = tp.IDThucPham where IDCongThuc = @1 ";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query, new object[] { idcongthuc });
            return data;
            
        }
        public bool InsertChiTiet(int idcongthuc, int idthucpham, float dinhluong)
        {
            string query = "insert tb_ChiTietCT(IDCongThuc, IDThucPham, DinhLuong) values( @1 , @2 , @3 )";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idcongthuc, idthucpham, dinhluong });
            return data > 0;
        }
        public bool Update(int idchitietct, float dinhluong)
        {
            string query = "update tb_ChiTietCT set DinhLuong = @1 where IDChiTietCT = @2 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { dinhluong, idchitietct });
            return data > 0;
        }
        public bool Delete(int idchitietct)
        {
            string query = "Delete tb_ChiTietCT where IDChiTietCT = @1 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idchitietct });
            return data > 0;
        }
    }
}

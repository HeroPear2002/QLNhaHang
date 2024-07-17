using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MonAnTDAO
    {
        private static MonAnTDAO instance;

        public static MonAnTDAO Instance
        {
            get { if (instance == null) instance = new MonAnTDAO(); return instance; }
            set => instance = value;
        }
        public MonAnTDAO() { }

        public DataTable GetList()
        {
            string query = "select IDMonAn, TenMon, Gia, TenCongThuc, IsMonAn from tb_MonAn ma join tb_CongThucMonAn ctma on ma.IDCongThuc = ctma.IDCongThuc";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            return data;
        }
        public bool Insert(string tenmon, float gia, int idcongthuc)
        {
            string query = "insert tb_MonAn(TenMon, Gia, IDCongThuc, IsMonAn) values ( @1 , @2 , @3 , 1)";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenmon, gia, idcongthuc });
            return data > 0;
        }
        public bool Update(int idmonan, string tenmon, float gia, int idcongthuc)
        {
            string query = "update tb_MonAn set TenMon = @1 , Gia = @2 , IDCongThuc = @3 where IDMonAn = @4 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenmon, gia, idcongthuc, idmonan });
            return data > 0;
        }
        public bool Update(int idmonan, int ismonan)
        {
            string query = "update tb_MonAn set IsMonAn = @1 where IDMonAn = @2 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { ismonan, idmonan });
            return data > 0;
        }
        public bool Delete(int id)
        {
            string query = "delete tb_MonAn where IDMonAn = @1 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data > 0;
        }
    }
}

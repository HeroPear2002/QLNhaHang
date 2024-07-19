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
            string query = "select IDMonAn, TenMon, Gia, IsMonAn from tb_MonAn";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            return data;
        }
        public bool Insert(string tenmon, float gia)
        {
            string query = "insert tb_MonAn(TenMon, Gia, IsMonAn) values ( @1 , @2 , 1)";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenmon, gia });
            return data > 0;
        }
        public bool Update(int idmonan, string tenmon, float gia)
        {
            string query = "update tb_MonAn set TenMon = @1 , Gia = @2  where IDMonAn = @3 ";
            int data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenmon, gia,  idmonan });
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

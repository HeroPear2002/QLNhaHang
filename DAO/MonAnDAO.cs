using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MonAnDAO
    {
        private static MonAnDAO instance;

        public static MonAnDAO Instance
        {
            get { if (instance == null) instance = new MonAnDAO(); return instance; }
            set => instance = value;
        }
        public MonAnDAO() { }
        public List<MonAnDTO> LisMonAn(string query)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<MonAnDTO> lsv = new List<MonAnDTO>();
            foreach (DataRow item in data.Rows)
            {
                MonAnDTO DTO = new MonAnDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<MonAnDTO> LisMonAn1(string tenban)
        {
            string query = "select a.IDMonAn, TenMon, SoLuong, Gia, (SoLuong * Gia) as thanhtien, TenBan, IDGoiMon from  tb_MonAn a join tb_GoiMon b on a.IDMonAn = b.IDMonAn join tb_DatBan c on b.IDDatBan = c.IDDatBan where IsGoiMon = 1 and c.IsDatBan = 1 and ( TenBan = @1 ) ";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query, new object[] { tenban });
            List<MonAnDTO> lsv = new List<MonAnDTO>();
            foreach (DataRow item in data.Rows)
            {
                MonAnDTO DTO = new MonAnDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<MONANCBDTO> ListTenMon()
        {
            List<MONANCBDTO> listTenSp = new List<MONANCBDTO>();
            string query = "select IdMonAn, TenMon, Gia from tb_MonAn";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            int i = 0;
            foreach (DataRow item in data.Rows)
            {
                MONANCBDTO CBDTO = new MONANCBDTO(item);
                listTenSp.Add(CBDTO);
                i++;
            }
            return listTenSp;
        }
        public bool insert(int soluong, string tenmonan, string tenban)
        {
            string query = "insert tb_GoiMon ([IDDatBan],[SoLuong],[IDMonAn],[IsGoiMon]) values ( @1 , @2 , @3 , 1)";
            int data = 0;
            int iddatban = idDatBan(tenban);
            int idmon = idMonAn(tenmonan);
            data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { iddatban, soluong, idmon });
            return data>0 ;
        }
        public bool updatedatmon(int soluong, int idgoimon)
        {
            string query = "update tb_GoiMon set soluong = @1 where IDGoiMon = @2 ";
            int data = 0;
            data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { soluong, idgoimon });
            return data > 0;
        }
        public bool insertban(string tenban)
        {
            string query = "insert tb_DatBan ([Tenban], [IsDatBan]) values ( @4 ,1)";
            int data = 0;
            data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenban });
            return data > 0;
        }
        public int isDatBan(string tenban)
        {
            string query = "select isDatBan from tb_DatBan where TenBan = @1 and isDatBan = 1";
            object data = new object();
            data = Dataprovider.Instance.ExecuteScalar(query, new object[] { tenban });
            if(data == null)
            {
                return 0;
            }
            return int.Parse(data.ToString());
        }
        public int idDatBan(string tenban)
        {
            string query = "select IDDatBan from tb_DatBan where TenBan = @1 and isDatBan = 1 ";
            object data = new object();
            data = Dataprovider.Instance.ExecuteScalar(query, new object[] { tenban });
            return int.Parse(data.ToString());
        }
        public int idMonAn(string tenmonan)
        {
            string query = "select IDMonAn from tb_MonAn where TenMon = @1 and isMonAn = 1 ";
            object data = new object();
            data = Dataprovider.Instance.ExecuteScalar(query, new object[] { tenmonan });
            return int.Parse(data.ToString());
        }
        public bool updatedatban(string tenban)
        {
            string query = "Update tb_DatBan set IsDatBan = 0 where TenBan = @1 and IsDatBan = 1";
            int data;
            data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { tenban });
            return data > 0;
        }
        public bool updategoimon(int idgoimon)
        {
            string query = "Update tb_GoiMon set IsGoiMon = 0 where IDGoiMon = @1 ";
            int data;
            data = Dataprovider.Instance.ExecuteNonQuery(query, new object[] { idgoimon });
            return data > 0;
        }
        public DataTable LisIDGoiMon(string query)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            return data;
        }
        public int getisban(int idmonan, string tenban)
        {
            int iddatban = idDatBan(tenban);
            string query = "select isgoimon from [dbo].[tb_GoiMon] where idMonAn = @1 and IDDatBan = @2 and isgoimon = @3";
            object data = new object();
            data = Dataprovider.Instance.ExecuteScalar(query, new object[] { idmonan, iddatban });
            return int.Parse(data.ToString());
        }
    }
}

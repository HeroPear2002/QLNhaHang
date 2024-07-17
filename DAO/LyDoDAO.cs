using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LyDoDAO
    {
        private static LyDoDAO instance;

        public static LyDoDAO Instance
        {
            get { if (instance == null) instance = new LyDoDAO(); return instance; }
            set => instance = value;
        }
        public LyDoDAO() { }
        public List<LyDoDTO> GetList()
        {
            string query = "select IDLyDo, LyDoXuatHang from tb_LyDoXH";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<LyDoDTO> lsv = new List<LyDoDTO>();
            foreach (DataRow item in data.Rows)
            {
                LyDoDTO DTO = new LyDoDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
    }
}

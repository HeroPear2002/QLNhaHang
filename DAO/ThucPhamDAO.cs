using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThucPhamDAO
    {
        private static ThucPhamDAO instance;

        public static ThucPhamDAO Instance
        {
            get { if (instance == null) instance = new ThucPhamDAO(); return instance; }
            set => instance = value;
        }
        public ThucPhamDAO() { }
        public List<ThucPhamDTO> GetList()
        {
            string query = "select IDThucPham, TenThucPham  from tb_ThucPham";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            List<ThucPhamDTO> lsv = new List<ThucPhamDTO>();
            foreach (DataRow item in data.Rows)
            {
                ThucPhamDTO DTO = new ThucPhamDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
    }
}

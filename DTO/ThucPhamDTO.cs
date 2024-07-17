using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThucPhamDTO
    {
        int iDThucPham;
        string tenThucPham;

        public ThucPhamDTO(int iDThucPham, string tenThucPham)
        {
            this.IDThucPham = iDThucPham;
            this.TenThucPham = tenThucPham;
        }
        public ThucPhamDTO(DataRow row)
        {
            this.IDThucPham = int.Parse(row["IDThucPham"].ToString());
            this.TenThucPham = row["TenThucPham"].ToString();
        }
        public int IDThucPham { get => iDThucPham; set => iDThucPham = value; }
        public string TenThucPham { get => tenThucPham; set => tenThucPham = value; }
    }
}

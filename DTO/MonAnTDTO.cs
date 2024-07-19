using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAnTDTO
    {
        int iDMonAn;
        string tenMon;
        float gia;
        int isMonAn;

        public MonAnTDTO(int iDMonAn, string tenMon, float gia, int isMonAn)
        {
            this.IDMonAn = iDMonAn;
            this.TenMon = tenMon;
            this.Gia = gia;
            this.IsMonAn = isMonAn;
        }
        public MonAnTDTO(DataRow row)
        {
            this.IDMonAn = int.Parse(row["IDMonAn"].ToString());
            this.TenMon = row["TenMon"].ToString();
            this.Gia = float.Parse(row["Gia"].ToString());
            this.IsMonAn = int.Parse(row["IsMonAn"].ToString());
        }

        public int IDMonAn { get => iDMonAn; set => iDMonAn = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public float Gia { get => gia; set => gia = value; }
        public int IsMonAn { get => isMonAn; set => isMonAn = value; }
    }
}

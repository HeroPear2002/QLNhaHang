using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LyDoDTO
    {
        int iDLyDo;
        string lyDoXuatHang;

        public LyDoDTO(int iDLyDo, string lyDoXuatHang)
        {
            this.IDLyDo = iDLyDo;
            this.LyDoXuatHang = lyDoXuatHang;
        }
        public LyDoDTO(DataRow row)
        {
            this.IDLyDo = int.Parse(row["IDLyDo"].ToString());
            this.LyDoXuatHang = row["LyDoXuatHang"].ToString();
        }
        public int IDLyDo { get => iDLyDo; set => iDLyDo = value; }
        public string LyDoXuatHang { get => lyDoXuatHang; set => lyDoXuatHang = value; }
    }
}

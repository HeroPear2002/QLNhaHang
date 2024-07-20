using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaHang
{
	public static class StaticEllipes
	{
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int HeightEllipse);

		public static void Ellipes(Control item, int boder, int boW, int boH)
		{
			item.Region = Region.FromHrgn(CreateRoundRectRgn(boder, boder, item.Width - boder, item.Height - boder, boW, boH));
		}
	}
}

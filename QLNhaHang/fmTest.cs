using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace QLNhaHang
{
	public partial class fmTest : DevExpress.XtraEditors.XtraForm
	{
		public fmTest()
		{
			InitializeComponent();
		}

		private void fmTest_Load(object sender, EventArgs e)
		{
			StaticEllipes.Ellipes(simpleButton1,3,30,30);
		}
	}
}
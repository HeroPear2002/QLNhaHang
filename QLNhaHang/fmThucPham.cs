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
using DAO;
using ExcelDataReader;
using System.IO;
using DevExpress.XtraReports.UI;

namespace QLNhaHang
{
	public partial class fmThucPham : DevExpress.XtraEditors.XtraForm
	{
		public fmThucPham()
		{
			InitializeComponent(); LoadControl();

		}
		bool them = true;
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}

		private void LoadData()
		{
			gridControl1.DataSource = QLThucPhamDAO.Instance.GetList();
		}

		private void CleanText()
		{
			txtTenTP.Text = string.Empty;
			txtDVT.Text = string.Empty;
			numHSD.Value = 0;
		}

		private void LockControl(bool v)
		{
			if (v)
			{
				txtTenTP.Enabled = false;
				txtDVT.Enabled = false;
				numHSD.Enabled = false;
				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;
				btnLuu.Enabled = false;
			}
			else
			{
				txtTenTP.Enabled = true;
				txtDVT.Enabled = true;
				numHSD.Enabled = true;
				btnThem.Enabled = false;
				btnSua.Enabled = false;
				btnXoa.Enabled = false;
				btnLuu.Enabled = true;
			}

		}
		void Save()
		{
			string tenthucpham = txtTenTP.Text;
			string donvitinh = txtDVT.Text;
			int hansudung = (int)numHSD.Value;
			if (them)
			{
				bool insert = QLThucPhamDAO.Instance.Insert(tenthucpham, donvitinh, hansudung);
				if (insert)
				{
					MessageBox.Show("Thanh Cong");
					return;
				}
				MessageBox.Show("That Bai");

			}
			else
			{
				int idthucpham = int.Parse(gridView1.GetFocusedRowCellValue("IDThucPham").ToString());
				bool update = QLThucPhamDAO.Instance.Update(idthucpham, tenthucpham, donvitinh, hansudung);
				if (update)
				{
					MessageBox.Show("Thanh Cong");
					return;
				}
				MessageBox.Show("That Bai");
			}


		}

		private void fmTest_Load(object sender, EventArgs e)
		{
		
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			LockControl(false);
			them = true;
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			LockControl(false);
			them = false;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			foreach (var item in gridView1.GetSelectedRows())
			{
				int i = int.Parse(gridView1.GetRowCellValue(item, "IDThucPham").ToString());
				bool delete = QLThucPhamDAO.Instance.Delete(i);
			}
			LoadControl();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			Save();
			LoadControl();
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			LoadControl();
		}
		private void gridView1_Click(object sender, EventArgs e)
		{
			try
			{
				txtTenTP.Text = gridView1.GetFocusedRowCellValue("TenThucPham").ToString();
				txtDVT.Text = gridView1.GetFocusedRowCellValue("DonViTinh").ToString();
				numHSD.Value = decimal.Parse(gridView1.GetFocusedRowCellValue("HanSuDung").ToString());
			}
			catch (Exception)
			{


			}
		}
	}
}
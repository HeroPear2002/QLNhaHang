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
using DAO;
using DTO;
using ExcelDataReader;
using System.IO;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;

namespace QLNhaHang
{
    public partial class fmNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public fmNhapHang()
        {
            InitializeComponent();
            LoadControl();
        }
		FilterInfoCollection filterInfoCollection;
		VideoCaptureDevice videoCaptureDevice;
        List<ThucPhamDTO> LsTenTp = ThucPhamDAO.Instance.GetList();
		DataTableCollection data;
		private void LoadControl()
        {
            LockControl(true);
            CleanText();
            LoadData();
        }

        private void LoadData()
        {
			filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (FilterInfo item in filterInfoCollection)
			{
				cbChonCam.Items.Add(item.Name);
			}
			if(cbChonCam.SelectedValue != null)
			{
				cbChonCam.SelectedIndex = 0;
			}
			
            slChonTP.Properties.DataSource = LsTenTp;
            slChonTP.Properties.DisplayMember = "TenThucPham";
            slChonTP.Properties.ValueMember = "IDThucPham";
            gridControl1.DataSource = NhapHangDAO.Instance.GetList();
        }

        private void CleanText()
        {
            txtSoLuongNhap.Text = string.Empty;
            txtLuongTon.Text = string.Empty;
            txtIDNhapHang.Text = string.Empty;
            slChonTP.Text = string.Empty;
        }

        private void LockControl(bool v)
        {
            txtIDNhapHang.Enabled = false;
            if (v)
            {
                txtSoLuongNhap.Enabled = false;
                txtLuongTon.Enabled = false;
                slChonTP.Enabled = false;
                dtNgayNhap.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
            }
            else
            {
                txtSoLuongNhap.Enabled = true;
                slChonTP.Enabled = true;
                txtLuongTon.Enabled = true;
                dtNgayNhap.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }

        }
        void Save()
        {
            float soluongnhap = float.Parse(txtSoLuongNhap.Text);
            float luongton;
            if(txtLuongTon.Text == "")
            {
                luongton = 0;
            }
            else
                luongton = float.Parse(txtLuongTon.Text);
            int idthucpham = int.Parse(slChonTP.EditValue.ToString());
            DateTime ngaynhap = dtNgayNhap.Value;
            int istrangthai;
            if (luongton == 0)
            {
                istrangthai = 0;
            }
            else
				istrangthai = 1;
			int idnhaphang = int.Parse(gridView1.GetFocusedRowCellValue("IDNhapHang").ToString());
			bool update = NhapHangDAO.Instance.Update(idnhaphang, idthucpham, soluongnhap, ngaynhap, luongton, istrangthai);
			if (update)
			{
				MessageBox.Show("Thanh Cong");
				return;
			}
			MessageBox.Show("That Bai");


        }
		private void btnThem_Click(object sender, EventArgs e)
        {
			DataTable data = NhapHangDAO.Instance.TenFile();
			if (lbPath.Text == "")
			{
				using (XtraOpenFileDialog Opfile = new XtraOpenFileDialog() { Filter = "Excel Workbook|*.xls;*.xlsx" })
				{
					if (Opfile.ShowDialog() == DialogResult.OK)
					{
						foreach (DataRow row in data.Rows)
						{
							if(row["TenFile"].ToString() == Opfile.SafeFileName)
							{
								MessageBox.Show("Đã nhập file này rồi.");
								return;
							}
						}
						bool insertfile = NhapHangDAO.Instance.insertFile(Opfile.SafeFileName);
						OpenFile(Opfile.FileName);
					}
				}
			}
			else
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string pathfull;
				string[] File = Directory.GetFiles(path);
				foreach (string item in File)
				{
					if(item == lbPath.Text + ".xlsx")
					{
						lbPath.Text = lbPath.Text + ".xlsx";
						pathfull = Path.Combine(path, lbPath.Text);
					}
					else if(item == lbPath.Text + ".xls")
					{
						lbPath.Text = lbPath.Text + ".xls";
						pathfull = Path.Combine(path, lbPath.Text);
					}
				}
				foreach (DataRow row in data.Rows)
				{
					if (row["TenFile"].ToString() == lbPath.Text)
					{
						MessageBox.Show("Đã nhập file này rồi.");
						return;
					}
				}
				bool insertfile = NhapHangDAO.Instance.insertFile(lbPath.Text);
				OpenFile(lbPath.Text);
			}
			LoadControl();
		}
		private void OpenFile(string pathfile)
		{
			using (var stream = File.Open(pathfile, FileMode.Open, FileAccess.Read))
			{
				using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
				{
					DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
					});
					data = result.Tables;
					foreach (DataTable dataTable in data)
					{
						foreach(DataRow row in dataTable.Rows)
						{
							int idthucpham = int.Parse(row["IDThucPham"].ToString());
							int soluongnhap = int.Parse(row["SoLuong"].ToString());
							DateTime ngaynhap = DateTime.Now;
							bool insert = NhapHangDAO.Instance.Insert(idthucpham, soluongnhap, ngaynhap);
						}
					}
				}
			}
		}
        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            txtLuongTon.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                int i = int.Parse(gridView1.GetRowCellValue(item, "IDNhapHang").ToString());
                bool delete = NhapHangDAO.Instance.Delete(i);
            }
            LoadControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtIDNhapHang.Text = gridView1.GetFocusedRowCellValue("IDNhapHang").ToString();
                txtSoLuongNhap.Text = gridView1.GetFocusedRowCellValue("SoLuongNhap").ToString();
                txtLuongTon.Text = gridView1.GetFocusedRowCellValue("LuongTon").ToString();
                dtNgayNhap.Value = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayNhap").ToString());
                string tenthucpham = gridView1.GetFocusedRowCellValue("TenThucPham").ToString();
                foreach (ThucPhamDTO item in LsTenTp)
                {
                    if(item.TenThucPham == tenthucpham)
                    {
                        slChonTP.EditValue = item.IDThucPham;
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
		private void Enter_Click(object sender, EventArgs e)
		{
			btnThem_Click(sender,e);
		}

		private void cbChonCam_SelectedValueChanged(object sender, EventArgs e)
		{
			if(videoCaptureDevice != null)
			{
				if(videoCaptureDevice.IsRunning)
				{
					videoCaptureDevice.Stop();
				}
			}
			if (cbChonCam.SelectedValue != null)
			{
				videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbChonCam.SelectedIndex].MonikerString);
				videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
				videoCaptureDevice.Start();
			}
		}

		private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
			BarcodeReader reader = new BarcodeReader();
			var result = reader.Decode(bitmap);
			if(result != null)
			{
				lbPath.Text = result.ToString();
			}
		}
	}
}
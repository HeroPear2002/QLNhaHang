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

namespace QLNhaHang
{
    public partial class fmCongThuc : DevExpress.XtraEditors.XtraForm
    {
        bool them = false;
		List<CongThucDTO> lisCT = new List<CongThucDTO>();
		List<ThucPhamDTO> LsTenTp = new List<ThucPhamDTO>();
		List<MONANCBDTO> LsTenMon = new List<MONANCBDTO>();
		public fmCongThuc()
        {
            InitializeComponent();
            LoadControl();
        }
        private void LoadControl()
        {
            them = false;
            LockControl(true);
            CleanText();
            LoadData();
        }

        private void LoadData()
        {
			lisCT = ChiTietCTDAO.Instance.ListCT();
			LsTenTp = ThucPhamDAO.Instance.GetList();
			LsTenMon = MonAnDAO.Instance.ListTenMon();
			slChonTP.Properties.DataSource = LsTenTp;
            slChonTP.Properties.DisplayMember = "TenThucPham";
            slChonTP.Properties.ValueMember = "IDThucPham";
            slChonCT.Properties.DataSource = lisCT;
            slChonCT.Properties.DisplayMember = "TenCongThuc";
            slChonCT.Properties.ValueMember = "IDCongThuc";
			slChonMon.Properties.DataSource = LsTenMon;
			slChonMon.Properties.DisplayMember = "TenMonAn";
			slChonMon.Properties.ValueMember = "IDMonAn";
			gridControl1.DataSource = null;
        }

        private void CleanText()
        {
            txtCongThuc.Text = string.Empty;
            txtDinhLuong.Text = string.Empty;
            slChonCT.Text = string.Empty;
            slChonTP.Text = string.Empty;
			slChonMon.Text = string.Empty;
		}

        private void LockControl(bool v)
        {
            btnThem.Enabled = false;
			txtCongThuc.Enabled = false;
			if (v)
            {
				btnThemMon.Enabled = true;
				slChonMon.Enabled = true;
                txtDinhLuong.Enabled = false;
                slChonTP.Enabled = false;
                slChonCT.Enabled = true;
                btnXoa.Enabled = false;
                btnThemTP.Enabled = false;
                btnXoaTP.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
				btnThemMon.Enabled = false;
				slChonMon.Enabled = false;
                slChonTP.Enabled = true;
                txtDinhLuong.Enabled = true;
                slChonCT.Enabled = true;
                btnXoa.Enabled = true;
                btnThemTP.Enabled = true;
                btnXoaTP.Enabled = true;
                btnLuu.Enabled = true;
            }

        }
        void Save()
        {
            int idcongthuc = int.Parse(slChonCT.EditValue.ToString());
            float dinhluong = 0;
            int idthucpham = 0;
            if (txtDinhLuong.Text != "" && slChonTP.EditValue.ToString() != "")
            {
                dinhluong = float.Parse(txtDinhLuong.Text);
                idthucpham = int.Parse(slChonTP.EditValue.ToString());
            }
            if (them)
            {
                bool insert = ChiTietCTDAO.Instance.InsertChiTiet(idcongthuc, idthucpham, dinhluong);
                if (insert)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tencongthuc = txtCongThuc.Text;
			int idmonan = int.Parse(slChonMon.EditValue.ToString());
            bool insert = ChiTietCTDAO.Instance.InsertCT(tencongthuc, idmonan);
            if (insert)
            {
                MessageBox.Show("Thanh Cong");
                LoadControl();
                return;
            }
            MessageBox.Show("That Bai");

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idcongthuc = int.Parse(slChonCT.EditValue.ToString());
            bool delete = ChiTietCTDAO.Instance.DeleteCT(idcongthuc);
            if (delete)
            {
                MessageBox.Show("Thanh Cong");
                LoadControl();
                return;
            }
            MessageBox.Show("That Bai");
        }
        private void btnThemTP_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = true;
        }
        private void btnXoaTP_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                int i = int.Parse(gridView1.GetRowCellValue(item, "IDChiTietCT").ToString());
                bool delete = ChiTietCTDAO.Instance.Delete(i);
            }
            LoadControl();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable data = (DataTable)gridControl1.DataSource;
            foreach (DataRow item in data.Rows)
            {
                if (item.RowState == DataRowState.Modified)
                {
                    int idchitietct = int.Parse(item["IDChiTietCT"].ToString());
                    float dinhluong = float.Parse(item["DinhLuong"].ToString());
                    bool kq = ChiTietCTDAO.Instance.Update(idchitietct, dinhluong);
                }
            }
            LoadControl();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }
        public void loadgrc1(int idcongthuc)
        {
            gridControl1.DataSource = ChiTietCTDAO.Instance.Tabledata(idcongthuc);
        }

        private void slChonCT_EditValueChanged(object sender, EventArgs e)
        {
            if(slChonCT.EditValue != null && slChonCT.EditValue.ToString() != "" && slChonCT.EditValue.ToString() != "0")
            {
                LockControl(false);
                int idcongthuc = int.Parse(slChonCT.EditValue.ToString());
                loadgrc1(idcongthuc);
				return;
            }
			LoadControl();
        }

        private void txtCongThuc_TextChanged(object sender, EventArgs e)
        {
            if(txtCongThuc.Text == "")
            {
                btnThem.Enabled = false;
                return;
            }
            btnThem.Enabled = true;
        }

		private void btnThemMon_Click(object sender, EventArgs e)
		{
			fmMonAn f = new fmMonAn();
			f.ShowDialog();
			LoadControl();
		}
		private void slChonMon_EditValueChanged(object sender, EventArgs e)
		{
			if(slChonMon.EditValue != null && slChonMon.EditValue.ToString() != "" && slChonMon.EditValue.ToString() != "0")
			{
				txtCongThuc.Enabled = true;
				btnThemMon.Enabled = false;
				return;
			}
			LoadControl();
		}
	}
}
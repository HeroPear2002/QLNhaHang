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
    public partial class fmXuatHang : DevExpress.XtraEditors.XtraForm
    {
        public fmXuatHang()
        {
            InitializeComponent();
            LoadControl();

        }
        bool them = true;
        List<ThucPhamDTO> LsTenTp = ThucPhamDAO.Instance.GetList();
        List<LyDoDTO> LsLyDo = LyDoDAO.Instance.GetList();
        private void LoadControl()
        {
            LockControl(true);
            CleanText();
            LoadData();
        }

        private void LoadData()
        {
            slChonTP.Properties.DataSource = LsTenTp;
            slChonTP.Properties.DisplayMember = "TenThucPham";
            slChonTP.Properties.ValueMember = "IDThucPham";
            slChonLD.Properties.DataSource = LsLyDo;
            slChonLD.Properties.DisplayMember = "LyDoXuatHang";
            slChonLD.Properties.ValueMember = "IDLyDo";
            gridControl1.DataSource = XuatHangDAO.Instance.GetList();
        }

        private void CleanText()
        {
            txtSoLuongXuat.Text = string.Empty;
            txtIDXuatHang.Text = string.Empty;
            slChonTP.Text = string.Empty;
            slChonLD.Text = string.Empty;
        }

        private void LockControl(bool v)
        {
            txtIDXuatHang.Enabled = false;
            if (v)
            {
                txtSoLuongXuat.Enabled = false;
                slChonTP.Enabled = false;
                slChonLD.Enabled = false;
                dtNgayXuat.Enabled = false;
                btnXThem.Enabled = true;
                btnXSua.Enabled = true;
                btnXXoa.Enabled = true;
                btnXLuu.Enabled = false;
            }
            else
            {
                txtSoLuongXuat.Enabled = true;
                slChonTP.Enabled = true;
                slChonLD.Enabled = true;
                dtNgayXuat.Enabled = true;
                btnXThem.Enabled = false;
                btnXSua.Enabled = false;
                btnXXoa.Enabled = false;
                btnXLuu.Enabled = true;
            }

        }
        void Save()
        {
            float soluongXuat = float.Parse(txtSoLuongXuat.Text);
            int idthucpham = int.Parse(slChonTP.EditValue.ToString());
            int idlydo = int.Parse(slChonLD.EditValue.ToString());
            DateTime ngayXuat = dtNgayXuat.Value;
            if (them)
            {
                bool insert = XuatHangDAO.Instance.Insert(idthucpham, soluongXuat, ngayXuat, idlydo);
                if (insert)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");

            }
            else
            {
                int idXuathang = int.Parse(gridView1.GetFocusedRowCellValue("IDXuatHang").ToString());
                bool update = XuatHangDAO.Instance.Update(idXuathang, idthucpham, soluongXuat, ngayXuat, idlydo);
                if (update)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");
            }


        }
        private void btnXThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = true;
        }

        private void btnXSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = false;
        }

        private void btnXXoa_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                int i = int.Parse(gridView1.GetRowCellValue(item, "IDXuatHang").ToString());
                bool delete = XuatHangDAO.Instance.Delete(i);
            }
            LoadControl();
        }

        private void btnXLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtIDXuatHang.Text = gridView1.GetFocusedRowCellValue("IDXuatHang").ToString();
                txtSoLuongXuat.Text = gridView1.GetFocusedRowCellValue("SoLuongXuat").ToString();
                dtNgayXuat.Value = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayXuat").ToString());
                slChonTP.Text = gridView1.GetFocusedRowCellValue("TenThucPham").ToString();
                slChonLD.Text = gridView1.GetFocusedRowCellValue("LyDoXuatHang").ToString();
                string tenthucpham = gridView1.GetFocusedRowCellValue("TenThucPham").ToString();
                foreach (ThucPhamDTO item in LsTenTp)
                {
                    if (item.TenThucPham == tenthucpham)
                    {
                        slChonTP.EditValue = item.IDThucPham;
                    }
                }
                string lydo = gridView1.GetFocusedRowCellValue("LyDoXuatHang").ToString();
                foreach (LyDoDTO item in LsLyDo)
                {
                    if (item.LyDoXuatHang == tenthucpham)
                    {
                        slChonTP.EditValue = item.IDLyDo;
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
    }
}
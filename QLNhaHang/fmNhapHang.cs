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
    public partial class fmNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public fmNhapHang()
        {
            InitializeComponent();
            LoadControl();

        }
        bool them = true;
        List<ThucPhamDTO> LsTenTp = ThucPhamDAO.Instance.GetList();
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
            if (them)
            {
                bool insert = NhapHangDAO.Instance.Insert(idthucpham, soluongnhap, ngaynhap);
                if (insert)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");

            }
            else
            {
                int idnhaphang = int.Parse(gridView1.GetFocusedRowCellValue("IDNhapHang").ToString());
                bool update = NhapHangDAO.Instance.Update(idnhaphang, idthucpham, soluongnhap, ngaynhap, luongton, istrangthai);
                if (update)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");
            }


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = true;
            txtLuongTon.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = false;
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
    }
}
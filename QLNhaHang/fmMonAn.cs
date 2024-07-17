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
using DTO;
using DAO;

namespace QLNhaHang
{
    public partial class fmMonAn : DevExpress.XtraEditors.XtraForm
    {
        public fmMonAn()
        {
            InitializeComponent();
            LoadControl();

        }
        bool them = true;
        List<CongThucDTO> lisCT = ChiTietCTDAO.Instance.ListCT();
        private void LoadControl()
        {
            LockControl(true);
            CleanText();
            LoadData();
        }

        private void LoadData()
        {
            slChonCT.Properties.DataSource = lisCT;
            slChonCT.Properties.DisplayMember = "TenCongThuc";
            slChonCT.Properties.ValueMember = "IDCongThuc";
            gridControl1.DataSource = MonAnTDAO.Instance.GetList();
        }

        private void CleanText()
        {
            txtTenMon.Text = string.Empty;
            txtGia.Text = string.Empty;
            slChonCT.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtTenMon.Enabled = false;
                txtGia.Enabled = false;
                slChonCT.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
            }
            else
            {
                txtTenMon.Enabled = true;
                txtGia.Enabled = true;
                slChonCT.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }

        }
        void Save()
        {
            float gia = float.Parse(txtGia.Text);
            int idcongthuc = int.Parse(slChonCT.EditValue.ToString());
            string tenmon = txtTenMon.Text;
            if (them)
            {
                bool insert = MonAnTDAO.Instance.Insert(tenmon, gia, idcongthuc);
                if (insert)
                {
                    MessageBox.Show("Thanh Cong");
                    return;
                }
                MessageBox.Show("That Bai");

            }
            else
            {
                int idmonan = int.Parse(gridView1.GetFocusedRowCellValue("IDMonAn").ToString());
                bool update = MonAnTDAO.Instance.Update(idmonan, tenmon, gia, idcongthuc);
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
                int i = int.Parse(gridView1.GetRowCellValue(item, "IDMonAn").ToString());
                bool delete = MonAnTDAO.Instance.Delete(i);
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
                    int idmonan = int.Parse(item["IDMonAn"].ToString());
                    int ismonan = int.Parse(item["IsMonAn"].ToString());
                    bool kq = MonAnTDAO.Instance.Update(idmonan, ismonan);
                }
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
                txtTenMon.Text = gridView1.GetFocusedRowCellValue("TenMon").ToString();
                txtGia.Text = gridView1.GetFocusedRowCellValue("Gia").ToString();
                string tenct = gridView1.GetFocusedRowCellValue("TenCongThuc").ToString();
                foreach (CongThucDTO item in lisCT)
                {
                    if (item.TenCongThuc == tenct)
                    {
                        slChonCT.EditValue = item.IDCongThuc;
                    }
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
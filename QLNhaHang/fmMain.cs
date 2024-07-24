using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace QLNhaHang
{
    public partial class fmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public fmMain()
        {
            InitializeComponent();
            LoadThucPham();
        }

        private void LoadThucPham()
        {
            NhapHangDAO.Instance.updatethucpham();
        }

        public void OpemForm(Type typeForm)
        {
            foreach (var item in this.MdiChildren)
            {
                if (typeForm == item.GetType())
                {
                    item.Close();
                    item.Activate();
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        private void btnDatBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpemForm(typeof(fmDatBan));
        }

        public void btnNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpemForm(typeof(fmNhapHang));
        }
        private void btnXuatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpemForm(typeof(fmXuatHang));
        }

        private void btnThemCongThuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpemForm(typeof(fmCongThuc));
        }

        private void btnMonAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpemForm(typeof(fmMonAn));
        }

		private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
		{
			using (XtraOpenFileDialog Opfile = new XtraOpenFileDialog() { Filter = "Excel Workbook|*.xls;*.xlsx" })
			{
				Opfile.ShowDialog();
				XtraReport1 report1 = new XtraReport1(Opfile.FileName, Opfile.SafeFileName);
				report1.ShowPreviewDialog();
			}
		}

		private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
		{
			OpemForm(typeof(fmThucPham));
		}
	}
}
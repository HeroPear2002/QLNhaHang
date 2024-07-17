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
    }
}
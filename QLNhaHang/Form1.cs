using DAO;
using DevExpress.XtraEditors;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNhaHang
{
    public partial class fmDatBan : DevExpress.XtraEditors.XtraForm
    {
        List<MonAnDTO> lisvTong = new List<MonAnDTO>();
        List<int> iddatban = new List<int>();
        public fmDatBan()
        {
            InitializeComponent();
            Loadbt(10, 3);
        }
        public void Loadbt(int soban, int sobantrenhang)
        {
            int pan_w = panel1.Width;
            int dai = (pan_w / (sobantrenhang * 3))/2;
            int rong = dai;
            int kc = pan_w / (sobantrenhang * 3) + 50;
            int j = 0;
            while(soban % sobantrenhang >= 0)
            {
                if (soban >= sobantrenhang)
                {
                    for (int i = 0; i < sobantrenhang; i++)
                    {
                        SimpleButton bt = new SimpleButton();
                        bt.Appearance.BackColor = Color.White;
                        bt.Location = new Point(dai, rong);
                        bt.Text = "Bàn "+j.ToString() + (i+1).ToString();
                        bt.Width = (pan_w / (sobantrenhang * 3)) * 2;
                        bt.Height = bt.Width / 2;
                        dai += bt.Width + (pan_w / (sobantrenhang * 3));
                        panel1.Controls.Add(bt);
                        bt.Click += Bt_Click;
                        bt.DoubleClick += Bt_DoubleClick;
                        bt.Name =j.ToString() + (i + 1).ToString();
                        LoadButton(bt);
                    }
                }
                else
                {
                    for (int i = 0; i < soban; i++)
                    {
                        SimpleButton bt = new SimpleButton();
                        bt.Appearance.BackColor = Color.White;
                        bt.Location = new Point(dai, rong);
                        bt.Text = "Bàn " + j.ToString() + (i + 1).ToString();
                        bt.Width = (pan_w / (sobantrenhang *3)) * 2;
                        bt.Height = bt.Width / 2;
                        dai += bt.Width + (pan_w / (sobantrenhang * 3));
                        panel1.Controls.Add(bt);
                        bt.Click += Bt_Click;
                        bt.DoubleClick += Bt_DoubleClick;
                        bt.Name =j.ToString() + (i + 1).ToString();
                        LoadButton(bt);
                    }
                }
                soban -= sobantrenhang;
                dai = (pan_w / (sobantrenhang * 3)) / 2;
                rong += kc;
                j++;
            }
        }
        private void LoadButton(SimpleButton bt)
        {
            if(MonAnDAO.Instance.isDatBan(bt.Name) == 1)
            {
                bt.Appearance.BackColor = Color.Red;
            }
        }
        private void Bt_DoubleClick(object sender, EventArgs e)
        {
            SimpleButton bt = sender as SimpleButton;
            lisvTong = new List<MonAnDTO>();
            gridControl1.DataSource = null;
            int IsDatBan = MonAnDAO.Instance.isDatBan(bt.Name);
            if(IsDatBan == 1)
            {
                fmGoiMon f = new fmGoiMon(bt.Name, bt.Name);
                f.ShowDialog();
                LoadButton(bt);
                return;
            }
            fmGoiMon fgoimon = new fmGoiMon("", bt.Name);
            fgoimon.ShowDialog();
            LoadButton(bt);
        }
        bool gopban = true;
        private void Bt_Click(object sender, EventArgs e)
        {
            double tienban = 0;
            SimpleButton bt = sender as SimpleButton;
            string nameban = bt.Name;
            MonAnDTO dto = lisvTong.FirstOrDefault(x => x.TenBan == nameban);
            List<MonAnDTO> lis = MonAnDAO.Instance.LisMonAn1(nameban);
            if (!gopban)
            {
                if (bt.Appearance.BackColor == Color.Blue)
                {
                    bt.Appearance.BackColor = Color.Red;
                    if (dto != null)
                    {
                        lisvTong.RemoveAll(x => x.TenBan == nameban);
                        gridControl1.DataSource = null;
                        gridControl1.DataSource = lisvTong;
                        foreach (var item in lisvTong)
                        {
                            tienban += item.ThanhTien;
                        }
                        TongtienThanhToan.Text = "Tổng tiền: " + tienban.ToString();
                        return;
                    }
                }
                else if (bt.Appearance.BackColor == Color.Red)
                {
                    bt.Appearance.BackColor = Color.Blue;
                    foreach (var item in lis)
                    {
                        lisvTong.Add(item);
                    }
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = lisvTong;
                    foreach (var item in lisvTong)
                    {
                        tienban += item.ThanhTien;
                    }
                }
            }

            else
            {
                lisvTong = new List<MonAnDTO>();
                foreach (var item in lis)
                {
                    lisvTong.Add(item);
                }
                gridControl1.DataSource = null;
                gridControl1.DataSource = lisvTong;
                foreach (var item in lis)
                {
                    tienban += item.ThanhTien;
                }
            }
            TongtienThanhToan.Text = "Tổng tiền: " + tienban.ToString();
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thanh toán", "Thanh Toán" , MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes && lisvTong.Count != 0)
            {
                ThanhToan();
                panel1.Controls.Clear();
                Loadbt(10, 3);
                gridControl1.DataSource = null;
                lisvTong = new List<MonAnDTO>();
            }
            else
                MessageBox.Show("Vui lòng chọn bàn thanh toán.");

        }
        public void ThanhToan()
        {
            foreach (var item in lisvTong)
            {
                int idgoimon = item.IDGoiMon;
                bool updategoimon = MonAnDAO.Instance.updategoimon(idgoimon);
                string tenban = item.TenBan;
                bool updatedatban = MonAnDAO.Instance.updatedatban(tenban);
            }
            
            TongtienThanhToan.Text = "Tổng tiền: 0 ";
        }

        private void btngopban_Click(object sender, EventArgs e)
        {

            lisvTong = new List<MonAnDTO>();
            if (gopban)
            {
                gopban = !gopban;
                btngopban.Text = "Đang gộp bàn";
            }
            else
            {
                gopban = !gopban;
                btngopban.Text = "Gộp bàn";
            }
            panel1.Controls.Clear();
            Loadbt(10, 3);
            gridControl1.DataSource = null;
        }
    }
}

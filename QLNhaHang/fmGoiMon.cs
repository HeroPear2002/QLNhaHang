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
using DevExpress.XtraGrid;

namespace QLNhaHang
{
    public partial class fmGoiMon : DevExpress.XtraEditors.XtraForm
    {
        string Tenban = "";
        DataTable data = new DataTable();
        List<MONANCBDTO> LsTenMon = MonAnDAO.Instance.ListTenMon();
        List<MonAnDTO> lismonan = new List<MonAnDTO>();
        Dictionary<int, int> IDSL = new Dictionary<int, int>();
        int sltamthoi = 0;
        public fmGoiMon()
        {
            InitializeComponent();
            
        }
        string _name = "";
        public fmGoiMon(string nametb, string tenban)
        {
            InitializeComponent();
            _name = nametb;
            Tenban = tenban;
            loadform();
        }
        public void loadform()
        {
            lbTen.Text = "Bàn " + Tenban.ToString();
            slTenMon.Properties.DataSource = LsTenMon;
            slTenMon.Properties.DisplayMember = "TenMonAn";
            slTenMon.Properties.ValueMember = "IDMonAn";
            LoadGridControl();
        }
        private void btnDatMon_Click(object sender, EventArgs e)
        {
            bool datmon = false;
            int slyeucau = 1;
            int idcongthuc = 0;
            DialogResult result = MessageBox.Show("Bạn muốn đặt món", "Đặt Món", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes && lismonan != MonAnDAO.Instance.LisMonAn1(_name) && lismonan.Count != 0)
            {
                foreach (MonAnDTO item in lismonan)
                {
                    List<int> slmon = new List<int>();
                    idcongthuc = CapNhatDAO.Instance.GetCT(item.IDMonAn);
                    List<CongThucMonAn> lisCongThuc = CapNhatDAO.Instance.LisIDTP(idcongthuc);
                    foreach (CongThucMonAn ID in lisCongThuc)
                    {
                        List<CapNhatNhapHangDTO> lisNhapHangUpDate = CapNhatDAO.Instance.LisTonKho(ID.IDThucPham);
                        float dinhluongdung = ID.DinhLuong * IDSL[item.IDMonAn];
                        if (dinhluongdung > 0)
                        {
                            dinhluongdung = dungnguyenlieu(lisNhapHangUpDate, dinhluongdung);
                            datmon = true;
                        }
                        if (dinhluongdung > 0)
                        {
                            slmon.Add(Convert.ToInt32(Math.Ceiling(dinhluongdung / ID.DinhLuong)));
                        }
                    }
                    if (slmon.Count == 0)
                    {
                        slmon.Add(0);
                    }
                    slmon.Sort();
                    slmon.Reverse();
                    int sl = IDSL[item.IDMonAn] - slmon[0];
                    slyeucau = sl;
                    foreach (CongThucMonAn ID in lisCongThuc)
                    {
                        if(sl > 0)
                        {
                            bool datain = CapNhatDAO.Instance.insertXuat(ID.IDThucPham, ID.DinhLuong * sl, DateTime.Now);
                        }
                    }
                    bool updategoimon = true;
                    if (item.IDGoiMon != 0)
                    {
                        bool data = MonAnDAO.Instance.updatedatmon(item.SoLuong - slmon[0], item.IDGoiMon);
                        updategoimon = false;
                    }
                    if (updategoimon && sl != 0)
                    {
                        if (_name == "")
                        {
                            bool data1 = MonAnDAO.Instance.insertban(Tenban);
                        }
                        bool data = MonAnDAO.Instance.insert(sl, item.TenMonAn, Tenban);
                    }
                    if(sl > 0 && slmon[0] != 0)
                    {
                        MessageBox.Show("Bạn còn đủ nguyên liệu để làm " + sl + " món " + item.TenMonAn);
                    }
                }
                if(datmon && slyeucau == 0)
                {
                    LoadGridControl();
                    MessageBox.Show("Đặt món không thành công");
                    return;
                }
                MessageBox.Show("Đặt món thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Chọn món trước đã.");
            }
        }
        public float dungnguyenlieu(List<CapNhatNhapHangDTO> lisNhapHangUpDate, float dinhluongdung)
        {
            float dinhluongthieu;
            foreach (CapNhatNhapHangDTO ss in lisNhapHangUpDate)
            {
                if (ss.TonKho >= dinhluongdung)
                {
                    bool dataup = CapNhatDAO.Instance.updateNhapHang(ss.TonKho - dinhluongdung, ss.IDNhapHang);
                    dinhluongdung = 0;
                }
                else
                {
                    bool dataup = CapNhatDAO.Instance.updateNhapHang(0, ss.IDNhapHang);
                    dinhluongdung -= ss.TonKho;
                }
            }
            dinhluongthieu = dinhluongdung;
            return dinhluongthieu;
        }
        public void LoadGridControl()
        {
            lismonan = new List<MonAnDTO>();
            if (_name !="")
             {
                lismonan = MonAnDAO.Instance.LisMonAn1(_name);
                gcchonmon.DataSource = lismonan;
            }
            else
            {
                gcchonmon.DataSource = null;
            }
             
        }
        private void btnchonmon_Click(object sender, EventArgs e)
        {
            if(slTenMon.EditValue.ToString() != "No")
            {
                bool themmoi = true;
                MonAnDTO dto = new MonAnDTO(int.Parse(slTenMon.EditValue.ToString()), slTenMon.Text, int.Parse(numsl.Value.ToString()), Convert.ToDouble(txtgia.Text), Convert.ToDouble(int.Parse(numsl.Value.ToString()) * int.Parse(txtgia.Text.ToString())), _name, 0);
                if (lismonan.Count == 0)
                {
                    IDSL.Add(dto.IDMonAn, dto.SoLuong);
                    sltamthoi += dto.SoLuong;
                    lismonan.Add(dto);
                }
                else
                {
                    for (int i = 0; i < lismonan.Count; i++)
                    {
                        if(!IDSL.ContainsKey(lismonan[i].IDMonAn))
                        {
                            IDSL.Add(lismonan[i].IDMonAn, 0);
                        }
                        if (lismonan[i].TenMonAn == dto.TenMonAn)
                        {
                            lismonan[i].SoLuong += dto.SoLuong;
                            sltamthoi += dto.SoLuong;
                            themmoi = false;
                            IDSL[dto.IDMonAn] = sltamthoi;
                        }
                    }
                    if (themmoi)
                    {
                        lismonan.Add(dto);
                        IDSL[dto.IDMonAn] = dto.SoLuong;
                    }
                }
                gcchonmon.DataSource = null;
                gcchonmon.DataSource = lismonan;
                return;
            }
            MessageBox.Show("Chọn món ăn đê");
        }

        private void slTenMon_EditValueChanged(object sender, EventArgs e)
        {
            int a= int.Parse(slTenMon.EditValue.ToString());
            List<MONANCBDTO> lsv= slTenMon.Properties.DataSource as List<MONANCBDTO>;
            MONANCBDTO dto = lsv.Find(x => x.IDMonAn == a);

            txtgia.Text = dto.Gia.ToString();
        }
    }
}
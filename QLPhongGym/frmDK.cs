using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QLPhongGym;
using DTO_QLPhongGym;

namespace QLPhongGym
{
    public partial class frmDK : Form
    {
        BLL_HoiVien HV = new BLL_HoiVien();
        BLL_GoiTap GT = new BLL_GoiTap();
        BLL_PT PT = new BLL_PT();
        public frmDK()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDK_Load(object sender, EventArgs e)
        {
            {
                cbGoitap.DataSource = GT.LayDSGoiTap();
                cbGoitap.DisplayMember = "tengoi";
                cbGoitap.ValueMember = "magoi";

                cbPT.DataSource = PT.LayDSPT();
                cbPT.DisplayMember = "ten";
                cbPT.ValueMember = "mapt";

                cbGioiTinh.SelectedIndex = -1;
                cbGoitap.SelectedIndex = -1;
                cbPT.SelectedIndex = -1;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbGoitap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói tập!", "Cảnh báo");
                return;
            }

            DTO_HoiVien hv = new DTO_HoiVien();
            hv.Ten = txtHVT.Text;
            hv.SDT = txtSDT.Text;
            hv.GioiTinh = cbGioiTinh.Text;
            hv.IdGoiTap = Convert.ToInt32(cbGoitap.SelectedValue);
            hv.NgayDK = dtpNgayDK.Value;

            if (cbPT.SelectedValue != null)
                hv.IdPT = Convert.ToInt32(cbPT.SelectedValue);
            else
                hv.IdPT = 0;

            // 3. Quăng cái thùng qua cho BLL xử lý
            if (HV.ThemHoiVien(hv))
            {
                MessageBox.Show("Đăng ký hội viên thành công!", "Thông báo");
                btnXoa_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại!", "Lỗi");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHVT.Clear();
            txtSDT.Clear();

            cbGioiTinh.SelectedIndex = -1;
            cbGoitap.SelectedIndex = -1;
            cbPT.SelectedIndex = -1;

            txtHVT.Focus();
        }
        private void txtHVT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLPhongGym
{
    public partial class frmTT : Form

    {
        string tenHoiVien;
        string goiTap;
        int thuePT;
        int tongTien;
        public frmTT(string ten, string goi, int pt, int tong)
        {
            InitializeComponent();
            tenHoiVien = ten;
            goiTap = goi;
            thuePT = pt;
            tongTien = tong;
        }
        private void frmTT_Load(object sender, EventArgs e)
        {
            lblHoiVien.Text = tenHoiVien;
            lblGoiTap.Text = goiTap;
            lblThuePT.Text = thuePT.ToString() + " VNĐ";
            lblTongTien.Text = tongTien.ToString() + " VNĐ";
            rdoThe.Checked = true;
            pnlThe.Visible = true;
            pnlQR.Visible = false;
        }
        private void rdoThe_CheckedChanged(object sender, EventArgs e)
        {
            pnlThe.Visible = rdoThe.Checked;
            pnlQR.Visible = !rdoThe.Checked;
        }
        private void rdoMomo_CheckedChanged(object sender, EventArgs e)
        {
            pnlQR.Visible = rdoMoMo.Checked;
            pnlThe.Visible = !rdoMoMo.Checked;
        }
        private void txtSoThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (rdoThe.Checked)
            {
                // Validate thẻ
                if (txtSoThe.Text == "" || txtChuThe.Text == "" || txtNgayHH.Text == "" || txtCVV.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin thẻ!");
                    return;
                }

                if (txtSoThe.Text.Length != 16)
                {
                    MessageBox.Show("Số thẻ phải 16 số!");
                    return;
                }

                if (txtCVV.Text.Length != 3)
                {
                    MessageBox.Show("CVV phải 3 số!");
                    return;
                }

                MessageBox.Show("Thanh toán bằng thẻ thành công!");
            }
            else if (rdoMoMo.Checked)
            {
                MessageBox.Show("Thanh toán bằng MoMo thành công!");
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnTT_Click(object sender, EventArgs e)
        {

        }
    }
}

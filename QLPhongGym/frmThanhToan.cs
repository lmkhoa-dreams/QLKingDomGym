using System;
using System.Windows.Forms;
using System.Data; // Phải có cái này để đọc bảng dữ liệu

namespace QLPhongGym
{
    public partial class frmThanhToan : Form
    {
        DAL_QLPhongGym.DAL_PT dalPT = new DAL_QLPhongGym.DAL_PT();
        DAL_QLPhongGym.DAL_HoiVien dalHV = new DAL_QLPhongGym.DAL_HoiVien();
        public frmThanhToan(string hoTen, string goiTap, string giaTien)
        {
            InitializeComponent();
            txtTenHoiVien.Text = hoTen;
            cbGoitap.Text = goiTap; 
            txtSoTien.Text = giaTien;
        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = dalPT.LayDanhSachPT();

                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    cboChonPT.DataSource = dt;
                    cboChonPT.DisplayMember = "ten"; 
                    cboChonPT.ValueMember = "mapt";  
                    cboChonPT.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Dữ liệu PT đang trống hoặc không kết nối được SQL!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoTien.Text) || cboChonPT.SelectedValue == null)
            {
                MessageBox.Show("nhập đủ số tiền và chọn PT đã nhé!", "Thông báo");
                return;
            }

            try
            {
                DTO_QLPhongGym.DTO_HoiVien hv = new DTO_QLPhongGym.DTO_HoiVien();
                hv.Ten = txtTenHoiVien.Text;
                hv.GioiTinh = "Nam"; 
                hv.SDT = "0000000000"; 

                hv.IdPT = int.Parse(cboChonPT.SelectedValue.ToString());

                hv.NgayDK = DateTime.Now;

                hv.IdGoiTap = 1;

                if (dalHV.ThemHoiVien(hv))
                {
                    MessageBox.Show("Thêm hội viên và thanh toán thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi code : " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
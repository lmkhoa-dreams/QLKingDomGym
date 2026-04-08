using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL_QLPhongGym;

namespace QLPhongGym
{
    public partial class frmGT : Form
    {
        BLL_GoiTap bll = new BLL_GoiTap();

        public frmGT()
        {
            InitializeComponent();
        }

        // 🔹 LOAD FORM
        private void frmGT_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // 🔹 LOAD DATA
        void LoadData()
        {
            dataGridView1.DataSource = bll.LayDSGoiTap();

            dataGridView1.Columns["magoi"].HeaderText = "Mã gói";
            dataGridView1.Columns["tengoi"].HeaderText = "Tên gói";
            dataGridView1.Columns["giatien"].HeaderText = "Giá tiền";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 🔹 NÚT THÊM (FIX GIÁ TIỀN 100%)
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenGoi.Text;

                // chỉ lấy số
                string giaText = new string(txtGia.Text.Where(char.IsDigit).ToArray());

                if (giaText == "")
                {
                    MessageBox.Show("Vui lòng nhập giá tiền");
                    return;
                }

                decimal gia = Convert.ToDecimal(giaText);

                if (bll.Add(ten, gia))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Tên gói không được để trống");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xử lý giá tiền");
            }
        }

        // 🔹 CLICK BẢNG
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtTenGoi.Text = dataGridView1.CurrentRow.Cells["tengoi"].Value.ToString();
                txtGia.Text = dataGridView1.CurrentRow.Cells["giatien"].Value.ToString();
            }
        }

        // 🔹 XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int maGoi = Convert.ToInt32(dataGridView1.CurrentRow.Cells["magoi"].Value);
                string tengoi = dataGridView1.CurrentRow.Cells["tengoi"].Value.ToString();
                DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn xóa [{tengoi}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (kq == DialogResult.Yes)
                {
                    //Gọi hàm Xoa ở BLL
                    if (bll.Delete(maGoi))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        dataGridView1.DataSource = bll.LayDSGoiTap();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa");
            }
        }

        // 🔹 THOÁT
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 🔥 FIX DESIGNER
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void txtHVT_TextChanged(object sender, EventArgs e) { }
        private void txtTien_TextChanged(object sender, EventArgs e) { }
    }
}
namespace QLPhongGym
{
    partial class frmQLPT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHVT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHVT
            // 
            this.txtHVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHVT.Location = new System.Drawing.Point(131, 188);
            this.txtHVT.Name = "txtHVT";
            this.txtHVT.Size = new System.Drawing.Size(173, 34);
            this.txtHVT.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(131, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 45);
            this.label3.TabIndex = 16;
            this.label3.Text = "Họ và Tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(341, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 67);
            this.label5.TabIndex = 18;
            this.label5.Text = "KingDomGym";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinh.Location = new System.Drawing.Point(733, 184);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(190, 39);
            this.cbGioiTinh.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(748, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 45);
            this.label4.TabIndex = 22;
            this.label4.Text = "Giới tính";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(432, 185);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(173, 34);
            this.txtSDT.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(407, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 45);
            this.label1.TabIndex = 24;
            this.label1.Text = "Số điện thoại";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1063, 232);
            this.dataGridView1.TabIndex = 26;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(658, 514);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(172, 55);
            this.btnQuayLai.TabIndex = 27;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnChinhSua.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChinhSua.Location = new System.Drawing.Point(451, 514);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(172, 55);
            this.btnChinhSua.TabIndex = 28;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(237, 514);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(172, 55);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(22, 514);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(172, 55);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(867, 514);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(172, 55);
            this.btnThoat.TabIndex = 31;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmQLPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 597);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnChinhSua);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGioiTinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHVT);
            this.Controls.Add(this.label3);
            this.Name = "frmQLPT";
            this.Text = "QLPT";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHVT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
    }
}
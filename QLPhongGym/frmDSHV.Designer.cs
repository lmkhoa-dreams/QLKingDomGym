namespace QLPhongGym
{
    partial class frmDSHV
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDSHV = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHV)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(325, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(359, 67);
            this.label3.TabIndex = 9;
            this.label3.Text = "KingDomGym";
            // 
            // dgvDSHV
            // 
            this.dgvDSHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHV.Location = new System.Drawing.Point(2, 207);
            this.dgvDSHV.Name = "dgvDSHV";
            this.dgvDSHV.RowHeadersWidth = 51;
            this.dgvDSHV.RowTemplate.Height = 24;
            this.dgvDSHV.Size = new System.Drawing.Size(992, 263);
            this.dgvDSHV.TabIndex = 10;
            this.dgvDSHV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvDSHV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(2, 147);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(808, 43);
            this.txtTimKiem.TabIndex = 11;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(816, 135);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(172, 55);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(674, 494);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(172, 55);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(146, 494);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(172, 55);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmDSHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 576);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvDSHV);
            this.Controls.Add(this.label3);
            this.Name = "frmDSHV";
            this.Text = "DS Hội Viên";
            this.Load += new System.EventHandler(this.frmDSHV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDSHV;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
    }
}
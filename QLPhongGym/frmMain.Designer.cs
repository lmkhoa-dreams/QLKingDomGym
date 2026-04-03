namespace QLPhongGym
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnDK = new System.Windows.Forms.Button();
            this.btnDSHV = new System.Windows.Forms.Button();
            this.btnGT = new System.Windows.Forms.Button();
            this.btnPT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDK
            // 
            this.btnDK.BackColor = System.Drawing.Color.White;
            this.btnDK.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDK.ForeColor = System.Drawing.Color.Red;
            this.btnDK.Location = new System.Drawing.Point(34, 27);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(199, 55);
            this.btnDK.TabIndex = 5;
            this.btnDK.Text = "Đăng Ký";
            this.btnDK.UseVisualStyleBackColor = false;
            // 
            // btnDSHV
            // 
            this.btnDSHV.BackColor = System.Drawing.Color.White;
            this.btnDSHV.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSHV.ForeColor = System.Drawing.Color.Red;
            this.btnDSHV.Location = new System.Drawing.Point(266, 27);
            this.btnDSHV.Name = "btnDSHV";
            this.btnDSHV.Size = new System.Drawing.Size(199, 55);
            this.btnDSHV.TabIndex = 6;
            this.btnDSHV.Text = "DS Hội Viên";
            this.btnDSHV.UseVisualStyleBackColor = false;
            // 
            // btnGT
            // 
            this.btnGT.BackColor = System.Drawing.Color.White;
            this.btnGT.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGT.ForeColor = System.Drawing.Color.Red;
            this.btnGT.Location = new System.Drawing.Point(746, 27);
            this.btnGT.Name = "btnGT";
            this.btnGT.Size = new System.Drawing.Size(199, 55);
            this.btnGT.TabIndex = 7;
            this.btnGT.Text = "Gói Tập";
            this.btnGT.UseVisualStyleBackColor = false;
            // 
            // btnPT
            // 
            this.btnPT.BackColor = System.Drawing.Color.White;
            this.btnPT.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPT.ForeColor = System.Drawing.Color.Red;
            this.btnPT.Location = new System.Drawing.Point(504, 27);
            this.btnPT.Name = "btnPT";
            this.btnPT.Size = new System.Drawing.Size(199, 55);
            this.btnPT.TabIndex = 8;
            this.btnPT.Text = "PT";
            this.btnPT.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(996, 530);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 628);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPT);
            this.Controls.Add(this.btnGT);
            this.Controls.Add(this.btnDSHV);
            this.Controls.Add(this.btnDK);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.Button btnDSHV;
        private System.Windows.Forms.Button btnGT;
        private System.Windows.Forms.Button btnPT;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
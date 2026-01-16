namespace QLBH_11_TRANMINHDUNG
{
    partial class frmDMChatlieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMChatlieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_boqua = new System.Windows.Forms.Button();
            this.btn_dong = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_machatlieu = new System.Windows.Forms.TextBox();
            this.txt_tenchatlieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tieudeCL = new System.Windows.Forms.Label();
            this.dgv_chatlieu = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chatlieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_boqua);
            this.panel1.Controls.Add(this.btn_dong);
            this.panel1.Controls.Add(this.btn_luu);
            this.panel1.Controls.Add(this.btn_sua);
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 69);
            this.panel1.TabIndex = 0;
            // 
            // btn_boqua
            // 
            this.btn_boqua.Location = new System.Drawing.Point(642, 16);
            this.btn_boqua.Name = "btn_boqua";
            this.btn_boqua.Size = new System.Drawing.Size(116, 41);
            this.btn_boqua.TabIndex = 0;
            this.btn_boqua.Text = "&Bỏ qua";
            this.btn_boqua.UseVisualStyleBackColor = true;
            this.btn_boqua.Click += new System.EventHandler(this.btn_boqua_Click);
            // 
            // btn_dong
            // 
            this.btn_dong.Location = new System.Drawing.Point(786, 16);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(116, 41);
            this.btn_dong.TabIndex = 0;
            this.btn_dong.Text = "&Đóng";
            this.btn_dong.UseVisualStyleBackColor = true;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(491, 16);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(116, 41);
            this.btn_luu.TabIndex = 0;
            this.btn_luu.Text = "&Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(338, 16);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(116, 41);
            this.btn_sua.TabIndex = 0;
            this.btn_sua.Text = "&Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(183, 16);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(116, 41);
            this.btn_xoa.TabIndex = 0;
            this.btn_xoa.Text = "&Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(26, 16);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(116, 41);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "&Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_machatlieu);
            this.panel2.Controls.Add(this.txt_tenchatlieu);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_tieudeCL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 120);
            this.panel2.TabIndex = 1;
            // 
            // txt_machatlieu
            // 
            this.txt_machatlieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_machatlieu.Location = new System.Drawing.Point(159, 43);
            this.txt_machatlieu.Name = "txt_machatlieu";
            this.txt_machatlieu.Size = new System.Drawing.Size(234, 27);
            this.txt_machatlieu.TabIndex = 2;
            this.txt_machatlieu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_machatlieu_KeyUp);
            // 
            // txt_tenchatlieu
            // 
            this.txt_tenchatlieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenchatlieu.Location = new System.Drawing.Point(159, 78);
            this.txt_tenchatlieu.Name = "txt_tenchatlieu";
            this.txt_tenchatlieu.Size = new System.Drawing.Size(234, 27);
            this.txt_tenchatlieu.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên chất liệu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã chất liệu";
            // 
            // lbl_tieudeCL
            // 
            this.lbl_tieudeCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tieudeCL.ForeColor = System.Drawing.Color.Blue;
            this.lbl_tieudeCL.Location = new System.Drawing.Point(216, 9);
            this.lbl_tieudeCL.Name = "lbl_tieudeCL";
            this.lbl_tieudeCL.Size = new System.Drawing.Size(468, 35);
            this.lbl_tieudeCL.TabIndex = 0;
            this.lbl_tieudeCL.Text = "DANH MỤC CHẤT LIỆU";
            this.lbl_tieudeCL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_chatlieu
            // 
            this.dgv_chatlieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chatlieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_chatlieu.Location = new System.Drawing.Point(0, 120);
            this.dgv_chatlieu.Name = "dgv_chatlieu";
            this.dgv_chatlieu.RowHeadersWidth = 51;
            this.dgv_chatlieu.RowTemplate.Height = 24;
            this.dgv_chatlieu.Size = new System.Drawing.Size(918, 355);
            this.dgv_chatlieu.TabIndex = 2;
            this.dgv_chatlieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chatlieu_CellContentClick);
            this.dgv_chatlieu.Click += new System.EventHandler(this.dgv_chatlieu_Click);
            // 
            // frmDMChatlieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 544);
            this.Controls.Add(this.dgv_chatlieu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMChatlieu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Chất liệu";
            this.Load += new System.EventHandler(this.frmDMChatlieu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chatlieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_boqua;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_tieudeCL;
        private System.Windows.Forms.DataGridView dgv_chatlieu;
        private System.Windows.Forms.TextBox txt_machatlieu;
        private System.Windows.Forms.TextBox txt_tenchatlieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
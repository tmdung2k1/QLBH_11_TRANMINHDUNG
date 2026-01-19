namespace QLBH_11_TRANMINHDUNG
{
    partial class frmTimkiemhoadon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimkiemhoadon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_boqua = new System.Windows.Forms.Button();
            this.btn_dong = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_thang = new System.Windows.Forms.TextBox();
            this.txt_nam = new System.Windows.Forms.TextBox();
            this.txt_tongtien = new System.Windows.Forms.TextBox();
            this.txt_makhachhang = new System.Windows.Forms.TextBox();
            this.txt_manhanvien = new System.Windows.Forms.TextBox();
            this.txt_mahoadon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_danhsachhoadon = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsachhoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_boqua);
            this.panel1.Controls.Add(this.btn_dong);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 599);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 62);
            this.panel1.TabIndex = 1;
            // 
            // btn_boqua
            // 
            this.btn_boqua.Location = new System.Drawing.Point(401, 13);
            this.btn_boqua.Name = "btn_boqua";
            this.btn_boqua.Size = new System.Drawing.Size(116, 41);
            this.btn_boqua.TabIndex = 7;
            this.btn_boqua.Text = "Tìm &lại";
            this.btn_boqua.UseVisualStyleBackColor = true;
            this.btn_boqua.Click += new System.EventHandler(this.btn_boqua_Click);
            // 
            // btn_dong
            // 
            this.btn_dong.Location = new System.Drawing.Point(571, 13);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(116, 41);
            this.btn_dong.TabIndex = 8;
            this.btn_dong.Text = "&Đóng";
            this.btn_dong.UseVisualStyleBackColor = true;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(239, 13);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(116, 41);
            this.btn_them.TabIndex = 12;
            this.btn_them.Text = "&Tìm kiếm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 44);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nháy đúp vào hóa đơn để hiện thông tin chi tiết";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_thang);
            this.panel3.Controls.Add(this.txt_nam);
            this.panel3.Controls.Add(this.txt_tongtien);
            this.panel3.Controls.Add(this.txt_makhachhang);
            this.panel3.Controls.Add(this.txt_manhanvien);
            this.panel3.Controls.Add(this.txt_mahoadon);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 142);
            this.panel3.TabIndex = 3;
            // 
            // txt_thang
            // 
            this.txt_thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_thang.Location = new System.Drawing.Point(143, 47);
            this.txt_thang.Name = "txt_thang";
            this.txt_thang.Size = new System.Drawing.Size(102, 27);
            this.txt_thang.TabIndex = 1;
            // 
            // txt_nam
            // 
            this.txt_nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nam.Location = new System.Drawing.Point(325, 47);
            this.txt_nam.Name = "txt_nam";
            this.txt_nam.Size = new System.Drawing.Size(102, 27);
            this.txt_nam.TabIndex = 1;
            // 
            // txt_tongtien
            // 
            this.txt_tongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongtien.Location = new System.Drawing.Point(615, 50);
            this.txt_tongtien.Name = "txt_tongtien";
            this.txt_tongtien.Size = new System.Drawing.Size(284, 27);
            this.txt_tongtien.TabIndex = 1;
            this.txt_tongtien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tongtien_KeyPress);
            // 
            // txt_makhachhang
            // 
            this.txt_makhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_makhachhang.Location = new System.Drawing.Point(615, 12);
            this.txt_makhachhang.Name = "txt_makhachhang";
            this.txt_makhachhang.Size = new System.Drawing.Size(284, 27);
            this.txt_makhachhang.TabIndex = 1;
            // 
            // txt_manhanvien
            // 
            this.txt_manhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_manhanvien.Location = new System.Drawing.Point(143, 86);
            this.txt_manhanvien.Name = "txt_manhanvien";
            this.txt_manhanvien.Size = new System.Drawing.Size(284, 27);
            this.txt_manhanvien.TabIndex = 1;
            // 
            // txt_mahoadon
            // 
            this.txt_mahoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mahoadon.Location = new System.Drawing.Point(143, 12);
            this.txt_mahoadon.Name = "txt_mahoadon";
            this.txt_mahoadon.Size = new System.Drawing.Size(284, 27);
            this.txt_mahoadon.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã khách hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tổng tiền:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Năm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tháng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn:";
            // 
            // dgv_danhsachhoadon
            // 
            this.dgv_danhsachhoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_danhsachhoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_danhsachhoadon.Location = new System.Drawing.Point(0, 142);
            this.dgv_danhsachhoadon.Name = "dgv_danhsachhoadon";
            this.dgv_danhsachhoadon.RowHeadersWidth = 51;
            this.dgv_danhsachhoadon.RowTemplate.Height = 24;
            this.dgv_danhsachhoadon.Size = new System.Drawing.Size(945, 413);
            this.dgv_danhsachhoadon.TabIndex = 4;
            // 
            // frmTimkiemhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 661);
            this.Controls.Add(this.dgv_danhsachhoadon);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimkiemhoadon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm hóa đơn";
            this.Load += new System.EventHandler(this.frmTimkiemhoadon_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsachhoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_boqua;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_danhsachhoadon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_thang;
        private System.Windows.Forms.TextBox txt_nam;
        private System.Windows.Forms.TextBox txt_tongtien;
        private System.Windows.Forms.TextBox txt_makhachhang;
        private System.Windows.Forms.TextBox txt_manhanvien;
        private System.Windows.Forms.TextBox txt_mahoadon;
    }
}
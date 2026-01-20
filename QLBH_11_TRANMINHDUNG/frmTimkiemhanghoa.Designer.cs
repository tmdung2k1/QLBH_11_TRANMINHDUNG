namespace QLBH_11_TRANMINHDUNG
{
    partial class frmTimkiemhanghoa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_timlai = new System.Windows.Forms.Button();
            this.btn_dong = new System.Windows.Forms.Button();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_hienthi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbo_machatlieu = new System.Windows.Forms.ComboBox();
            this.txt_dongiaden = new System.Windows.Forms.TextBox();
            this.txt_dongiatu = new System.Windows.Forms.TextBox();
            this.txt_soluongden = new System.Windows.Forms.TextBox();
            this.txt_soluongtu = new System.Windows.Forms.TextBox();
            this.txt_tenhang = new System.Windows.Forms.TextBox();
            this.txt_mahang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_danhsachhanghoa = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsachhanghoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_timlai);
            this.panel1.Controls.Add(this.btn_dong);
            this.panel1.Controls.Add(this.btn_timkiem);
            this.panel1.Controls.Add(this.btn_hienthi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 558);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 62);
            this.panel1.TabIndex = 1;
            // 
            // btn_timlai
            // 
            this.btn_timlai.Location = new System.Drawing.Point(387, 11);
            this.btn_timlai.Name = "btn_timlai";
            this.btn_timlai.Size = new System.Drawing.Size(116, 41);
            this.btn_timlai.TabIndex = 9;
            this.btn_timlai.Text = "Tìm &lại";
            this.btn_timlai.UseVisualStyleBackColor = true;
            this.btn_timlai.Click += new System.EventHandler(this.btn_timlai_Click);
            // 
            // btn_dong
            // 
            this.btn_dong.Location = new System.Drawing.Point(680, 11);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(116, 41);
            this.btn_dong.TabIndex = 11;
            this.btn_dong.Text = "&Đóng";
            this.btn_dong.UseVisualStyleBackColor = true;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(237, 11);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(116, 41);
            this.btn_timkiem.TabIndex = 8;
            this.btn_timkiem.Text = "&Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_hienthi
            // 
            this.btn_hienthi.Location = new System.Drawing.Point(534, 11);
            this.btn_hienthi.Name = "btn_hienthi";
            this.btn_hienthi.Size = new System.Drawing.Size(116, 41);
            this.btn_hienthi.TabIndex = 10;
            this.btn_hienthi.Text = "&Hiển thị tất cả";
            this.btn_hienthi.UseVisualStyleBackColor = true;
            this.btn_hienthi.Click += new System.EventHandler(this.btn_hienthi_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 44);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin hàng hóa cần tìm và nhấn Tìm kiếm";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbo_machatlieu);
            this.panel3.Controls.Add(this.txt_dongiaden);
            this.panel3.Controls.Add(this.txt_dongiatu);
            this.panel3.Controls.Add(this.txt_soluongden);
            this.panel3.Controls.Add(this.txt_soluongtu);
            this.panel3.Controls.Add(this.txt_tenhang);
            this.panel3.Controls.Add(this.txt_mahang);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 182);
            this.panel3.TabIndex = 0;
            // 
            // cbo_machatlieu
            // 
            this.cbo_machatlieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_machatlieu.FormattingEnabled = true;
            this.cbo_machatlieu.Location = new System.Drawing.Point(143, 106);
            this.cbo_machatlieu.Name = "cbo_machatlieu";
            this.cbo_machatlieu.Size = new System.Drawing.Size(215, 28);
            this.cbo_machatlieu.TabIndex = 2;
            // 
            // txt_dongiaden
            // 
            this.txt_dongiaden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dongiaden.Location = new System.Drawing.Point(745, 139);
            this.txt_dongiaden.Name = "txt_dongiaden";
            this.txt_dongiaden.Size = new System.Drawing.Size(165, 27);
            this.txt_dongiaden.TabIndex = 7;
            this.txt_dongiaden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dongiaden_KeyPress);
            // 
            // txt_dongiatu
            // 
            this.txt_dongiatu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dongiatu.Location = new System.Drawing.Point(492, 139);
            this.txt_dongiatu.Name = "txt_dongiatu";
            this.txt_dongiatu.Size = new System.Drawing.Size(165, 27);
            this.txt_dongiatu.TabIndex = 6;
            this.txt_dongiatu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dongiatu_KeyPress);
            // 
            // txt_soluongden
            // 
            this.txt_soluongden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_soluongden.Location = new System.Drawing.Point(745, 67);
            this.txt_soluongden.Name = "txt_soluongden";
            this.txt_soluongden.Size = new System.Drawing.Size(165, 27);
            this.txt_soluongden.TabIndex = 5;
            this.txt_soluongden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_soluongden_KeyPress);
            // 
            // txt_soluongtu
            // 
            this.txt_soluongtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_soluongtu.Location = new System.Drawing.Point(492, 67);
            this.txt_soluongtu.Name = "txt_soluongtu";
            this.txt_soluongtu.Size = new System.Drawing.Size(165, 27);
            this.txt_soluongtu.TabIndex = 4;
            this.txt_soluongtu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_soluongtu_KeyPress);
            // 
            // txt_tenhang
            // 
            this.txt_tenhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenhang.Location = new System.Drawing.Point(143, 67);
            this.txt_tenhang.Name = "txt_tenhang";
            this.txt_tenhang.Size = new System.Drawing.Size(272, 27);
            this.txt_tenhang.TabIndex = 1;
            // 
            // txt_mahang
            // 
            this.txt_mahang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mahang.Location = new System.Drawing.Point(143, 27);
            this.txt_mahang.Name = "txt_mahang";
            this.txt_mahang.Size = new System.Drawing.Size(215, 27);
            this.txt_mahang.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(685, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Đến:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(685, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Đến:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Từ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(441, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Từ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đơn giá bán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chất liệu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hàng:";
            // 
            // dgv_danhsachhanghoa
            // 
            this.dgv_danhsachhanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_danhsachhanghoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_danhsachhanghoa.Location = new System.Drawing.Point(0, 182);
            this.dgv_danhsachhanghoa.Name = "dgv_danhsachhanghoa";
            this.dgv_danhsachhanghoa.RowHeadersWidth = 51;
            this.dgv_danhsachhanghoa.RowTemplate.Height = 24;
            this.dgv_danhsachhanghoa.Size = new System.Drawing.Size(982, 332);
            this.dgv_danhsachhanghoa.TabIndex = 3;
            // 
            // frmTimkiemhanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 620);
            this.Controls.Add(this.dgv_danhsachhanghoa);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTimkiemhanghoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm hàng hóa";
            this.Load += new System.EventHandler(this.frmTimkiemhanghoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsachhanghoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_timlai;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_hienthi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbo_machatlieu;
        private System.Windows.Forms.TextBox txt_dongiaden;
        private System.Windows.Forms.TextBox txt_dongiatu;
        private System.Windows.Forms.TextBox txt_soluongden;
        private System.Windows.Forms.TextBox txt_soluongtu;
        private System.Windows.Forms.TextBox txt_tenhang;
        private System.Windows.Forms.TextBox txt_mahang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_danhsachhanghoa;
    }
}

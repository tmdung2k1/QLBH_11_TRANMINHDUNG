namespace QLBH_11_TRANMINHDUNG
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tệpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_danhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_chatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_nhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_khachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_hanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_hoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_hoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_timkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufind_hoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufind_hang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnufind_khachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_baocao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBC_hangton = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBC_doanhthu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBC_sanpham = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHien_trogiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_vainet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tệpTinToolStripMenuItem,
            this.mnu_danhmuc,
            this.mnu_hoadon,
            this.mnu_timkiem,
            this.mnu_baocao,
            this.trợGiúpToolStripMenuItem,
            this.mnu_vainet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1434, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tệpTinToolStripMenuItem
            // 
            this.tệpTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_file});
            this.tệpTinToolStripMenuItem.Name = "tệpTinToolStripMenuItem";
            this.tệpTinToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.tệpTinToolStripMenuItem.Text = "&Tệp tin";
            // 
            // mnu_file
            // 
            this.mnu_file.Name = "mnu_file";
            this.mnu_file.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnu_file.Size = new System.Drawing.Size(183, 26);
            this.mnu_file.Text = "Thoát";
            this.mnu_file.Click += new System.EventHandler(this.mnu_file_Click_1);
            // 
            // mnu_danhmuc
            // 
            this.mnu_danhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_chatlieu,
            this.mnu_nhanvien,
            this.mnu_khachhang,
            this.mnu_hanghoa});
            this.mnu_danhmuc.Name = "mnu_danhmuc";
            this.mnu_danhmuc.Size = new System.Drawing.Size(90, 24);
            this.mnu_danhmuc.Text = "&Danh mục";
            // 
            // mnu_chatlieu
            // 
            this.mnu_chatlieu.Image = ((System.Drawing.Image)(resources.GetObject("mnu_chatlieu.Image")));
            this.mnu_chatlieu.Name = "mnu_chatlieu";
            this.mnu_chatlieu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnu_chatlieu.Size = new System.Drawing.Size(224, 26);
            this.mnu_chatlieu.Text = "&Chất liệu";
            this.mnu_chatlieu.Click += new System.EventHandler(this.chấtToolStripMenuItem_Click);
            // 
            // mnu_nhanvien
            // 
            this.mnu_nhanvien.Image = global::QLBH_11_TRANMINHDUNG.Properties.Resources.Employees;
            this.mnu_nhanvien.Name = "mnu_nhanvien";
            this.mnu_nhanvien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnu_nhanvien.Size = new System.Drawing.Size(224, 26);
            this.mnu_nhanvien.Text = "&Nhân viên";
            this.mnu_nhanvien.Click += new System.EventHandler(this.mnu_nhanvien_Click);
            // 
            // mnu_khachhang
            // 
            this.mnu_khachhang.Image = global::QLBH_11_TRANMINHDUNG.Properties.Resources.customer;
            this.mnu_khachhang.Name = "mnu_khachhang";
            this.mnu_khachhang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnu_khachhang.Size = new System.Drawing.Size(224, 26);
            this.mnu_khachhang.Text = "&Khách hàng";
            this.mnu_khachhang.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // mnu_hanghoa
            // 
            this.mnu_hanghoa.Image = global::QLBH_11_TRANMINHDUNG.Properties.Resources.Commodities;
            this.mnu_hanghoa.Name = "mnu_hanghoa";
            this.mnu_hanghoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnu_hanghoa.Size = new System.Drawing.Size(224, 26);
            this.mnu_hanghoa.Text = "&Hàng hóa";
            this.mnu_hanghoa.Click += new System.EventHandler(this.mnu_hanghoa_Click);
            // 
            // mnu_hoadon
            // 
            this.mnu_hoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_hoadonban});
            this.mnu_hoadon.Name = "mnu_hoadon";
            this.mnu_hoadon.Size = new System.Drawing.Size(81, 24);
            this.mnu_hoadon.Text = "&Hóa đơn";
            // 
            // mnu_hoadonban
            // 
            this.mnu_hoadonban.Name = "mnu_hoadonban";
            this.mnu_hoadonban.Size = new System.Drawing.Size(179, 26);
            this.mnu_hoadonban.Text = "&Hóa đơn bán";
            this.mnu_hoadonban.Click += new System.EventHandler(this.mnu_hoadonban_Click);
            // 
            // mnu_timkiem
            // 
            this.mnu_timkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufind_hoadon,
            this.mnufind_hang,
            this.mnufind_khachhang});
            this.mnu_timkiem.Name = "mnu_timkiem";
            this.mnu_timkiem.Size = new System.Drawing.Size(84, 24);
            this.mnu_timkiem.Text = "&Tìm kiếm";
            // 
            // mnufind_hoadon
            // 
            this.mnufind_hoadon.Name = "mnufind_hoadon";
            this.mnufind_hoadon.Size = new System.Drawing.Size(169, 26);
            this.mnufind_hoadon.Text = "Hóa đơn";
            this.mnufind_hoadon.Click += new System.EventHandler(this.mnufind_hoadon_Click);
            // 
            // mnufind_hang
            // 
            this.mnufind_hang.Name = "mnufind_hang";
            this.mnufind_hang.Size = new System.Drawing.Size(169, 26);
            this.mnufind_hang.Text = "Hàng";
            this.mnufind_hang.Click += new System.EventHandler(this.mnufind_hang_Click);
            // 
            // mnufind_khachhang
            // 
            this.mnufind_khachhang.Name = "mnufind_khachhang";
            this.mnufind_khachhang.Size = new System.Drawing.Size(169, 26);
            this.mnufind_khachhang.Text = "Khách hàng";
            this.mnufind_khachhang.Click += new System.EventHandler(this.mnufind_khachhang_Click);
            // 
            // mnu_baocao
            // 
            this.mnu_baocao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBC_sanpham,
            this.mnuBC_hangton,
            this.mnuBC_doanhthu});
            this.mnu_baocao.Name = "mnu_baocao";
            this.mnu_baocao.Size = new System.Drawing.Size(77, 24);
            this.mnu_baocao.Text = "&Báo cáo";
            // 
            // mnuBC_sanpham
            // 
            this.mnuBC_sanpham.Name = "mnuBC_sanpham";
            this.mnuBC_sanpham.Size = new System.Drawing.Size(161, 26);
            this.mnuBC_sanpham.Text = "Sản phẩm";
            this.mnuBC_sanpham.Click += new System.EventHandler(this.mnuBC_sanpham_Click);
            // 
            // mnuBC_hangton
            // 
            this.mnuBC_hangton.Name = "mnuBC_hangton";
            this.mnuBC_hangton.Size = new System.Drawing.Size(161, 26);
            this.mnuBC_hangton.Text = "Hàng tồn";
            this.mnuBC_hangton.Click += new System.EventHandler(this.mnuBC_hangton_Click);
            // 
            // mnuBC_doanhthu
            // 
            this.mnuBC_doanhthu.Name = "mnuBC_doanhthu";
            this.mnuBC_doanhthu.Size = new System.Drawing.Size(161, 26);
            this.mnuBC_doanhthu.Text = "Doanh thu";
            this.mnuBC_doanhthu.Click += new System.EventHandler(this.mnuBC_doanhthu_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHien_trogiup});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // mnuHien_trogiup
            // 
            this.mnuHien_trogiup.Name = "mnuHien_trogiup";
            this.mnuHien_trogiup.Size = new System.Drawing.Size(147, 26);
            this.mnuHien_trogiup.Text = "Trợ giúp";
            // 
            // mnu_vainet
            // 
            this.mnu_vainet.Name = "mnu_vainet";
            this.mnu_vainet.Size = new System.Drawing.Size(68, 24);
            this.mnu_vainet.Text = "&Vài nét";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = global::QLBH_11_TRANMINHDUNG.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1434, 698);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình quản lý bán hàng lưu niệm";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tệpTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_file;
        private System.Windows.Forms.ToolStripMenuItem mnu_danhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnu_chatlieu;
        private System.Windows.Forms.ToolStripMenuItem mnu_nhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnu_khachhang;
        private System.Windows.Forms.ToolStripMenuItem mnu_hanghoa;
        private System.Windows.Forms.ToolStripMenuItem mnu_hoadon;
        private System.Windows.Forms.ToolStripMenuItem mnu_hoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnu_timkiem;
        private System.Windows.Forms.ToolStripMenuItem mnufind_hoadon;
        private System.Windows.Forms.ToolStripMenuItem mnufind_hang;
        private System.Windows.Forms.ToolStripMenuItem mnufind_khachhang;
        private System.Windows.Forms.ToolStripMenuItem mnu_baocao;
        private System.Windows.Forms.ToolStripMenuItem mnuBC_hangton;
        private System.Windows.Forms.ToolStripMenuItem mnuBC_doanhthu;
        private System.Windows.Forms.ToolStripMenuItem mnuBC_sanpham;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHien_trogiup;
        private System.Windows.Forms.ToolStripMenuItem mnu_vainet;
    }
}


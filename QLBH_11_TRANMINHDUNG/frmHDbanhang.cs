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
using QLBH_11_TRANMINHDUNG.Class;



namespace QLBH_11_TRANMINHDUNG
{
    public partial class frmHDbanhang : Form
    {
        DataTable tblH;
        public frmHDbanhang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmHDbanhang_Load(object sender, EventArgs e)
        {
            btn_themhoadon.Enabled = true;
            btn_luuhoadon.Enabled = false;
            btn_huyhoadon.Enabled = false;
            btn_inhoadon.Enabled = false;
            txt_maHDban.ReadOnly = true;
            txt_tennhanvien.ReadOnly = true;
            txt_tenkhach.ReadOnly = true;
            txt_diachi.ReadOnly = true;
            mtb_dienthoai.ReadOnly = true;
            txt_tenhang.ReadOnly = true;
            txt_dongia.ReadOnly = true;
            txt_thanhtien.ReadOnly = true;
            txt_tongtien.ReadOnly = true;
            txt_giamgia.Text = "0";
            txt_tongtien.Text = "0";
            Functions.FillCombo("SELECT MaKhach, TenKhach FROM tblKhach", cbo_makhach, "MaKhach", "TenKhach");
            cbo_makhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM tblNhanVien", cbo_manhanvien, "MaNhanVien", "TenNhanVien");
            cbo_manhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHang, TenHang FROM tblHang", cbo_mahang, "MaHang", "TenHang");
            cbo_mahang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txt_maHDban.Text != "")
            {
                LoadInfoHoaDon();
                btn_huyhoadon.Enabled = true;
                btn_inhoadon.Enabled = true;
            }
            LoadDataGridView();
        }
        //Phương thức LoadDataGridView
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaHang, b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM tblChiTietHDBan AS a, tblHang AS b WHERE a.MaHDBan = N'" + txt_maHDban.Text + "' AND a.MaHang=b.MaHang";
            tblH = Functions.GetDataToTable(sql);
            dvg_hoadonbanhang.DataSource = tblH;
            dvg_hoadonbanhang.Columns[0].HeaderText = "Mã hàng";
            dvg_hoadonbanhang.Columns[1].HeaderText = "Tên hàng";
            dvg_hoadonbanhang.Columns[2].HeaderText = "Số lượng";
            dvg_hoadonbanhang.Columns[3].HeaderText = "Đơn giá";
            dvg_hoadonbanhang.Columns[4].HeaderText = "Giảm giá %";
            dvg_hoadonbanhang.Columns[5].HeaderText = "Thành tiền";
            dvg_hoadonbanhang.Columns[0].Width = 80;
            dvg_hoadonbanhang.Columns[1].Width = 130;
            dvg_hoadonbanhang.Columns[2].Width = 80;
            dvg_hoadonbanhang.Columns[3].Width = 90;
            dvg_hoadonbanhang.Columns[4].Width = 90;
            dvg_hoadonbanhang.Columns[5].Width = 90;
            dvg_hoadonbanhang.AllowUserToAddRows = false;
            dvg_hoadonbanhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        //Phương thức LoadInfoHoaDon
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
            dtp_ngayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
            cbo_manhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaKhach FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
            cbo_makhach.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
            txt_tongtien.Text = Functions.GetFieldValues(str);
            lbl_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txt_tongtien.Text));
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbo_manhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_manhanvien.Text == "")
                txt_tennhanvien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenNhanVien from tblNhanVien where MaNhanVien =N'" + cbo_manhanvien.SelectedValue + "'";
            txt_tennhanvien.Text = Functions.GetFieldValues(str);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_themhoadon_Click(object sender, EventArgs e)
        {
            btn_huyhoadon.Enabled = false;
            btn_luuhoadon.Enabled = true;
            btn_inhoadon.Enabled = false;
            btn_themhoadon.Enabled = false;
            ResetValues();
            txt_maHDban.Text = Functions.CreateKey("HDB");
            LoadDataGridView();

        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = Functions.ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        private void ResetValues()
        {
            txt_maHDban.Text = "";
            dtp_ngayban.Text = DateTime.Now.ToShortDateString();
            cbo_manhanvien.Text = "";
            cbo_makhach.Text = "";
            txt_tongtien.Text = "0";
            lbl_bangchu.Text = "Bằng chữ: ";
            cbo_mahang.Text = "";
            txt_soluong.Text = "";
            txt_giamgia.Text = "0";
            txt_thanhtien.Text = "0";
        }

        private void btn_luuhoadon_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDBan FROM tblHDBan WHERE MaHDBan=N'" + txt_maHDban.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (cbo_manhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbo_manhanvien.Focus();
                    return;
                }
                if (cbo_makhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbo_makhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblHDBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" + txt_maHDban.Text.Trim() + "','" +
                        Functions.ConvertDateTime(dtp_ngayban.Text.Trim()) + "',N'" + cbo_manhanvien.SelectedValue + "',N'" +
                        cbo_makhach.SelectedValue + "'," + txt_tongtien.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cbo_mahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mahang.Focus();
                return;
            }
            if ((txt_soluong.Text.Trim().Length == 0) || (txt_soluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_soluong.Text = "";
                txt_soluong.Focus();
                return;
            }
            if (txt_giamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_giamgia.Focus();
                return;
            }
            sql = "SELECT MaHang FROM tblChiTietHDBan WHERE MaHang=N'" + cbo_mahang.SelectedValue + "' AND MaHDBan = N'" + txt_maHDban.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbo_mahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + cbo_mahang.SelectedValue + "'"));
            if (Convert.ToDouble(txt_soluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_soluong.Text = "";
                txt_soluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txt_maHDban.Text.Trim() + "',N'" + cbo_mahang.SelectedValue + "'," + txt_soluong.Text + "," + txt_dongia.Text + "," + txt_giamgia.Text + "," + txt_thanhtien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txt_soluong.Text);
            sql = "UPDATE tblHang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cbo_mahang.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txt_thanhtien.Text);
            sql = "UPDATE tblHDBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
            Functions.RunSQL(sql);
            txt_tongtien.Text = Tongmoi.ToString();
            lbl_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));
            ResetValuesHang();
            btn_huyhoadon.Enabled = true;
            btn_themhoadon.Enabled = true;
            btn_inhoadon.Enabled = true;

        }
        private void ResetValuesHang()
        {
            cbo_mahang.Text = "";
            txt_soluong.Text = "";
            txt_giamgia.Text = "0";
            txt_thanhtien.Text = "0";
        }

        private void dvg_hoadonbanhang_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dvg_hoadonbanhang.CurrentRow.Cells["MaHang"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dvg_hoadonbanhang.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dvg_hoadonbanhang.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + txt_maHDban.Text + "' AND MaHang = N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHDBan SET TongTien =" + tongmoi + " WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
                Functions.RunSQL(sql);
                txt_tongtien.Text = tongmoi.ToString();
                lbl_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tongmoi.ToString()));
                LoadDataGridView();
            }

        }

        private void cbo_makhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_makhach.Text == "")
            {
                txt_tenkhach.Text = "";
                txt_diachi.Text = "";
                mtb_dienthoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenKhach from tblKhach where MaKhach = N'" + cbo_makhach.SelectedValue + "'";
            txt_tenkhach.Text = Functions.GetFieldValues(str);
            str = "Select DiaChi from tblKhach where MaKhach = N'" + cbo_makhach.SelectedValue + "'";
            txt_diachi.Text = Functions.GetFieldValues(str);
            str = "Select DienThoai from tblKhach where MaKhach= N'" + cbo_makhach.SelectedValue + "'";
            mtb_dienthoai.Text = Functions.GetFieldValues(str);

        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txt_soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_soluong.Text);
            if (txt_giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_giamgia.Text);
            if (txt_dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_dongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txt_thanhtien.Text = tt.ToString();

        }
    }
}

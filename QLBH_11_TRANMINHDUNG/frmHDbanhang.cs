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
using COMExcel = Microsoft.Office.Interop.Excel;

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
            Functions.FillCombo("SELECT MaKhach, TenKhachHang FROM tblKhach", cbo_makhach, "MaKhach", "TenKhachHang");
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
         
            string ngayBanStr = Functions.GetFieldValues(str);
            if (!string.IsNullOrEmpty(ngayBanStr))
            {
                dtp_ngayban.Value = DateTime.Parse(ngayBanStr);
            }        

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
            txt_maHDban.Text = CreateKey("HDB");
            LoadDataGridView();
        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
           
            key = key + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            return key;
        }
        private void ResetValues()
        {
            txt_maHDban.Text = "";
            dtp_ngayban.Value = DateTime.Now;
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

               
                string ngayBanSQL = dtp_ngayban.Value.ToString("yyyy-MM-dd");

                sql = "INSERT INTO tblHDBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" +
                      txt_maHDban.Text.Trim() + "','" +
                      ngayBanSQL + "',N'" + // Sử dụng biến đã định dạng
                      cbo_manhanvien.SelectedValue + "',N'" +
                      cbo_makhach.SelectedValue + "'," +
                      txt_tongtien.Text + ")";
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
            if (cbo_makhach.SelectedValue != null)
            {
                str = "Select TenKhachHang from tblKhach where MaKhach = N'" + cbo_makhach.SelectedValue + "'";
                txt_tenkhach.Text = Functions.GetFieldValues(str);
                str = "Select DiaChi from tblKhach where MaKhach = N'" + cbo_makhach.SelectedValue + "'";
                txt_diachi.Text = Functions.GetFieldValues(str);
                str = "Select DienThoai from tblKhach where MaKhach= N'" + cbo_makhach.SelectedValue + "'";
                mtb_dienthoai.Text = Functions.GetFieldValues(str);
            }
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

        private void cbo_mahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_mahang.Text == "")
            {
                txt_tenhang.Text = "";
                txt_dongia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            if (cbo_mahang.SelectedValue != null)
            {
                str = "SELECT TenHang FROM tblHang WHERE MaHang =N'" + cbo_mahang.SelectedValue + "'";
                txt_tenhang.Text = Functions.GetFieldValues(str);
                str = "SELECT DonGiaBan FROM tblHang WHERE MaHang =N'" + cbo_mahang.SelectedValue + "'";
                txt_dongia.Text = Functions.GetFieldValues(str);
            }
        }

        // Phương thức btnXoa_Click
        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaHang,SoLuong FROM tblChiTietHDBan WHERE MaHDBan = N'" + txt_maHDban.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + txt_maHDban.Text + "'";
                Functions.RunSQL(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHDBan WHERE MaHDBan=N'" + txt_maHDban.Text + "'";
                Functions.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btn_huyhoadon.Enabled = false;
                btn_inhoadon.Enabled = false;
            }
        }

        private void txt_giamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
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

        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop B.A.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDBan, a.NgayBan, a.TongTien, b.TenKhachHang, b.DiaChi, b.DienThoai, c.TenNhanVien FROM tblHDBan AS a, tblKhach AS b, tblNhanVien AS c WHERE a.MaHDBan = N'" + txt_maHDban.Text + "' AND a.MaKhach = b.MaKhach AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien " +
                  "FROM tblChiTietHDBan AS a , tblHang AS b WHERE a.MaHDBan = N'" +
                  txt_maHDban.Text + "' AND a.MaHang = b.MaHang";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if (cbo_mahoadon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_mahoadon.Focus();
                return;
            }
            txt_maHDban.Text = cbo_mahoadon.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btn_huyhoadon.Enabled = true;
            btn_luuhoadon.Enabled = true;
            btn_inhoadon.Enabled = true;
            cbo_mahoadon.SelectedIndex = -1;
        }

        private void cbo_mahoadon_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHDBan FROM tblHDBan", cbo_mahoadon, "MaHDBan", "MaHDBan");
            cbo_mahoadon.SelectedIndex = -1;
        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void frmHDbanhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
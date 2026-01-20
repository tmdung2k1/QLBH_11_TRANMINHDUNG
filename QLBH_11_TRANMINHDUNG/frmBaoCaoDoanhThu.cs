using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH_11_TRANMINHDUNG.Class;
using Microsoft.Reporting.WinForms;
using Word = Microsoft.Office.Interop.Word;

namespace QLBH_11_TRANMINHDUNG
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            this.rpvBaoCao.RefreshReport();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpTuNgay.Value > dtpDenNgay.Value)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu doanh thu
                string sql = @"SELECT 
                              h.NgayBan, 
                              h.MaHDBan, 
                              hh.TenHang,
                              ct.SoLuong,
                              ct.DonGia,
                              ct.GiamGia,
                              (ct.SoLuong * ct.DonGia - ct.GiamGia) AS ThanhTien
                              FROM tblHDBan h
                              INNER JOIN tblChiTietHDBan ct ON h.MaHDBan = ct.MaHDBan
                              INNER JOIN tblHang hh ON ct.MaHang = hh.MaHang
                              WHERE h.NgayBan >= '" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + @"' 
                              AND h.NgayBan <= '" + dtpDenNgay.Value.ToString("yyyy-MM-dd") + @"'
                              ORDER BY h.NgayBan DESC";

                DataTable dt = Functions.GetDataToTable(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa các data source cũ
                rpvBaoCao.LocalReport.DataSources.Clear();

                // Đường dẫn đến file report
                rpvBaoCao.LocalReport.ReportPath = Application.StartupPath + "\\rptDoanhThu.rdlc";

                // Tạo parameters cho report
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("TuNgay", dtpTuNgay.Value.ToString("dd/MM/yyyy"));
                parameters[1] = new ReportParameter("DenNgay", dtpDenNgay.Value.ToString("dd/MM/yyyy"));
                rpvBaoCao.LocalReport.SetParameters(parameters);

                // Tạo ReportDataSource
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;

                // Thêm data source vào report
                rpvBaoCao.LocalReport.DataSources.Add(rds);

                // Refresh report để hiển thị
                rpvBaoCao.RefreshReport();

                MessageBox.Show("Đã tạo báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpvBaoCao_Load(object sender, EventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpTuNgay.Value > dtpDenNgay.Value)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu
                string sql = @"SELECT 
                              h.NgayBan, 
                              h.MaHDBan, 
                              hh.TenHang,
                              ct.SoLuong,
                              ct.DonGia,
                              ct.GiamGia,
                              (ct.SoLuong * ct.DonGia - ct.GiamGia) AS ThanhTien
                              FROM tblHDBan h
                              INNER JOIN tblChiTietHDBan ct ON h.MaHDBan = ct.MaHDBan
                              INNER JOIN tblHang hh ON ct.MaHang = hh.MaHang
                              WHERE h.NgayBan >= '" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + @"' 
                              AND h.NgayBan <= '" + dtpDenNgay.Value.ToString("yyyy-MM-dd") + @"'
                              ORDER BY h.NgayBan DESC";

                DataTable dt = Functions.GetDataToTable(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo SaveFileDialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveDialog.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";
                saveDialog.Title = "Lưu báo cáo Word";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo Word Application
                    Word.Application wordApp = new Word.Application();
                    Word.Document wordDoc = wordApp.Documents.Add();
                    wordApp.Visible = false;

                    // Thêm tiêu đề
                    Word.Paragraph para1 = wordDoc.Paragraphs.Add();
                    para1.Range.Text = "BÁO CÁO DOANH THU BÁN HÀNG";
                    para1.Range.Font.Size = 16;
                    para1.Range.Font.Bold = 1;
                    para1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para1.Range.InsertParagraphAfter();

                    // Thêm khoảng thời gian
                    Word.Paragraph para2 = wordDoc.Paragraphs.Add();
                    para2.Range.Text = "Từ ngày: " + dtpTuNgay.Value.ToString("dd/MM/yyyy") + " - Đến ngày: " + dtpDenNgay.Value.ToString("dd/MM/yyyy");
                    para2.Range.Font.Size = 11;
                    para2.Range.Font.Bold = 1;
                    para2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para2.Range.InsertParagraphAfter();

                    // Thêm ngày xuất
                    Word.Paragraph para3 = wordDoc.Paragraphs.Add();
                    para3.Range.Text = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    para3.Range.Font.Size = 11;
                    para3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para3.Range.InsertParagraphAfter();
                    para3.Range.InsertParagraphAfter();

                    // Tạo bảng
                    int rows = dt.Rows.Count + 1;
                    int cols = 7;
                    Word.Table table = wordDoc.Tables.Add(para3.Range, rows, cols);
                    table.Borders.Enable = 1;

                    // Header
                    table.Cell(1, 1).Range.Text = "Ngày bán";
                    table.Cell(1, 2).Range.Text = "Số HĐ";
                    table.Cell(1, 3).Range.Text = "Tên hàng";
                    table.Cell(1, 4).Range.Text = "SL";
                    table.Cell(1, 5).Range.Text = "Đơn giá";
                    table.Cell(1, 6).Range.Text = "Giảm giá";
                    table.Cell(1, 7).Range.Text = "Thành tiền";

                    // Format header
                    for (int col = 1; col <= cols; col++)
                    {
                        table.Cell(1, col).Range.Font.Bold = 1;
                        table.Cell(1, col).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Cell(1, col).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                    }

                    // Dữ liệu
                    decimal tongDoanhThu = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        table.Cell(i + 2, 1).Range.Text = Convert.ToDateTime(dt.Rows[i]["NgayBan"]).ToString("dd/MM/yyyy");
                        table.Cell(i + 2, 2).Range.Text = dt.Rows[i]["MaHDBan"].ToString();
                        table.Cell(i + 2, 3).Range.Text = dt.Rows[i]["TenHang"].ToString();
                        table.Cell(i + 2, 4).Range.Text = dt.Rows[i]["SoLuong"].ToString();
                        table.Cell(i + 2, 5).Range.Text = string.Format("{0:#,##0}", dt.Rows[i]["DonGia"]);
                        table.Cell(i + 2, 6).Range.Text = string.Format("{0:#,##0}", dt.Rows[i]["GiamGia"]);
                        table.Cell(i + 2, 7).Range.Text = string.Format("{0:#,##0}", dt.Rows[i]["ThanhTien"]);

                        tongDoanhThu += Convert.ToDecimal(dt.Rows[i]["ThanhTien"]);

                        // Căn phải cho cột số
                        table.Cell(i + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(i + 2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(i + 2, 6).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(i + 2, 7).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    }

                    // Thêm tổng cộng
                    Word.Paragraph para4 = wordDoc.Paragraphs.Add();
                    para4.Range.Text = "\n\nTổng doanh thu: " + string.Format("{0:#,##0}", tongDoanhThu) + " VNĐ";
                    para4.Range.Font.Size = 12;
                    para4.Range.Font.Bold = 1;
                    para4.Range.Font.Color = Word.WdColor.wdColorDarkRed;

                    // Lưu file
                    wordDoc.SaveAs2(saveDialog.FileName);
                    wordDoc.Close();
                    wordApp.Quit();

                    // Giải phóng COM objects
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(table);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);

                    MessageBox.Show("Đã xuất báo cáo ra Word thành công!\nFile: " + saveDialog.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file Word
                    if (MessageBox.Show("Bạn có muốn mở file vừa tạo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

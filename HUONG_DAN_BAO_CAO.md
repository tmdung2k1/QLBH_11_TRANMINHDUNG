# HƯỚNG DẪN TẠO BÁO CÁO VỚI REPORTVIEWER

## BƯỚC 1: CÀI ĐẶT REPORTVIEWER

1. Mở Solution trong Visual Studio
2. Chuột phải vào project **QLBH_11_TRANMINHDUNG** > **Manage NuGet Packages**
3. Chọn tab **Browse**
4. Tìm kiếm: `Microsoft.ReportingServices.ReportViewerControl.Winforms`
5. Chọn và nhấn **Install**
6. Chấp nhận License

## BƯỚC 2: TẠO FILE BÁO CÁO (.RDLC)

1. Trong **Solution Explorer**, chuột phải vào project > **Add** > **New Item**
2. Chọn **Reporting** (bên trái) > **Report** (bên phải)
3. Đặt tên: `rptSanPham.rdlc`
4. Nhấn **Add**

## BƯỚC 3: TẠO DATASET CHO BÁO CÁO

1. Kích đúp vào file `rptSanPham.rdlc` vừa tạo
2. Ở cửa sổ **Report Data** (bên trái), chuột phải vào **DataSets** > **Add Dataset**
3. Trong hộp thoại:
   - Name: `DataSet1`
   - Data source: **New data source...**
   - Type: chọn **Microsoft SQL Server**
   - Connection string: (giống connection trong Functions.cs)
   - Query: 
   ```sql
   SELECT MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu 
   FROM tblHang
   ```
4. Nhấn **OK**

## BƯỚC 4: THIẾT KẾ BÁO CÁO

1. Chuột phải vào vùng trống của report > **Insert** > **Table**
2. Kéo thả các trường từ **DataSet1** vào các cột của Table:
   - Cột 1: MaHang
   - Cột 2: TenHang
   - Cột 3: MaChatLieu
   - Cột 4: SoLuong
   - Cột 5: DonGiaNhap
   - Cột 6: DonGiaBan
   - Cột 7: GhiChu

3. Chỉnh sửa Header:
   - Mã hàng
   - Tên hàng
   - Chất liệu
   - Số lượng
   - Giá nhập
   - Giá bán
   - Ghi chú

4. **Thêm Page Header** (tuỳ chọn):
   - Chuột phải vào report > **Page Header** > **Add**
   - Thêm TextBox với nội dung: "BÁO CÁO DANH SÁCH SẢN PHẨM"
   - Set Font = Bold, Size = 16

## BƯỚC 5: CẤU HÌNH FILE RDLC

1. Chọn file `rptSanPham.rdlc` trong **Solution Explorer**
2. Ở cửa sổ **Properties**, đổi:
   - **Copy to Output Directory** = **Copy if newer**

## BƯỚC 6: CHẠY THỬ NGHIỆM

1. Build lại project
2. Chạy ứng dụng
3. Gọi form báo cáo:
   ```csharp
   frmBaoCao frm = new frmBaoCao();
   frm.ShowDialog();
   ```
4. Nhấn nút "Tạo báo cáo"

## LƯU Ý:

- Nếu báo lỗi không tìm thấy file .rdlc, kiểm tra đường dẫn trong code
- Tên DataSet trong code phải trùng với tên DataSet trong file .rdlc
- Đảm bảo connection string đúng với database

## MỞ RỘNG:

Bạn có thể tạo thêm các báo cáo khác:
- Báo cáo hóa đơn bán hàng
- Báo cáo doanh thu theo thời gian
- Báo cáo khách hàng
- Báo cáo tồn kho

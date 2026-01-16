-- 1. Tạo Database
CREATE DATABASE QLCHLUUNIEM;
GO
USE QLCHLUUNIEM;
GO

-- 2. Tạo bảng Chất Liệu (TBChatLieu)
CREATE TABLE TBChatLieu (
    MaChatLieu NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenChatLieu NVARCHAR(50) NOT NULL
);

-- 3. Tạo bảng Nhân Viên (TBNhanVien)
CREATE TABLE TBNhanVien (
    MaNhanVien NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenNhanVien NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(100),
    DienThoai NVARCHAR(15),
    NgaySinh DATETIME
);

-- 4. Tạo bảng Khách Hàng (TBKhach)
CREATE TABLE TBKhach (
    MaKhach NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenKhach NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100),
    DienThoai NVARCHAR(15)
);

-- 5. Tạo bảng Hàng Hóa (TBHang)
CREATE TABLE TBHang (
    MaHang NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenHang NVARCHAR(50) NOT NULL,
    MaChatLieu NVARCHAR(50) NOT NULL,
    SoLuong FLOAT,
    DonGiaNhap FLOAT,
    DonGiaBan FLOAT,
    Anh NVARCHAR(200), -- Đường dẫn ảnh
    GhiChu NVARCHAR(200),
    FOREIGN KEY (MaChatLieu) REFERENCES TBChatLieu(MaChatLieu)
);

-- 6. Tạo bảng Hóa Đơn Bán (TBHDBan)
CREATE TABLE TBHDBan (
    MaHDBan NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaNhanVien NVARCHAR(50) NOT NULL,
    NgayBan DATETIME NOT NULL,
    MaKhach NVARCHAR(50) NOT NULL,
    TongTien FLOAT,
    FOREIGN KEY (MaNhanVien) REFERENCES TBNhanVien(MaNhanVien),
    FOREIGN KEY (MaKhach) REFERENCES TBKhach(MaKhach)
);

-- 7. Tạo bảng Chi Tiết Hóa Đơn Bán (TBChiTietHDBan)
CREATE TABLE TBChiTietHDBan (
    MaHDBan NVARCHAR(50) NOT NULL,
    MaHang NVARCHAR(50) NOT NULL,
    SoLuong FLOAT,
    DonGia FLOAT,
    GiamGia FLOAT,
    ThanhTien FLOAT,
    PRIMARY KEY (MaHDBan, MaHang),
    FOREIGN KEY (MaHDBan) REFERENCES TBHDBan(MaHDBan),
    FOREIGN KEY (MaHang) REFERENCES TBHang(MaHang)
);

-- 8. Thêm một vài dữ liệu mẫu (Để test phần mềm)
INSERT INTO TBChatLieu VALUES ('CL01', N'Gốm sứ'), ('CL02', N'Sơn mài');
INSERT INTO TBNhanVien VALUES ('NV01', N'Trần Minh Dũng', N'Nam', N'Hà Nội', '0912345678', '2000-01-01');
INSERT INTO TBKhach VALUES ('KH01', N'Nguyễn Văn A', N'Hà Nội', '0987654321');
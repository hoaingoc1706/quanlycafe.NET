create database QLCafe;
-- Bảng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon VARCHAR(10) PRIMARY KEY,
    MaKhachHang VARCHAR(10) NOT NULL,
    MaNhanVien VARCHAR(10) NOT NULL,
    NgayBan DATE NOT NULL,
    TongTien FLOAT NOT NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng ChiTietHDB
CREATE TABLE ChiTietHDB (
    MaHoaDon VARCHAR(10) NOT NULL,
    MaSanPham VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien FLOAT NOT NULL,
    KhuyenMai NVARCHAR(20) NOT NULL,
    GhiChu NVARCHAR(255),
    PRIMARY KEY (MaHoaDon, MaSanPham),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Bảng HoaDonNhap
CREATE TABLE HoaDonNhap (
    MaDonNhap VARCHAR(10) PRIMARY KEY,
    MaNhanVien VARCHAR(10) NOT NULL,
    MaNhaCungCap VARCHAR(10) NOT NULL,
    NgayNhap DATE NOT NULL,
    TongTien FLOAT NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

-- Bảng ChiTietHDN
CREATE TABLE ChiTietHDN (
    MaDonNhap VARCHAR(10) NOT NULL,
    MaSanPham VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia FLOAT NOT NULL,
    ThanhTien FLOAT NOT NULL,
    KhuyenMai NVARCHAR(20) NOT NULL,
    PRIMARY KEY (MaDonNhap, MaSanPham),
    FOREIGN KEY (MaDonNhap) REFERENCES HoaDonNhap(MaDonNhap),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Bảng SanPham
CREATE TABLE SanPham (
    MaSanPham VARCHAR(10) NOT NULL PRIMARY KEY ,
    TenSanPham NVARCHAR(50) NOT NULL,
    MaLoai VARCHAR(10) NOT NULL,
    GiaBan FLOAT NOT NULL,
    SoLuong INT NOT NULL,
    HinhAnh NVARCHAR(255) NOT NULL,
    FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);

-- Tạo bảng CongDung
CREATE TABLE CongDung (
    MaCongDung VARCHAR(10) PRIMARY KEY,
    TenCongDung NVARCHAR(100)
);

-- Sửa bảng SanPham để thêm thuộc tính MaCongDung
ALTER TABLE SanPham
ADD MaCongDung VARCHAR(10);

-- Tạo khóa ngoại giữa SanPham và CongDung
ALTER TABLE SanPham
ADD CONSTRAINT FK_SanPham_CongDung FOREIGN KEY (MaCongDung)
REFERENCES CongDung (MaCongDung);


--Thêm thuộc tính Giá Nhập
ALTER TABLE SanPham
ADD GiaNhap FLOAT; 

-- Bảng Loai
CREATE TABLE Loai (
    MaLoai VARCHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
);

-- Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(10) PRIMARY KEY,
    TenKhachHang NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    SoDienThoai VARCHAR(10) NOT NULL
);

-- Bảng NhaCungCap
CREATE TABLE NhaCungCap (
    MaNhaCungCap VARCHAR(10) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    SoDienThoai VARCHAR(10) NOT NULL
);

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(10) PRIMARY KEY,
    TenNhanVien NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    MaQue VARCHAR(10) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    SoDienThoai VARCHAR(10) NOT NULL,
    FOREIGN KEY (MaQue) REFERENCES Que(MaQue)
);

-- Bảng Que
CREATE TABLE Que (
    MaQue VARCHAR(10) PRIMARY KEY,
    TenQue NVARCHAR(50) NOT NULL
);


-- Chèn lại dữ liệu 
-- Bảng Que
INSERT INTO Que (MaQue, TenQue) VALUES ('Q01', 'Hà Nội');
INSERT INTO Que (MaQue, TenQue) VALUES ('Q02', 'Bắc Ninh');
INSERT INTO Que (MaQue, TenQue) VALUES ('Q03', 'Hải Phòng');
INSERT INTO Que (MaQue, TenQue) VALUES ('Q04', 'Nam Định');
INSERT INTO Que (MaQue, TenQue) VALUES ('Q05', 'Đà Nẵng');

-- Bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DiaChi, MaQue, NgaySinh, GioiTinh, SoDienThoai) 
VALUES ('NV01', 'Nguyễn Văn Bình', '123 Kim Giang, Hà Nội', 'Q01', '1985-05-01', 'Nam', '0912345678');
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DiaChi, MaQue, NgaySinh, GioiTinh, SoDienThoai) 
VALUES ('NV02', 'Trần Thị Lanh', '20 Láng, Hà Nội', 'Q02', '1990-08-15', 'Nữ', '0987654321');
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DiaChi, MaQue, NgaySinh, GioiTinh, SoDienThoai) 
VALUES ('NV03', 'Phạm Văn Cường', '456 Trường Chinh, Hải Phòng', 'Q03', '1988-02-20', 'Nam', '0911122233');
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DiaChi, MaQue, NgaySinh, GioiTinh, SoDienThoai) 
VALUES ('NV04', 'Lê Thị Thu', '789 Nam Cao, Nam Định', 'Q04', '1992-11-30', 'Nữ', '0944455667');
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DiaChi, MaQue, NgaySinh, GioiTinh, SoDienThoai) 
VALUES ('NV05', 'Ngô Minh Tú', '12 Hùng Vương, Đà Nẵng', 'Q05', '1987-07-14', 'Nam', '0977788990');

-- Bảng KhachHang
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES ('KH01', 'Lê Văn C', '789 Láng, Hà Nội', '0934567890');
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES ('KH02', 'Phạm Thị D', '321 Tây Sơn, Hà Nội', '0923456789');
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES ('KH03', 'Nguyễn Thị H', '456 Kim Mã, Hà Nội', '0915566778');
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES ('KH04', 'Trần Văn K', '789 Đại Cồ Việt, Hà Nội', '0989988776');
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai)
VALUES ('KH05', 'Lê Thị M', '123 Trần Hưng Đạo, Hà Nội', '0933221100');

-- Bảng NhaCungCap
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES ('NCC01', 'Công ty ABC', 'Số 1, Trường Chinh, Hà Nội', '0901234567');
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES ('NCC02', 'Công ty XYZ', 'Số 2, Chùa Bộc, Hà Nội', '0907654321');
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES ('NCC03', 'Công ty LMN', 'Số 3, Lê Thanh Nghị, Hà Nội', '0910112233');
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES ('NCC04', 'Công ty PQR', 'Số 4, Giải Phóng, Hà Nội', '0921223344');
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
VALUES ('NCC05', 'Công ty STU', 'Số 5, Phạm Ngọc Thạch, Hà Nội', '0932334455');


-- Bảng Loai
INSERT INTO Loai (MaLoai, TenLoai)
VALUES ('L01', 'Cafe');
INSERT INTO Loai (MaLoai, TenLoai)
VALUES ('L02', 'Sinh tố');
INSERT INTO Loai (MaLoai, TenLoai)
VALUES ('L03', 'Trà');
INSERT INTO Loai (MaLoai, TenLoai)
VALUES ('L04', 'Nước ép');
INSERT INTO Loai (MaLoai, TenLoai)
VALUES ('L05', 'Đồ uống khác'); 

-- Bảng CongDung
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES ('CD01', 'Đồ uống pha chế');
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES ('CD02', 'Nguyên liệu');
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES ('CD03', 'Đồ uống sẵn');
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES ('CD04', 'Chăm sóc sức khỏe');
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES ('CD05', 'Bổ sung dinh dưỡng');


-- Bảng SanPham
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, GiaBan, SoLuong, HinhAnh, MaCongDung, GiaNhap)
VALUES ('SP03', 'Cà phê nâu', 'L01', 30000, 100, 'cafenau.jpg', 'CD01', 20000);
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, GiaBan, SoLuong, HinhAnh, MaCongDung, GiaNhap)
VALUES ('SP04', 'Sinh tố', 'L02', 50000, 150, 'sinhtobo.jpg', 'CD01', 30000);
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, GiaBan, SoLuong, HinhAnh, MaCongDung, GiaNhap)
VALUES ('SP05', 'Trà xanh', 'L03', 20000, 120, 'traxanh.jpg', 'CD03', 15000);
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, GiaBan, SoLuong, HinhAnh, MaCongDung, GiaNhap)
VALUES ('SP06', 'Nước ép cam', 'L04', 40000, 80, 'nuocep.jpg', 'CD04', 30000);
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, GiaBan, SoLuong, HinhAnh, MaCongDung, GiaNhap)
VALUES ('SP07', 'Nước suối', 'L05', 10000, 200, 'nuocsuoi.jpg', 'CD05', 5000);

-- Bảng HoaDon
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien)
VALUES ('HD01', 'KH01', 'NV01','2023-05-01', 60000);
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien)
VALUES ('HD02', 'KH02', 'NV02', '2023-05-02', 100000);
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien)
VALUES ('HD03', 'KH03', 'NV03', '2023-05-03', 40000);
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien)
VALUES ('HD04', 'KH04', 'NV04', '2023-05-04', 80000);
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien)
VALUES ('HD05', 'KH05', 'NV05', '2023-05-05', 20000);

-- Bảng ChiTietHDB
INSERT INTO ChiTietHDB (MaHoaDon, MaSanPham, SoLuong, ThanhTien, KhuyenMai, GhiChu)
VALUES ('HD01', 'SP03', 2, 60000, '0%', 'Không ghi chú');
INSERT INTO ChiTietHDB (MaHoaDon, MaSanPham, SoLuong, ThanhTien, KhuyenMai, GhiChu)
VALUES ('HD02', 'SP04', 2, 100000, '0%', 'Không ghi chú');
INSERT INTO ChiTietHDB (MaHoaDon, MaSanPham, SoLuong, ThanhTien, KhuyenMai, GhiChu)
VALUES ('HD03', 'SP05', 2, 40000, '0%', 'Không ghi chú');
INSERT INTO ChiTietHDB (MaHoaDon, MaSanPham, SoLuong, ThanhTien, KhuyenMai, GhiChu)
VALUES ('HD04', 'SP06', 2, 80000, '0%', 'Không ghi chú');
INSERT INTO ChiTietHDB (MaHoaDon, MaSanPham, SoLuong, ThanhTien, KhuyenMai, GhiChu)
VALUES ('HD05', 'SP07', 2, 20000, '0%', 'Không ghi chú');


-- Bảng HoaDonNhap
INSERT INTO HoaDonNhap (MaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
VALUES ('HDN01', 'NV01', 'NCC01', '2023-05-01', 200000);
INSERT INTO HoaDonNhap (MaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
VALUES ('HDN02', 'NV02', 'NCC02', '2023-05-02', 300000);
INSERT INTO HoaDonNhap (MaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
VALUES ('HDN03', 'NV03', 'NCC03', '2023-05-03', 150000);
INSERT INTO HoaDonNhap (MaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
VALUES ('HDN04', 'NV04', 'NCC04', '2023-05-04', 300000);
INSERT INTO HoaDonNhap (MaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap, TongTien)
VALUES ('HDN05', 'NV05', 'NCC05', '2023-05-05', 50000);

-- Bảng ChiTietHDN
INSERT INTO ChiTietHDN (MaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien, KhuyenMai)
VALUES ('HDN01', 'SP03', 10, 20000, 200000, '0%');
INSERT INTO ChiTietHDN (MaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien, KhuyenMai)
VALUES ('HDN02', 'SP04', 10, 30000, 300000, '0%');
INSERT INTO ChiTietHDN (MaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien, KhuyenMai)
VALUES ('HDN03', 'SP05', 10, 15000, 150000, '0%');
INSERT INTO ChiTietHDN (MaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien, KhuyenMai)
VALUES ('HDN04', 'SP06', 10, 30000, 300000, '0%');
INSERT INTO ChiTietHDN (MaDonNhap, MaSanPham, SoLuong, DonGia, ThanhTien, KhuyenMai)
VALUES ('HDN05', 'SP07', 10, 5000, 50000, '0%');

--trigger cập nhật số lượng sản phẩm khi nhập
CREATE TRIGGER trg_UpdateSanPhamOnInsertChiTietHDN
ON ChiTietHDN
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET SanPham.SoLuong = SanPham.SoLuong + inserted.SoLuong
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham;
END;

--trigger khi bán
CREATE TRIGGER trg_UpdateSanPhamOnInsertChiTietHDB
ON ChiTietHDB
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET SanPham.SoLuong = SanPham.SoLuong - inserted.SoLuong
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham;
END;

--Giá nhập được update theo đơn giá
CREATE TRIGGER trg_UpdateGiaNhapOnInsertChiTietHDN
ON ChiTietHDN
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET SanPham.GiaNhap = inserted.DonGia
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham;
END;

--Giá bán bằng 110% giá nhập (Khi nhập nhập giá bán bằng 0)
CREATE TRIGGER trg_UpdateGiaBan
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật GiaBan của SanPham bằng 110% GiaNhap
    UPDATE SanPham
    SET GiaBan = GiaNhap * 1.1
END;
--cập nhật số lượng khi sửa chi tiết hoá đơn
CREATE TRIGGER update_count
ON ChiTietHDN
AFTER UPDATE
AS
BEGIN
	UPDATE SanPham
	SET SanPham.SoLuong = updated.SoLuong
	FROM SanPham INNER JOIN updated
	ON SanPham.MaSanPham = updated.MaSanPham;
END;


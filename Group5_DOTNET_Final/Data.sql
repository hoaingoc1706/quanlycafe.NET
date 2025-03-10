USE [master]
GO
/****** Object:  Database [QLCafe]    Script Date: 04/06/2024 11:03:03 CH ******/
CREATE DATABASE [QLCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLCafe] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLCafe] SET RECOVERY FULL 
GO
ALTER DATABASE [QLCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QLCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLCafe', N'ON'
GO
ALTER DATABASE [QLCafe] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLCafe] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLCafe]
GO
/****** Object:  Table [dbo].[ChiTietHDB]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDB](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[KhuyenMai] [nvarchar](20) NOT NULL,
	[GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDN](
	[MaDonNhap] [varchar](10) NOT NULL,
	[MaSanPham] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[KhuyenMai] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonNhap] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongDung]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongDung](
	[MaCongDung] [varchar](10) NOT NULL,
	[TenCongDung] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCongDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaKhachHang] [varchar](10) NOT NULL,
	[MaNhanVien] [varchar](10) NOT NULL,
	[NgayBan] [date] NOT NULL,
	[TongTien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[MaDonNhap] [varchar](10) NOT NULL,
	[MaNhanVien] [varchar](10) NOT NULL,
	[MaNhaCungCap] [varchar](10) NOT NULL,
	[NgayNhap] [date] NOT NULL,
	[TongTien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [varchar](10) NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SoDienThoai] [varchar](15) NOT NULL,
 CONSTRAINT [PK__KhachHan__88D2F0E597A41C73] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [varchar](10) NOT NULL,
	[TenLoai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [varchar](10) NOT NULL,
	[TenNhaCungCap] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SoDienThoai] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[MaQue] [varchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[SoDienThoai] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Que]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Que](
	[MaQue] [varchar](10) NOT NULL,
	[TenQue] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 04/06/2024 11:03:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [varchar](10) NOT NULL,
	[TenSanPham] [nvarchar](50) NOT NULL,
	[MaLoai] [varchar](10) NOT NULL,
	[GiaBan] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[HinhAnh] [nvarchar](255) NOT NULL,
	[MaCongDung] [varchar](10) NULL,
	[GiaNhap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHDB] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien], [KhuyenMai], [GhiChu]) VALUES (N'HD01', N'SP03', 2, 60000, N'0%', N'Không ghi chú')
INSERT [dbo].[ChiTietHDB] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien], [KhuyenMai], [GhiChu]) VALUES (N'HD02', N'SP04', 2, 100000, N'0%', N'Không ghi chú')
INSERT [dbo].[ChiTietHDB] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien], [KhuyenMai], [GhiChu]) VALUES (N'HD03', N'SP05', 2, 40000, N'0%', N'Không ghi chú')
INSERT [dbo].[ChiTietHDB] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien], [KhuyenMai], [GhiChu]) VALUES (N'HD04', N'SP06', 2, 80000, N'0%', N'Không ghi chú')
INSERT [dbo].[ChiTietHDB] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien], [KhuyenMai], [GhiChu]) VALUES (N'HD05', N'SP07', 2, 20000, N'0%', N'Không ghi chú')
GO
INSERT [dbo].[ChiTietHDN] ([MaDonNhap], [MaSanPham], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN01', N'SP03', 10, 20000, 200000, N'0%')
INSERT [dbo].[ChiTietHDN] ([MaDonNhap], [MaSanPham], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN02', N'SP04', 10, 30000, 300000, N'0%')
INSERT [dbo].[ChiTietHDN] ([MaDonNhap], [MaSanPham], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN03', N'SP05', 10, 15000, 150000, N'0%')
INSERT [dbo].[ChiTietHDN] ([MaDonNhap], [MaSanPham], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN04', N'SP06', 10, 30000, 300000, N'0%')
INSERT [dbo].[ChiTietHDN] ([MaDonNhap], [MaSanPham], [SoLuong], [DonGia], [ThanhTien], [KhuyenMai]) VALUES (N'HDN05', N'SP07', 10, 5000, 50000, N'0%')
GO
INSERT [dbo].[CongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD01', N'Đường pha chế')
INSERT [dbo].[CongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD02', N'Nguyên liệu')
INSERT [dbo].[CongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD03', N'Đường sấy')
INSERT [dbo].[CongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD04', N'Chăm sóc sức khỏe')
INSERT [dbo].[CongDung] ([MaCongDung], [TenCongDung]) VALUES (N'CD05', N'Bổ sung dinh dưỡng')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayBan], [TongTien]) VALUES (N'HD01', N'KH01', N'NV01', CAST(N'2023-05-01' AS Date), 60000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayBan], [TongTien]) VALUES (N'HD02', N'KH02', N'NV02', CAST(N'2023-05-02' AS Date), 100000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayBan], [TongTien]) VALUES (N'HD03', N'KH03', N'NV03', CAST(N'2023-05-03' AS Date), 40000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayBan], [TongTien]) VALUES (N'HD04', N'KH04', N'NV04', CAST(N'2023-05-04' AS Date), 80000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayBan], [TongTien]) VALUES (N'HD05', N'KH05', N'NV05', CAST(N'2023-05-05' AS Date), 20000)
GO
INSERT [dbo].[HoaDonNhap] ([MaDonNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien]) VALUES (N'HDN01', N'NV01', N'NCC01', CAST(N'2023-05-01' AS Date), 200000)
INSERT [dbo].[HoaDonNhap] ([MaDonNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien]) VALUES (N'HDN02', N'NV02', N'NCC02', CAST(N'2023-05-02' AS Date), 300000)
INSERT [dbo].[HoaDonNhap] ([MaDonNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien]) VALUES (N'HDN03', N'NV03', N'NCC03', CAST(N'2023-05-03' AS Date), 150000)
INSERT [dbo].[HoaDonNhap] ([MaDonNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien]) VALUES (N'HDN04', N'NV04', N'NCC04', CAST(N'2023-05-04' AS Date), 300000)
INSERT [dbo].[HoaDonNhap] ([MaDonNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien]) VALUES (N'HDN05', N'NV05', N'NCC05', CAST(N'2023-05-05' AS Date), 50000)
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'i', N'i', N'i', N'(9  )    -')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'KH01', N'Lê Văn C', N'789 Láng, Hà Nội', N'0934567890')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'KH02', N'Phạm Thị D', N'321 Tây Sơn, Hà Nội', N'0923456789')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'KH03', N'Nguyễn Thị H', N'456 Kim Mã, Hà Nội', N'0915566778')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'KH04', N'Trần Văn K', N'789 Đại Cồ Việt, Hà Nội', N'0989988776')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai]) VALUES (N'KH05', N'Lê Thị M', N'123 Trần Hưng Đạo, Hà Nội', N'0933221100')
GO
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (N'L01', N'Cà phê')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (N'L02', N'Sinh tố')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (N'L03', N'Trà')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (N'L04', N'Nước ép')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (N'L05', N'Đồ uống khác')
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC01', N'Công ty ABC', N'Số 1, Trường Chinh, Hà Nội', N'0901234567')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC02', N'Công ty XYZ', N'Số 2, Chùa Bộc, Hà Nội', N'0907654321')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC03', N'Công ty LMN', N'Số 3, Lê Thanh Nghị, Hà Nội', N'0910112233')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC04', N'Công ty PQR', N'Số 4, Giải Phóng, Hà Nội', N'0921223344')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC05', N'Công ty STU', N'Số 5, Phạm Ngọc Thạch, Hà Nội', N'0932334455')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV01', N'Nguyễn Văn Bình', N'123 Kim Giang, Hà Nội', N'Q01', CAST(N'1985-05-01' AS Date), N'Nam', N'0912345679')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV02', N'Nguyễn Thị Lanh ', N'20 Láng, Hà Nội', N'Q02', CAST(N'1990-08-15' AS Date), N'Nữ', N'0987654321')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV03', N'Phạm Văn Cường', N'456 Truờng Chinh, Hải Phòng', N'Q03', CAST(N'1988-02-20' AS Date), N'Nam', N'0911122233')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV04', N'Lê Thị Thu', N'789 Nam Cao, Nam Ðịnh', N'Q04', CAST(N'1992-11-30' AS Date), N'Nữ', N'0944455667')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV05', N'Ngô Minh Tú', N'12 Hùng Vuong, Ðà Nẵng', N'Q05', CAST(N'1987-07-14' AS Date), N'Nam', N'0977788990')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV06', N'Nguyễn Minh Hằng', N'12 Quan Nhân, Hà Nội', N'Q02', CAST(N'2000-11-02' AS Date), N'Nữ', N'0987768964')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV07', N'Hoàng Minh Ngọc', N'47 Nguyễn Tuân', N'Q01', CAST(N'1999-11-11' AS Date), N'Nữ', N'0784835392')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [DiaChi], [MaQue], [NgaySinh], [GioiTinh], [SoDienThoai]) VALUES (N'NV08', N'Nguyễn Thị Minh', N'78 phố Huế, Hà Nội', N'Q04', CAST(N'2000-11-02' AS Date), N'Nữ', N'0968945352')
GO
INSERT [dbo].[Que] ([MaQue], [TenQue]) VALUES (N'Q01', N'Hà Nội')
INSERT [dbo].[Que] ([MaQue], [TenQue]) VALUES (N'Q02', N'Bắc Ninh')
INSERT [dbo].[Que] ([MaQue], [TenQue]) VALUES (N'Q03', N'Hải Phòng')
INSERT [dbo].[Que] ([MaQue], [TenQue]) VALUES (N'Q04', N'Nam Ðịnh')
INSERT [dbo].[Que] ([MaQue], [TenQue]) VALUES (N'Q05', N'Ðà Nẵng')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoai], [GiaBan], [SoLuong], [HinhAnh], [MaCongDung], [GiaNhap]) VALUES (N'SP03', N'Cà phê nâu', N'L01', 22000, 108, N'cafenau.jpg', N'CD01', 20000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoai], [GiaBan], [SoLuong], [HinhAnh], [MaCongDung], [GiaNhap]) VALUES (N'SP04', N'Sinh tố', N'L02', 33000, 158, N'sinhtobo.jpg', N'CD01', 30000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoai], [GiaBan], [SoLuong], [HinhAnh], [MaCongDung], [GiaNhap]) VALUES (N'SP05', N'Trà xanh', N'L03', 16500, 128, N'traxanh.jpg', N'CD03', 15000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoai], [GiaBan], [SoLuong], [HinhAnh], [MaCongDung], [GiaNhap]) VALUES (N'SP06', N'Nước ép cam', N'L04', 33000, 88, N'nuocep.jpg', N'CD04', 30000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoai], [GiaBan], [SoLuong], [HinhAnh], [MaCongDung], [GiaNhap]) VALUES (N'SP07', N'Nước suối', N'L05', 5500, 208, N'nuocsuoi.jpg', N'CD05', 5000)
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD FOREIGN KEY([MaDonNhap])
REFERENCES [dbo].[HoaDonNhap] ([MaDonNhap])
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaKhachH__5BE2A6F2] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaKhachH__5BE2A6F2]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaQue])
REFERENCES [dbo].[Que] ([MaQue])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_CongDung] FOREIGN KEY([MaCongDung])
REFERENCES [dbo].[CongDung] ([MaCongDung])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_CongDung]
GO
USE [master]
GO
ALTER DATABASE [QLCafe] SET  READ_WRITE 
GO

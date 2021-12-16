CREATE DATABASE [QUANLYTRASUA]
GO

USE [QUANLYTRASUA]
GO

--TẠO CÁC BẢNG
CREATE TABLE TaiKhoan
(
	TenTaiKhoan		NVARCHAR(100) PRIMARY KEY,
	MatKhau			NVARCHAR(100) NOT NULL,
	HoTen			NVARCHAR (1000) NOT NULL,
	Email			NVARCHAR (100),
	SoDienThoai		NVARCHAR (100) NOT NULL,
	NgayTao			SMALLDATETIME NOT NULL
)

CREATE TABLE ChucVu
(
	MaCV			INT IDENTITY (1,1) PRIMARY KEY,
	TenChucVu		NVARCHAR(200) NOT NULL,
	GhiChu			NVARCHAR(1000)
)

CREATE TABLE NhanVien
(
	MaNV			NVARCHAR(20) PRIMARY KEY,
	HoTen			NVARCHAR(100) NOT NULL,
	DiaChi			NVARCHAR(50),
	GioiTinh		NVARCHAR(10) CHECK(GioiTinh = N'Nam' OR GioiTinh = N'Nữ'),
	NgaySinh		DATETIME NOT NULL,
	SoDienThoai		NVARCHAR(100) NOT NULL,
	TenTaiKhoan		NVARCHAR(100) REFERENCES TaiKhoan(TenTaiKhoan),
	TrangThai		BIT NOT NULL,
	MaCV			INT REFERENCES ChucVu(MaCV)
)

CREATE TABLE Ban
(
	MaBan			INT IDENTITY (1,1) PRIMARY KEY,
	TenBan			NVARCHAR(100) NOT NULL,
	TrangThaiBan	BIT NOT NULL
)

CREATE TABLE HoaDon
(
	MaHoaDon		INT IDENTITY (1,1) PRIMARY KEY,
	TenHoaDon		NVARCHAR(200) NOT NULL,
	MaBan			INT REFERENCES Ban(MaBan),
	TongTien		INT NOT NULL,
	GiamGia			FLOAT NOT NULL,
	Thue			FLOAT NOT NULL,
	TrangThaiHD		INT NOT NULL,
	NgayTao			DATETIME NOT NULL,
	TaiKhoanTao		NVARCHAR(100) REFERENCES TaiKhoan(TenTaiKhoan)
)

CREATE TABLE ChiTietHoaDon
(
	MaChiTietHoaDon	INT IDENTITY (1,1) PRIMARY KEY,
	MaHoaDon		INT REFERENCES HoaDon(MaHoaDon),
	MaNuocUong		INT REFERENCES NuocUong(MaNuocUong),
	SoLuong			INT
)

CREATE TABLE LoaiNuoc
(
	MaLoai			INT IDENTITY (1,1) PRIMARY KEY,
	TenLoai			NVARCHAR(100) NOT NULL,
)

CREATE TABLE NuocUong
(
	MaNuocUong		INT IDENTITY (1,1) PRIMARY KEY,
	TenNuocUong		NVARCHAR(200) NOT NULL,
	MaLoai			INT REFERENCES LoaiNuoc(MaLoai),
	DonGia			INT NOT NULL,
	DonViTinh		NVARCHAR(100) NOT NULL
)

--Thêm dữ liệu
SET DATEFORMAT dmy
INSERT [TaiKhoan] ([TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao]) VALUES (N'gominn',		N'gominn',		N'Nguyễn Việt Duy Danh',	N'duydanh16042019@gmail.com',	'0917291154', '20/11/2021')
INSERT [TaiKhoan] ([TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao]) VALUES (N'qngtuann',	N'qngtuann',	N'Trương Quang Tuấn',		N'quangtuan2402@gmail.com',		'0334502288', '20/11/2021')
INSERT [TaiKhoan] ([TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao]) VALUES (N'qngbao',		N'qngbao',		N'Nguyễn Trần Quang Bảo',	N'quangbao@gmail.com',			'0987654321', '20/11/2021')

SET IDENTITY_INSERT [ChucVu] ON 
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(1, N'Quản lý',				NULL)
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(2, N'Nhân viên phục vụ',	NULL)
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(3, N'Nhân viên pha chế',	NULL)

INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [TenTaiKhoan], [TrangThai], [MaCV]) VALUES (1,	N'Nguyễn Việt Duy Danh',	'Nam',	N'Đà Lạt',	'21/12/2001', '0917291154',	'gominn',	1,	2)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [TenTaiKhoan], [TrangThai], [MaCV]) VALUES (2,	N'Nguyễn Trần Quang Bảo',	'Nam',	N'Đà Lạt',	'03/10/2001', '0987654321',	'qngbao',	1,	3)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [TenTaiKhoan], [TrangThai], [MaCV]) VALUES (3,	N'Nguyễn Việt Duy Danh',	'Nam',	N'Đà Lạt',	'21/12/2001', '0917291154',	'gominn',	0,	2)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [TenTaiKhoan], [TrangThai], [MaCV]) VALUES (4,	N'Trương Quang Tuấn',		'Nam',	N'Đà Lạt',	'24/02/2001', '0334502288',	'qngtuann',	1,	1)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [TenTaiKhoan], [TrangThai], [MaCV]) VALUES (5,	N'Nguyễn Trần Quang Bảo',	'Nam',	N'Đà Lạt',	'03/10/2001', '0987654321',	'qngbao',	0,	3)

SET IDENTITY_INSERT [ChucVu] OFF
SET IDENTITY_INSERT [Ban] ON 
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (1, N'01', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (2, N'02', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (3, N'03', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (4, N'04', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (5, N'05', 0)

SET DATEFORMAT dmy
SET IDENTITY_INSERT [Ban] OFF
SET IDENTITY_INSERT [HoaDon] ON 
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (1, N'Hóa đơn thanh toán', 1, 150000, 0.05, 0.1, 1, '20/11/2021', 'gominn')
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (2, N'Hóa đơn thanh toán', 1, 300000, 0.05, 0.1, 1, '20/11/2021', 'gominn')
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (3, N'Hóa đơn thanh toán', 4, 700000, 0.05, 0.1, 1, '20/11/2021', 'gominn')
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (4, N'Hóa đơn thanh toán', 5, 250000, 0.05, 0.1, 1, '20/11/2021', 'gominn')
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (5, N'Hóa đơn thanh toán', 3, 75000,	0.05, 0.1, 1, '20/11/2021', 'gominn')
INSERT [HoaDon] ([MaHoaDon], [TenHoaDon], [MaBan], [TongTien], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [TaiKhoanTao]) VALUES (6, N'Hóa đơn thanh toán', 2, 500000, 0.05, 0.1, 1, '20/11/2021', 'gominn')

SET IDENTITY_INSERT [HoaDon] OFF
SET IDENTITY_INSERT [LoaiNuoc] ON 
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (1,N'Trà sữa')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (2,N'Sữa tươi')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (3,N'Trà')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (4,N'Cà phê')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (5,N'Nước ngọt')

SET IDENTITY_INSERT [ChiTietHoaDon] ON
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (1, 1, 12, 10)
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (2, 4, 1, 10)
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (3, 6, 5, 20)

SET IDENTITY_INSERT [LoaiNuoc] OFF
SET IDENTITY_INSERT [NuocUong] ON 
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (1,  N'Trà sữa truyền thống',			1, 25000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (2,  N'Trà sữa khoai môn dẻo',			1, 30000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (3,  N'Trà sữa sốt dưa lưới',			1, 30000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (4,  N'Trà sữa bạc hà dưa lưới',		1, 30000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (5,  N'Sữa tươi trân châu đường đen',	2, 25000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (6,  N'Trà đào',						3, 20000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (7,  N'Trà vải',						3, 20000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (8,  N'Cà phê sữa đá',					4, 12000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (9,  N'Cà phê sữa nóng',				4, 12000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (10, N'Cà phê đen đá',					4, 12000, N'Ly')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (11, N'Sting',							5, 10000, N'Chai')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (12, N'Bò húc',							5, 15000, N'Lon')
INSERT [NuocUong] ([MaNuocUong], [TenNuocUong], [MaLoai], [DonGia], [DonViTinh]) VALUES (13, N'Coca-cola',						5, 10000, N'Chai')

CREATE DATABASE [QUANLYTRASUA]
GO
USE [QUANLYTRASUA]
GO


--TẠO CÁC BẢNG
CREATE TABLE ChucVu
(
	MaCV			INT IDENTITY (1,1) PRIMARY KEY,
	TenChucVu		NVARCHAR(200) NOT NULL,
	GhiChu			NVARCHAR(1000)
)

CREATE TABLE TaiKhoan
(
	MaTK			INT IDENTITY PRIMARY KEY,
	TenTaiKhoan		NVARCHAR(100),
	MatKhau			NVARCHAR(100) NOT NULL,
	HoTen			NVARCHAR (1000) NOT NULL,
	Email			NVARCHAR (100),
	SoDienThoai		NVARCHAR (100) NOT NULL,
	NgayTao			SMALLDATETIME NOT NULL,
	MaCV			INT REFERENCES ChucVu(MaCV)
)

select MaCV from Dbo.TaiKhoan


CREATE TABLE NhanVien
(
	MaNV			NVARCHAR(20) PRIMARY KEY,
	HoTen			NVARCHAR(100) NOT NULL,
	DiaChi			NVARCHAR(50),
	GioiTinh		NVARCHAR(10) CHECK(GioiTinh = N'Nam' OR GioiTinh = N'Nữ'),
	NgaySinh		DATETIME NOT NULL,
	SoDienThoai		NVARCHAR(100) NOT NULL,
	MaTK		int references TaiKhoan(MaTK),
	TrangThai		BIT NOT NULL
)

CREATE TABLE Ban
(
	MaBan			INT IDENTITY (1,1) PRIMARY KEY,
	TenBan			NVARCHAR(100) NOT NULL,
	TrangThaiBan	INT NOT NULL DEFAULT 0
)

CREATE TABLE HoaDon
(
	MaHoaDon		INT IDENTITY (1,1) PRIMARY KEY,
	GiamGia			FLOAT NOT NULL,
	Thue			FLOAT NOT NULL,
	TrangThaiHD		INT NOT NULL,
	NgayTao			DATETIME,
	NgayThanhToan	DATETIME,
	MaBan			INT REFERENCES Ban(MaBan),
	TaiKhoanTao		INT REFERENCES TaiKhoan(MaTK)
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

CREATE TABLE ChiTietHoaDon
(
	MaChiTietHoaDon	INT IDENTITY (1,1) PRIMARY KEY,
	MaHoaDon		INT REFERENCES HoaDon(MaHoaDon),
	MaNuocUong		INT REFERENCES NuocUong(MaNuocUong),
	SoLuong			INT
)



--MaTK			INT IDENTITY PRIMARY KEY,
--	TenTaiKhoan		NVARCHAR(100),
--	MatKhau			NVARCHAR(100) NOT NULL,
--	HoTen			NVARCHAR (1000) NOT NULL,
--	Email			NVARCHAR (100),
--	SoDienThoai		NVARCHAR (100) NOT NULL,
--	NgayTao			SMALLDATETIME NOT NULL
--Thêm dữ liệu
SET IDENTITY_INSERT [ChucVu] on 
--SET IDENTITY_INSERT [TaiKhoan] off
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(1, N'Quản lý',				NULL)
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(2, N'Nhân viên phục vụ',	NULL)
INSERT [ChucVu]	([MaCV], [TenChucVu], [GhiChu])	VALUES	(3, N'Nhân viên pha chế',	NULL)
SET IDENTITY_INSERT [ChucVu] OFF

SET IDENTITY_INSERT [TaiKhoan] ON 
SET DATEFORMAT dmy
INSERT [TaiKhoan] ([MaTK],[TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao], [MaCV]) VALUES (1,N'gominn',N'gominn',N'Nguyễn Việt Duy Danh',	N'duydanh16042019@gmail.com',	'0917291154', '20/11/2021',2)
INSERT [TaiKhoan] ([MaTK],[TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao], [MaCV]) VALUES (2,N'qngtuann',	N'qngtuann',	N'Trương Quang Tuấn',		N'quangtuan2402@gmail.com',		'0334502288', '20/11/2021',1)
INSERT [TaiKhoan] ([MaTK],[TenTaiKhoan], [MatKhau], [HoTen], [Email], [SoDienThoai], [NgayTao], [MaCV]) VALUES (3,N'qngbao',		N'qngbao',		N'Nguyễn Trần Quang Bảo',	N'quangbao@gmail.com',			'0987654321', '20/11/2021',3)


INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [MaTK], [TrangThai]) VALUES (1,	N'Nguyễn Việt Duy Danh',	'Nam',	N'Đà Lạt',	'21/12/2001', '0917291154',	1,	1)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [MaTK], [TrangThai]) VALUES (2,	N'Nguyễn Trần Quang Bảo',	'Nam',	N'Đà Lạt',	'03/10/2001', '0987654321',	3,	1)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [MaTK], [TrangThai]) VALUES (3,	N'Nguyễn Việt Duy Danh',	'Nam',	N'Đà Lạt',	'21/12/2001', '0917291154',	1,	0)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [MaTK], [TrangThai]) VALUES (4,	N'Trương Quang Tuấn',		'Nam',	N'Đà Lạt',	'24/02/2001', '0334502288',	2,	1)
INSERT [NhanVien] ([MaNV], [HoTen], [GioiTinh], [DiaChi], [NgaySinh], [SoDienThoai], [MaTK], [TrangThai]) VALUES (5,	N'Nguyễn Trần Quang Bảo',	'Nam',	N'Đà Lạt',	'03/10/2001', '0987654321',	3,	0)
SET IDENTITY_INSERT [TaiKhoan] OFF 
SET IDENTITY_INSERT [Ban] ON 
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (1, N'Bàn 1', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (2, N'Bàn 2', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (3, N'Bàn 3', 1)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (4, N'Bàn 4', 0)
INSERT [Ban] ([MaBan], [TenBan], [TrangThaiBan]) VALUES (5, N'Bàn 5', 0)
SET IDENTITY_INSERT [Ban] OFF

DECLARE @i INT = 6
WHILE @i <= 20
BEGIN
	INSERT [Ban] (TenBan) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
SELECT * FROM Ban

SET DATEFORMAT dmy
SET IDENTITY_INSERT [HoaDon] ON 
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (1, 5, 10, 0, '20/11/2021', NULL,			1, 1)
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (2, 5, 10, 0, '20/11/2021', NULL,			2, 1)
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (3, 5, 10, 1, '20/11/2021', '20/11/2021', 2, 1)
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (4, 5, 10, 1, '20/11/2021', '20/11/2021',	5, 1)
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (5, 5, 10, 0,	'20/11/2021', NULL,			3, 1)
INSERT [HoaDon] ([MaHoaDon], [GiamGia], [Thue], [TrangThaiHD], [NgayTao], [NgayThanhToan], [MaBan], [TaiKhoanTao]) VALUES (6, 5, 10, 0, '20/11/2021', NULL,			4, 1)
SET IDENTITY_INSERT [HoaDon] OFF

SET IDENTITY_INSERT [LoaiNuoc] ON 
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (1,N'Trà sữa')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (2,N'Sữa tươi')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (3,N'Trà')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (4,N'Cà phê')
INSERT [LoaiNuoc] ([MaLoai], [TenLoai]) VALUES (5,N'Nước ngọt')
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
SET IDENTITY_INSERT [NuocUong] OFF

SET IDENTITY_INSERT [ChiTietHoaDon] ON
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (1, 1, 12, 10)
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (2, 4, 1, 10)
INSERT [ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaNuocUong], [SoLuong]) VALUES (3, 6, 5, 20)
SET IDENTITY_INSERT [ChiTietHoaDon] OFF



--Khởi tạo PROC
CREATE PROC Table_GetAll
AS
	SELECT * FROM Ban
GO

Create procedure [dbo].[NuocUong_GetAll]
as
	select * from NuocUong
-----------------------------------------
-- thủ tục lấy bảng LoaiNuoc
Create procedure [LoaiNuoc_GetAll]
as
	select * from LoaiNuoc
-----------------------------------------
-- thủ tục thêm, xoá, sửa bảng LoaiNuoc
create PROCEDURE [dbo].[LoaiNuoc_InsertUpdateDelete]
 @MaLoai int output,
 @TenLoai nvarchar(100),
 @Action int
AS
-- Nếu Action = 0, thực hiện thêm dữ liệu
IF @Action = 0
	BEGIN
	If not exists (select * from LoaiNuoc where TenLoai = @TenLoai)
		begin
			INSERT INTO [LoaiNuoc]([TenLoai])
			VALUES (@TenLoai)
			SET @MaLoai = @@identity -- Thiết lập ID tự tăng
		END
	end
-- Nếu Action = 1, thực hiện cập nhật dữ liệu
ELSE IF @Action = 1
	BEGIN
		UPDATE [LoaiNuoc] SET [TenLoai] = @TenLoai
		WHERE [MaLoai] = @MaLoai
	END
-- Nếu Action = 2, thực hiện xóa dữ liệu
ELSE IF @Action = 2
	BEGIN
		DELETE FROM [LoaiNuoc] WHERE [MaLoai] = @MaLoai
	END
-----------------------------------------
-- thủ tục thêm, xoá, sửa bảng NuocUong
CREATE PROCEDURE [dbo].[NuocUong_InsertUpdateDelete]
 @MaNuocUong int output,
 @TenNuocUong nvarchar(200),
 @MaLoai int,
 @DonGia int,
 @DonViTinh nvarchar(100),
 @Action int
AS
-- Nếu Action = 0, thực hiện thêm dữ liệu
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
	BEGIN
		If not exists (select * from NuocUong where TenNuocUong = @TenNuocUong)
		begin
			INSERT INTO [NuocUong] ([TenNuocUong],[MaLoai],[DonGia],[DonViTinh])
			VALUES ( @TenNuocUong, @MaLoai, @DonGia, @DonViTinh)
			SET @MaNuocUong = @@identity -- Thiết lập ID tự tăng
		END	
	end
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
	BEGIN
		UPDATE [NuocUong]
		SET [TenNuocUong] = @TenNuocUong,
			[MaLoai]=@MaLoai,
			[DonGia]=@DonGia,
			[DonViTinh]=@DonViTinh
		WHERE [MaNuocUong] = @MaNuocUong
	END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
	BEGIN
		DELETE FROM [NuocUong] WHERE [MaNuocUong] = @MaNuocUong
	END

-----------------------------------------
-- tìm kiếm theo tên bảng NuocUong
create procedure [dbo].[NuocUong_TimTheoTen]
 @TenNuocUong nvarchar(200)
As
	Begin
		select * from NuocUong where TenNuocUong = '%' + @TenNuocUong + '%'
	End

-------------------------
CREATE PROCEDURE [GetUncheckBillIdByTableId]
	@maBan INT
AS
BEGIN
	SELECT * FROM [HoaDon] WHERE MaBan = @maBan AND TrangThaiHD = 0
END
GO

CREATE PROCEDURE [GetListDrinkDetailsByTableId]
	@maBan INT
AS
BEGIN
	SELECT NU.TenNuocUong, CTHD.SoLuong, NU.DonGia, (CTHD.SoLuong * NU.DonGia) AS ThanhTien
	FROM HoaDon AS HD, ChiTietHoaDon AS CTHD, NuocUong AS NU
	WHERE CTHD.MaHoaDon = HD.MaHoaDon AND CTHD.MaNuocUong = Nu.MaNuocUong AND HD.TrangThaiHD = 0 AND HD.MaBan = @maBan
END
GO

--lấy bảng tài khoản

----
create procedure [dbo].[TaiKhoan_GetAll]
as
SELECT * from [dbo].[TaiKhoan]

------------------------------------------
--thêm xoá sửa bảng tài khoản
Create procedure [dbo].[TaiKhoan_InsertDeleteUpdate]
@tenTaiKhoan nvarchar(100) output,
@matKhau nvarchar(100),
@hoTen nvarchar(1000),
@email	nvarchar(100),
@soDienThoai nvarchar(100),
@ngayTao SMALLDATETIME,
@Action int
as
if @Action=0
begin
	INSERT into [TaiKhoan]([TenTaiKhoan],[MatKhau],[HoTen],[Email],[SoDienThoai],[NgayTao])
	VALUES (@tenTaiKhoan,@matKhau,@hoTen,@email,@soDienThoai,@ngayTao)
	end
ELSE if @Action=1
begin 
	UPDATE [TaiKhoan]
	SET [TenTaiKhoan]=@tenTaiKhoan,[MatKhau]=@matKhau,[HoTen]=@hoTen,[Email]=email,[SoDienThoai]=@soDienThoai,[NgayTao]=@ngayTao
	WHERE [TenTaiKhoan]=@tenTaiKhoan
	end
ELSE if @Action=2
begin 
	DELETE from [TaiKhoan] WHERE [TenTaiKhoan]=@tenTaiKhoan
end
-------------------------phan quyen-----------------

create procedure [dbo].[ChucVu_GetALl]
as
select * from dbo.ChucVu
go

--select TaiKhoan.TenTaiKhoan as TenDN, TaiKhoan.MatKhau as mk, NhanVien.HoTen , ChucVu.MaCV from TaiKhoan
--inner join 

--create procedure [dbo].[PhanQuyen_GetAll]
--@maTK
--as
--select a.TenTaiKhoan, a.MatKhau , b.HoTen , c.TenChucVu from TaiKhoan a,NhanVien b,ChucVu c
--where a.MaTK=b.MaTK and c.MaCV=b.MaCV
--go
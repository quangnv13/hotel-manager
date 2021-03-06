CREATE DATABASE QLKS_test


CREATE TABLE dbo.tblnhanvien(
	manv NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	tennv NVARCHAR (50),
	gioitinh NVARCHAR (3),
	ngaysinh DATE,
	sdt NVARCHAR (50),
	diachi NVARCHAR (50),
	chucvu NVARCHAR (50))

CREATE TABLE dbo.tbluser(
	username NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	manv NVARCHAR (50) NOT NULL FOREIGN  KEY  REFERENCES  tblnhanvien(manv) ON DELETE CASCADE ON UPDATE CASCADE,
	password NVARCHAR (50) NOT NULL,
	permission NVARCHAR (50))


CREATE TABLE dbo.tblkhachhang(
	makh NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	tenkh NVARCHAR (50),
	gioitinh NVARCHAR (3),
	ngaysinh DATE,
	cmnd NVARCHAR (50),
	diachi NVARCHAR (50),
	sdt NVARCHAR (50),
	ghichu NVARCHAR (50))

CREATE TABLE dbo.tblloaiphong(
	maloai NVARCHAR(50) NOT NULL primary KEY ,
	gia INT NOT NULL)


CREATE TABLE dbo.tblphong(
	maphong NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	maloai NVARCHAR (50) NOT NULL FOREIGN  KEY  REFERENCES  tblloaiphong(maloai) ON DELETE CASCADE ON UPDATE CASCADE)


CREATE TABLE dbo.tbltrangthaiphong(
	maphong NVARCHAR (50) NOT NULL FOREIGN  KEY  REFERENCES  tblphong(maphong) ON DELETE CASCADE ON UPDATE CASCADE,
	trangthai NVARCHAR (50) NOT NULL)


CREATE TABLE dbo.tbldatphong(
	mapd NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	maphong NVARCHAR (50) NOT NULL FOREIGN  KEY  REFERENCES  tblphong(maphong) ON DELETE CASCADE ON UPDATE CASCADE)

CREATE TABLE dbo.tblctdatphong(
	mapd NVARCHAR (50) NOT NULL,
	makh NVARCHAR (50) NOT NULL,
	ngayden DATE,
	ngaydi DATE,
	tongtiendat INT,
	username NVARCHAR(50),
	trangthai NVARCHAR(50) NOT NULL DEFAULT N'Chưa nhận',
	CONSTRAINT  pk_ctdatphong1 FOREIGN KEY (mapd) REFERENCES dbo.tbldatphong(mapd) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT  pk_ctdatphong2 FOREIGN KEY (makh) REFERENCES dbo.tblkhachhang(makh) ON DELETE CASCADE ON UPDATE CASCADE)


CREATE TABLE dbo.tbldichvu(
	madv NVARCHAR (50) NOT NULL primary KEY ,
	tendv NVARCHAR (50),
	gia INT,
	donvitinh NVARCHAR(50) )


CREATE TABLE dbo.tbldichvuthem(
	mapd NVARCHAR(50) FOREIGN KEY REFERENCES dbo.tbldatphong(mapd) ON DELETE CASCADE ON UPDATE CASCADE,
	madv NVARCHAR(50) FOREIGN KEY REFERENCES dbo.tbldichvu(madv) ON DELETE CASCADE ON UPDATE CASCADE,
	soluong INT,
	tongtiendv INT)

CREATE FUNCTION AUTO_IDBILL()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(mahd) FROM dbo.tblhoadon) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(mahd, 3)) FROM dbo.tblhoadon
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE dbo.tblhoadon(
	mahd NVARCHAR(5) PRIMARY KEY CONSTRAINT mahd DEFAULT DBO.AUTO_IDBILL(),
	tongtien INT,
	ngaythanhtoan DATE DEFAULT GETDATE(),
	mapd NVARCHAR (50) NOT NULL,
	makh NVARCHAR (50) NOT NULL,
	manv NVARCHAR (50) NOT NULL,
	tinhtrang NVARCHAR(50) NOT NULL DEFAULT 'Chưa thanh toán',
	CONSTRAINT  pk_hd1 FOREIGN KEY (mapd) REFERENCES dbo.tbldatphong(mapd) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT  pk_hd2 FOREIGN KEY (manv) REFERENCES dbo.tblnhanvien(manv) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT  pk_hd3 FOREIGN KEY (makh) REFERENCES dbo.tblkhachhang(makh) ON DELETE CASCADE ON  UPDATE CASCADE)

CREATE TABLE dbo.tblvattu(
	mavattu NVARCHAR (50) NOT NULL PRIMARY  KEY ,
	tenvattu NVARCHAR (50))

CREATE TABLE dbo.tblctvattu(
	mavattu NVARCHAR (50) NOT NULL,
	maloai NVARCHAR (50),
	soluong INT,
	CONSTRAINT pk_vattu1 FOREIGN KEY (mavattu) REFERENCES dbo.tblvattu(mavattu) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT pk_vattu2 FOREIGN KEY (maloai) REFERENCES dbo.tblloaiphong(maloai) ON DELETE CASCADE ON UPDATE CASCADE)








---Test query---
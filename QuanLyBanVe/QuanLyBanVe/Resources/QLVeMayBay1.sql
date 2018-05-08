﻿CREATE DATABASE QLVeMayBay
USE QLVeMayBay

SET DATEFORMAT mdy
CREATE TABLE KHACHHANG
(
	MAKH CHAR(5) PRIMARY KEY,
	HOTEN NVARCHAR(50),
	TUOI INT,
	GIOITINH BIT,
	CMND CHAR(15),
	DIACHI NVARCHAR(50),
	SDT CHAR(15),
)
CREATE TABLE HANGHK
(
	MAHHK CHAR(5) PRIMARY KEY,
	TENHHK NVARCHAR(30),
)
CREATE TABLE SANBAY
(
	MASB CHAR(5) PRIMARY KEY,
	TENSANBAY NVARCHAR(40),
)
CREATE TABLE CHUYENBAY
(
	MACB CHAR(5) PRIMARY KEY,
	MASBDI CHAR(5),
	MASBDEN CHAR(5),
	MAHHK CHAR(5),	
	THOIGIANKHOIHANH SMALLDATETIME,
	THOIGIANDEN SMALLDATETIME,
	SOGHEHANG1 INT,
	SOGHEHANG2 INT,
	GIAVE INT
)

CREATE TABLE HANGVE
(
	MAHV CHAR(5) PRIMARY KEY,
	TENHANGVE NVARCHAR(20),
)
CREATE TABLE TINHTRANG
(
	MATT CHAR(5) PRIMARY KEY,
	TENTINHTRANG NVARCHAR(10),
)
CREATE TABLE VE
(
	MAVE CHAR(5) PRIMARY KEY,
	MACB CHAR(5),
	MAHHK CHAR(5),
	MAHV CHAR(5),
	GIATIEN INT,	
	MATT CHAR(5),
)

CREATE TABLE CHITIETCB
(
	MACB CHAR(5) PRIMARY KEY,
	MASBTG CHAR(5),
	THOIGIANDUNG INT,
	GHICHU NVARCHAR(20),
)
CREATE TABLE PHIEUDATMUA
(	
	MAVE CHAR(5),
	MAKH CHAR(5),
	THOIGIANDAT SMALLDATETIME,
	DATHANHTOAN BIT
	PRIMARY KEY (MAVE, MAKH)
)
CREATE TABLE THAMSO
(
	MATS CHAR(5),
	NGAYAPDUNG SMALLDATETIME,
	TENTS NVARCHAR(20),
	GIATRI INT,
)

CREATE PROCEDURE TaoThanhVien
	@MaKH char(5),
	@HoTen NVARCHAR(50),
	@Tuoi INT,
	@GioiTinh BIT,
	@CMND CHAR(15),
	@DiaChi NVARCHAR(50),
	@SDT CHAR(15)
AS
BEGIN
	INSERT INTO KHACHHANG(MaKH, HoTen,Tuoi,GioiTinh,CMND,DiaChi, SDT)
	VALUES (@MaKH, @HoTen,@Tuoi,@GioiTinh,@CMND,@DiaChi, @SDT);
END

CREATE PROCEDURE SuaCB
	@MaCB char(5),
	@MaSBDi nvarchar(40),
	@MaSBDen nvarCHAR(40),
	@MaHHK nvarCHAR(20),
	@ThoiGianKhoiHanh smalldatetime,
	@ThoiGianDen smalldatetime,
	@SoGheHang1 INT,
	@SoGheHang2 INT,
	@GiaVe INT
AS
BEGIN
	UPDATE CHUYENBAY
	SET
	MaSBDi = (SELECT MASB
		FROM SANBAY
		WHERE SANBAY.TENSANBAY = @MaSBDi),
	MASBDEN = (SELECT MASB
		FROM SANBAY
		WHERE SANBAY.TENSANBAY = @MaSBDen),
	MAHHK = (SELECT MAHHK
		FROM HANGHK
		WHERE TENHHK = @MaHHK),
	THOIGIANKHOIHANH = @ThoiGianKhoiHanh,
	THOIGIANDEN = @ThoiGianDen,
	SOGHEHANG1 = @SoGheHang1,
	SOGHEHANG2 = @SoGheHang2,
	GIAVE = @GiaVe
	WHERE MACB = @MaCB;
END

CREATE PROCEDURE XoaChuyenBay
	@MaCB char(5)
AS
BEGIN
	DELETE FROM CHUYENBAY WHERE MACB = @MaCB;
END

CREATE PROCEDURE UpdateTinhTrangVe
	@MaTT char(5),
	@MaVe char(5)
AS
BEGIN
	UPDATE VE
	SET MATT = @MaTT
	WHERE MAVE = @MaVe
END

CREATE PROCEDURE TaoPhieuDatMua	
	@MaVe CHAR(5),
	@MaKH CHAR(5),
	@ThoiGianDat SMALLDATETIME
AS
BEGIN
	INSERT INTO PHIEUDATMUA
	VALUES (@MaVe, @MaKH, @ThoiGianDat, 1)
END

CREATE PROCEDURE LietKeCB
AS
BEGIN
	SELECT distinct CB.MACB, A.[SÂN BAY ĐI] AS 'SÂN BAY ĐI', B.[SÂN BAY ĐẾN] AS 'SÂN BAY ĐẾN', 
		HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', THOIGIANKHOIHANH AS'THỜI GIAN KHỞI HÀNH', THOIGIANDEN AS 'THỜI GIAN ĐẾN', 
		CB.SOGHEHANG1 AS 'SỐ GHẾ HẠNG 1', CB.SOGHEHANG2 AS'SỐ GHẾ HẠNG 2', CB.GIAVE AS'GIÁ VÉ'
	FROM 
	(SELECT CB.MASBDI, SB.TENSANBAY AS'SÂN BAY ĐI' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDI = SB.MASB) AS A
	INNER JOIN 	CHUYENBAY CB ON A.MASBDI = CB.MASBDI INNER JOIN
	(SELECT CB.MASBDEN, SB.TENSANBAY AS'SÂN BAY ĐẾN' FROM SANBAY SB 
	INNER JOIN CHUYENBAY CB ON CB.MASBDEN = SB.MASB) AS B ON CB.MASBDEN = B.MASBDEN
	INNER JOIN HANGHK HHK ON CB.MAHHK = HHK.MAHHK
END

CREATE PROCEDURE ThemCB
	@MaCB char(5),
	@MaSBDi nvarCHAR(40),
	@MaSBDen nvarCHAR(40),
	@MaHHK nvarCHAR(20),
	@ThoiGianKhoiHanh SMALLDATETIME,
	@ThoiGianDen SMALLDATETIME,
	@SoGheHang1 INT,
	@SoGheHang2 INT,
	@GiaVe INT
AS
BEGIN
	INSERT INTO CHUYENBAY(MACB,MASBDI,MASBDEN,MAHHK,THOIGIANKHOIHANH,THOIGIANDEN,SOGHEHANG1,SOGHEHANG2,GIAVE)
	VALUES (@MaCB, (SELECT MASB FROM SANBAY WHERE TENSANBAY = @MaSBDi),
		(SELECT MASB FROM SANBAY WHERE TENSANBAY = @MaSBDen),
		(SELECT MAHHK FROM HANGHK WHERE TENHHK = @MaHHK), @ThoiGianKhoiHanh,
		@ThoiGianDen, @SoGheHang1, @SoGheHang2, @GiaVe)
END

CREATE PROCEDURE TraCuu
	@MaSBDi nvarchar(40),
	@MaSBDen nvarchar(40),
	@ThoiGianBay datetime
AS
BEGIN
	SELECT distinct CB.MACB, A.[SÂN BAY ĐI] AS 'SÂN BAY ĐI', B.[SÂN BAY ĐẾN] AS 'SÂN BAY ĐẾN', 
		HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', THOIGIANKHOIHANH AS'THỜI GIAN KHỞI HÀNH', THOIGIANDEN AS 'THỜI GIAN ĐẾN', 
		CB.SOGHEHANG1 AS 'SỐ GHẾ HẠNG 1', CB.SOGHEHANG2 AS'SỐ GHẾ HẠNG 2', CB.GIAVE AS'GIÁ VÉ'
	FROM 
	(SELECT CB.MASBDI, SB.TENSANBAY AS'SÂN BAY ĐI' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDI = SB.MASB) AS A
	INNER JOIN 	CHUYENBAY CB ON A.MASBDI = CB.MASBDI INNER JOIN
	(SELECT CB.MASBDEN, SB.TENSANBAY AS'SÂN BAY ĐẾN' FROM SANBAY SB 
	INNER JOIN CHUYENBAY CB ON CB.MASBDEN = SB.MASB) AS B ON CB.MASBDEN = B.MASBDEN
	INNER JOIN HANGHK HHK ON CB.MAHHK = HHK.MAHHK
WHERE a.[SÂN BAY ĐI] = @MaSBDi AND b.[SÂN BAY ĐẾN] = @MaSBDen AND 
		convert (date, CB.THOIGIANKHOIHANH) = @ThoiGianBay
END

CREATE PROCEDURE LietKeVe
AS
BEGIN
	SELECT DISTINCT VE.MAVE, VE.MACB,HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', HV.TENHANGVE AS 'HẠNG VÉ',
	VE.GIATIEN AS 'GIÁ TIỀN', TT.TENTINHTRANG AS 'TÌNH TRẠNG'
	FROM VE INNER JOIN HANGHK HHK ON VE.MAHHK = HHK.MAHHK
	INNER JOIN TINHTRANG TT ON VE.MATT = TT.MATT
	INNER JOIN HANGVE HV ON HV.MAHV = VE.MAHV
END

CREATE PROCEDURE ChonHangVe
	@TenHangVe nvarchar(8)
AS
BEGIN
	SELECT DISTINCT VE.MAVE, VE.MACB,HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', HV.TENHANGVE AS 'HẠNG VÉ',
	VE.GIATIEN AS 'GIÁ TIỀN', TT.TENTINHTRANG AS 'TÌNH TRẠNG'
	FROM VE INNER JOIN HANGHK HHK ON VE.MAHHK = HHK.MAHHK
	INNER JOIN TINHTRANG TT ON VE.MATT = TT.MATT
	INNER JOIN HANGVE HV ON HV.MAHV = VE.MAHV
	WHERE HV.TENHANGVE = @TenHangVe
END

CREATE PROCEDURE LoadSanBay
	@MaSB char(5)
AS
BEGIN
	SELECT TENSANBAY
	FROM SANBAY 
	WHERE MASB = @MaSB
END

CREATE DATABASE QLVeMayBay
USE QLVeMayBay

SET DATEFORMAT dmy


-----------------------------------------
----------- Tao Bang-------------
CREATE TABLE KHACHHANG
(
	MAKH CHAR(5) PRIMARY KEY,
	HOTEN NVARCHAR(50),
	NAMSINH INT,
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
Create Table QUYDINH
(
	MaQuyDinh varchar(50),
	TenQuyDinh nvarchar(100),
	GiaTri int,
	NgayApDung smalldatetime
	Primary key (MaQuyDinh, NgayApDung)
)



-------------------------------------------
------------ Insert Du lieu -----------
Insert into HANGVE Values
('HV001', N'Vé hạng 1'),
('HV002', N'Vé hạng 2')

Insert into CHITIETCB Values
('CB01', 'SB02', 15, Null),
('CB02', 'SB01', 20, Null),
('CB03', 'SB02', 35, Null)

Insert into HANGHK Values
('HHK01', 'VietNam Airline'),
('HHK02', 'Jetstar'),
('HHK03','VASCO'),
('HHK04','Jetstar Pacific Airlines')

Insert into CHUYENBAY Values
('CB000', 'SB01', 'SB02', 'HHK01', '3/5/2018 09:00:00', '3/5/2018 12:00:00', 10, 10, 100000),
('CB001', 'SB03', 'SB02', 'HHK02', '4/5/2018 13:15:00', '4/5/2018 16:30:00', 20, 20, 200000),
('CB002', 'SB01', 'SB03', 'HHK01', '15/5/2018 03:00:00', '5/5/2018 08:10:00', 15, 15, 150000)

Insert into KHACHHANG Values
('KH000', N'Nguyễn Văn A', 1998, 1, '2778194257', 'TPHCM', '0987234612'),
('KH001', N'Trần Thị B', 1988, 0, '273278135', N'Bình Dương', '0917246182'),
('KH002', N'Lê Văn C', 1978, 1, '253261268', N'Đồng Nai', '0982612341'),
('KH003', N'Võ Thanh Minh', 1968, 1, '215467289', 'BR-VT', '0643265172')

Insert into SANBAY Values
('SB01', N'Đà Nẵng'),
('SB02', N'HCM'),
('SB03', N'Hà Nội')

Insert into TINHTRANG Values
('TT000', N'Còn trống'),
('TT001', N'Đã bán'),
('TT002', N'Đã đặt')

Insert into VE Values
('VE101', 'CB000', 'HHK01', 'HV001', 1005000, 'TT000'),
('VE102', 'CB001', 'HHK01', 'HV002', 1000000, 'TT000'),
('VE103', 'CB001', 'HHK01', 'HV001', 1005000, 'TT000'),
('VE201', 'CB002', 'HHK03', 'HV001', 2100000, 'TT000'),
('VE202', 'CB002', 'HHK03', 'HV001', 2100000, 'TT000'),
('VE203', 'CB002', 'HHK03', 'HV002', 2000000, 'TT000'),  
('VE301', 'CB003', 'HHK04', 'HV002', 1500000, 'TT001'),
('VE302', 'CB003', 'HHK04', 'HV001', 1575000, 'TT002')

Insert into PHIEUDATMUA Values
('VE301', 'KH000', '1/5/2018 08:00:00', 1),
('VE302', 'KH003', '28/4/2018 23:15:05', 0)

Insert into QuyDinh Values
('ThoiGianBayMin', N'Thời gian bay tối thiểu (phút)', 30, '12/6/2018'),
('SoSanBayTrungGianMax', N'Số sân bay trung gian tối đa', 2, '12/6/2018'),
('ThoiGianDungMin', N'Thời gian dừng sân bay trung gian tối thiểu (phút)', 10, '12/6/2018'),
('ThoiGianDungMax', N'Thời gian dừng sân bay trung gian tối đa (phút)', 20, '12/6/2018'),
('SoLuongHangVe', N'Số lượng hạng vé', 2, '12/6/2018'),
('GioiHanNgayDatVe', N'Số ngày đặt vé chậm nhất trước ngày khởi hành', 1, '12/06/2018')

--------------------------------------------
----------- Tao Procedure----------

---------- Procedure Khach --------
Create Function AutoID_KH()
	Returns varchar(5)
As
Begin	
	Declare @ID varchar(5)
	If (Select Count(MAKH) From KHACHHANG) = 0
		Begin
			Set @ID = 'KH000' 
		End		
	Else
		Begin
			Declare @tempID varchar(5)
			Select @tempID = Max(Right(MAKH, 3)) From KHACHHANG
			Select @ID = Case
				When @tempID + 1 <= 9 Then 'KH00' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 99 Then 'KH0' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 999 Then 'KH' + Convert(char, Convert(int, @tempID)+1)			
			End
		End
	Return @ID
End

CREATE PROCEDURE TaoThanhVien
	@HoTen NVARCHAR(50),
	@Tuoi INT,
	@GioiTinh BIT,
	@CMND CHAR(15),
	@DiaChi NVARCHAR(50),
	@SDT CHAR(15)
AS
BEGIN
	DECLARE @MaKH char(5)
	SELECT @MaKH = dbo.AutoID_KH()
	INSERT INTO KHACHHANG(MaKH, HoTen,NAMSINH,GioiTinh,CMND,DiaChi, SDT)
	VALUES (@MaKH, @HoTen,@Tuoi,@GioiTinh,@CMND,@DiaChi, @SDT)
END

-------- Procedure Chuyen bay ---------
CREATE PROCEDURE LietKeCB
AS
BEGIN
	SELECT distinct CB.MACB, A.[SÂN BAY ĐI] AS 'SÂN BAY ĐI', B.[SÂN BAY ĐẾN] AS 'SÂN BAY ĐẾN', 
		HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', THOIGIANKHOIHANH AS'THỜI GIAN KHỞI HÀNH', THOIGIANDEN AS 'THỜI GIAN ĐẾN', 
		CB.SOGHEHANG1 AS 'SỐ GHẾ HẠNG 1', CB.SOGHEHANG2 AS'SỐ GHẾ HẠNG 2', CB.GIAVE AS'GIÁ VÉ'
	FROM 
	(SELECT CB.MASBDI, SB.TENSANBAY AS 'SÂN BAY ĐI' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDI = SB.MASB) AS A
	INNER JOIN 	CHUYENBAY CB ON A.MASBDI = CB.MASBDI INNER JOIN
	(SELECT CB.MASBDEN, SB.TENSANBAY AS'SÂN BAY ĐẾN' FROM SANBAY SB 
	INNER JOIN CHUYENBAY CB ON CB.MASBDEN = SB.MASB) AS B ON CB.MASBDEN = B.MASBDEN
	INNER JOIN HANGHK HHK ON CB.MAHHK = HHK.MAHHK
	ORDER BY CB.MACB ASC
END

--------

Create Function AutoID_CB()
	Returns varchar(5)
As
Begin	
	Declare @ID varchar(5)
	If (Select Count(MACB) From CHUYENBAY) = 0
		Begin
			Set @ID = 'CB000' 
		End		
	Else
		Begin
			Declare @tempID varchar(5)
			Select @tempID = Max(Right(MACB, 3)) From CHUYENBAY
			Select @ID = Case
				When @tempID + 1 <= 9 Then 'CB00' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 99 Then 'CB0' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 999 Then 'CB' + Convert(char, Convert(int, @tempID)+1)			
			End
		End
	Return @ID
End

CREATE PROCEDURE ThemCB	
	@TenSBDi nvarCHAR(30),
	@TenSBDen nvarCHAR(30),
	@TenHHK nvarCHAR(30),
	@TenSBTG nvarCHAR(30),
	@ThoiGianDung int,
	@ThoiGianKhoiHanh SMALLDATETIME,
	@ThoiGianDen SMALLDATETIME,
	@SoGheHang1 INT,
	@SoGheHang2 INT,
	@GiaVe INT
AS
BEGIN
	DECLARE @MaCB char(5)
	SELECT @MaCB = dbo.AutoID_CB()

	INSERT INTO CHUYENBAY(MACB, MASBDI, MASBDEN, MAHHK, THOIGIANKHOIHANH,THOIGIANDEN, SOGHEHANG1, SOGHEHANG2, GIAVE)
	VALUES (@MaCB,
	(SELECT MASB FROM SANBAY WHERE TENSANBAY = @TenSBDi),
	(SELECT MASB FROM SANBAY WHERE TENSANBAY = @TenSBDen),
	(SELECT MAHHK FROM HANGHK WHERE TENHHK = @TenHHK),
	@ThoiGianKhoiHanh, @ThoiGianDen, @SoGheHang1, @SoGheHang2, @GiaVe)

	INSERT INTO CHITIETCB(MACB, MASBTG, THOIGIANDUNG, GHICHU)
	VALUES (@MaCB, (SELECT MASB FROM SANBAY WHERE TENSANBAY =@TenSBTG), @ThoiGianDung, NULL)
END


-----

CREATE PROCEDURE SuaCB
	@MaCB char(5),
	@TenSBDi nvarCHAR(30),
	@TenSBDen nvarCHAR(30),
	@TenHHK nvarCHAR(30),
	@TenSBTG nvarCHAR(30),
	@ThoiGianDung int,
	@ThoiGianKhoiHanh SMALLDATETIME,
	@ThoiGianDen SMALLDATETIME,
	@SoGheHang1 INT,
	@SoGheHang2 INT,
	@GiaVe INT
AS
BEGIN
	UPDATE CHUYENBAY
	SET
	MaSBDi = (SELECT MASB FROM SANBAY WHERE TENSANBAY = @TenSBDi),
	MASBDEN = (SELECT MASB FROM SANBAY WHERE TENSANBAY = @TenSBDen),
	MAHHK = (SELECT MAHHK FROM HANGHK WHERE TENHHK = @TenHHK),
	THOIGIANKHOIHANH = @ThoiGianKhoiHanh,
	THOIGIANDEN = @ThoiGianDen,
	SOGHEHANG1 = @SoGheHang1,
	SOGHEHANG2 = @SoGheHang2,
	GIAVE = @GiaVe
	WHERE MACB = @MaCB;

	UPDATE CHITIETCB
	SET
	MASBTG = (SELECT MASB FROM SANBAY WHERE TENSANBAY = @TenSBTG),
	THOIGIANDUNG = @ThoiGianDung
	WHERE MACB = @MaCB
END

------

CREATE PROCEDURE XoaCB
	@MaCB char(5)
AS
BEGIN
	DELETE FROM CHUYENBAY WHERE MACB = @MaCB;
	DELETE FROM CHUYENBAY WHERE MACB = @MaCB;
END

------

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

CREATE PROCEDURE ChiTietChuyenBay
	@MaCB char(5)
AS
BEGIN 
	SELECT distinct CB.MACB, A.[SÂN BAY ĐI] AS 'SÂN BAY ĐI', B.[SÂN BAY ĐẾN] AS 'SÂN BAY ĐẾN', 
		HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', THOIGIANKHOIHANH AS'THỜI GIAN KHỞI HÀNH', THOIGIANDEN AS 'THỜI GIAN ĐẾN', 
		D.[SÂN BAY TRUNG GIAN] AS'SÂN BAY TRUNG GIAN', D.THOIGIANDUNG AS 'THỜI GIAN DỪNG',
		CB.SOGHEHANG1 AS 'SỐ GHẾ HẠNG 1 (TRỐNG)', CB.SOGHEHANG2 AS'SỐ GHẾ HẠNG 2 (TRỐNG)', CB.GIAVE AS'GIÁ VÉ', D.GHICHU AS 'GHI CHÚ'
	FROM 
	(SELECT CB.MASBDI, SB.TENSANBAY AS 'SÂN BAY ĐI' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDI = SB.MASB) AS A
	INNER JOIN 	CHUYENBAY CB ON A.MASBDI = CB.MASBDI INNER JOIN
	(SELECT CB.MASBDEN, SB.TENSANBAY AS'SÂN BAY ĐẾN' FROM SANBAY SB 
	INNER JOIN CHUYENBAY CB ON CB.MASBDEN = SB.MASB) AS B ON CB.MASBDEN = B.MASBDEN
	INNER JOIN HANGHK HHK ON CB.MAHHK = HHK.MAHHK
	INNER JOIN (SELECT CT.MACB, C.[SÂN BAY TRUNG GIAN], CT.THOIGIANDUNG, CT.GHICHU
				FROM (SELECT CT.MASBTG, SB.TENSANBAY AS 'SÂN BAY TRUNG GIAN' FROM CHITIETCB CT 
				INNER JOIN SANBAY SB ON CT.MASBTG = SB.MASB) AS C INNER JOIN CHITIETCB CT ON CT.MASBTG = C.MASBTG)AS D
				ON D.MACB = CB.MACB
	WHERE CB.MACB = @MaCB
END

------------- Procedure Ve -----------
Create Function AutoID_VE()
	Returns varchar(5)
As
Begin	
	Declare @ID varchar(5)
	If (Select Count(MAVE) From VE) = 0
		Begin
			Set @ID = 'VE000' 
		End		
	Else
		Begin
			Declare @tempID varchar(5)
			Select @tempID = Max(Right(MAVE, 3)) From VE
			Select @ID = Case
				When @tempID + 1 <= 9 Then 'VE00' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 99 Then 'VE0' + Convert(char, Convert(int, @tempID)+1)
				When @tempID + 1 <= 999 Then 'VE' + Convert(char, Convert(int, @tempID)+1)			
			End
		End
	Return @ID
End

CREATE PROCEDURE ThemVe
	@MaCB char(5),
	@TenHHK nvarchar(30),
	@MaHV char(5),
	@GiaTien int,
	@MaTT char(5)
AS
BEGIN
	DECLARE @MaVe char(5)
	SELECT @MaVe = dbo.AutoID_VE()
	INSERT INTO VE(MAVE, MACB, MAHHK, MAHV, GIATIEN, MATT)
	VALUES (@MaVe, @MaCB, 
			(SELECT MAHHK FROM HANGHK WHERE HANGHK.TENHHK = @TenHHK),
			@MaHV, @GiaTien, @MaTT)
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

CREATE PROCEDURE CountVeHang1
	@MaCB char(5)
AS
BEGIN 
	SELECT COUNT(VE.MAVE) AS 'TONGSOVE'
	FROM VE INNER JOIN CHUYENBAY CB ON VE.MACB = CB.MACB
	WHERE VE.MAHV ='HV001' AND CB.MACB = @MaCB
	GROUP BY CB.MACB  
END

CREATE PROCEDURE CountVeHang2
	@MaCB char(5)
AS
BEGIN 
	SELECT COUNT(VE.MAVE) AS 'TONGSOVE'
	FROM VE INNER JOIN CHUYENBAY CB ON VE.MACB = CB.MACB
	WHERE VE.MAHV ='HV002' AND CB.MACB = @MaCB
	GROUP BY CB.MACB 
END

CREATE PROCEDURE VeHang1Trong
	@MaCB char(5)
AS
BEGIN
	SELECT CB.SOGHEHANG1 - A.[ĐÃ ĐẶT]
	FROM CHUYENBAY CB INNER JOIN 
		(SELECT CB.MACB, COUNT(VE.MAVE) AS 'ĐÃ ĐẶT'
		FROM VE INNER JOIN CHUYENBAY CB ON VE.MACB = CB.MACB
		INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
	WHERE VE.MAHV ='HV001'
	GROUP BY CB.MACB ) AS A
	ON CB.MACB = A.MACB
	WHERE CB.MACB = @MaCB
END

CREATE PROCEDURE VeHang2Trong
	@MaCB char(5)
AS
BEGIN
	SELECT CB.SOGHEHANG2 - A.[ĐÃ ĐẶT]
	FROM CHUYENBAY CB INNER JOIN 
		(SELECT CB.MACB, COUNT(VE.MAVE) AS 'ĐÃ ĐẶT'
		FROM VE INNER JOIN CHUYENBAY CB ON VE.MACB = CB.MACB
		INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
	WHERE VE.MAHV ='HV002'
	GROUP BY CB.MACB ) AS A
	ON CB.MACB = A.MACB
	WHERE CB.MACB = @MaCB
END
------

CREATE PROCEDURE LietKeVe
	@MaCB char(5)
AS
BEGIN
	SELECT DISTINCT VE.MAVE, VE.MACB, HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', HV.TENHANGVE AS 'HẠNG VÉ',
	VE.GIATIEN AS 'GIÁ TIỀN', TT.TENTINHTRANG AS 'TÌNH TRẠNG'
	FROM VE INNER JOIN HANGHK HHK ON VE.MAHHK = HHK.MAHHK
	INNER JOIN TINHTRANG TT ON VE.MATT = TT.MATT
	INNER JOIN HANGVE HV ON HV.MAHV = VE.MAHV
	WHERE VE.MACB = @MaCB
END


CREATE PROCEDURE ChonHangVe
	@MaHangVe varchar(5),
	@MaCB char(5)
AS
BEGIN	 
	SELECT DISTINCT VE.MAVE, VE.MACB,HHK.TENHHK AS 'HÃNG HÀNG KHÔNG', HV.TENHANGVE AS 'HẠNG VÉ',
	VE.GIATIEN AS 'GIÁ TIỀN', TT.TENTINHTRANG AS 'TÌNH TRẠNG'
	FROM VE INNER JOIN HANGHK HHK ON VE.MAHHK = HHK.MAHHK
	INNER JOIN TINHTRANG TT ON VE.MATT = TT.MATT
	INNER JOIN HANGVE HV ON HV.MAHV = VE.MAHV
	WHERE VE.MACB = @MaCB and VE.MAHV = @MaHangVe
END

------

CREATE PROCEDURE LoadVeCapNhat
	@MaCB char(5) =null,
	@MaVe char(5) =null
AS
BEGIN
	SELECT DISTINCT VE.MAVE, VE.MACB, VE.GIATIEN AS 'GIÁ VÉ', TT.TENTINHTRANG AS 'TÌNH TRẠNG', PDM.DATHANHTOAN AS'THANH TOÁN'
	FROM VE INNER JOIN TINHTRANG TT ON VE.MATT = TT.MATT
	INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
	WHERE VE.MACB = @MaCB OR VE.MAVE = @MaVe
END

CREATE PROCEDURE InVe
	@MaVe char(5) = null
AS
BEGIN
	SELECT DISTINCT VE.MAVE, VE.MACB, TENHHK, FORMAT(CB.THOIGIANKHOIHANH,'HH:mm') AS'GIOBAY', FORMAT(CB.THOIGIANKHOIHANH,'dd/MM/yyyy') AS'NGAYBAY',
		KH.HOTEN, A.[SÂN BAY ĐI] AS'SANBAYDI', B.[SÂN BAY ĐẾN] AS'SANBAYDEN'
	FROM VE INNER JOIN HANGHK HHK ON VE.MAHHK = HHK.MAHHK
		INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
		INNER JOIN CHUYENBAY CB ON CB.MACB = VE.MACB	
		INNER JOIN KHACHHANG KH ON PDM.MAKH = KH.MAKH
		INNER JOIN
		(SELECT CB.MASBDI, SB.TENSANBAY AS 'SÂN BAY ĐI' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDI = SB.MASB) AS A ON A.MASBDI = CB.MASBDI
		INNER JOIN 
		(SELECT CB.MASBDEN, SB.TENSANBAY AS 'SÂN BAY ĐẾN' FROM 
			SANBAY SB INNER JOIN CHUYENBAY CB ON CB.MASBDEN = SB.MASB) AS B ON B.MASBDEN = CB.MASBDEN
	WHERE VE.MaVe = @MaVe
END

-------------- Procedure San bay -------------
CREATE PROCEDURE LoadSanBay
	@MaSB char(5)
AS
BEGIN
	SELECT TENSANBAY
	FROM SANBAY 
	WHERE MASB = @MaSB
END

-------- Procedure Phieu dat mua ---------
CREATE PROCEDURE TaoPhieuDatMua	
	@MaVe CHAR(5),
	@MaKH CHAR(5),
	@ThoiGianDat SMALLDATETIME,
	@DaThanhToan bit
AS
BEGIN
	INSERT INTO PHIEUDATMUA
	VALUES (@MaVe, @MaKH, @ThoiGianDat, @DaThanhToan)
END


--------- Procedure Bao cao -----------

CREATE PROCEDURE BaoCao
	@TuNgay smalldatetime,
	@DenNgay smalldatetime
AS
BEGIN
	SELECT DISTINCT A.MACB,A.[ĐÃ BÁN], A.[DOANH THU], ROUND(A.[ĐÃ BÁN]*1.0/B.[TỔNG SỐ],2) AS'TỈ LỆ'
	FROM 
		(SELECT VE.MACB, COUNT(VE.MAVE) AS'ĐÃ BÁN', SUM(VE.GIATIEN) AS 'DOANH THU'
			FROM VE 
			INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
			WHERE VE.MATT='TT001'
			GROUP BY VE.MACB) AS A 
		INNER JOIN 
			(SELECT VE.MACB, COUNT(VE.MAVE) AS 'TỔNG SỐ'
			FROM VE
			GROUP BY VE.MACB) AS B
		ON A.MACB = B.MACB
		INNER JOIN VE ON A.MACB = VE.MACB
		INNER JOIN PHIEUDATMUA PDM ON VE.MAVE=PDM.MAVE
	WHERE VE.MATT='TT001' AND CONVERT(DATE, PDM.THOIGIANDAT) >= @TuNgay 
		AND CONVERT(DATE, PDM.THOIGIANDAT) <= @DenNgay
END

-------

CREATE PROCEDURE BaoCaoNam
	@NAM INT
AS
BEGIN
	SELECT DISTINCT A.MACB,A.[ĐÃ BÁN] AS'DABAN', A.[DOANH THU] AS 'DOANHTHU', ROUND(A.[ĐÃ BÁN]*1.0/B.[TỔNG SỐ],2) AS'TILE'
	FROM 
		(SELECT VE.MACB, COUNT(VE.MAVE) AS'ĐÃ BÁN', SUM(VE.GIATIEN) AS 'DOANH THU'
			FROM VE 
			INNER JOIN PHIEUDATMUA PDM ON VE.MAVE = PDM.MAVE
			WHERE VE.MATT='TT001'
			GROUP BY VE.MACB) AS A 
		INNER JOIN 
			(SELECT VE.MACB, COUNT(VE.MAVE) AS 'TỔNG SỐ'
			FROM VE
			GROUP BY VE.MACB) AS B
		ON A.MACB = B.MACB
		INNER JOIN VE ON A.MACB = VE.MACB
		INNER JOIN PHIEUDATMUA PDM ON VE.MAVE=PDM.MAVE
	WHERE VE.MATT='TT001' AND DATEPART(YEAR, PDM.THOIGIANDAT) = @NAM
END


CREATE PROCEDURE ThanhToan
	@MaVe char(5)
AS
BEGIN
	UPDATE PHIEUDATMUA
	SET DATHANHTOAN ='1'
	WHERE MAVE = @MaVe
	UPDATE VE
	SET MATT ='TT001'
	WHERE MAVE= @MaVe
END

CREATE PROCEDURE HoanVe
	@MaVe char(5)
AS
BEGIN 
	DELETE FROM PHIEUDATMUA WHERE MAVE = @MaVe
	UPDATE VE
	SET MATT = 'TT000'
	WHERE MAVE = @MaVe
END

----Procedure QuyDinh
CREATE PROCEDURE GetQuyDinh
	@MaQuyDinh varchar(50)
AS
BEGIN
	SELECT TOP 1 GiaTri
	FROM QUYDINH
	WHERE (MaQuyDinh = @MaQuyDinh)
	ORDER BY NgayApDung DESC		 
END

CREATE PROCEDURE GetNgayApDungQuyDinh
	@MaQuyDinh varchar(50)
AS
BEGIN
	SELECT TOP 1 NgayApDung
	FROM QUYDINH
	WHERE (MaQuyDinh = @MaQuyDinh)
	ORDER BY NgayApDung DESC
		 
END

CREATE PROCEDURE CapNhatQuyDinh
	@MaQuyDinh VARCHAR(50),
	@GiaTri INT,
	@NgayApDung smalldatetime
AS
BEGIN
	DECLARE @TenQuyDinh NVARCHAR(50)
	SELECT @TenQuyDinh = (SELECT DISTINCT TenQuyDinh FROM QUYDINH WHERE MaQuyDinh = @MaQuyDinh)
	INSERT INTO QUYDINH VALUES (@MaQuyDinh, @TenQuyDinh, @GiaTri, @NgayApDung)
END
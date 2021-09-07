Create database QLY_ThuVien_DH
go

use QLY_ThuVien_DH
go

create table TaiKhoan
(
	ID varchar(10) primary key,
	TenTK nvarchar(50),
	MatKhau varchar(50),
	Quyen nvarchar(50)
)

create table TacGia
(
	MaTG varchar(20) primary key,
	TenTG nvarchar(150),
	GhiChu nvarchar(150)
)

create table TheLoai
(
	MaTL varchar(20) primary key,
	TenTL nvarchar(150)
)

create table NhaXuatBan
(
	MaNXB varchar(20) primary key,
	TenNXB nvarchar(150),
	DiaChi nvarchar(150),
	Email varchar(50),
	TTNDaiDien nvarchar(100)
)

create table Sach
(
	MaSach varchar(20)  primary key,
	TenSach nvarchar(150),
	NamXB date,
	SoLuong int,
	TrangThai Nvarchar(50),
	MaTG varchar(20),
	MaTL varchar(20),
	MaNXB varchar(20)
	foreign key (MaTG) references TacGia(MaTG),
	foreign key (MaTL) references TheLoai(MaTL),
	foreign key (MaNXB) references NhaXuatBan(MaNXB)
)

create table NhanVien(
	MaNV varchar(20) primary key,
	HoTen nvarchar(150),
	GioiTinh nvarchar(10),
	DiaChi nvarchar(150),
	NgaySinh date,
	SoDT nvarchar(15),
)
select*from NhanVien
create table TheThuVien
(
	SoThe varchar(20) primary key,
	MaNV varchar(20),
	NgayBanDau date,
	NgayHetHan date,
	GhiChu text
	foreign key (MaNV) references NhanVien(MaNV)
)

create table SinhVien
(
	MaSV varchar(20) primary key,
	HoTenSV nvarchar(150),
	GioiTinh nvarchar(5),
	NgaySinh date,
	DiaChi nvarchar(150),
	SoDT varchar(30),
	SoThe varchar(20)
	foreign key (SoThe) references TheThuVien(SoThe)
)

create table MuonTra
(
	MaMT varchar(20) primary key Constraint MaMT DEFAULT dbo.auto_MuonTra(),
	SoThe varchar(20),
	MaNV varchar(20),
	MaSV varchar(20),
	NgayMuon date,
	SoLuongMuon int
	foreign key (SoThe) references TheThuVien(SoThe),
	foreign key (MaNV) references NhanVien(MaNV),
	foreign key (MaSV) references SinhVien(MaSV)
)

create table CTMuonTra
(
	MaMT varchar(20),
	MaSach varchar(20),
	GhiChu text,
	DaTra nvarchar(20),
	SoLuongTra int
	constraint CTMuonTra_pk primary key (MaMT,MaSach)
)
alter table CTMuonTra
add foreign key (MaSach) references Sach(MaSach)
alter table CTMuonTra
add foreign key (MaMT) references MuonTra(MaMT)

insert into TaiKhoan values ('TK01', '', N'admin', '123456789', 'Admin')
insert into TaiKhoan values ('TK02', '', N'NhanVien', '123456789', N'Nhân Viên')
select * from TaiKhoan

insert into NhanVien values ('NV001','JinJin',N'Nam',N'Lâm Đồng','11/05/2002','0797909465') 
select * from NhanVien
go

--ràng buộc 
--1. giới tính chỉ có nam hoặc nữ
alter table NhanVien
add constraint NhanVien_GioiTinh_c Check (GioiTinh = N'Nam' or GioiTinh = N'Nữ')
--Sinh Viên
alter table SinhVien
add Constraint SinhVien_GioiTinh_c Check (GioiTinh = N'Nam' or GioiTinh = N'Nữ')
--2. 
select*from nhanvien
select * from SinhVien
go

--tạo proceducer sinh mã tự động cho bảng TaiKhoan
create proc sp_TaiKhoan_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(ID) + 1 from TaiKhoan where ID like 'TK'
	set @ma_next = 'TK' + right('0' + cast(@max as varchar(20)),20)

	while (exists(select ID from TaiKhoan where ID = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='TK' + RIGHT('0' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end

declare @return_Value int
execute @return_Value = [dbo].[sp_TaiKhoan_SinhMaTuDong]
select 'Return Value' = @return_Value
go

--Sinh mã tự động sinh viên
create proc sp_SinhVien_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaSV) + 1 from SinhVien where MaSV like 'SV'
	set @ma_next = 'SV' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaSV from SinhVien where MaSV = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='SV' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end

declare @return_Value int
execute @return_Value = [dbo].[sp_SinhVien_SinhMaTuDong]
select 'Return Value' = @return_Value
go

--Sinh Mã tự động Sách
create proc sp_Sach_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int
	select @max = Count(MaSach) + 1 from Sach where MaSach like 'Sach'
	set @ma_next = 'Sach' + RIGHT('00' + cast(@max as varchar(20)),20)
	while (exists (select MaSach from Sach where MaSach = @ma_next))
		begin
			set @max = @max +1
			set @ma_next = 'Sach' + right('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end
execute dbo.sp_Sach_SinhMaTuDong
go

-- Sinh Mã tự động Mượn tả theo ngày
CREATE FUNCTION auto_MuonTra()
RETURNS VARCHAR(15)
AS
BEGIN
	DECLARE @id VARCHAR(15)
	IF (SELECT COUNT(MaMT) FROM MuonTra) = 0
		SET @id = '0'
	ELSE
		SELECT @id = MAX(RIGHT(MaMT, 5)) FROM MuonTra
		SELECT @id = CASE
			WHEN @id = 99999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV00001'
			WHEN @id >= 0 and @id < 9 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV0000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
			WHEN @id >= 9 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
			WHEN @id >= 99 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV00' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
			WHEN @id >= 999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV0' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
			WHEN @id >= 9999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'DV' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		END
	RETURN @id
END

select dbo.auto_MuonTra() from MuonTra



select*from Sach
go

--thủ tục select all dữ liệu của bảng NhanVien
create proc sp_SelectAll_NhanVien
as
begin
	Select * from NhanVien
end

-- Sinh mã tự động bảng NhanVien
create proc sp_NhanVien_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaNV) + 1 from NhanVien where MaNV like 'NV'
	set @ma_next = 'NV' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaNV from NhanVien where MaNV = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='NV' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end

declare @return_Value int
execute @return_Value = [dbo].[sp_NhanVien_SinhMaTuDong]
select 'Return Value' = @return_Value


-- Thủ tục Insert into dữ liệu vào bảng Nhân Viên
create procedure sp_Insert_NhanVien
(
	@MaNV varchar(20),
	@HoTen nvarchar(150),
	@GioiTinh nvarchar(10),
	@DiaChi nvarchar(150),
	@NgaySinh date,
	@SoDT nvarchar(15)
)
as
begin
	Insert into NhanVien values (@MaNV,@HoTen,@GioiTinh,@DiaChi,@NgaySinh,@SoDT)
end

--Thủ tục update dữ liệu vào bảng Nhân Viên.
create procedure sp_Update_NhanVien
(
	@MaNV varchar(20),
	@HoTen nvarchar(150),
	@GioiTinh nvarchar(10),
	@DiaChi nvarchar(150),
	@NgaySinh date,
	@SoDT nvarchar(15)
)
as
begin
	UPDATE [dbo].[NhanVien]
   SET
       [HoTen] = @HoTen,
       [GioiTinh] = @GioiTinh,
       [DiaChi] = @DiaChi,
       [NgaySinh] = @NgaySinh,
       [SoDT] = @SoDT
 WHERE [MaNV] = @MaNV
 end

 select*from NhanVien
go


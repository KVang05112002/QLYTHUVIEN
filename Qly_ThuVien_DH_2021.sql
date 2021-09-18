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
	GhiChu nvarchar(250),
	MaSV varchar(20)
	foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_Masv foreign key (MaSV) references SinhVien(MaSV)
)

create table SinhVien
(
	MaSV varchar(20) primary key,
	HoTenSV nvarchar(150),
	GioiTinh nvarchar(5),
	NgaySinh date,
	DiaChi nvarchar(150),
	SoDT varchar(30)
)

create table MuonTra
(
	MaMT varchar(20) primary key Constraint MaMT DEFAULT dbo.auto_MuonTra(),
	SoThe varchar(20),
	MaNV varchar(20),
	MaSV varchar(20),
	NgayMuon date,
	SoLuongMuon int,
	TinhTrang nvarchar (100),
	GhiChu nvarchar(200)
	foreign key (SoThe) references TheThuVien(SoThe),
	foreign key (MaNV) references NhanVien(MaNV),
	foreign key (MaSV) references SinhVien(MaSV)
)

create table PhieuMuon
(
	MaPM varchar(20) primary key,
	MaSach varchar(20),
	SoThe varchar(20),
	NgayMuon date,
	MaSV varchar(20)
	Constraint PRK_PhieuMuon_Sach foreign key (MaSach) references Sach(MaSach),
	Constraint PRK_PhieuMuon_TheThuVien foreign key (SoThe) references TheThuVien(SoThe),
	constraint PRK_PhieuMuon_SinhVien foreign key (MaSV) references SinhVien(MaSV)
)

create table PhieuNhacTra
(
	MaPNT varchar(20) primary key,
	SoThe varchar(20),
	MaSV varchar(20),
	NgayLapPhat date,
	DonGiaPhat float,
	MaNV varchar(20),
	MaSach varchar(20)
	Constraint PRK_PhieuNhacTra_TheThuVien foreign key (SoThe) references TheThuVien(SoThe),
	Constraint PRK_PhieuNhacTra_SinhVien foreign key (MaSV) references SinhVien(MaSV),
	Constraint PRK_PhieuNhacTra_NhanVien foreign key (MaNV) references NhanVien(MaNV),
	Constraint PRK_PhieuNhacTra_Sach foreign key (MaSach) references Sach(MaSach)
)

go
insert into TaiKhoan values ('TK01', '', N'admin', '123456789', 'Admin')
insert into TaiKhoan values ('TK02', '', N'NhanVien', '123456789', N'Nhân Viên')
select * from TaiKhoan

insert into NhanVien values ('NV001','JinJin',N'Nam',N'Lâm Đồng','11/05/2002','0797909465') 
select * from NhanVien

insert into SinhVien values ('SV001',N'K Vảng',N'Nam','11/05/2002',N'Lâm Đồng','0797909465')
insert into SinhVien values ('SV002',N'Nguyễn Hữu Tuấn',N'Nam','11/09/2002',N'Ninh Thuận','0797909465')
select*from SinhVien

select*from TacGia
insert into TacGia values ('TG001',N'Xuân Quỳnh','')
go
select*from TheLoai
insert into TheLoai values ('TL001',N'Thơ')
go
select*from NhaXuatBan
insert into NhaXuatBan values ('NXB001',N'Kim Đồng',N'Lâm Đồng','kimdong@gmail.com',N'Giám Đốc Nguyễn Vĩnh Xuân')
go
insert into Sach values ('S001',N'Sóng','11/05/1992',30,N'Còn','TG001','TL001','NXB001')
select*from Sach
delete TacGia where MaTG = 'TG001'
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
--SINH VIÊN
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

create procedure sp_Insert_SinhVien
(
	@MaSV varchar(20),
	@HoTenSV nvarchar(150),
	@GioiTinh nvarchar(5),
	@NgaySinh date,
	@DiaChi nvarchar(150),
	@SoDT varchar(30)
)
as
begin
	Insert into SinhVien values (@MaSV,@HoTenSV, @GioiTinh, @NgaySinh, @DiaChi, @SoDT )
end
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
alter procedure sp_Update_NhanVien
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
	UPDATE NhanVien
   SET
       HoTen = @HoTen,
       GioiTinh = @GioiTinh,
       DiaChi = @DiaChi,
       NgaySinh = @NgaySinh,
       SoDT = @SoDT
	WHERE MaNV = @MaNV
 end

 select*from NhanVien
go
  
--Thẻ Thư Viện
--Sinh Mã Tự Động THẻ THư viện
create proc sp_TheThuVien_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(SoThe) + 1 from TheThuVien where SoThe like 'TV'
	set @ma_next = 'TV' + right('000' + cast(@max as varchar(20)),20)

	while (exists(select SoThe from TheThuVien where SoThe = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='TV' + RIGHT('000' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end

--Thêm dữ liệu
alter procedure sp_Insert_TheThuVien
(
	@SoThe varchar(20),
	@MaNV varchar(20),
	@NgayBanDau date,
	@NgayHetHan date,
	@GhiChu nvarchar(250),
	@MaSV varchar(20)
)
as
begin
	Insert into TheThuVien values (@SoThe,@MaNV,@NgayBanDau,@NgayHetHan,@GhiChu,@MaSV)
end
go

--Nhà Xuất Bản
create proc sp_NXB_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaNXB) + 1 from NhaXuatBan where MaNXB like 'NXB'
	set @ma_next = 'NXB' + right('000' + cast(@max as varchar(20)),20)

	while (exists(select MaNXB from NhaXuatBan where MaNXB = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='NXB' + RIGHT('000' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end
select * from NhaXuatBan
/*lấy ds*/
create proc [dbo].[SP_LayDSNXB]
as
begin
    select * from NhaXuatBan
end
/*Thêm*/
create proc [dbo].[SP_ThemNXB]
(
@MaNXB varchar(20),
@TenNXB nvarchar(150),
@Diachi nvarchar(150),
@Email nvarchar(50),
@TTNDaiDien nvarchar(100)
)
as
begin
    insert into NhaXuatBan values (@MaNXB, @TenNXB, @Diachi, @Email,  @TTNDaiDien)
end
/*Sửa*/
create proc [dbo].[SP_SuaNXB]
(
@MaNXB varchar(20),
@TenNXB nvarchar(150),
@Diachi nvarchar(150),
@Email nvarchar(50),
@TTNDaiDien nvarchar(100)
)
as
begin
    update NhaXuatBan set
    TenNXB = @Tennxb,
	Diachi = @Diachi,
    Email = @Email,
    TTNDaiDien = @TTNDaiDien
    where MaNXB = @MaNXB
end

go
--Phiếu Mượn
--Sinh Mã Tự Động Phiêu Mượn
alter proc sp_PhieuMuon_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaPM) + 1 from PhieuMuon where MaPM like 'PM'
	set @ma_next = 'PM' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaPM from PhieuMuon where MaPM = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='PM' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end
--insert into phiếu mượn
create proc sp_insertinto_PhieuMuon
(
	@MaPM varchar(20),
	@MaSach varchar(20),
	@SoThe varchar(20),
	@NgayMuon date,
	@MaSV varchar(20)
)
as
begin
	Insert into PhieuMuon values (@MaPM,@MaSach,@SoThe,@NgayMuon,@MaSV)
end
--update phiếu mượn
create proc sp_Update_PhieuMuon
(
	@MaPM varchar(20),
	@MaSach varchar(20),
	@SoThe varchar(20),
	@NgayMuon date,
	@MaSV varchar(20)
)
as
begin
	update PhieuMuon 
	set
	MaSach = @MaSach,
	SoThe = @SoThe,
	NgayMuon = @NgayMuon,
	MaSV = @MaSV
	where MaPM = @MaPM
end
go
--Thể Loại
--Sinh mã tự động thể loại
create proc sp_TheLoai_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaTL) + 1 from TheLoai where MaTL like 'TL'
	set @ma_next = 'TL' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaTL from TheLoai where MaTL = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='TL' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end

--Insert into Thê loại
create proc sp_insertinto_TheLoai
(
	@MaTL varchar(20),
	@TenTL nvarchar(150)
)
as
begin
	insert into TheLoai Values (@MaTL, @TenTL)
end
go
--Tác Giả
--Sinh mã tự động
create proc sp_TacGia_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaTG) + 1 from TacGia where MaTG like 'TG'
	set @ma_next = 'TG' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaTG from TacGia where MaTG = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='TG' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end
--insert into Tác Giả
create proc sp_insertinto_TacGia
(
	@MaTG varchar(20),
	@TenTG nvarchar(150),
	@GhiChu nvarchar(150)
)
as
begin
	insert into TacGia Values (@MaTG, @TenTG,@GhiChu)
end
go
--Phieu Nhac tra
--sinh mã tụ động phieu nhắc trả
create proc sp_PhieuNhacTra_SinhMaTuDong
as
begin
	declare @ma_next varchar(20)
	declare @max int 

	select @max=Count(MaPNT) + 1 from PhieuNhacTra where MaPNT like 'PNT'
	set @ma_next = 'PNT' + right('00' + cast(@max as varchar(20)),20)

	while (exists(select MaPNT from PhieuNhacTra where MaPNT = @ma_next))
		begin
			set @max = @max + 1
			set @ma_next='PNT' + RIGHT('00' + cast(@max as varchar(20)),20)
		end
		select @ma_next
end
--insert into dữ liệu cho bảng phieu nhác trả
create proc sp_Insert_PhieuNhacTra
(
	@MaPNT varchar(20),
	@SoThe varchar(20),
	@MaSV varchar(20),
	@NgayLapPhat date,
	@DonGiaPhat float,
	@MaNV varchar(20),
	@MaSach varchar(20)
)
as
begin
	insert into PhieuNhacTra values(@MaPNT,@SoThe,@MaSV,@NgayLapPhat,@DonGiaPhat,@MaNV,@MaSach)
end
--Update dữ liệu phiếu nhắc trả
create proc sp_Update_PhieuNhacTra
(
	@MaPNT varchar(20),
	@SoThe varchar(20),
	@MaSV varchar(20),
	@NgayLapPhat date,
	@DonGiaPhat float,
	@MaNV varchar(20),
	@MaSach varchar(20)
)
as
begin
	Update PhieuNhacTra
	set
	SoThe = @SoThe,
	MaSV = @MaSV,
	NgayLapPhat = @NgayLapPhat,
	DonGiaPhat = @DonGiaPhat,
	MaNV = @MaNV,
	MaSach = @MaSach
	where MaPNT = @MaPNT
end
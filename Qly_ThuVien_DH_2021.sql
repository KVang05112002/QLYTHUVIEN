Create database QLY_ThuVien_DH
go

use QLY_ThuVien_DH
go

create table TaiKhoan
(
	ID varchar(10) primary key,
	Masv varchar(20),
	TenTK nvarchar(50),
	MatKhau varchar(50),
	Quyen nvarchar(50)
)
alter table TaiKhoan
drop column Masv
select*from TaiKhoan
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
	Hinhanh varbinary (max)
)

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
	Hinhanh varbinary (Max),
	SoThe varchar(20)
	foreign key (SoThe) references TheThuVien(SoThe)
)

create table MuonTra
(
	MaMT varchar(20) primary key,
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


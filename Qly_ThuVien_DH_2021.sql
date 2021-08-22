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

insert into TaiKhoan values ('TK01', '', N'admin', '123456789', 'Admin')
insert into TaiKhoan values ('TK02', '', N'NhanVien', '123456789', N'Nhân Viên')
select * from TaiKhoan
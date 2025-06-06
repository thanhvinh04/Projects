create database TTTA_day2

create table GIAO_VIEN ( 
                        [ma_gv] char(4) primary key,
						[hoten_gv] nvarchar(50) not null,
						[namsinh_gv] int,
						[phai_gv] nvarchar(3) check ([phai_gv] in (N'Nam',N'Nữ')),
						[diachi_gv] nvarchar(500),
						[sdt_gv] varchar(10) not null,
						[email_gv] varchar(40),
						[diem_ielts_gv] float not null,
						[luong] int
                        )

CREATE table HOC_VIEN  (
                       [ma_hv] char(6) primary key,
					   [hoten_hv] nvarchar(50) not null,
					   [namsinh_hv] int,
					   [phai_hv] nvarchar(3) check ([phai_hv] in (N'Nam',N'Nữ')),
					   [diachi_hv] nvarchar(500),
					   [sdt_hv] varchar(10) not null ,
					   [email_hv] varchar(40) 
                       )

create table KHOA_HOC (
                       [ma_kh] char(4) primary key,
					   [ten_kh] nvarchar(50) not null,
					   [dau_vao] nvarchar(50) not null,
					   [dau_ra] nvarchar(50) not null,
					   [hoc_phi] int
					   )

create table LOP_HOC (
                      [ma_lh] char(5) primary key,
					  [ten_lh] nvarchar(50) not null,
					  [ma_kh] char(4) foreign key references KHOA_HOC([ma_kh]),
					  [gv_ptrach] char(4) foreign key references GIAO_VIEN([ma_gv]),
					  [ngay_mo] date,
					  [ngay_dong] date
					  )
alter table LOP_HOC alter column [gv_ptrach] char(4) not null
alter table LOP_HOC alter column [ma_kh] char(4) not null
					
create table DANG_KY (
                      [ma_hv] char(6) foreign key references HOC_VIEN([ma_hv]) not null,
					  [ma_kh] char(4) foreign key references KHOA_HOC([ma_kh]) not null,
					  )
alter table DANG_KY add primary key ([ma_hv],[ma_kh])

create table LICH (
                   [ma_thu] char(3) primary key,
				   [thu] nvarchar(10),
				   )

create table CA (
                 [ma_ca] char(3) primary key,
				 [gio_vao] varchar(10) not null,
				 [gio_ra] varchar(10) not null,
				 )

create table PHONG (
                    [ma_phong] char(4) primary key,
					[so_phong] char(3) not NULL UNIQUE,
					)

create table NGAY_CA (
                      [ma_id] char(4) primary key,
					  [ma_thu] char(3) foreign key references LICH([ma_thu]),
					  [ma_ca] char(3) foreign key references CA([ma_ca]),
					  )

create table PHONG_NGAY_CA (
                            [ma_id] char(4) foreign key references NGAY_CA([ma_id]) not null,
							[ma_phong] char(4) foreign key references PHONG([ma_phong]) not null,
							[ma_lh] char(5) foreign key references LOP_HOC([ma_lh]) not null,
							)
alter table PHONG_NGAY_CA add primary key ([ma_id],[ma_phong])
alter table PHONG_NGAY_CA add unique ([ma_id],[ma_lh])

create table KQHT (
                   [ma_hv] char(6) foreign key references HOC_VIEN([ma_hv]) not null,
				   [ma_lh] char(5) foreign key references LOP_HOC([ma_lh]) not null,
				   [diem] float,
				   [so_buoi_vang] INT DEFAULT 0,
				   [ngay_nhap_hoc] date,
				   )
				  
alter table KQHT add primary key ([ma_hv],[ma_lh])

-- insert HOC_VIEN
insert HOC_VIEN values ('HV0001', N'Nguyễn Văn Một', 2004, N'Nam', N'Quận 8', '0994939411', 'mot123@gmail.com')
insert HOC_VIEN values ('HV0002', N'Lê Thị Hai', 2005, N'Nữ', N'Quận 7', '0399499422', 'hai123@gmail.com')
insert HOC_VIEN values ('HV0003', N'Quách Ba', 2005, N'Nam', N'Quận 5', '0394929933', 'ba123@gmail.com')
insert HOC_VIEN values ('HV0004', N'Nguyễn Hoài An', 2003, N'Nữ', N'Quận 11', '0123456789', 'bon123@gmail.com')
insert HOC_VIEN values ('HV0005', N'Trần Thế Vinh', 2002, N'Nam', N'Quận 9', '0123456779', 'nam123@gmail.com')
insert HOC_VIEN values ('HV0006', N'Võ Trần Trung Quân', 2001, N'Nam', N'Quận 11', '0125456779', 'sau123@gmail.com')
insert HOC_VIEN values ('HV0007', N'Phạm Văn Tuấn', 2004, N'Nam', N'Quận 6', '0125416779', 'bay123@gmail.com')
insert HOC_VIEN values ('HV0008', N'Phạm Thế Vinh', 2005, N'Nam', N'Quận 7', '0125456782', 'tam123@gmail.com')
insert HOC_VIEN values ('HV0009', N'Phạm Đình Thanh', 1999, N'Nam', N'Quận 8', '0125456731', 'chin123@gmail.com')
insert HOC_VIEN values ('HV0010', N'Phạm Tuấn Khởi', 1998, N'Nam', N'Quận 9', '0125446782', 'muoi123@gmail.com')
insert HOC_VIEN values ('HV0011', N'Lê Anh Khoa', 1999, N'Nam', N'Quận 10', '0125446783', 'mot1234@gmail.com')
insert HOC_VIEN values ('HV0012', N'Trần Ngọc Hoa', 2000, N'Nữ', N'Quận 11', '0125446784', 'hai1234@gmail.com')
insert HOC_VIEN values ('HV0013', N'Phạm Mỹ Hoa', 2001, N'Nữ', N'Thủ Đức', '0125446785', 'ba1234@gmail.com')
insert HOC_VIEN values ('HV0014', N'Phan Anh Tuấn', 2000, N'Nam', N'Phú Nhuận', '0125446786', 'bon1234@gmail.com')
insert HOC_VIEN values ('HV0015', N'Trần Diệu My', 2001, N'Nữ', N'Tân Bình', '0125446787', 'nam1234@gmail.com')
insert HOC_VIEN values ('HV0016', N'Phạm Đình Công', 2002, N'Nam', N'Quận 11', '0125446788', 'sau1234@gmail.com')
insert HOC_VIEN values ('HV0017', N'Nguyễn Trung Kiên', 2003, N'Nam', N'Quận 8', '0125446789', 'bay1234@gmail.com')
insert HOC_VIEN values ('HV0018', N'Hồ Chí Cường', 1998, N'Nam', N'Tân Bình', '0125446790', 'tam1234@gmail.com')
insert HOC_VIEN values ('HV0019', N'Trần Thanh Mai', 2002, N'Nữ', N'Tân Bình', '0125446791', 'chin1234@gmail.com')
insert HOC_VIEN values ('HV0020', N'Mai Cẩm Tiên', 2001, N'Nữ', N'Gò Vấp', '0125446792', 'muoi1234@gmail.com')
insert HOC_VIEN values ('HV0021', N'Trần Tình', 1995, N'Nam', N'Quận 1', '0125446756', 'mu234@gmail.com')
insert HOC_VIEN values ('HV0022', N'Phạm Tuyên', 1997, N'Nam', N'Quận 2', '0125446723', 'mu1234@gmail.com')
insert HOC_VIEN values ('HV0023', N'Trần Thế', 1989, N'Nam', N'Bình Chánh', '0125446754', 'muoi134@gmail.com')
insert HOC_VIEN values ('HV0024', N'Nguyễn Trần Trung Quân', 1989, N'Nam', N'Quận 9', '0125446592', 'mui1234@gmail.com')
insert HOC_VIEN values ('HV0025', N'Nguyễn Thanh Tùng', 1988, N'Nam', N'Quận 7', '0125446709', 'muoi124@gmail.com')

-- insert GIAO_VIEN
insert GIAO_VIEN values ('GV01', N'Phạm Bằng', 1997, N'Nam', N'Quận 7', '09949394', 'gv01@gmail.com', 7.5, 7000)
insert GIAO_VIEN values ('GV02', N'Phạm Khác', 1987, N'Nam', N'Quận 1', '03994994', 'gv02@gmail.com', 8, 8000)
insert GIAO_VIEN values ('GV03', N'Trần Chung', 1988, N'Nam', N'Bình Chánh', '03949299', 'gv03@gmail.com', 8.5, 9500)
insert GIAO_VIEN values ('GV04', N'Nguyễn Trần Thế Anh', 1999, N'Nam', N'Quận 5', '08237454', 'gv04@gmail.com', 8, 10000)

-- insert KHOA_HOC
insert KHOA_HOC values ('KH01',N'IELTS',N'0 - 4.0',N'5.5+',10000)
insert KHOA_HOC values ('KH02',N'IELTS',N'4.0 - 5.0',N'6.5+',13000)
insert KHOA_HOC values ('KH03',N'IELTS',N'5.5 - 6.0',N'7.5+',20000)
insert KHOA_HOC values ('KH04',N'TOEIC 2 KỸ NĂNG',N'0 - 450',N'600+',6000)
insert KHOA_HOC values ('KH05',N'TOEIC 2 KỸ NĂNG',N'500 - 700',N'800+',8000)
insert KHOA_HOC values ('KH06',N'GIAO TIẾP',N'0 - 3.0',N'5.0+',6000)
insert KHOA_HOC values ('KH07',N'GIAO TIẾP',N'3.0 - 5.0',N'6.0+',9000)
insert KHOA_HOC values ('KH08',N'TOEIC 4 KỸ NĂNG',N'0 - 450',N'600+',8000)
insert KHOA_HOC values ('KH09',N'TOEIC 4 KỸ NĂNG',N'500 - 700',N'800+',11000)
-- insert DANG_KY
insert DANG_KY values 
('HV0001', 'KH01'),
('HV0002', 'KH01'),
('HV0003', 'KH01'),
('HV0004', 'KH01'),
('HV0005', 'KH01'),
('HV0006', 'KH05'),
('HV0007', 'KH05'),
('HV0008', 'KH05'),
('HV0009', 'KH05'),
('HV0010', 'KH05'),
('HV0011', 'KH08'),
('HV0012', 'KH08'),
('HV0013', 'KH08'),
('HV0014', 'KH08'),
('HV0015', 'KH08'),
('HV0016', 'KH04'),
('HV0017', 'KH04'),
('HV0018', 'KH04'),
('HV0019', 'KH04'),
('HV0020', 'KH04'),
('HV0001','KH04')
insert DANG_KY values ('HV0021', 'KH01')
insert DANG_KY values ('HV0022', 'KH01')
insert DANG_KY values ('HV0023', 'KH01')
insert DANG_KY values ('HV0024', 'KH01')
insert DANG_KY values ('HV0025', 'KH01')

-- insert LOP_HOC
insert LOP_HOC values ('LH001', N'IELTS 5.5+', 'KH01', 'GV01', '20220905', '20221120')
insert LOP_HOC values ('LH002', N'TOEIC 2 KỸ NĂNG 800+', 'KH05', 'GV03', '20230715', '20230929')
insert LOP_HOC values ('LH003', N'TOEIC 4 KỸ NĂNG 600+', 'KH08', 'GV02', '20230906', '20231121')
insert LOP_HOC values ('LH004', N'TOEIC 2 KỸ NĂNG 600+', 'KH04', 'GV04', '20231002', '20231217')
insert LOP_HOC values ('LH009', N'TOEIC 2 KỸ NĂNG 600+', 'KH01', 'GV04', '20231002', '20231217')

-- insert LICH
insert LICH values ('Mon', N'Thứ Hai')
insert LICH values ('Tue', N'Thứ Ba')
insert LICH values ('Wed', N'Thứ Tư')
insert LICH values ('Thu', N'Thứ Năm')
insert LICH values ('Fri', N'Thứ Sáu')
insert LICH values ('Sat', N'Thứ Bảy')
insert LICH values ('Sun', N'Chủ nhật')

-- insert CA
insert CA values ('CA1','7h30','9h')
insert CA values ('CA2','16h','17h30')
insert CA values ('CA3','18h','19h30')
insert CA values ('CA4','20h','21h30')

-- insert PHONG
insert PHONG values ('PH01','101')
insert PHONG values ('PH02','102')
insert PHONG values ('PH03','103')
insert PHONG values ('PH04','201')
insert PHONG values ('PH05','202')
insert PHONG values ('PH06','203')
insert PHONG values ('PH07','301')
insert PHONG values ('PH08','302')
insert PHONG values ('PH09','303')
insert PHONG values ('PH10','401')
insert PHONG values ('PH11','402')
insert PHONG values ('PH12','403')

-- insert NGAY_CA
insert NGAY_CA values ('NC01', 'Mon', 'CA1')
insert NGAY_CA values ('NC02', 'Wed', 'CA3')
insert NGAY_CA values ('NC03', 'Fri', 'CA1')
insert NGAY_CA values ('NC04', 'Wed', 'CA4')
insert NGAY_CA values ('NC05', 'Sun', 'CA3')

-- insert PHONG_NGAY_CA
insert PHONG_NGAY_CA values ('NC01', 'PH01', 'LH001')
insert PHONG_NGAY_CA values ('NC02', 'PH01', 'LH001')
insert PHONG_NGAY_CA values ('NC03', 'PH03', 'LH001')
insert PHONG_NGAY_CA values ('NC01', 'PH02', 'LH002')
insert PHONG_NGAY_CA values ('NC05', 'PH01', 'LH002')
insert PHONG_NGAY_CA values ('NC04', 'PH02', 'LH002')
insert PHONG_NGAY_CA values ('NC03', 'PH05', 'LH003')
insert PHONG_NGAY_CA values ('NC04', 'PH06', 'LH003')
insert PHONG_NGAY_CA values ('NC05', 'PH07', 'LH003')
insert PHONG_NGAY_CA values ('NC01', 'PH08', 'LH004')
insert PHONG_NGAY_CA values ('NC05', 'PH09', 'LH004')
insert PHONG_NGAY_CA values ('NC03', 'PH10', 'LH004')

SELECT * FROM dbo.KQHT
-- insert KQHT
insert KQHT values 
('HV0001', 'LH001', 4, 1, '20220905'),
('HV0002', 'LH001', 3, 2, '20220908'),
('HV0003', 'LH001', 8, 1, '20220905'),
('HV0004', 'LH001', 9, 1, '20220905'),
('HV0005', 'LH001', 7, 0, '20220905')
insert KQHT values 
('HV0006', 'LH002', 6, 0, '20230715'),
('HV0007', 'LH002', 9, 0, '20230715'),
('HV0008', 'LH002', 8, 0, '20230715'),
('HV0009', 'LH002', 2, 3, '20230715'),
('HV0010', 'LH002', 7, 0, '20230715')
insert KQHT values 
('HV0011', 'LH003', null, 0, '20230906'),
('HV0012', 'LH003', null, 0, '20230906'),
('HV0013', 'LH003', null, 0, '20230906'),
('HV0014', 'LH003', null, 0, '20230908'),
('HV0015', 'LH003', null, 0, '20230906')
insert KQHT values 
('HV0016', 'LH004', null, 0, '20231002'),
('HV0017', 'LH004', null, 0, '20231002'),
('HV0018', 'LH004', null, 0, '20231002'),
('HV0019', 'LH004', null, 0, '20231002'),
('HV0020', 'LH004', null, 0, '20231002'),
('HV0001','LH004',null,0,'20231002')
insert KQHT values
('HV0021', 'LH009', null, 0, '20231002'),
('HV0022', 'LH009', null, 0, '20231002'),
('HV0023', 'LH009', null, 0, '20231002'),
('HV0024', 'LH009', null, 0, '20231002'),
('HV0025', 'LH009', null, 0, '20231002'),
('HV0002', 'LH009', null, 0, '20231002')
go
-- RBTV 1: Giáo viên phải có bằng IELTS từ 7.5 trở lên và bé hơn hoặc bằng 9.0
create trigger TRIGGER1 on GIAO_VIEN 
for insert, update
as
begin
      declare @count int = 0
	  select @count = count(*) from inserted where inserted.diem_ielts_gv < 7.5 and inserted.diem_ielts_gv > 9.0
	  if (@count > 0)
	  begin
	        print N'Điểm IELTS của giáo viên phải lớn hơn hoặc bằng 7.5'
			rollback tran
	  end
end
go
-- RBTV 2: Các giáo viên có bằng IELTS dưới 8.0 không được dạy các khóa IELTS 7.5+, TOEIC 2 kỹ năng 800+, TOEIC 4 kỹ năng 800+
create trigger TRIGGER2 on LOP_HOC 
for insert, update
as
begin
      declare @count int = 0
	  declare @makh1 char(4)
	  declare @makh2 char(4)
	  declare @makh3 char(4)
	  select @makh1 = ma_kh from khoa_hoc where ten_kh = 'IELTS' and dau_ra = '7.5+'
	  select @makh2 = ma_kh from khoa_hoc where ten_kh = N'TOEIC 2 KỸ NĂNG' and dau_ra = '800+'
	  select @makh3 = ma_kh from khoa_hoc where ten_kh = N'TOEIC 4 KỸ NĂNG' and dau_ra = '800+'
	  select @count = count(*) from GIAO_VIEN join inserted on GIAO_VIEN.[ma_gv] = [inserted].[gv_ptrach]
	  where [inserted].[ma_kh] in (@makh1, @makh2, @makh3) and GIAO_VIEN.[diem_ielts_gv] < 8.0
	  if (@count > 0)
	  begin
	        print N'Giáo viên không đủ điều kiện để dạy học lớp này'
			rollback tran
	  end
end

go

-- RBTV 4: Lương của giáo viên thấp nhất là 5 triệu.
Create trigger TRIGGER4 on GIAO_VIEN 
for insert, update
as
begin
      declare @count int = 0
	  select @count = count(*) from inserted where [luong] < 5000
	  if (@count > 0)
	  begin
	        print N'Lương giáo viên phải cao hơn hoặc bằng 5000'
			rollback tran
	  end
END
go
-- RBTV 5: Một học viên không thể học cùng lúc nhiều hơn 1 lớp học trong cùng một khóa học.
Create trigger TRIGGER5 on KQHT 
for insert, update
as
begin
      declare @count int = 0
	  select @count = count(*) from 
	  (select KQHT.[ma_hv], KQHT.[ma_lh], LOP_HOC.[ma_kh], LOP_HOC.[ngay_mo], LOP_HOC.[ngay_dong]
	         from KQHT join LOP_HOC on KQHT.[ma_lh] = LOP_HOC.[ma_lh]) as B1,
	  (select inserted.[ma_hv], inserted.[ma_lh], LOP_HOC.[ma_kh], LOP_HOC.[ngay_mo], LOP_HOC.[ngay_dong]
	         from inserted join LOP_HOC on inserted.[ma_lh] = LOP_HOC.[ma_lh]) as B2
	  where B1.[ma_hv] = B2.[ma_hv] and B1.[ma_lh] != B2.[ma_lh]
	        and ((B1.[ngay_mo] >= B2.[ngay_mo] and B1.[ngay_mo] <= B2.[ngay_dong])
			    or (B1.[ngay_mo] <= B2.[ngay_mo] and B2.[ngay_mo] <= B1.[ngay_dong]))
			and B1.[ma_kh] = B2.[ma_kh]
	  if (@count > 0)
	  begin
	        print N'Một học viên không thể học cùng lúc nhiều hơn 1 lớp học trong cùng một khóa học'
			rollback tran
	  end
end
go
-- RBTV 6: Ngày mở nhỏ hơn ngày đóng
Create trigger TRIGGER6 on LOP_HOC
for insert, update
as
begin
       declare @count int = 0
	   select @count = count(*) from [inserted]
	   where [inserted].[ngay_mo] > [inserted].[ngay_dong]
	   if (@count > 0)
	   begin
	         print N'Ngày mở phải nhỏ hơn ngày đóng'
			 rollback tran
	   end
end
go
-- RBTV 7: Lớp học có thể nhận thêm học viên nếu như lớp đó mở chưa quá một tuần
Create trigger TRIGGER7 on KQHT
for insert, update
as
begin
     declare @ngaymo date
	 declare @ngaynhaphoc date
	 select @ngaymo = ngay_mo, @ngaynhaphoc = ngay_nhap_hoc from LOP_HOC as A1,
	        [inserted] as A2 
	 where A1.[ma_lh] = A2.[ma_lh]
	 if (DATEDIFF(day, @ngaymo, @ngaynhaphoc) > 7 or DATEDIFF(day, @ngaymo, @ngaynhaphoc) < 0)
	 begin
	       print N'Dữ liệu không hợp lệ'
		   rollback tran
	 end
end
go
-- RBTV 8: Trung tâm chỉ tuyển giáo viên lớn hơn 19 tuổi
CREATE trigger TRIGGER9 on GIAO_VIEN
for insert, update
as
begin
      declare @count int
	  select @count = count(*) from [inserted] 
	  where YEAR(getdate()) - namsinh_gv < 20
	  if @count > 0
	  begin
	        print N'Dữ liệu không hợp lệ'
			rollback tran
	 end
end
go
-- RBTV 9: Lớp học mà học viên theo học phải dạy chương trình khóa học mà học viên đó đăng ký
create trigger TRIGGER10 on KQHT
for insert, update
as
begin
	declare @lopday char(5)
	declare @lophoc char(5)
	

	select @lopday =LH.ma_kh 
	from LOP_HOC as LH,inserted
	where LH.ma_lh=inserted.ma_lh
	if (@lopday not in 
						(select DANG_KY.ma_kh 
						from inserted,DANG_KY
						where inserted.ma_hv=DANG_KY.ma_hv)) 
		begin
			print N'Lớp đăng ký không trùng khớp'
			rollback transaction
		end
end
go
-- RBTV 11.1: MA_GV phải có dạng ‘GV%’
CREATE TRIGGER TRIGGER11 ON GIAO_VIEN
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Count INT = 0
	SELECT @Count = COUNT(*) FROM INSERTED WHERE MA_GV NOT LIKE 'GV%'
	IF(@Count > 0)
		BEGIN
			PRINT N'MA_GV không hợp lệ'
			ROLLBACK TRAN
		END
END
go
-- RBTV 11.2: MA_HV phải có dạng ‘HV%’
CREATE TRIGGER TRIGGER12 ON HOC_VIEN
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Count INT = 0
	SELECT @Count = COUNT(*) FROM INSERTED WHERE MA_HV NOT LIKE 'HV%'
	IF(@Count > 0)
		BEGIN
			PRINT N'MA_HV không hợp lệ'
			ROLLBACK TRAN
		END
END
go
-- RBTV 11.3: MA_LH phải có dạng ‘LH%’
CREATE TRIGGER TRIGGER13 ON LOP_HOC
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @Count INT = 0
	SELECT @Count = COUNT(*) FROM INSERTED WHERE MA_LH NOT LIKE 'LH%'
	IF(@Count > 0)
		BEGIN
			PRINT N'MA_LH không hợp lệ'
			ROLLBACK TRAN
		END
END
go
-- RBTV 12: Một lớp học có tối thiểu 5 học viên và tối đa 15 học viên
CREATE TRIGGER gioi_han_hoc_vien ON dbo.KQHT
AFTER INSERT, UPDATE 
AS 
BEGIN
	DECLARE @slhocvien INT 
	SELECT @slhocvien = COUNT(*) FROM (SELECT ma_lh, COUNT(*) AS soluong  FROM dbo.KQHT
                                   GROUP BY ma_lh
								   HAVING COUNT(*) <5 OR COUNT(*) >15) AS slhv
	IF @slhocvien > 0
	BEGIN
		PRINT 'LOP HOC THIEU THANH VIEN HOAC QUA SO LUONG QUY DINH'
		ROLLBACK TRAN
	END
END


insert LOP_HOC values ('LH009', N'TOEIC 2 KỸ NĂNG 600+', 'KH01', 'GV04', '20231002', '20231217')
insert KQHT values
('HV0021', 'LH009', null, 0, '20231002'),
('HV0022', 'LH009', null, 0, '20231002'),
('HV0023', 'LH009', null, 0, '20231002'),
('HV0024', 'LH009', null, 0, '20231002'),
('HV0025', 'LH009', null, 0, '20231002'),
('HV0002', 'LH009', null, 0, '20231002')
insert KQHT values
('HV0019', 'LH009', null, 0, '20231002')
insert DANG_KY values ('HV0025', 'KH01')

DECLARE @MAHV CHAR(6) = 'HV0001'
DECLARE @NGAY DATE = '20231027'
DECLARE @THU CHAR(6)
SET @THU = LEFT(DATENAME(WEEKDAY, @NGAY),3)
PRINT @THU
SELECT MA_HV, B3.* FROM
(SELECT B1.MA_HV, B1.MA_LH FROM (SELECT * FROM KQHT WHERE MA_HV = @MAHV) AS B1 JOIN LOP_HOC ON B1.MA_LH = LOP_HOC.MA_LH WHERE NGAY_DONG >= @NGAY AND @NGAY >= NGAY_MO) AS B2
JOIN
(SELECT PNC.MA_LH, NGAY_CA.MA_CA, PNC.MA_PHONG, NGAY_CA.MA_THU FROM PHONG_NGAY_CA PNC JOIN NGAY_CA ON PNC.MA_ID = NGAY_CA.MA_ID) AS B3
ON B2.MA_LH = B3.MA_LH WHERE MA_THU = @THU

-- Liệt kê những học viên sinh năm 2004 trở về sau
-- Danh sách những mã học viên vắng từ 3 buổi trở lên
-- Danh sách những mã học viên có điểm tổng kết bé hơn 7
-- Danh sách những mã học viên vắng từ 3 buổi trở lên và có điểm tổng kết bé hơn 7
select t2.[ma_hv], t2.[ma_lh], t1.[hoten_hv], t2.[diem], t2.[so_buoi_vang]
from HOC_VIEN t1, KQHT t2 where t1.[ma_hv] = t2.[ma_hv] and t2.[so_buoi_vang] > 2 and t2.[diem] < 7

SELECT * FROM HOC_VIEN
SELECT ma_hv, hoten_hv, namsinh_hv FROM HOC_VIEN WHERE NAMSINH_HV >= 2004

SELECT HOC_VIEN.ma_hv, HOC_VIEN.hoten_hv, KQHT.ma_hv, KQHT.ma_lh, KQHT.so_buoi_vang, KQHT.diem 
FROM HOC_VIEN, KQHT
WHERE HOC_VIEN.ma_hv = KQHT.ma_hv AND so_buoi_vang >=3 AND diem < 7

-- Danh sách những mã học viên vắng từ 3 buổi trở lên
SELECT KQHT.ma_hv FROM KQHT WHERE KQHT.so_buoi_vang >= 3

-- Danh sách những học viên vắng từ 3 buổi trở lên và có điểm tổng kết bé hơn 7
SELECT HOC_VIEN.hoten_hv FROM HOC_VIEN, KQHT WHERE HOC_VIEN.ma_hv = KQHT.ma_hv
AND KQHT.so_buoi_vang >= 3 AND KQHT.diem < 7
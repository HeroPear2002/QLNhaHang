drop database QLNhaHang
go
create database QLNhaHang

CREATE TABLE tb_ThucPham (
    IDThucPham int IDENTITY(1,1) PRIMARY KEY,
    TenThucPham nvarchar(50),
	DonViTinh nvarchar(50),
    HanSuDung int 
);
CREATE TABLE tb_File (
	IDFile int IDENTITY(1,1) PRIMARY KEY,
    TenFile nvarchar(50),
    
);
CREATE TABLE tb_NhapHang (
	IDNhapHang int IDENTITY(1,1) PRIMARY KEY,
    IDThucPham int,
    DinhLuong float,
    NgayNhap datetime,
	TonKho float,
	IDFile int,
	IsTrangThai int 
	FOREIGN KEY (IDThucPham) REFERENCES tb_ThucPham(IDThucPham),
	FOREIGN KEY (IDFile) REFERENCES tb_File(IDFile),
);
CREATE TABLE tb_LyDoXH (
	IDLyDo int IDENTITY(1,1) PRIMARY KEY,
    LyDoXuatHang nvarchar(50)
);
CREATE TABLE tb_XuatHang (
	IDXuatHang int IDENTITY(1,1) PRIMARY KEY,
    IDThucPham int,
    DinhLuong float,
    NgayXuat datetime,
	IDLyDo int 
	FOREIGN KEY (IDThucPham) REFERENCES tb_ThucPham(IDThucPham),
	FOREIGN KEY (IDLyDo) REFERENCES tb_LyDoXH(IDLyDo),
);

CREATE TABLE tb_MonAn (
    IDMonAn int IDENTITY(1,1) PRIMARY KEY,
    TenMon nvarchar(50),
    Gia money,
    IsMonAn int
	
);
CREATE TABLE tb_CongThucMonAn (
    IDCongThuc int IDENTITY(1,1) PRIMARY KEY,
    TenCongThuc nvarchar(50),
	IDMonAn int
	FOREIGN KEY (IDMonAn) REFERENCES tb_MonAn(IDMonAn),
);
CREATE TABLE tb_ChiTietCT (
    IDChiTietCT int IDENTITY(1,1) PRIMARY KEY,
	IDCongThuc int,
	IDThucPham int,
	DinhLuong float
	FOREIGN KEY (IDCongThuc) REFERENCES tb_CongThucMonAn(IDCongThuc),
	FOREIGN KEY (IDThucPham) REFERENCES tb_ThucPham(IDThucPham),
);
CREATE TABLE tb_DatBan (
    IDDatBan int IDENTITY(1,1) PRIMARY KEY,
    Tenban nvarchar(50),
    IsDatBan int
);

go
CREATE TABLE tb_GoiMon (
    IDGoiMon int IDENTITY(1,1) PRIMARY KEY,
    IDDatBan int,
    SoLuong int,
    IDMonAn int,
    IsGoiMon int,
    FOREIGN KEY (IDMonAn) REFERENCES tb_MonAn(IDMonAn),
    FOREIGN KEY (IDDatBan) REFERENCES tb_DatBan(IDDatBan)
);

INSERT INTO tb_ThucPham (TenThucPham, DonViTinh, HanSuDung)
VALUES
    ('Gạo', 'kg', 365),
    ('Thịt bò', 'kg', 3),
    ('Rau cải', 'bó', 7),
    ('Bún', 'kg', 3),
	('Trứng gà', 'quả', 30),
    ('Thịt gà', 'kg', 3),
	('Cua', 'kg', 3),
	('Bánh mì', 'cái', 7),
	('Thịt lợn', 'kg', 3),
	('Hành tây', 'củ', 180);


INSERT INTO tb_NhapHang (IDThucPham, DinhLuong, NgayNhap, TonKho, IsTrangThai)
VALUES
    (1, 100, '2024-07-01', 100, 1),
    (2, 50, '2024-07-02', 50, 1),
    (3, 30, '2024-07-03', 30, 1),
    (4, 80, '2024-07-04', 80, 1),
    (5, 120, '2024-07-05', 120, 1);

INSERT INTO tb_LyDoXH (LyDoXuatHang)
VALUES
    ('Bán cho khách hàng'),
    ('Hỏng hóc');

INSERT INTO tb_XuatHang (IDThucPham, DinhLuong, NgayXuat, IDLyDo)
VALUES
    (1, 50, '2024-07-06', 1),
    (2, 20, '2024-07-07', 1),
    (3, 10, '2024-07-08', 1),
    (4, 40, '2024-07-09', 1),
    (5, 60, '2024-07-10', 1);

INSERT INTO tb_MonAn (TenMon, Gia , IsMonAn)
VALUES
    ('Bún riêu cua', 50000, 1),
    ('Phở bò', 60000, 1),
    ('Bánh mì thịt nướng', 25000, 1),
	('Bún bò Huế', 60000, 1),
	('Bún chả', 60000, 1),
	('Cơm gà hấp', 60000, 1);
INSERT INTO tb_CongThucMonAn (TenCongThuc, IDMonAn)
VALUES
    ('Phở bò', 2),
    ('Cơm gà hấp', 6),
    ('Bún riêu cua', 1),
    ('Bánh mì thịt nướng', 3),
	('Bún bò Huế', 4),
    ('Bún chả', 5);

INSERT INTO tb_ChiTietCT (IDCongThuc, IDThucPham, DinhLuong)
VALUES
    (1, 1, 0.200), -- Gạo
    (1, 2, 0.100), -- Thịt bò
    (1, 3, 0.50),  -- Rau cải
    (1, 4, 0.150), -- Bún
    (1, 5, 2),   -- Trứng gà
	(2, 1, 0.150), -- Gạo
    (2, 6, 0.200), -- Gà
    (2, 3, 0.50),  -- Rau cải
    (2, 5, 1),   -- Trứng gà
	(3, 1, 0.100), -- Gạo
    (3, 7, 0.150), -- Cua
    (3, 3, 0.50),  -- Rau cải
    (3, 4, 0.100),  -- Bún
	(4, 8, 1),   -- Bánh mì
    (4, 9, 0.200), -- Thịt nướng
    (4, 3, 0.50),  -- Rau cải
    (4, 10, 0.5),  -- Hành tây
    (4, 5, 2),   -- Trứng gà
	(5, 1, 0.100),  -- Gạo
    (5, 9, 0.150), -- Thịt lợn
    (5, 3, 0.50),  -- Rau cải
    (5, 4, 0.100),  -- Bún
    (5, 5, 2);   -- Trứng gà


INSERT INTO tb_GoiMon (IDDatBan, SoLuong, IDMonAn, IsGoiMon)
VALUES
    (1, 2, 1, 1),
    (2, 1, 2, 1),
    (3, 3, 3, 1);

INSERT INTO tb_DatBan (Tenban, IsDatBan)
VALUES
    ('Bàn số 1', 1),
    ('Bàn số 2', 1),
    ('Bàn số 3', 1);

select a.IDMonAn, TenMon, SoLuong, Gia, (SoLuong * Gia) as thanhtien from  tb_MonAn a join tb_GoiMon b on a.IDMonAn = b.IDGoiMon join tb_DatBan c on b.IDDatBan = c.IDDatBan where IDGoiMon = 1 and b.IDDatBan = 1 or 
select b.IDGoiMon from  tb_MonAn a join tb_GoiMon b on a.IDMonAn = b.IDGoiMon join tb_DatBan c on b.IDDATBAN = c.IDDATBAN
select IDDatBan from tb_DatBan where TenBan = N'01' and isDatBan = 1
select IDMonAn from tb_MonAn where TenMon = N'Bún riêu cua' and isMonAn = 1
insert tb_GoiMon ([IDDatBan],[SoLuong],[IDMonAn],[IsGoiMon]) values (1,2,1,1)
insert tb_DatBan ([Tenban], [IsDatBan]) values ( '01',1)
Update tb_GoiMon set [IsGoiMon] = 0 where IDGOIMON = 1
Update tb_DatBan set IsDatBan = 0 where IdDatBan = 1
select IdMonAn, TenMon from tb_MonAn
select c.IDDatBan from  tb_MonAn a join tb_GoiMon b on a.IDMonAn = b.IDMonAn join tb_DatBan c on b.IDDatBan = c.IDDatBan where IsGoiMon = 1 and c.IsDatBan = 1 or TenBan = N'01' group by c.IDDatBan 

select Top(1)IDThucPham from tb_ThucPham order by IDThucPham desc
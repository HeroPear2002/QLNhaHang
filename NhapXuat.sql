update tb_NhapHang set TonKho = 1 where IDNhapHang = 1
update tb_NhapHang set IsTrangThai = 1 where TonKho = 0
insert tb_XuatHang(IDThucPham, DinhLuong, NgayXuat, IDLyDo) values ( @1 , @2, @3 , 0)
select SoLuong, IDCongThuc from tb_GoiMon gm join tb_MonAn ma on gm.IDMonAn = ma.IDMonAn where IDGoiMon = 1 -- cthuc mon an
Select IDThucPham, DinhLuong from tb_CongThucMonAn ctma join tb_ChiTietCT ctct on ctma.IDCongThuc = ctct.IDCongThuc where ctct.IDCongThuc = 1 --Lis thuc pham
select TonKho, NgayNhap from tb_NhapHang where IsTrangThai = 1 and IDThucPham = 6 Order by NgayNhap   -- lis nhap kho
select IDCongThuc from tb_MonAn where IDMonAn = 1 
select * from tb_ThucPham
update tb_ChiTietCT set DinhLuong = DinhLuong*1/100 where IDThucPham = 8 or IDThucPham = 11 or IDThucPham = 12 or IDThucPham = 14
insert tb_XuatHang(IDThucPham, DinhLuong, NgayXuat, IDLyDo) values ( @1 , @2, @3 , 2)
select TonKho from tb_NhapHang where 12- day(NgayNhap) > (select HanSuDung from tb_ThucPham where IDThucPham = 7 ) and IDThucPham = 7 and IsTrangThai = 1
update tb_NhapHang set TonKho = 0 where 12- day(NgayNhap) > (select HanSuDung from tb_ThucPham where IDThucPham = 7 ) and IDThucPham = 7 and IsTrangThai = 1
select Sum(TonKho) from tb_NhapHang where 2024 - day(NgayNhap) > 365 and IDThucPham = 6 and IsTrangThai = 1

select xh.IDXuatHang, TenThucPham, DonViTinh, DinhLuong, NgayXuat, LyDoXuatHang  from tb_XuatHang xh join tb_ThucPham tp on xh.IDThucPham = tp.IDThucPham join tb_LyDoXH ld on ld.IDLyDo = xh.IDLyDo
insert tb_XuatHang(IDThucPham, DinhLuong, NgayXuat, IDLyDo) values ( @1 , @2, @3 , 0)
update tb_XuatHang set IDThucPham = @1 , DinhLuong = @2 , NgayXuat = @3 , IDLyDo = @4 where IDXuatHang = @5
CREATE DATABASE KingDomGym;
GO

USE KingDomGym;
GO

CREATE TABLE taikhoan (
    tendangnhap VARCHAR(50) PRIMARY KEY,
    matkhau VARCHAR(100) NOT NULL
);

CREATE TABLE hoivien (
    mahv INT IDENTITY(1,1) PRIMARY KEY,
    ten NVARCHAR(100),
    gioitinh NVARCHAR(20),
    sdt VARCHAR(20)
);

CREATE TABLE pt (
    mapt INT IDENTITY(1,1) PRIMARY KEY,
    ten NVARCHAR(100),
    gioitinh NVARCHAR(20),
    sdt VARCHAR(20)
);

CREATE TABLE goitap (
    magoi INT IDENTITY(1,1) PRIMARY KEY,
    tengoi NVARCHAR(100) NOT NULL,
    giatien DECIMAL(18,0) NOT NULL
);

CREATE TABLE dangky (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoivien_mahv INT,
    goitap_magoi INT,
    pt_mapt INT NULL,
    ngay_dangky DATE,

    FOREIGN KEY (hoivien_mahv) REFERENCES hoivien(mahv),
    FOREIGN KEY (goitap_magoi) REFERENCES goitap(magoi),
    FOREIGN KEY (pt_mapt) REFERENCES pt(mapt)
);
GO

INSERT INTO taikhoan (tendangnhap, matkhau)
VALUES
('admin', '123456');

INSERT INTO hoivien (ten, gioitinh, sdt)
VALUES 
(N'Trịnh Anh Khoa', N'Nam', '123456789'),
(N'Lê Thị Ngọc Hân', N'Nữ', '123456798');

INSERT INTO pt (ten, gioitinh, sdt)
VALUES 
(N'Lê Minh Khoa', N'Nam', '012345678'),
(N'Lê Thị Tuyết An', N'Nữ', '012345679');

INSERT INTO goitap (tengoi, giatien)
VALUES 
(N'Gói tập 1 tháng', 250000),
(N'Gói tập 1 năm', 2800000);

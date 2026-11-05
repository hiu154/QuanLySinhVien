-- ===================================================================
-- DATABASE CREATION SCRIPT: QuanLySinhVienDB
-- Ứng dụng Quản lý Sinh viên - Kiến trúc 3 tầng (UI - BLL - DAL)
-- ===================================================================

USE master;
GO

IF DB_ID(N'QuanLySinhVienDB') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLySinhVienDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLySinhVienDB;
END
GO

CREATE DATABASE QuanLySinhVienDB;
GO

USE QuanLySinhVienDB;
GO

-- 1. BẢNG DEPARTMENTS (Khoa)
CREATE TABLE Departments (
    DepartmentID NVARCHAR(20) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 2. BẢNG CLASSES (Lớp học)
CREATE TABLE Classes (
    ClassID NVARCHAR(20) PRIMARY KEY,
    ClassName NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentID NVARCHAR(20) NOT NULL,
    AcademicYear NVARCHAR(20) NULL,
    HeadTeacher NVARCHAR(100) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Classes_Departments FOREIGN KEY (DepartmentID) 
        REFERENCES Departments(DepartmentID) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

-- 3. BẢNG STUDENTS (Sinh viên)
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentCode NVARCHAR(20) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(20) NULL,
    Address NVARCHAR(200) NULL,
    ClassID NVARCHAR(20) NOT NULL,
    AdmissionDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT N'Đang học',
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Students_Classes FOREIGN KEY (ClassID) 
        REFERENCES Classes(ClassID) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

-- 4. BẢNG SUBJECTS (Môn học)
CREATE TABLE Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectCode NVARCHAR(20) NOT NULL UNIQUE,
    SubjectName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL CHECK (Credits > 0 AND Credits <= 15),
    MidtermWeight DECIMAL(3,2) NOT NULL DEFAULT 0.40 CHECK (MidtermWeight >= 0 AND MidtermWeight <= 1),
    FinalWeight DECIMAL(3,2) NOT NULL DEFAULT 0.60 CHECK (FinalWeight >= 0 AND FinalWeight <= 1),
    Description NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 5. BẢNG SEMESTERS (Học kỳ)
CREATE TABLE Semesters (
    SemesterID NVARCHAR(20) PRIMARY KEY,
    SemesterName NVARCHAR(50) NOT NULL,
    SchoolYear NVARCHAR(20) NOT NULL,
    StartDate DATE NULL,
    EndDate DATE NULL,
    IsCurrent BIT NOT NULL DEFAULT 0
);
GO

-- 6. BẢNG ENROLLMENTS (Đăng ký môn học)
CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    SubjectID INT NOT NULL,
    SemesterID NVARCHAR(20) NOT NULL,
    EnrollmentDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(30) NOT NULL DEFAULT N'Đã đăng ký',
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentID) 
        REFERENCES Students(StudentID) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_Enrollments_Subjects FOREIGN KEY (SubjectID) 
        REFERENCES Subjects(SubjectID) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_Enrollments_Semesters FOREIGN KEY (SemesterID) 
        REFERENCES Semesters(SemesterID) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT UQ_Student_Subject_Semester UNIQUE (StudentID, SubjectID, SemesterID)
);
GO

-- 7. BẢNG GRADES (Điểm số & Kết quả)
CREATE TABLE Grades (
    GradeID INT IDENTITY(1,1) PRIMARY KEY,
    EnrollmentID INT NOT NULL UNIQUE,
    MidtermScore DECIMAL(4,2) NULL CHECK (MidtermScore IS NULL OR (MidtermScore >= 0.0 AND MidtermScore <= 10.0)),
    FinalScore DECIMAL(4,2) NULL CHECK (FinalScore IS NULL OR (FinalScore >= 0.0 AND FinalScore <= 10.0)),
    TotalScore DECIMAL(4,2) NULL CHECK (TotalScore IS NULL OR (TotalScore >= 0.0 AND TotalScore <= 10.0)),
    LetterGrade NVARCHAR(5) NULL,
    AcademicRank NVARCHAR(30) NULL,
    IsPassed BIT NULL,
    Notes NVARCHAR(255) NULL,
    UpdatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Grades_Enrollments FOREIGN KEY (EnrollmentID) 
        REFERENCES Enrollments(EnrollmentID) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

-- 8. BẢNG USERS (Tài khoản người dùng)
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(30) NOT NULL CHECK (Role IN (N'Admin', N'Teacher', N'Student')),
    Email NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(20) NULL,
    StudentID INT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    LastLogin DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Users_Students FOREIGN KEY (StudentID) 
        REFERENCES Students(StudentID) ON UPDATE CASCADE ON DELETE SET NULL
);
GO

-- 9. BẢNG SYSTEMLOGS (Nhật ký hệ thống - Chương 8)
CREATE TABLE SystemLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Timestamp DATETIME DEFAULT GETDATE(),
    LogLevel NVARCHAR(20) NOT NULL,
    Username NVARCHAR(50) NULL,
    Action NVARCHAR(100) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    ExceptionDetails NVARCHAR(MAX) NULL
);
GO

-- ===================================================================
-- SEED DATA (DỮ LIỆU KHỞI TẠO MẪU ĐẦY ĐỦ)
-- ===================================================================

-- 1. Khoa
INSERT INTO Departments (DepartmentID, DepartmentName, Description) VALUES
(N'CNTT', N'Công nghệ thông tin', N'Khoa đào tạo CNTT, Kỹ thuật phần mềm, An toàn thông tin'),
(N'KTe', N'Kinh tế & Quản trị kinh doanh', N'Khoa đào tạo QTKD, Marketing, Tài chính ngân hàng'),
(N'DTVT', N'Điện tử viễn thông', N'Khoa đào tạo Kỹ thuật điện tử, IoT và Viễn thông'),
(N'NNgu', N'Ngoại ngữ', N'Khoa đào tạo Ngôn ngữ Anh, Ngôn ngữ Nhật');
GO

-- 2. Lớp học
INSERT INTO Classes (ClassID, ClassName, DepartmentID, AcademicYear, HeadTeacher) VALUES
(N'21CNTT1', N'Lớp CNTT 1 - K21', N'CNTT', N'2021-2025', N'ThS. Nguyễn Văn Toàn'),
(N'21CNTT2', N'Lớp CNTT 2 - K21', N'CNTT', N'2021-2025', N'TS. Lê Thị Mai'),
(N'22KTPM1', N'Lớp Kỹ thuật phần mềm 1 - K22', N'CNTT', N'2022-2026', N'TS. Trần Hữu Đức'),
(N'22QTKD1', N'Lớp Quản trị kinh doanh 1 - K22', N'KTe', N'2022-2026', N'ThS. Hoàng Thu Thủy'),
(N'23DTVT1', N'Lớp Điện tử viễn thông 1 - K23', N'DTVT', N'2023-2027', N'ThS. Đỗ Minh Khang'),
(N'23NNA01', N'Lớp Ngôn ngữ Anh 1 - K23', N'NNgu', N'2023-2027', N'ThS. Phạm Ngọc Lan');
GO

-- 3. Sinh viên
INSERT INTO Students (StudentCode, FullName, DateOfBirth, Gender, Email, PhoneNumber, Address, ClassID, AdmissionDate, Status) VALUES
(N'SV001', N'Nguyễn Văn An', '2003-05-15', N'Nam', N'an.nguyen@student.edu.vn', N'0912345671', N'Hà Nội', N'21CNTT1', '2021-09-01', N'Đang học'),
(N'SV002', N'Trần Thị Bích', '2003-08-20', N'Nữ', N'bich.tran@student.edu.vn', N'0912345672', N'Hải Phòng', N'21CNTT1', '2021-09-01', N'Đang học'),
(N'SV003', N'Lê Hoàng Cường', '2003-02-10', N'Nam', N'cuong.le@student.edu.vn', N'0912345673', N'Đà Nẵng', N'21CNTT2', '2021-09-01', N'Đang học'),
(N'SV004', N'Phạm Mỹ Dung', '2004-11-25', N'Nữ', N'dung.pham@student.edu.vn', N'0912345674', N'TP. Hồ Chí Minh', N'22KTPM1', '2022-09-01', N'Đang học'),
(N'SV005', N'Đỗ Minh Em', '2004-03-30', N'Nam', N'em.do@student.edu.vn', N'0912345675', N'Cần Thơ', N'22KTPM1', '2022-09-01', N'Bảo lưu'),
(N'SV006', N'Vũ Thị Giang', '2004-07-12', N'Nữ', N'giang.vu@student.edu.vn', N'0912345676', N'Nam Định', N'22QTKD1', '2022-09-01', N'Đang học'),
(N'SV007', N'Bùi Quang Hải', '2005-09-18', N'Nam', N'hai.bui@student.edu.vn', N'0912345677', N'Quảng Ninh', N'23DTVT1', '2023-09-01', N'Đang học'),
(N'SV008', N'Ngô Thùy Linh', '2005-12-05', N'Nữ', N'linh.ngo@student.edu.vn', N'0912345678', N'Huế', N'23NNA01', '2023-09-01', N'Đang học'),
(N'SV009', N'Đặng Quốc Nam', '2003-01-22', N'Nam', N'nam.dang@student.edu.vn', N'0912345679', N'Bắc Ninh', N'21CNTT1', '2021-09-01', N'Nghỉ học'),
(N'SV010', N'Hoàng Yến Oanh', '2004-04-14', N'Nữ', N'oanh.hoang@student.edu.vn', N'0912345680', N'Thanh Hóa', N'22KTPM1', '2022-09-01', N'Đang học');
GO

-- 4. Môn học
INSERT INTO Subjects (SubjectCode, SubjectName, Credits, MidtermWeight, FinalWeight, Description) VALUES
(N'CS101', N'Lập trình C# căn bản', 3, 0.40, 0.60, N'Cơ sở ngôn ngữ C# và .NET Framework'),
(N'DB201', N'Cơ sở dữ liệu & SQL Server', 4, 0.40, 0.60, N'Thiết kế CSDL quan hệ, T-SQL, Stored Procedures'),
(N'SE301', N'Công nghệ phần mềm & 3 Tầng', 3, 0.30, 0.70, N'Mô hình phát triển phần mềm, UI-BLL-DAL, Clean Code'),
(N'NET401', N'Lập trình WinForms nâng cao', 3, 0.40, 0.60, N'WinForms, ADO.NET, DataBinding, Báo cáo'),
(N'ENG101', N'Tiếng Anh chuyên ngành CNTT', 2, 0.50, 0.50, N'Thuật ngữ và giao tiếp kỹ thuật CNTT');
GO

-- 5. Học kỳ
INSERT INTO Semesters (SemesterID, SemesterName, SchoolYear, StartDate, EndDate, IsCurrent) VALUES
(N'HK1_2024_2025', N'Học kỳ 1', N'2024-2025', '2024-09-05', '2025-01-15', 0),
(N'HK2_2024_2025', N'Học kỳ 2', N'2024-2025', '2025-02-15', '2025-06-30', 0),
(N'HK1_2025_2026', N'Học kỳ 1', N'2025-2026', '2025-09-05', '2026-01-15', 1),
(N'HK2_2025_2026', N'Học kỳ 2', N'2025-2026', '2026-02-15', '2026-06-30', 0);
GO

-- 6. Đăng ký môn học & 7. Điểm số
-- Sinh viên 1 (SV001 - An)
INSERT INTO Enrollments (StudentID, SubjectID, SemesterID) VALUES
(1, 1, N'HK1_2024_2025'), -- C#
(1, 2, N'HK1_2024_2025'), -- DB
(1, 3, N'HK1_2025_2026'); -- SE

-- Điểm cho SV001
-- C#: Midterm = 8.5, Final = 9.0 => Total = 8.5*0.4 + 9.0*0.6 = 8.8 (Giỏi, A)
INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES (1, 8.50, 9.00, 8.80, N'A', N'Giỏi', 1, N'Học tập tốt, tích cực');

-- DB: Midterm = 9.0, Final = 9.5 => Total = 9.0*0.4 + 9.5*0.6 = 9.3 (Xuất sắc, A+)
INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES (2, 9.00, 9.50, 9.30, N'A+', N'Xuất sắc', 1, N'Xuất sắc');

-- SE: Midterm = 8.0, Final = 7.5 => Total = 8.0*0.3 + 7.5*0.7 = 7.65 (Khá, B+)
INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES (3, 8.00, 7.50, 7.65, N'B+', N'Khá', 1, N'Đạt yêu cầu');

-- Sinh viên 2 (SV002 - Bích)
INSERT INTO Enrollments (StudentID, SubjectID, SemesterID) VALUES
(2, 1, N'HK1_2024_2025'),
(2, 2, N'HK1_2024_2025');

INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES 
(4, 7.00, 6.50, 6.70, N'B', N'Khá', 1, N'Hoàn thành khá tốt'),
(5, 8.00, 8.50, 8.30, N'A', N'Giỏi', 1, N'Chăm chỉ');

-- Sinh viên 3 (SV003 - Cường)
INSERT INTO Enrollments (StudentID, SubjectID, SemesterID) VALUES
(3, 1, N'HK1_2024_2025'),
(3, 2, N'HK1_2024_2025');

-- Điểm yếu để test cảnh báo học vụ
INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES 
(6, 4.00, 3.50, 3.70, N'F', N'Yếu', 0, N'Cần thi lại / học lại'),
(7, 5.00, 4.50, 4.70, N'D', N'Trung bình', 1, N'Qua môn vớt');

-- Sinh viên 4 (SV004 - Dung)
INSERT INTO Enrollments (StudentID, SubjectID, SemesterID) VALUES
(4, 1, N'HK1_2025_2026'),
(4, 3, N'HK1_2025_2026');

INSERT INTO Grades (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes)
VALUES 
(8, 9.50, 9.00, 9.20, N'A+', N'Xuất sắc', 1, N'Thành tích xuất sắc'),
(9, 8.50, 8.50, 8.50, N'A', N'Giỏi', 1, N'Nắm vững kiến thức');

-- 8. Tài khoản người dùng (Users)
-- Mật khẩu mặc định là: 123456
-- Hash SHA-256 của ("123456" + "QlsV2026Salt!") = 43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915
INSERT INTO Users (Username, PasswordHash, Salt, FullName, Role, Email, PhoneNumber, StudentID, IsActive) VALUES
(N'admin', N'43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915', N'QlsV2026Salt!', N'Quản trị viên Hệ thống', N'Admin', N'admin@qlsv.edu.vn', N'0901234567', NULL, 1),
(N'giangvien1', N'43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915', N'QlsV2026Salt!', N'ThS. Nguyễn Văn Toàn', N'Teacher', N'toan.nv@qlsv.edu.vn', N'0907654321', NULL, 1),
(N'giangvien2', N'43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915', N'QlsV2026Salt!', N'TS. Lê Thị Mai', N'Teacher', N'mai.lt@qlsv.edu.vn', N'0908889999', NULL, 1),
(N'sv001', N'43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915', N'QlsV2026Salt!', N'Nguyễn Văn An', N'Student', N'an.nguyen@student.edu.vn', N'0912345671', 1, 1),
(N'sv002', N'43a355d94bdc2b59538815e054aeb4665db4a394ef880e84f57f13eb05ca0915', N'QlsV2026Salt!', N'Trần Thị Bích', N'Student', N'bich.tran@student.edu.vn', N'0912345672', 2, 1);
GO

-- 9. Nhật ký hệ thống mẫu
INSERT INTO SystemLogs (LogLevel, Username, Action, Message) VALUES
(N'Information', N'SYSTEM', N'DATABASE_INIT', N'Khởi tạo cơ sở dữ liệu QuanLySinhVienDB thành công.'),
(N'Information', N'admin', N'LOGIN', N'Quản trị viên đăng nhập hệ thống lần đầu.'),
(N'Information', N'admin', N'SEED_DATA', N'Đã nạp danh sách khoa, lớp, môn học và sinh viên mẫu.');
GO

PRINT N'=== TẠO DATABASE VÀ DỮ LIỆU MẪU QUAN LÝ SINH VIÊN THÀNH CÔNG! ===';
GO

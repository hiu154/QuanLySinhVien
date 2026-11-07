# HỆ THỐNG QUẢN LÝ SINH VIÊN (STUDENT MANAGEMENT SYSTEM)

> **Môn học**: Công nghệ Phần mềm / Phát triển Ứng dụng .NET  
> **Nền tảng**: C# .NET 10 (Windows Forms) & Microsoft SQL Server  
> **Kiến trúc**: 3 Tầng chuẩn Enterprise (UI - BLL - DAL - DTO)  
> **Kiểm thử**: xUnit Testing (41/41 Unit Tests Passed)  

---

## BẢNG PHÂN CÔNG NHIỆM VỤ THÀNH VIÊN (AI LÀM GÌ)

| STT | Họ và Tên | Vai trò | Trách nhiệm chính | File mã nguồn phụ trách | Tỷ lệ đóng góp |
|:---:|:---|:---|:---|:---|:---:|
| **1** | **Lâm Tấn Hiếu**<br>`jes2006.vn@gmail.com` | **Trưởng nhóm**<br>Kiến trúc sư hệ thống | • Thiết kế kiến trúc 3 tầng & Cơ sở dữ liệu 9 bảng<br>• Core DAL: `DbConnectionFactory` (tự động nhận diện SQL Server)<br>• UI Shell: `FrmMain`, Sidebar động, `FrmLogin`, `FrmDbConfig`<br>• Thư viện giao diện `UiHelper` (Icon Vector GDI+ phẳng, DoubleBuffered)<br>• Xác thực tài khoản SHA-256 + Salt & Phân quyền RBAC<br>• Cơ chế khôi phục quyền động khi đổi tài khoản (Switch User)<br>• Nhập & Quản lý điểm số `FrmGrade`<br>• Thiết kế & hiện thực 41 bộ kiểm thử tự động xUnit | `DbConnectionFactory.cs`<br>`UiHelper.cs`<br>`FrmMain.cs`, `FrmLogin.cs`<br>`FrmGrade.cs`<br>`AuthBLL.cs`, `UserDAL.cs`<br>`QuanLySinhVien.Tests/*` | **100%** |
| **2** | **Thái Phương Trinh**<br>`thaitrinh2346@gmail.com` | **Thành viên**<br>Phân tích & Thống kê | • Module Báo cáo Thống kê & Phân tích Học vụ<br>• Dashboard 5 chỉ số KPI tổng quan toàn trường (`FrmStatistics`)<br>• Tự động thống kê & lọc sinh viên cảnh báo học vụ (Điểm < 5.0)<br>• Xuất dữ liệu báo cáo ra file CSV/Excel (chuẩn UTF-8 BOM chống lỗi font)<br>• Thuật toán tính điểm có trọng số, xếp loại và quy đổi GPA hệ 4<br>• Module Quản lý Môn học & Tín chỉ (`FrmSubject`)<br>• Đăng ký môn học & Kiểm tra trùng lịch / giới hạn tín chỉ | `StatisticsDTO/DAL/BLL.cs`<br>`FrmStatistics.cs`<br>`SubjectDTO/DAL/BLL.cs`<br>`FrmSubject.cs`<br>`EnrollmentDTO/DAL/BLL.cs`<br>`SemesterBLL.cs` | **100%** |
| **3** | **Lý Yến Trang**<br>`lyyentrang169@gmail.com` | **Thành viên**<br>Quản lý Hồ sơ & Bảo mật | • Module Quản lý Hồ sơ Sinh viên CRUD & Bộ lọc tìm kiếm (`FrmStudent`)<br>• Module Quản lý Cơ cấu Đào tạo: Khoa & Lớp sinh hoạt (`FrmClassDepartment`)<br>• Nghiệp vụ Toàn quyền điều chuyển sinh viên giữa các lớp<br>• Quản lý danh mục Học kỳ & Đợt đăng ký môn học<br>• Quản trị tài khoản người dùng: Phân quyền, Khóa/Mở khóa, Reset mật khẩu (`FrmUserAccount`)<br>• Module Nhật ký hệ thống Audit Log & Giám sát lỗi ngoại lệ Exception (`FrmSystemLogs`)<br>• Xây dựng hệ thống ghi log đa luồng `AppLogger` | `StudentDTO/DAL/BLL.cs`<br>`FrmStudent.cs`<br>`DepartmentDTO/DAL/BLL.cs`<br>`ClassDTO/DAL/BLL.cs`<br>`FrmClassDepartment.cs`<br>`FrmUserAccount.cs`<br>`AppLogDTO/DAL/BLL.cs`<br>`AppLogger.cs`, `FrmSystemLogs.cs` | **100%** |

---

## CHI TIẾT CÔNG VIỆC TỪNG THÀNH VIÊN

### 1. Lâm Tấn Hiếu (Trưởng nhóm - Kiến trúc hệ thống, Giao diện chính, Bảo mật & Testing)
- **Kiến trúc & Cơ sở dữ liệu**:
  - Khởi tạo cấu trúc giải pháp đa dự án (`QuanLySinhVien` và `QuanLySinhVien.Tests`).
  - Soạn thảo kịch bản SQL Server chuẩn hóa (`01_CreateDatabase_QLSV.sql`) gồm 9 bảng quan hệ chặt chẽ: `Departments`, `Classes`, `Students`, `Subjects`, `Semesters`, `Enrollments`, `Grades`, `Users`, `SystemLogs`.
  - Cài đặt `DbConnectionFactory.cs` thông minh: Tự động quét và phát hiện các SQL Server Instance khả dụng (`(localdb)\MSSQLLocalDB`, `.\SQLEXPRESS`, `.` localhost), tự động tạo CSDL mẫu nếu máy mới chưa có, tự động nạp dữ liệu hạt giống (Seed Data).
  - Xây dựng form cấu hình kết nối linh hoạt `FrmDbConfig` cho phép người dùng tùy chỉnh chuỗi kết nối khi triển khai trên máy khác.
- **Xác thực, Phân quyền & Quản lý phiên làm việc**:
  - Hiện thực `UserDTO`, `UserDAL` kết hợp hàm băm mật khẩu `SHA-256 + Salt` chống tấn công vét cạn.
  - Thiết kế `FrmLogin` giao diện chia đôi hiện đại, có nút kiểm tra tình trạng kết nối CSDL theo thời gian thực.
  - Xây dựng cơ chế **Khôi phục toàn bộ quyền giao diện động (Dynamic Switch User)**: Giúp người dùng đăng xuất và đổi tài khoản giữa Quản trị viên và Giảng viên mà không bị mất quyền hoặc phải tắt mở lại ứng dụng.
  - Hiện thực form Đổi mật khẩu cá nhân `FrmChangePassword`.
- **Giao diện Shell & Trải nghiệm người dùng (UI/UX Core)**:
  - Thiết kế form chính `FrmMain` với Sidebar điều hướng tự động co giãn và hiển thị theo quyền người dùng đăng nhập.
  - Xây dựng thư viện dùng chung `UiHelper.cs`:
    - Bộ tạo biểu tượng vector phẳng vẽ bằng C# GDI+ (`SmoothingMode.AntiAlias`) độ nét cao 18×18 (Dashboard, Sinh viên, Khoa lớp, Môn học, Bảng điểm, Thống kê, Tài khoản, Nhật ký, Đổi mật khẩu, Đăng xuất). Loại bỏ hoàn toàn emoji và các ký tự giả lập AI.
    - Phương thức tối ưu `StyleDataGridView`: Bật bộ đệm kép `DoubleBuffered` chống giật hình bằng Reflection, cấu hình `AutoSizeColumnsMode = Fill` giúp bảng biểu tự động dãn tràn khung nhìn, chuẩn hóa màu tiêu đề xám than Slate 800 (`#1E293B`) và highlight mềm mại (`#DBEAFE`).
- **Phân hệ Quản lý & Nhập điểm**:
  - Xây dựng `GradeDTO`, `GradeDAL` và giao diện `FrmGrade`.
  - Phân quyền điểm: Cho phép Giáo viên chọn lớp học phần mình phụ trách để nhập điểm; Quản trị viên có toàn quyền can thiệp điểm số toàn trường.
- **Kiểm thử tự động (Unit Testing)**:
  - Xây dựng toàn bộ dự án `QuanLySinhVien.Tests` với **41 test case xUnit** bao phủ toàn bộ các tầng nghiệp vụ: `AuthBLLTests`, `StudentBLLTests`, `GradeBLLTests`, `StatisticsBLLTests`, `AppLoggerTests`.

---

### 2. Thái Phương Trinh (Thành viên - Phân tích Dữ liệu, Thống kê & Quản lý Học phần)
- **Module Báo cáo Thống kê & Phân tích Học vụ (Dashboard Analytics)**:
  - Thiết kế mô hình dữ liệu `StatisticsDTO`.
  - Cài đặt tầng truy vấn dữ liệu `StatisticsDAL`: Truy vấn kết hợp dữ liệu toàn trường, tính toán điểm trung bình tích lũy, tỷ lệ sinh viên Đạt / Trượt theo từng môn học và từng lớp sinh hoạt.
  - Hiện thực logic nghiệp vụ `StatisticsBLL`: Tự động quét và phát hiện các sinh viên rơi vào diện **Cảnh báo học vụ** (Điểm tổng kết < 5.0).
  - Thiết kế giao diện Dashboard `FrmStatistics`:
    - 5 Thẻ KPI nổi bật (Tổng số sinh viên, Số lớp sinh hoạt, Số môn học, Điểm trung bình toàn trường, Tỷ lệ đạt).
    - Bảng danh sách sinh viên bị cảnh báo học vụ kèm mã SV, họ tên, lớp và điểm số chi tiết.
- **Tính toán Điểm số chuyên sâu & Xuất dữ liệu**:
  - Nâng cấp `GradeBLL`: Thuật toán tự động tính điểm tổng kết có trọng số (Quá trình, Giữa kỳ, Cuối kỳ) theo tỷ lệ cấu hình của từng môn học.
  - Tự động quy đổi sang thang điểm chữ (A+, A, B+, B, C+, C, D+, D, F) và thang điểm 4 (GPA).
  - Xây dựng tính năng xuất bảng điểm và danh sách sinh viên ra file CSV / Excel với chuẩn mã hóa **UTF-8 with BOM** (chống lỗi hiển thị font tiếng Việt khi mở trên Microsoft Excel).
- **Module Quản lý Môn học & Đăng ký Học phần**:
  - Định nghĩa thực thể `SubjectDTO`, cài đặt `SubjectDAL` và `SubjectBLL`: Thêm môn học mới, cập nhật số tín chỉ, thiết lập tỷ lệ trọng số điểm GK/CK linh hoạt cho từng môn.
  - Thiết kế form `FrmSubject` phục vụ quản lý danh mục môn học.
  - Xây dựng `EnrollmentDTO`, `EnrollmentDAL`, `EnrollmentBLL`: Đăng ký môn học, kiểm tra điều kiện trùng lịch học và khống chế số lượng tín chỉ đăng ký tối đa/tối thiểu trong học kỳ.
  - Cài đặt `SemesterBLL`: Thiết lập danh mục học kỳ và mở/đóng đợt đăng ký môn học.

---

### 3. Lý Yến Trang (Thành viên - Quản lý Sinh viên, Cơ cấu Tổ chức, Phân quyền & Audit Log)
- **Module Quản lý Hồ sơ Sinh viên (Student Profile Management)**:
  - Định nghĩa thực thể dữ liệu `StudentDTO` với đầy đủ các thuộc tính thông tin cá nhân, liên hệ, ngày nhập học, lớp sinh hoạt và tình trạng học tập.
  - Cài đặt tầng truy cập dữ liệu `StudentDAL`: Thực hiện các thao tác CRUD (Thêm mới, Cập nhật thông tin, Xóa hồ sơ sinh viên, Kiểm tra chống trùng mã sinh viên hoặc email).
  - Hiện thực nghiệp vụ `StudentBLL`: Kiểm tra ràng buộc hợp lệ dữ liệu đầu vào (độ tuổi, định dạng email, số điện thoại, ngày nhập học), tích hợp cơ chế tìm kiếm đa năng (theo Mã SV, Họ tên, Khoa, Lớp, Trạng thái học tập).
  - Thiết kế giao diện `FrmStudent` trực quan, bố cục rõ ràng với các nút hành động thuần Việt (Thêm mới, Cập nhật, Xóa, Làm mới, Tìm kiếm).
- **Module Cơ cấu Tổ chức & Đào tạo (Academic Structure)**:
  - Xây dựng `DepartmentDTO`, `DepartmentDAL`, `DepartmentBLL`: Thêm, sửa, xóa Khoa trực thuộc.
  - Xây dựng `ClassDTO`, `ClassDAL`, `ClassBLL`: Quản lý danh mục Lớp sinh hoạt, liên kết khóa ngoại với Khoa.
  - Thiết kế giao diện `FrmClassDepartment` dạng Tab đôi quản lý đồng thời cả Khoa và Lớp sinh hoạt.
  - Hiện thực tính năng **Điều chuyển lớp học**: Cho phép chuyển sinh viên sang lớp mới và tự động cập nhật sĩ số sinh viên của từng lớp.
- **Module Quản trị Tài khoản & Phân quyền (User Administration)**:
  - Thiết kế giao diện `FrmUserAccount` cho Quản trị viên.
  - Mở rộng `UserDAL` và `AuthBLL`: Tạo tài khoản mới, phân quyền (Admin / Teacher / Student), Khóa / Mở khóa tài khoản người dùng, Reset mật khẩu về mặc định (`123456`).
- **Module Nhật ký Hệ thống & Giám sát An toàn (Audit Logging & Security)**:
  - Xây dựng module ghi vết đa luồng `AppLogger` ghi log song song ra Console, File đĩa và bảng `SystemLogs` trong SQL Server.
  - Định nghĩa `AppLogDTO`, `AppLogDAL`, `AppLogBLL`: Lưu vết chi tiết danh tính người thao tác, hành động thêm/sửa/xóa, thời điểm và nội dung thay đổi dữ liệu.
  - Thiết kế giao diện `FrmSystemLogs`: Tra cứu lịch sử thao tác, bộ lọc theo mức độ log (`Information`, `Warning`, `Error`), giám sát lỗi ngoại lệ hệ thống giúp kịp thời xử lý sự cố.

---

## MA TRẬN CHỨC NĂNG & PHÂN QUYỀN HỆ THỐNG

| Nhóm chức năng | Chức năng cụ thể | Quản trị viên (Admin) | Giảng viên (Teacher) | Sinh viên (Student) | Người phụ trách |
|:---|:---|:---:|:---:|:---:|:---|
| **Bàn làm việc** | Xem 5 chỉ số KPI tổng quan | Có | Có (Theo lớp) | Không | Thái Phương Trinh |
| | Cảnh báo học vụ (Điểm < 5.0) | Có | Có (Theo lớp) | Không | Thái Phương Trinh |
| **Quản lý Sinh viên** | Xem danh sách & Tìm kiếm sinh viên | Có | Có (Theo lớp) | Không | Lý Yến Trang |
| | Thêm mới, Sửa hồ sơ sinh viên | Có | Không | Không | Lý Yến Trang |
| | Xóa hồ sơ sinh viên | Có | Không | Không | Lý Yến Trang |
| **Khoa & Lớp học** | Xem danh mục Khoa & Lớp | Có | Có (Chỉ xem) | Không | Lý Yến Trang |
| | Thêm, sửa, xóa Khoa & Lớp | Có | Không | Không | Lý Yến Trang |
| | Điều chuyển sinh viên giữa các lớp | Có | Không | Không | Lý Yến Trang |
| **Môn học & Học phần** | Xem danh mục Môn học | Có | Có (Chỉ xem) | Có (Xem) | Thái Phương Trinh |
| | Thêm, sửa môn, sửa số tín chỉ | Có | Không | Không | Thái Phương Trinh |
| | Cấu hình trọng số điểm GK/CK | Có | Không | Không | Thái Phương Trinh |
| | Mở/đóng đợt đăng ký môn học | Có | Không | Không | Thái Phương Trinh |
| **Quản lý Điểm số** | Tra cứu bảng điểm sinh viên | Toàn trường | Theo lớp phụ trách | Cá nhân | Lâm Tấn Hiếu |
| | Nhập & sửa điểm quá trình, điểm thi | Toàn trường | Lớp phụ trách | Không | Lâm Tấn Hiếu |
| | Tự động tính điểm tổng kết & GPA hệ 4 | Có | Có | Có (Xem) | Thái Phương Trinh |
| | Xuất bảng điểm ra Excel/CSV (UTF-8 BOM) | Có | Có | Không | Thái Phương Trinh |
| **Báo cáo Thống kê** | Thống kê tỷ lệ Đạt / Trượt môn | Toàn trường | Lớp phụ trách | Không | Thái Phương Trinh |
| | Xuất báo cáo thống kê | Có | Có | Không | Thái Phương Trinh |
| **Quản trị Tài khoản** | Tạo mới tài khoản người dùng | Có | Không | Không | Lý Yến Trang |
| | Phân quyền Admin / Teacher / Student | Có | Không | Không | Lý Yến Trang |
| | Khóa / Mở khóa tài khoản | Có | Không | Không | Lý Yến Trang |
| | Reset mật khẩu về mặc định | Có | Không | Không | Lý Yến Trang |
| **Nhật ký & Bảo mật** | Xem Audit Log (Ai thêm/sửa/xóa gì) | Có | Không | Không | Lý Yến Trang |
| | Giám sát lỗi Exception hệ thống | Có | Không | Không | Lý Yến Trang |
| **Cá nhân & Tiện ích** | Đổi mật khẩu cá nhân | Có | Có | Có | Lâm Tấn Hiếu |
| | Cấu hình kết nối CSDL linh hoạt | Có | Không | Không | Lâm Tấn Hiếu |

---

## ĐẶC TẢ KỸ THUẬT & CÔNG NGHỆ ÁP DỤNG

1. **Mô hình kiến trúc 3 tầng (3-Tier Architecture)**:
   - **Tầng Trình diễn (Presentation Layer - UI)**: Windows Forms (.NET 10), giao diện Fluent UI, xử lý bất đồng bộ `async/await` chống đơ cửa sổ khi tải dữ liệu lớn.
   - **Tầng Nghiệp vụ (Business Logic Layer - BLL)**: Thực hiện kiểm tra toàn vẹn dữ liệu, tính toán điểm số có trọng số, thuật toán quy đổi điểm GPA, lọc cảnh báo học vụ, xử lý logic phân quyền.
   - **Tầng Truy cập Dữ liệu (Data Access Layer - DAL)**: Sử dụng ADO.NET thuần (`SqlConnection`, `SqlCommand`, `SqlDataReader`, `SqlTransaction`) được tối ưu hóa truy vấn có tham số (`SqlParameter`) nhằm ngăn chặn triệt để lỗ hổng SQL Injection.
   - **Tầng Thực thể (Data Transfer Object - DTO)**: Chứa các lớp truyền tải dữ liệu độc lập giữa các tầng.

2. **Giao diện người dùng & Đồ họa**:
   - Sử dụng **Vector Icons vẽ trực tiếp bằng C# GDI+** (`System.Drawing.Drawing2D.SmoothingMode.AntiAlias`): Cho chất lượng hiển thị sắc nét, không vỡ nét trên màn hình High-DPI, hoàn toàn độc lập với font hệ thống, không bị lỗi font ô vuông `▯` hay dấu hỏi `??`.
   - DataGridView hỗ trợ **DoubleBuffered bằng Reflection**: Loại bỏ triệt để hiện tượng nhấp nháy màn hình (flickering), chế độ tự co giãn `Fill` lấp đầy toàn bộ khung nhìn hiển thị.

3. **Bảo mật & Xác thực**:
   - Mật khẩu được mã hóa một chiều bằng giải thuật `SHA-256` kết hợp chuỗi `Salt` ngẫu nhiên lưu trong CSDL.
   - Phân quyền theo vai trò (Role-Based Access Control - RBAC) tại cả tầng giao diện (ẩn/hiện chức năng) và tầng nghiệp vụ BLL.

4. **Kiểm thử tự động (Unit Testing)**:
   - Sử dụng framework **xUnit** và bộ thư viện Assertions để kiểm tra độ tin cậy của mã nguồn.
   - Đạt tỷ lệ hoàn thành **41/41 test case** (100% Passed) cho các ca kiểm thử xác thực, tính điểm, xếp loại, cảnh báo học vụ và ghi log.

---

## HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### 1. Yêu cầu môi trường
- Hệ điều hành: Windows 10 / 11.
- .NET SDK: Phiên bản **.NET 10.0** trở lên.
- Hệ quản trị CSDL: Microsoft SQL Server (bản LocalDB, Express, hoặc Developer/Enterprise).

### 2. Khởi chạy ứng dụng
- Mở Terminal tại thư mục dự án và thực thi lệnh:
  ```powershell
  dotnet build QuanLySinhVien/QuanLySinhVien.sln
  dotnet run --project QuanLySinhVien/QuanLySinhVien/QuanLySinhVien.csproj
  ```
- **Cơ chế tự động**: Ứng dụng sẽ tự động dò tìm SQL Server trên máy bạn, tự động tạo CSDL `QuanLySinhVienDB` và tự động nạp sẵn dữ liệu mẫu ban đầu nếu CSDL chưa tồn tại.

### 3. Danh sách tài khoản thử nghiệm có sẵn
| Tên đăng nhập | Mật khẩu mặc định | Vai trò | Họ và tên |
|:---|:---:|:---:|:---|
| `admin` | `123456` | **Quản trị viên** | Quản trị viên Hệ thống |
| `giangvien1` | `123456` | **Giảng viên** | ThS. Nguyễn Văn Toàn |
| `giangvien2` | `123456` | **Giảng viên** | TS. Lê Thị Mai |
| `sv001` | `123456` | **Sinh viên** | Nguyễn Văn An |
| `sv002` | `123456` | **Sinh viên** | Trần Thị Bích |

### 4. Chạy bộ kiểm thử Unit Tests
```powershell
dotnet test QuanLySinhVien.Tests/QuanLySinhVien.Tests.csproj
```
Kết quả mong đợi: `Passed! - Failed: 0, Passed: 41, Skipped: 0, Total: 41`.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    /// <summary>
    /// Business Logic Layer cho Sinh viên (Chương 9)
    /// Kiểm tra toàn bộ quy tắc nghiệp vụ trước khi gọi DAL.
    /// </summary>
    public class StudentBLL
    {
        private readonly StudentDAL _dal;

        public StudentBLL(StudentDAL? dal = null)
        {
            _dal = dal ?? new StudentDAL();
        }

        public List<StudentDTO> GetAllStudents()
        {
            try
            {
                return _dal.GetAll();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("STUDENT_GET_ALL", "Lỗi lấy danh sách sinh viên", ex);
                throw;
            }
        }

        public StudentDTO? GetStudentById(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Mã ID sinh viên không hợp lệ.");

            return _dal.GetById(studentId);
        }

        public StudentDTO? GetStudentByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Mã sinh viên không được để trống.");

            return _dal.GetByCode(code.Trim());
        }

        public List<StudentDTO> SearchStudents(string? keyword, string? classId = null, string? departmentId = null, string? status = null)
        {
            return _dal.Search(keyword, classId, departmentId, status);
        }

        public int AddStudent(StudentDTO student, string? operatorUsername = null)
        {
            ValidateStudent(student, isNew: true);

            // Kiểm tra trùng mã sinh viên
            if (_dal.IsCodeExists(student.StudentCode))
            {
                AppLogger.LogWarning("STUDENT_ADD", $"Trùng mã sinh viên: {student.StudentCode}", operatorUsername);
                throw new ArgumentException($"Mã sinh viên '{student.StudentCode}' đã tồn tại trong hệ thống. Vui lòng nhập mã khác.");
            }

            // Kiểm tra trùng email
            if (_dal.IsEmailExists(student.Email))
            {
                AppLogger.LogWarning("STUDENT_ADD", $"Trùng email sinh viên: {student.Email}", operatorUsername);
                throw new ArgumentException($"Email '{student.Email}' đã được sinh viên khác sử dụng.");
            }

            int newId = _dal.Insert(student);
            AppLogger.LogInformation("STUDENT_ADD", $"Thêm sinh viên thành công: {student.StudentCode} - {student.FullName} (Lớp: {student.ClassID})", operatorUsername);
            return newId;
        }

        public bool UpdateStudent(StudentDTO student, string? operatorUsername = null)
        {
            if (student.StudentID <= 0)
                throw new ArgumentException("Hãy chọn sinh viên cần sửa.");

            ValidateStudent(student, isNew: false);

            // Kiểm tra trùng mã với sinh viên khác
            if (_dal.IsCodeExists(student.StudentCode, student.StudentID))
            {
                AppLogger.LogWarning("STUDENT_UPDATE", $"Trùng mã sinh viên khi cập nhật: {student.StudentCode}", operatorUsername);
                throw new ArgumentException($"Mã sinh viên '{student.StudentCode}' đã bị trùng với sinh viên khác.");
            }

            // Kiểm tra trùng email với sinh viên khác
            if (_dal.IsEmailExists(student.Email, student.StudentID))
            {
                AppLogger.LogWarning("STUDENT_UPDATE", $"Trùng email sinh viên khi cập nhật: {student.Email}", operatorUsername);
                throw new ArgumentException($"Email '{student.Email}' đã được sinh viên khác sử dụng.");
            }

            int affected = _dal.Update(student);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("STUDENT_UPDATE", $"Cập nhật thông tin sinh viên thành công: {student.StudentCode} - {student.FullName}", operatorUsername);
            }
            return success;
        }

        public bool DeleteStudent(int studentId, string? operatorUsername = null)
        {
            if (studentId <= 0)
                throw new ArgumentException("Hãy chọn sinh viên cần xóa.");

            // Kiểm tra ràng buộc: Nếu sinh viên đã có lịch sử đăng ký môn học hoặc điểm thi thì cảnh báo
            if (_dal.HasEnrollments(studentId))
            {
                AppLogger.LogWarning("STUDENT_DELETE", $"Từ chối xóa sinh viên ID {studentId} do đang có dữ liệu môn học/điểm thi", operatorUsername);
                throw new InvalidOperationException("Không thể xóa sinh viên này vì đang có dữ liệu đăng ký môn học hoặc kết quả điểm trong hệ thống. Vui lòng chuyển trạng thái sang 'Nghỉ học' hoặc 'Bảo lưu'.");
            }

            int affected = _dal.Delete(studentId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("STUDENT_DELETE", $"Đã xóa sinh viên ID {studentId} khỏi hệ thống", operatorUsername);
            }
            return success;
        }

        public bool ChangeClass(int studentId, string newClassId, string? operatorUsername = null)
        {
            if (studentId <= 0)
                throw new ArgumentException("Hãy chọn sinh viên cần chuyển lớp.");

            if (string.IsNullOrWhiteSpace(newClassId))
                throw new ArgumentException("Vui lòng chọn lớp học mới.");

            int affected = _dal.UpdateClassForStudent(studentId, newClassId.Trim());
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("STUDENT_CHANGE_CLASS", $"Chuyển sinh viên ID {studentId} sang lớp {newClassId}", operatorUsername);
            }
            return success;
        }

        private static void ValidateStudent(StudentDTO s, bool isNew)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s), "Dữ liệu sinh viên không được rỗng.");

            s.StudentCode = s.StudentCode.Trim();
            s.FullName = s.FullName.Trim();
            s.Email = s.Email.Trim();
            s.PhoneNumber = s.PhoneNumber?.Trim();
            s.Address = s.Address?.Trim();
            s.ClassID = s.ClassID.Trim();
            s.Status = string.IsNullOrWhiteSpace(s.Status) ? "Đang học" : s.Status.Trim();
            s.Gender = string.IsNullOrWhiteSpace(s.Gender) ? "Nam" : s.Gender.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(s.StudentCode))
                throw new ArgumentException("Mã sinh viên không được để trống.");

            if (string.IsNullOrWhiteSpace(s.FullName))
                throw new ArgumentException("Họ và tên sinh viên không được để trống.");

            if (string.IsNullOrWhiteSpace(s.ClassID))
                throw new ArgumentException("Vui lòng chọn lớp học cho sinh viên.");

            if (string.IsNullOrWhiteSpace(s.Email))
                throw new ArgumentException("Email không được để trống.");

            // 2. Quy tắc mã sinh viên phải bắt đầu bằng SV (theo Slide bài giảng Chương 9)
            if (!s.StudentCode.StartsWith("SV", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Mã sinh viên phải bắt đầu bằng 'SV' (Ví dụ: SV001, SV002...).");

            // 3. Kiểm tra định dạng Email
            const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(s.Email, emailRegex))
                throw new ArgumentException("Địa chỉ Email không đúng định dạng (Ví dụ: an.nguyen@student.edu.vn).");

            // 4. Kiểm tra số điện thoại nếu có
            if (!string.IsNullOrEmpty(s.PhoneNumber))
            {
                if (!Regex.IsMatch(s.PhoneNumber, @"^[0-9+() -]{9,15}$"))
                    throw new ArgumentException("Số điện thoại không hợp lệ (từ 9 đến 15 chữ số).");
            }

            // 5. Kiểm tra tuổi sinh viên hợp lệ (từ 15 tuổi đến 100 tuổi)
            int age = DateTime.Today.Year - s.DateOfBirth.Year;
            if (s.DateOfBirth > DateTime.Today || age < 15 || age > 100)
                throw new ArgumentException("Ngày sinh không hợp lệ (sinh viên phải từ 15 tuổi trở lên).");

            // 6. Kiểm tra độ dài tối đa
            if (s.StudentCode.Length > 20)
                throw new ArgumentException("Mã sinh viên không được vượt quá 20 ký tự.");

            if (s.FullName.Length > 100)
                throw new ArgumentException("Họ và tên không được vượt quá 100 ký tự.");

            if (s.Email.Length > 100)
                throw new ArgumentException("Email không được vượt quá 100 ký tự.");
        }
    }
}

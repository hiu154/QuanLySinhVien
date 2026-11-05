using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class SubjectBLL
    {
        private readonly SubjectDAL _dal;

        public SubjectBLL(SubjectDAL? dal = null)
        {
            _dal = dal ?? new SubjectDAL();
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            return _dal.GetAll();
        }

        public SubjectDTO? GetSubjectById(int subjectId)
        {
            if (subjectId <= 0)
                throw new ArgumentException("Mã môn học không hợp lệ.");
            return _dal.GetById(subjectId);
        }

        public int AddSubject(SubjectDTO s, string? operatorUsername = null)
        {
            ValidateSubject(s);

            if (_dal.IsCodeExists(s.SubjectCode))
            {
                AppLogger.LogWarning("SUBJECT_ADD", $"Trùng mã môn học: {s.SubjectCode}", operatorUsername);
                throw new ArgumentException($"Mã môn học '{s.SubjectCode}' đã tồn tại.");
            }

            int newId = _dal.Insert(s);
            AppLogger.LogInformation("SUBJECT_ADD", $"Thêm môn học thành công: {s.SubjectCode} - {s.SubjectName} ({s.Credits} TC)", operatorUsername);
            return newId;
        }

        public bool UpdateSubject(SubjectDTO s, string? operatorUsername = null)
        {
            if (s.SubjectID <= 0)
                throw new ArgumentException("Hãy chọn môn học cần sửa.");

            ValidateSubject(s);

            if (_dal.IsCodeExists(s.SubjectCode, s.SubjectID))
            {
                AppLogger.LogWarning("SUBJECT_UPDATE", $"Trùng mã môn học khi sửa: {s.SubjectCode}", operatorUsername);
                throw new ArgumentException($"Mã môn học '{s.SubjectCode}' đã bị trùng.");
            }

            int affected = _dal.Update(s);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("SUBJECT_UPDATE", $"Cập nhật môn học thành công: {s.SubjectCode} - {s.SubjectName}", operatorUsername);
            }
            return success;
        }

        public bool DeleteSubject(int subjectId, string? operatorUsername = null)
        {
            if (subjectId <= 0)
                throw new ArgumentException("Hãy chọn môn học cần xóa.");

            // QUY TẮC BẢO VỆ: Không cho xóa môn học đang có sinh viên đăng ký / có điểm
            if (_dal.HasEnrollments(subjectId))
            {
                AppLogger.LogWarning("SUBJECT_DELETE", $"Từ chối xóa môn học ID {subjectId} vì đã có đăng ký/điểm", operatorUsername);
                throw new InvalidOperationException("Không thể xóa môn học này vì đã có dữ liệu đăng ký hoặc kết quả điểm của sinh viên trong hệ thống.");
            }

            int affected = _dal.Delete(subjectId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("SUBJECT_DELETE", $"Đã xóa môn học ID {subjectId}", operatorUsername);
            }
            return success;
        }

        private static void ValidateSubject(SubjectDTO s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            s.SubjectCode = s.SubjectCode.Trim();
            s.SubjectName = s.SubjectName.Trim();

            if (string.IsNullOrWhiteSpace(s.SubjectCode))
                throw new ArgumentException("Mã môn học không được để trống.");

            if (string.IsNullOrWhiteSpace(s.SubjectName))
                throw new ArgumentException("Tên môn học không được để trống.");

            if (s.Credits <= 0 || s.Credits > 15)
                throw new ArgumentException("Số tín chỉ phải từ 1 đến 15.");

            if (s.MidtermWeight < 0 || s.MidtermWeight > 1 || s.FinalWeight < 0 || s.FinalWeight > 1)
                throw new ArgumentException("Trọng số điểm phải nằm trong khoảng từ 0.0 đến 1.0.");

            decimal sum = s.MidtermWeight + s.FinalWeight;
            if (Math.Abs(sum - 1.0m) > 0.01m)
                throw new ArgumentException($"Tổng trọng số quá trình ({s.MidtermWeight * 100}%) và thi ({s.FinalWeight * 100}%) phải bằng 100% (1.0).");
        }
    }
}

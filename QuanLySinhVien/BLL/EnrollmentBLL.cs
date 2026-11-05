using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class EnrollmentBLL
    {
        private readonly EnrollmentDAL _dal;

        public EnrollmentBLL(EnrollmentDAL? dal = null)
        {
            _dal = dal ?? new EnrollmentDAL();
        }

        public List<EnrollmentDTO> GetEnrollments(int? studentId = null, int? subjectId = null, string? semesterId = null, string? classId = null)
        {
            return _dal.GetEnrollments(studentId, subjectId, semesterId, classId);
        }

        public int EnrollStudent(int studentId, int subjectId, string semesterId, string? operatorUsername = null)
        {
            if (studentId <= 0)
                throw new ArgumentException("Vui lòng chọn sinh viên.");

            if (subjectId <= 0)
                throw new ArgumentException("Vui lòng chọn môn học.");

            if (string.IsNullOrWhiteSpace(semesterId))
                throw new ArgumentException("Vui lòng chọn học kỳ.");

            semesterId = semesterId.Trim();

            // Kiểm tra sinh viên đã đăng ký môn này trong học kỳ này chưa
            if (_dal.IsEnrolled(studentId, subjectId, semesterId))
            {
                AppLogger.LogWarning("ENROLL_ADD", $"Sinh viên ID {studentId} đã đăng ký môn ID {subjectId} trong kỳ {semesterId}", operatorUsername);
                throw new InvalidOperationException("Sinh viên này đã đăng ký môn học trong học kỳ được chọn rồi.");
            }

            int id = _dal.Enroll(studentId, subjectId, semesterId);
            AppLogger.LogInformation("ENROLL_ADD", $"Đăng ký môn học thành công cho SV ID {studentId}, môn ID {subjectId}, kỳ {semesterId}", operatorUsername);
            return id;
        }

        public bool CancelEnrollment(int enrollmentId, string? operatorUsername = null)
        {
            if (enrollmentId <= 0)
                throw new ArgumentException("Hãy chọn bản ghi đăng ký cần hủy.");

            int affected = _dal.Delete(enrollmentId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("ENROLL_CANCEL", $"Hủy đăng ký môn học ID {enrollmentId}", operatorUsername);
            }
            return success;
        }
    }
}

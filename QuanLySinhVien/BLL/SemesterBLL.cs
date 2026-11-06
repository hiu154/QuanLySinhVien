using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class SemesterBLL
    {
        private readonly SemesterDAL _dal;

        public SemesterBLL(SemesterDAL? dal = null)
        {
            _dal = dal ?? new SemesterDAL();
        }

        public List<SemesterDTO> GetAllSemesters()
        {
            return _dal.GetAll();
        }

        public SemesterDTO? GetCurrentSemester()
        {
            return _dal.GetCurrent();
        }

        public bool AddSemester(SemesterDTO sem, string? operatorUsername = null)
        {
            ValidateSemester(sem);

            if (_dal.IsIdExists(sem.SemesterID))
            {
                AppLogger.LogWarning("SEMESTER_ADD", $"Trùng mã học kỳ: {sem.SemesterID}", operatorUsername);
                throw new ArgumentException($"Mã học kỳ '{sem.SemesterID}' đã tồn tại.");
            }

            int affected = _dal.Insert(sem);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("SEMESTER_ADD", $"Thêm học kỳ thành công: {sem.SemesterID} - {sem.SemesterName} ({sem.SchoolYear})", operatorUsername);
            }
            return success;
        }

        public bool UpdateSemester(SemesterDTO sem, string? operatorUsername = null)
        {
            ValidateSemester(sem);

            int affected = _dal.Update(sem);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("SEMESTER_UPDATE", $"Cập nhật học kỳ thành công: {sem.SemesterID}", operatorUsername);
            }
            return success;
        }

        public void SetCurrentSemester(string semesterId, string? operatorUsername = null)
        {
            if (string.IsNullOrWhiteSpace(semesterId))
                throw new ArgumentException("Vui lòng chọn học kỳ.");

            _dal.SetCurrentSemester(semesterId.Trim());
            AppLogger.LogInformation("SEMESTER_SET_CURRENT", $"Đặt học kỳ hiện tại là: {semesterId}", operatorUsername);
        }

        private static void ValidateSemester(SemesterDTO s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            s.SemesterID = s.SemesterID.Trim();
            s.SemesterName = s.SemesterName.Trim();
            s.SchoolYear = s.SchoolYear.Trim();

            if (string.IsNullOrWhiteSpace(s.SemesterID))
                throw new ArgumentException("Mã học kỳ không được để trống (Ví dụ: HK1_2025_2026).");

            if (string.IsNullOrWhiteSpace(s.SemesterName))
                throw new ArgumentException("Tên học kỳ không được để trống (Ví dụ: Học kỳ 1).");

            if (string.IsNullOrWhiteSpace(s.SchoolYear))
                throw new ArgumentException("Năm học không được để trống (Ví dụ: 2025-2026).");
        }
    }
}

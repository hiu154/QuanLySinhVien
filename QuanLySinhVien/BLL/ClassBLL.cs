using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class ClassBLL
    {
        private readonly ClassDAL _dal;

        public ClassBLL(ClassDAL? dal = null)
        {
            _dal = dal ?? new ClassDAL();
        }

        public List<ClassDTO> GetAllClasses()
        {
            return _dal.GetAll();
        }

        public List<ClassDTO> GetClassesByDepartment(string departmentId)
        {
            if (string.IsNullOrWhiteSpace(departmentId))
                return GetAllClasses();
            return _dal.GetByDepartment(departmentId.Trim());
        }

        public ClassDTO? GetClassById(string classId)
        {
            if (string.IsNullOrWhiteSpace(classId))
                throw new ArgumentException("Mã lớp không được để trống.");
            return _dal.GetById(classId.Trim());
        }

        public bool AddClass(ClassDTO cls, string? operatorUsername = null)
        {
            ValidateClass(cls);

            if (_dal.IsIdExists(cls.ClassID))
            {
                AppLogger.LogWarning("CLASS_ADD", $"Trùng mã lớp: {cls.ClassID}", operatorUsername);
                throw new ArgumentException($"Mã lớp '{cls.ClassID}' đã tồn tại.");
            }

            int affected = _dal.Insert(cls);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("CLASS_ADD", $"Thêm lớp học thành công: {cls.ClassID} - {cls.ClassName}", operatorUsername);
            }
            return success;
        }

        public bool UpdateClass(ClassDTO cls, string? operatorUsername = null)
        {
            ValidateClass(cls);

            int affected = _dal.Update(cls);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("CLASS_UPDATE", $"Cập nhật lớp học thành công: {cls.ClassID} - {cls.ClassName}", operatorUsername);
            }
            return success;
        }

        public bool DeleteClass(string classId, string? operatorUsername = null)
        {
            if (string.IsNullOrWhiteSpace(classId))
                throw new ArgumentException("Vui lòng chọn lớp học cần xóa.");

            classId = classId.Trim();

            // QUY TẮC BẢO VỆ: Không cho xóa lớp đang có sinh viên
            if (_dal.HasStudents(classId))
            {
                AppLogger.LogWarning("CLASS_DELETE", $"Từ chối xóa lớp {classId} vì đang có sinh viên", operatorUsername);
                throw new InvalidOperationException($"Không thể xóa lớp '{classId}' vì đang có sinh viên thuộc lớp này. Hãy chuyển sinh viên sang lớp khác trước.");
            }

            int affected = _dal.Delete(classId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("CLASS_DELETE", $"Đã xóa lớp học {classId}", operatorUsername);
            }
            return success;
        }

        private static void ValidateClass(ClassDTO c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            c.ClassID = c.ClassID.Trim();
            c.ClassName = c.ClassName.Trim();
            c.DepartmentID = c.DepartmentID.Trim();

            if (string.IsNullOrWhiteSpace(c.ClassID))
                throw new ArgumentException("Mã lớp không được để trống.");

            if (string.IsNullOrWhiteSpace(c.ClassName))
                throw new ArgumentException("Tên lớp không được để trống.");

            if (string.IsNullOrWhiteSpace(c.DepartmentID))
                throw new ArgumentException("Vui lòng chọn khoa trực thuộc của lớp.");

            if (c.ClassID.Length > 20)
                throw new ArgumentException("Mã lớp không được quá 20 ký tự.");

            if (c.ClassName.Length > 100)
                throw new ArgumentException("Tên lớp không được quá 100 ký tự.");
        }
    }
}

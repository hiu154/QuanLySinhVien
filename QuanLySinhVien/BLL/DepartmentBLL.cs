using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL _dal;

        public DepartmentBLL(DepartmentDAL? dal = null)
        {
            _dal = dal ?? new DepartmentDAL();
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            return _dal.GetAll();
        }

        public DepartmentDTO? GetDepartmentById(string departmentId)
        {
            if (string.IsNullOrWhiteSpace(departmentId))
                throw new ArgumentException("Mã khoa không được để trống.");
            return _dal.GetById(departmentId.Trim());
        }

        public bool AddDepartment(DepartmentDTO dept, string? operatorUsername = null)
        {
            ValidateDepartment(dept);

            if (_dal.IsIdExists(dept.DepartmentID))
            {
                AppLogger.LogWarning("DEPT_ADD", $"Trùng mã khoa: {dept.DepartmentID}", operatorUsername);
                throw new ArgumentException($"Mã khoa '{dept.DepartmentID}' đã tồn tại.");
            }

            int affected = _dal.Insert(dept);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("DEPT_ADD", $"Thêm khoa mới thành công: {dept.DepartmentID} - {dept.DepartmentName}", operatorUsername);
            }
            return success;
        }

        public bool UpdateDepartment(DepartmentDTO dept, string? operatorUsername = null)
        {
            ValidateDepartment(dept);

            int affected = _dal.Update(dept);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("DEPT_UPDATE", $"Cập nhật khoa thành công: {dept.DepartmentID} - {dept.DepartmentName}", operatorUsername);
            }
            return success;
        }

        public bool DeleteDepartment(string departmentId, string? operatorUsername = null)
        {
            if (string.IsNullOrWhiteSpace(departmentId))
                throw new ArgumentException("Vui lòng chọn khoa cần xóa.");

            departmentId = departmentId.Trim();

            // QUY TẮC BẢO VỆ: Không cho xóa khoa đang được dữ liệu lớp học sử dụng
            if (_dal.HasClasses(departmentId))
            {
                AppLogger.LogWarning("DEPT_DELETE", $"Từ chối xóa khoa {departmentId} vì đang chứa lớp học", operatorUsername);
                throw new InvalidOperationException($"Không thể xóa khoa '{departmentId}' vì đang có các lớp học thuộc khoa này. Bạn phải chuyển hoặc xóa các lớp học trước.");
            }

            int affected = _dal.Delete(departmentId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("DEPT_DELETE", $"Đã xóa khoa {departmentId}", operatorUsername);
            }
            return success;
        }

        private static void ValidateDepartment(DepartmentDTO d)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));
            d.DepartmentID = d.DepartmentID.Trim();
            d.DepartmentName = d.DepartmentName.Trim();

            if (string.IsNullOrWhiteSpace(d.DepartmentID))
                throw new ArgumentException("Mã khoa không được để trống.");

            if (string.IsNullOrWhiteSpace(d.DepartmentName))
                throw new ArgumentException("Tên khoa không được để trống.");

            if (d.DepartmentID.Length > 20)
                throw new ArgumentException("Mã khoa không được quá 20 ký tự.");

            if (d.DepartmentName.Length > 100)
                throw new ArgumentException("Tên khoa không được quá 100 ký tự.");
        }
    }
}

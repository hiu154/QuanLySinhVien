using System;
using System.Collections.Generic;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.BLL
{
    public class ClassBLL
    {
        public List<ClassDTO> GetAllClasses() => new List<ClassDTO>();
        public bool DeleteClass(string classId, string? username = null) => true;
        public bool SaveClass(ClassDTO c, bool isNew, string? username = null) => true;
    }
    public class DepartmentBLL
    {
        public List<DepartmentDTO> GetAllDepartments() => new List<DepartmentDTO>();
        public bool SaveDepartment(DepartmentDTO d, bool isNew, string? username = null) => true;
        public bool DeleteDepartment(string deptId, string? username = null) => true;
    }
}

using System;

namespace QuanLySinhVien.DTO
{
    public class ClassDTO
    {
        public string ClassID { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string? AcademicYear { get; set; }
        public string? HeadTeacher { get; set; }
        public int TotalStudents { get; set; }
    }
}

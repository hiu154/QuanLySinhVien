using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Lớp học
    /// </summary>
    public class ClassDTO
    {
        public string ClassID { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string DepartmentID { get; set; } = string.Empty;
        public string? DepartmentName { get; set; }
        public string? AcademicYear { get; set; }
        public string? HeadTeacher { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Thống kê liên quan
        public int TotalStudents { get; set; }

        public string DisplayText => $"{ClassID} - {ClassName}";
    }
}

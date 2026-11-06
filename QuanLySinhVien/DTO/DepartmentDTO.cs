using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Khoa
    /// </summary>
    public class DepartmentDTO
    {
        public string DepartmentID { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Thống kê liên quan
        public int TotalClasses { get; set; }
        public int TotalStudents { get; set; }

        public string DisplayText => $"{DepartmentID} - {DepartmentName}";
    }
}

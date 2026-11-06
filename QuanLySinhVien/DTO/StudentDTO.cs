using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// Data Transfer Object cho Sinh viên (Chương 9)
    /// Dùng để luân chuyển dữ liệu giữa UI, BLL và DAL.
    /// </summary>
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = new DateTime(2003, 1, 1);
        public string Gender { get; set; } = "Nam"; // "Nam", "Nữ", "Khác"
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string ClassID { get; set; } = string.Empty;
        public string? ClassName { get; set; }
        public string? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime AdmissionDate { get; set; } = DateTime.Today;
        public string Status { get; set; } = "Đang học"; // "Đang học", "Nghỉ học", "Bảo lưu", "Đã tốt nghiệp"
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Display helper
        public string DisplayText => $"{StudentCode} - {FullName} ({ClassName})";
    }
}

using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Tài khoản người dùng & Phân quyền
    /// </summary>
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Teacher"; // "Admin", "Teacher", "Student"
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? StudentID { get; set; }
        public string? StudentCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Helper kiểm tra quyền
        public bool IsAdmin => string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);
        public bool IsTeacher => string.Equals(Role, "Teacher", StringComparison.OrdinalIgnoreCase);
        public bool IsStudent => string.Equals(Role, "Student", StringComparison.OrdinalIgnoreCase);
    }
}

using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Nhật ký hệ thống (Chương 8 - Logging)
    /// </summary>
    public class AppLogDTO
    {
        public int LogID { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string LogLevel { get; set; } = "Information"; // Debug, Information, Warning, Error, Critical
        public string? Username { get; set; } = "SYSTEM";
        public string Action { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? ExceptionDetails { get; set; }
    }
}

using System;
using System.IO;
using System.Text;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Logging
{
    public enum LogSeverity
    {
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5
    }

    /// <summary>
    /// Hệ thống Logging chuẩn theo bài học Chương 8:
    /// - Hỗ trợ 5 mức log: Debug, Information, Warning, Error, Critical
    /// - Ghi log ra file rolling (logs/app_yyyyMMdd.log)
    /// - Bắn sự kiện OnLogLogged để UI hiển thị trực tiếp
    /// - Đồng bộ lưu vào bảng SystemLogs trong cơ sở dữ liệu
    /// </summary>
    public static class AppLogger
    {
        private static readonly object _lock = new object();
        private static string _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        public static LogSeverity MinimumLevel { get; set; } = LogSeverity.Debug;

        public static event Action<AppLogDTO>? OnLogLogged;

        // Callback để lưu log vào database qua DAL mà không tạo vòng lặp phụ thuộc
        public static Action<AppLogDTO>? DatabaseLogHandler { get; set; }

        static AppLogger()
        {
            try
            {
                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }
            }
            catch
            {
                // Fallback nếu không có quyền tạo thư mục
            }
        }

        public static void SetLogDirectory(string path)
        {
            _logDirectory = path;
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public static void LogDebug(string action, string message, string? username = null)
        {
            Log(LogSeverity.Debug, action, message, username, null);
        }

        public static void LogInformation(string action, string message, string? username = null)
        {
            Log(LogSeverity.Information, action, message, username, null);
        }

        public static void LogWarning(string action, string message, string? username = null)
        {
            Log(LogSeverity.Warning, action, message, username, null);
        }

        public static void LogError(string action, string message, Exception? ex = null, string? username = null)
        {
            Log(LogSeverity.Error, action, message, username, ex);
        }

        public static void LogCritical(string action, string message, Exception? ex = null, string? username = null)
        {
            Log(LogSeverity.Critical, action, message, username, ex);
        }

        private static void Log(LogSeverity level, string action, string message, string? username, Exception? ex)
        {
            if (level < MinimumLevel) return;

            var dto = new AppLogDTO
            {
                Timestamp = DateTime.Now,
                LogLevel = level.ToString(),
                Username = string.IsNullOrWhiteSpace(username) ? "SYSTEM" : username,
                Action = action,
                Message = message,
                ExceptionDetails = ex != null ? $"{ex.GetType().FullName}: {ex.Message}\n{ex.StackTrace}" : null
            };

            // 1. Ghi ra file log
            WriteToFile(dto);

            // 2. Kích hoạt event cập nhật UI (nếu có form đang mở)
            try
            {
                OnLogLogged?.Invoke(dto);
            }
            catch { }

            // 3. Ghi vào database qua callback (nếu đã đăng ký)
            if (DatabaseLogHandler != null && level >= LogSeverity.Information)
            {
                try
                {
                    DatabaseLogHandler(dto);
                }
                catch
                {
                    // Tránh vòng lặp ngoại lệ nếu database bị mất kết nối
                }
            }
        }

        private static void WriteToFile(AppLogDTO log)
        {
            lock (_lock)
            {
                try
                {
                    string fileName = $"app_{DateTime.Today:yyyyMMdd}.log";
                    string filePath = Path.Combine(_logDirectory, fileName);

                    var sb = new StringBuilder();
                    sb.Append($"[{log.Timestamp:yyyy-MM-dd HH:mm:ss.fff}] ");
                    sb.Append($"[{log.LogLevel.ToUpperInvariant()}] ");
                    sb.Append($"[User:{log.Username}] ");
                    sb.Append($"[Action:{log.Action}] ");
                    sb.AppendLine(log.Message);

                    if (!string.IsNullOrEmpty(log.ExceptionDetails))
                    {
                        sb.AppendLine($"   Exception: {log.ExceptionDetails}");
                    }

                    File.AppendAllText(filePath, sb.ToString(), Encoding.UTF8);
                }
                catch
                {
                    // Tránh throw làm crash ứng dụng
                }
            }
        }
    }
}

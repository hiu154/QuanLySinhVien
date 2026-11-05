using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Factory quản lý kết nối cơ sở dữ liệu SQL Server (Chương 6 & Chương 9).
    /// Hỗ trợ đọc từ App.config và tự động phát hiện instance SQL Server nếu cần.
    /// </summary>
    public static class DbConnectionFactory
    {
        private static string _connectionString = string.Empty;
        private const string DefaultDatabaseName = "QuanLySinhVienDB";

        static DbConnectionFactory()
        {
            // Đọc từ App.config trước
            try
            {
                var setting = ConfigurationManager.ConnectionStrings["QuanLySinhVienConnection"];
                if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    _connectionString = setting.ConnectionString;
                }
            }
            catch
            {
                // Fallback nếu không đọc được config
            }

            // Nếu vẫn trống, đặt mặc định kết nối tới máy cục bộ
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _connectionString = $"Server=.;Database={DefaultDatabaseName};Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;";
            }
        }

        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        /// <summary>
        /// Tạo mới một đối tượng SqlConnection
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Kiểm tra kết nối tới cơ sở dữ liệu.
        /// Trả về true nếu thành công, kèm thông báo chi tiết.
        /// </summary>
        public static (bool Success, string Message) TestConnection()
        {
            try
            {
                using var conn = CreateConnection();
                conn.Open();
                return (true, "Kết nối SQL Server thành công!");
            }
            catch (SqlException ex)
            {
                return (false, $"Lỗi kết nối SQL Server (Mã lỗi {ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi không xác định: {ex.Message}");
            }
        }

        /// <summary>
        /// Thử tự động tìm kiếm instance SQL Server đang hoạt động trên máy
        /// </summary>
        public static bool AutoDetectServer(out string workingServer)
        {
            string[] serversToTry = new string[] { ".", "localhost", @".\SQLEXPRESS", @".\MSSQLSERVER01" };
            foreach (var server in serversToTry)
            {
                string testCs = $"Server={server};Database={DefaultDatabaseName};Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
                try
                {
                    using var conn = new SqlConnection(testCs);
                    conn.Open();
                    _connectionString = testCs;
                    workingServer = server;
                    return true;
                }
                catch
                {
                    // Tiếp tục thử server khác
                }
            }

            workingServer = string.Empty;
            return false;
        }

        public static object DbValue(object? val)
        {
            if (val == null) return DBNull.Value;
            if (val is string str && string.IsNullOrWhiteSpace(str)) return DBNull.Value;
            return val;
        }
    }
}

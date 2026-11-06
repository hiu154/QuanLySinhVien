using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.DAL
{
    /// <summary>
    /// Factory quản lý kết nối cơ sở dữ liệu SQL Server (Chương 6 & Chương 9).
    /// Hỗ trợ:
    /// 1. Tự động nhận diện instance SQL Server trên mọi máy tính (., SQLEXPRESS, LocalDB, MSSQLSERVER01, v.v.).
    /// 2. Tự động phát hiện và khởi tạo CSDL 'QuanLySinhVienDB' từ kịch bản SQL nhúng nếu máy chưa có CSDL.
    /// 3. Cho phép cấu hình linh hoạt qua giao diện để chia sẻ và chạy trên nhiều máy tính khác nhau.
    /// </summary>
    public static class DbConnectionFactory
    {
        private static string _connectionString = string.Empty;
        public const string DefaultDatabaseName = "QuanLySinhVienDB";

        static DbConnectionFactory()
        {
            // 1. Đọc từ App.config nếu có
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
                // Bỏ qua lỗi đọc config
            }

            // 2. Mặc định kết nối cục bộ với Windows Authentication
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
        /// Tạo mới đối tượng kết nối SqlConnection
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Kiểm tra kết nối tới CSDL hiện tại.
        /// </summary>
        public static (bool Success, string Message) TestConnection(string? connectionStringToTest = null)
        {
            string cs = !string.IsNullOrWhiteSpace(connectionStringToTest) ? connectionStringToTest : _connectionString;
            try
            {
                using var conn = new SqlConnection(cs);
                conn.Open();
                return (true, "Kết nối cơ sở dữ liệu SQL Server thành công!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 4060)
                {
                    return (false, $"Máy chủ SQL Server phản hồi tốt nhưng Database '{DefaultDatabaseName}' chưa tồn tại (Mã lỗi 4060).");
                }
                if (ex.Number == 26 || ex.Number == 53)
                {
                    return (false, $"Không thể kết nối tới máy chủ SQL Server. Vui lòng kiểm tra lại tên Server (Mã lỗi {ex.Number}).");
                }
                return (false, $"Lỗi SQL Server ({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy toàn bộ nội dung file SQL khởi tạo (ưu tiên Embedded Resource trong assembly, sau đó đọc file đĩa).
        /// </summary>
        public static string GetSqlCreationScript()
        {
            // 1. Thử đọc từ Embedded Resource
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                string[] resNames = new string[]
                {
                    "01_CreateDatabase_QLSV.sql",
                    "QuanLySinhVien.SQL.01_CreateDatabase_QLSV.sql",
                    "QuanLySinhVien.01_CreateDatabase_QLSV.sql"
                };

                foreach (var name in resNames)
                {
                    using var stream = asm.GetManifestResourceStream(name);
                    if (stream != null)
                    {
                        using var reader = new StreamReader(stream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
            }

            // 2. Thử đọc từ file trên đĩa
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidatePaths = new string[]
            {
                Path.Combine(baseDir, "SQL", "01_CreateDatabase_QLSV.sql"),
                Path.Combine(baseDir, "01_CreateDatabase_QLSV.sql"),
                Path.Combine(baseDir, "..", "..", "..", "SQL", "01_CreateDatabase_QLSV.sql"),
                Path.Combine(baseDir, "..", "..", "..", "..", "QuanLySinhVien", "SQL", "01_CreateDatabase_QLSV.sql")
            };

            foreach (var path in candidatePaths)
            {
                try
                {
                    string fullPath = Path.GetFullPath(path);
                    if (File.Exists(fullPath))
                    {
                        return File.ReadAllText(fullPath, Encoding.UTF8);
                    }
                }
                catch
                {
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Tự động khởi tạo CSDL QuanLySinhVienDB từ kịch bản SQL trên máy chủ chỉ định.
        /// </summary>
        public static (bool Success, string Message) InitializeDatabase(string serverName, string? username = null, string? password = null, Action<string>? progressCallback = null)
        {
            if (string.IsNullOrWhiteSpace(serverName)) serverName = ".";

            string masterCs;
            if (string.IsNullOrWhiteSpace(username))
            {
                masterCs = $"Server={serverName};Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=10;";
            }
            else
            {
                masterCs = $"Server={serverName};Database=master;User Id={username};Password={password};TrustServerCertificate=True;Connect Timeout=10;";
            }

            string sqlScript = GetSqlCreationScript();
            if (string.IsNullOrWhiteSpace(sqlScript))
            {
                return (false, "Không tìm thấy nội dung file kịch bản SQL '01_CreateDatabase_QLSV.sql' để khởi tạo CSDL.");
            }

            try
            {
                progressCallback?.Invoke($"Đang kết nối tới máy chủ SQL Server '{serverName}' (master)...");
                using var conn = new SqlConnection(masterCs);
                conn.Open();

                progressCallback?.Invoke("Đang phân tích và thực thi kịch bản tạo 9 bảng CSDL & dữ liệu mẫu...");
                var batches = Regex.Split(sqlScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                int count = 0;

                foreach (var batch in batches)
                {
                    string sql = batch.Trim();
                    if (string.IsNullOrWhiteSpace(sql)) continue;

                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    cmd.ExecuteNonQuery();
                    count++;
                }

                // Cập nhật chuỗi kết nối chuẩn tới CSDL vừa tạo
                if (string.IsNullOrWhiteSpace(username))
                {
                    _connectionString = $"Server={serverName};Database={DefaultDatabaseName};Integrated Security=True;TrustServerCertificate=True;Connect Timeout=10;";
                }
                else
                {
                    _connectionString = $"Server={serverName};Database={DefaultDatabaseName};User Id={username};Password={password};TrustServerCertificate=True;Connect Timeout=10;";
                }

                progressCallback?.Invoke($"Khởi tạo hoàn tất ({count} khối lệnh thành công)!");
                return (true, $"Đã khởi tạo thành công CSDL '{DefaultDatabaseName}' trên máy chủ '{serverName}'!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi khi khởi tạo CSDL trên máy chủ '{serverName}': {ex.Message}");
            }
        }

        /// <summary>
        /// Tự động quét và sửa lỗi kết nối trên máy hiện tại.
        /// Nếu CSDL chưa có, sẽ tự động tạo luôn CSDL để ứng dụng hoạt động ngay.
        /// </summary>
        public static (bool Success, string Message, string WorkingServer) AutoDetectAndFixConnection()
        {
            // 1. Thử kết nối hiện tại
            var currentTest = TestConnection();
            if (currentTest.Success)
            {
                string srv = GetServerFromConnectionString(_connectionString);
                return (true, "Kết nối CSDL hiện tại thành công.", srv);
            }

            // 1b. Nếu kết nối hiện tại báo lỗi 4060 (Server có thật, nhưng chưa có DB)
            try
            {
                using var testConn = CreateConnection();
                testConn.Open();
            }
            catch (SqlException ex) when (ex.Number == 4060)
            {
                string srv = GetServerFromConnectionString(_connectionString);
                var initRes = InitializeDatabase(srv);
                if (initRes.Success)
                {
                    return (true, $"Đã tự động khởi tạo CSDL trên máy chủ '{srv}'!", srv);
                }
            }
            catch
            {
            }

            // 2. Danh sách các instance SQL Server thông dụng trên Windows
            string[] candidates = new string[]
            {
                ".",
                "localhost",
                "(local)",
                @".\SQLEXPRESS",
                @"(localdb)\MSSQLLocalDB",
                @".\MSSQLSERVER01",
                @".\MSSQLSERVER"
            };

            foreach (var srv in candidates)
            {
                // 2a. Thử xem instance này có sẵn QuanLySinhVienDB chưa
                string testDbCs = $"Server={srv};Database={DefaultDatabaseName};Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
                try
                {
                    using var conn = new SqlConnection(testDbCs);
                    conn.Open();
                    _connectionString = testDbCs;
                    return (true, $"Đã tự động tìm thấy và kết nối tới CSDL trên máy chủ '{srv}'.", srv);
                }
                catch (SqlException ex) when (ex.Number == 4060)
                {
                    // Instance này chạy nhưng chưa có DB -> Tự động khởi tạo ngay!
                    var initRes = InitializeDatabase(srv);
                    if (initRes.Success)
                    {
                        return (true, $"Đã tìm thấy máy chủ '{srv}' và tự động khởi tạo CSDL thành công!", srv);
                    }
                }
                catch
                {
                    // Tiếp tục thử instance tiếp theo
                }
            }

            return (false, "Không thể tự động kết nối hoặc tìm thấy máy chủ SQL Server. Vui lòng mở cấu hình CSDL.", string.Empty);
        }

        public static string GetServerFromConnectionString(string cs)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(cs);
                return builder.DataSource;
            }
            catch
            {
                return ".";
            }
        }

        public static object DbValue(object? val)
        {
            if (val == null) return DBNull.Value;
            if (val is string str && string.IsNullOrWhiteSpace(str)) return DBNull.Value;
            return val;
        }
    }
}

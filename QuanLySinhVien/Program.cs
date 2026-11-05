using System;
using System.Windows.Forms;
using QuanLySinhVien.DAL;

namespace QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kiểm tra kết nối cơ sở dữ liệu khi khởi động
            try
            {
                using var conn = DbConnectionFactory.CreateConnection();
                conn.Open();
            }
            catch
            {
                // Cho phép tiếp tục nếu chưa có cấu hình DB
            }
        }
    }
}

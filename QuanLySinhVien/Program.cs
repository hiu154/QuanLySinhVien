using System;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.Forms;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi đầu chính của ứng dụng Quản lý Sinh viên (Chương 6, 8, 9).
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo dịch vụ ghi nhật ký (Logging - Chương 8)
            try
            {
                AppLogBLL.InitializeDatabaseLogging();
                AppLogger.LogInformation("APP_START", "=== ỨNG DỤNG QUẢN LÝ SINH VIÊN BẮT ĐẦU HOẠT ĐỘNG ===");
            }
            catch
            {
                // Tiếp tục ngay cả khi DB chưa sẵn sàng
            }

            // 2. Mở màn hình đăng nhập
            using var loginForm = new FrmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Đăng nhập thành công -> Vào giao diện chính
                Application.Run(new FrmMain());
            }

            AppLogger.LogInformation("APP_EXIT", "Ứng dụng Quản lý Sinh viên đã đóng.");
        }
    }
}

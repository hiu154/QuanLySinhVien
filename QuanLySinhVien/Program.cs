using System;
using System.Windows.Forms;
using QuanLySinhVien.Forms;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                AppLogger.LogInformation("APP_START", "=== ỨNG DỤNG QUẢN LÝ SINH VIÊN BẮT ĐẦU HOẠT ĐỘNG ===");
            }
            catch
            {
            }

            using var loginForm = new FrmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }

            AppLogger.LogInformation("APP_EXIT", "Ứng dụng Quản lý Sinh viên đã đóng.");
        }
    }
}

using System;
using System.IO;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;
using Xunit;

namespace QuanLySinhVien.Tests
{
    public class AppLoggerTests
    {
        [Fact]
        public void AppLogger_LogInformation_ShouldFireEventAndWriteToFile()
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), $"logger_test_{Guid.NewGuid():N}");
            AppLogger.SetLogDirectory(tempDir);

            bool eventFired = false;
            string recordedAction = string.Empty;

            Action<AppLogDTO> handler = dto =>
            {
                if (dto.Action == "UNIT_TEST_ACTION")
                {
                    eventFired = true;
                    recordedAction = dto.Action;
                }
            };

            AppLogger.OnLogLogged += handler;

            try
            {
                // Act
                AppLogger.LogInformation("UNIT_TEST_ACTION", "Kiểm thử ghi nhận nhật ký hệ thống", "tester");

                // Assert
                Assert.True(eventFired);
                Assert.Equal("UNIT_TEST_ACTION", recordedAction);

                // Kiểm tra file log trong thư mục
                string[] files = Directory.GetFiles(tempDir, "*.log");
                Assert.NotEmpty(files);
                string fileContent = File.ReadAllText(files[0]);
                Assert.Contains("[INFORMATION]", fileContent);
                Assert.Contains("[Action:UNIT_TEST_ACTION]", fileContent);
                Assert.Contains("Kiểm thử ghi nhận nhật ký hệ thống", fileContent);
            }
            finally
            {
                AppLogger.OnLogLogged -= handler;
                if (Directory.Exists(tempDir))
                {
                    try { Directory.Delete(tempDir, true); } catch { }
                }
            }
        }
    }
}

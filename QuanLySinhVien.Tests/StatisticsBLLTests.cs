using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QuanLySinhVien.BLL;
using Xunit;

namespace QuanLySinhVien.Tests
{
    public class StatisticsBLLTests
    {
        public class CsvTestModel
        {
            public string Code { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public decimal Score { get; set; }
            public string Description { get; set; } = string.Empty;
        }

        [Fact]
        public void ExportToCsv_ShouldWriteUtf8WithBom()
        {
            // Arrange
            string tempFile = Path.Combine(Path.GetTempPath(), $"test_export_{Guid.NewGuid():N}.csv");
            var testData = new List<CsvTestModel>
            {
                new CsvTestModel { Code = "SV001", Name = "Nguyễn Văn An", Score = 8.5m, Description = "Sinh viên xuất sắc" },
                new CsvTestModel { Code = "SV002", Name = "Trần Thị Bích, Lớp CNTT", Score = 7.0m, Description = "Có dấu phẩy, kiểm tra quote" }
            };

            string[] headers = { "Mã SV", "Họ và tên", "Điểm GPA", "Ghi chú" };

            try
            {
                // Act
                StatisticsBLL.ExportToCsv(
                    testData,
                    tempFile,
                    item => new string[] { item.Code, item.Name, item.Score.ToString("F2"), item.Description },
                    headers
                );

                // Assert
                Assert.True(File.Exists(tempFile));

                // Kiểm tra 3 byte đầu tiên là UTF-8 BOM: 0xEF, 0xBB, 0xBF
                byte[] bytes = File.ReadAllBytes(tempFile);
                Assert.True(bytes.Length >= 3);
                Assert.Equal(0xEF, bytes[0]);
                Assert.Equal(0xBB, bytes[1]);
                Assert.Equal(0xBF, bytes[2]);

                // Đọc lại nội dung kiểm tra tiếng Việt có dấu
                string content = File.ReadAllText(tempFile, Encoding.UTF8);
                Assert.Contains("Mã SV,Họ và tên,Điểm GPA,Ghi chú", content);
                Assert.Contains("Nguyễn Văn An", content);
                Assert.Contains("\"Trần Thị Bích, Lớp CNTT\"", content); // Phải được bọc trong nháy kép do có dấu phẩy
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
    }
}

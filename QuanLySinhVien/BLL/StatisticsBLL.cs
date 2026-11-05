using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class StatisticsBLL
    {
        private readonly StatisticsDAL _dal;

        public StatisticsBLL(StatisticsDAL? dal = null)
        {
            _dal = dal ?? new StatisticsDAL();
        }

        public DashboardSummaryDTO GetDashboardSummary()
        {
            return _dal.GetDashboardSummary();
        }

        public List<ChartItemDTO> GetStudentsByDepartment()
        {
            return _dal.GetStudentsByDepartment();
        }

        public List<ChartItemDTO> GetStudentsByStatus()
        {
            return _dal.GetStudentsByStatus();
        }

        public List<ChartItemDTO> GetAcademicRankDistribution(string? semesterId = null)
        {
            return _dal.GetAcademicRankDistribution(semesterId);
        }

        public List<StudentTranscriptSummaryDTO> GetStudentGPASummaries(string? semesterId = null, string? classId = null)
        {
            return _dal.GetStudentGPASummaries(semesterId, classId);
        }

        /// <summary>
        /// Xuất dữ liệu sang định dạng CSV (UTF-8 BOM hỗ trợ tiếng Việt trên Excel)
        /// </summary>
        public static void ExportToCsv<T>(IEnumerable<T> data, string filePath, Func<T, string[]> rowSelector, string[] headers)
        {
            var sb = new StringBuilder();

            // Headers
            sb.AppendLine(string.Join(",", FormatCsvRow(headers)));

            // Rows
            foreach (var item in data)
            {
                string[] values = rowSelector(item);
                sb.AppendLine(string.Join(",", FormatCsvRow(values)));
            }

            // Ghi file với UTF8 with BOM để Microsoft Excel hiển thị đúng tiếng Việt có dấu
            var utf8Bom = new UTF8Encoding(true);
            File.WriteAllText(filePath, sb.ToString(), utf8Bom);

            AppLogger.LogInformation("EXPORT_CSV", $"Đã xuất dữ liệu ra file: {filePath}", AuthBLL.CurrentUser?.Username);
        }

        private static string[] FormatCsvRow(string[] fields)
        {
            string[] formatted = new string[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                string f = fields[i] ?? string.Empty;
                // Nếu chứa dấu phẩy, dấu nháy kép hoặc xuống dòng, bọc trong cặp nháy kép
                if (f.Contains(",") || f.Contains("\"") || f.Contains("\n") || f.Contains("\r"))
                {
                    f = "\"" + f.Replace("\"", "\"\"") + "\"";
                }
                formatted[i] = f;
            }
            return formatted;
        }
    }
}

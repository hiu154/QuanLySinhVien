using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class StatisticsDAL
    {
        public DashboardSummaryDTO GetOverviewStatistics()
        {
            var summary = new DashboardSummaryDTO();
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Open();

            using var cmd1 = new SqlCommand("SELECT COUNT(*) FROM Students WHERE Status = N'Đang học';", conn);
            summary.TotalActiveStudents = Convert.ToInt32(cmd1.ExecuteScalar() ?? 0);

            using var cmd2 = new SqlCommand("SELECT COUNT(*) FROM Classes;", conn);
            summary.TotalClasses = Convert.ToInt32(cmd2.ExecuteScalar() ?? 0);

            using var cmd3 = new SqlCommand("SELECT COUNT(*) FROM Subjects;", conn);
            summary.TotalSubjects = Convert.ToInt32(cmd3.ExecuteScalar() ?? 0);

            using var cmd4 = new SqlCommand("SELECT COUNT(*) FROM Departments;", conn);
            summary.TotalDepartments = Convert.ToInt32(cmd4.ExecuteScalar() ?? 0);

            return summary;
        }

        public Dictionary<string, int> GetRankDistribution(string? semesterId = null)
        {
            var dict = new Dictionary<string, int>
            {
                { "Xuất sắc", 0 }, { "Giỏi", 0 }, { "Khá", 0 }, { "Trung bình", 0 }, { "Yếu", 0 }
            };
            return dict;
        }
    }
}

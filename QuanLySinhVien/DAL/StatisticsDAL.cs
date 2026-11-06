using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class StatisticsDAL
    {
        public DashboardSummaryDTO GetDashboardSummary()
        {
            var summary = new DashboardSummaryDTO();
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Open();

            // 1. Counts
            const string countSql = @"
                SELECT 
                    (SELECT COUNT(*) FROM Students) AS TotalStudents,
                    (SELECT COUNT(*) FROM Classes) AS TotalClasses,
                    (SELECT COUNT(*) FROM Departments) AS TotalDepartments,
                    (SELECT COUNT(*) FROM Subjects) AS TotalSubjects,
                    (SELECT COUNT(*) FROM Students WHERE Status = N'Đang học') AS ActiveStudents,
                    (SELECT COUNT(*) FROM Students WHERE Status = N'Bảo lưu') AS SuspendedStudents,
                    (SELECT COUNT(*) FROM Students WHERE Status = N'Nghỉ học') AS DroppedStudents,
                    (SELECT COUNT(*) FROM Students WHERE Status = N'Đã tốt nghiệp') AS GraduatedStudents,
                    (SELECT COUNT(*) FROM Enrollments) AS TotalEnrollments,
                    (SELECT COUNT(*) FROM Grades WHERE IsPassed = 1) AS PassedCount,
                    (SELECT COUNT(*) FROM Grades WHERE IsPassed = 0) AS FailedCount,
                    (SELECT ISNULL(AVG(TotalScore), 0) FROM Grades WHERE TotalScore IS NOT NULL) AS AvgScore;";

            using (var cmd = new SqlCommand(countSql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    summary.TotalStudents = Convert.ToInt32(reader["TotalStudents"]);
                    summary.TotalClasses = Convert.ToInt32(reader["TotalClasses"]);
                    summary.TotalDepartments = Convert.ToInt32(reader["TotalDepartments"]);
                    summary.TotalSubjects = Convert.ToInt32(reader["TotalSubjects"]);
                    summary.ActiveStudents = Convert.ToInt32(reader["ActiveStudents"]);
                    summary.SuspendedStudents = Convert.ToInt32(reader["SuspendedStudents"]);
                    summary.DroppedStudents = Convert.ToInt32(reader["DroppedStudents"]);
                    summary.GraduatedStudents = Convert.ToInt32(reader["GraduatedStudents"]);
                    summary.TotalEnrollments = Convert.ToInt32(reader["TotalEnrollments"]);
                    summary.PassedCount = Convert.ToInt32(reader["PassedCount"]);
                    summary.FailedCount = Convert.ToInt32(reader["FailedCount"]);
                    summary.AverageTotalScore = Convert.ToDecimal(reader["AvgScore"]);
                }
            }

            return summary;
        }

        public List<ChartItemDTO> GetStudentsByDepartment()
        {
            var list = new List<ChartItemDTO>();
            const string sql = @"
                SELECT d.DepartmentName AS Category, COUNT(s.StudentID) AS StudentCount
                FROM Departments d
                LEFT JOIN Classes c ON d.DepartmentID = c.DepartmentID
                LEFT JOIN Students s ON c.ClassID = s.ClassID
                GROUP BY d.DepartmentID, d.DepartmentName
                ORDER BY StudentCount DESC;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            int total = 0;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int c = Convert.ToInt32(reader["StudentCount"]);
                    total += c;
                    list.Add(new ChartItemDTO
                    {
                        Category = reader["Category"].ToString() ?? string.Empty,
                        Count = c
                    });
                }
            }

            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((decimal)item.Count * 100 / total, 1);
                }
            }
            return list;
        }

        public List<ChartItemDTO> GetStudentsByStatus()
        {
            var list = new List<ChartItemDTO>();
            const string sql = @"
                SELECT Status AS Category, COUNT(*) AS StudentCount
                FROM Students
                GROUP BY Status
                ORDER BY StudentCount DESC;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            int total = 0;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int c = Convert.ToInt32(reader["StudentCount"]);
                    total += c;
                    list.Add(new ChartItemDTO
                    {
                        Category = reader["Category"].ToString() ?? string.Empty,
                        Count = c
                    });
                }
            }

            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((decimal)item.Count * 100 / total, 1);
                }
            }
            return list;
        }

        public List<ChartItemDTO> GetAcademicRankDistribution(string? semesterId = null)
        {
            var list = new List<ChartItemDTO>();
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            string sql = @"
                SELECT ISNULL(g.AcademicRank, N'Chưa có điểm') AS Category, COUNT(*) AS GradeCount
                FROM Enrollments e
                LEFT JOIN Grades g ON e.EnrollmentID = g.EnrollmentID";

            if (!string.IsNullOrWhiteSpace(semesterId))
            {
                sql += " WHERE e.SemesterID = @SemesterID";
                cmd.Parameters.Add("@SemesterID", SqlDbType.NVarChar, 20).Value = semesterId;
            }

            sql += " GROUP BY g.AcademicRank ORDER BY GradeCount DESC;";
            cmd.CommandText = sql;
            conn.Open();
            int total = 0;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int c = Convert.ToInt32(reader["GradeCount"]);
                    total += c;
                    list.Add(new ChartItemDTO
                    {
                        Category = reader["Category"].ToString() ?? string.Empty,
                        Count = c
                    });
                }
            }

            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((decimal)item.Count * 100 / total, 1);
                }
            }
            return list;
        }

        public List<StudentTranscriptSummaryDTO> GetStudentGPASummaries(string? semesterId = null, string? classId = null)
        {
            var list = new List<StudentTranscriptSummaryDTO>();
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            var whereClauses = new List<string>();
            if (!string.IsNullOrWhiteSpace(semesterId))
            {
                whereClauses.Add("e.SemesterID = @SemesterID");
                cmd.Parameters.Add("@SemesterID", SqlDbType.NVarChar, 20).Value = semesterId;
            }
            if (!string.IsNullOrWhiteSpace(classId))
            {
                whereClauses.Add("s.ClassID = @ClassID");
                cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar, 20).Value = classId;
            }

            string sql = @"
                SELECT s.StudentID, s.StudentCode, s.FullName, c.ClassName,
                       SUM(CASE WHEN g.TotalScore IS NOT NULL THEN sub.Credits ELSE 0 END) AS TotalCredits,
                       SUM(CASE WHEN g.IsPassed = 1 THEN 1 ELSE 0 END) AS PassedSubjects,
                       SUM(CASE WHEN g.IsPassed = 0 THEN 1 ELSE 0 END) AS FailedSubjects,
                       SUM(CASE WHEN g.TotalScore IS NOT NULL THEN g.TotalScore * sub.Credits ELSE 0 END) AS WeightedScoreSum
                FROM Students s
                INNER JOIN Classes c ON s.ClassID = c.ClassID
                LEFT JOIN Enrollments e ON s.StudentID = e.StudentID
                LEFT JOIN Subjects sub ON e.SubjectID = sub.SubjectID
                LEFT JOIN Grades g ON e.EnrollmentID = g.EnrollmentID";

            if (whereClauses.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", whereClauses);
            }

            sql += @"
                GROUP BY s.StudentID, s.StudentCode, s.FullName, c.ClassName
                ORDER BY s.StudentCode;";

            cmd.CommandText = sql;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int credits = Convert.ToInt32(reader["TotalCredits"]);
                decimal weightedSum = Convert.ToDecimal(reader["WeightedScoreSum"]);
                decimal gpa10 = credits > 0 ? Math.Round(weightedSum / credits, 2) : 0m;
                
                // Quy đổi GPA hệ 4 xấp xỉ
                decimal gpa4 = 0m;
                if (gpa10 >= 8.5m) gpa4 = 4.0m;
                else if (gpa10 >= 8.0m) gpa4 = 3.5m;
                else if (gpa10 >= 7.0m) gpa4 = 3.0m;
                else if (gpa10 >= 6.5m) gpa4 = 2.5m;
                else if (gpa10 >= 5.5m) gpa4 = 2.0m;
                else if (gpa10 >= 5.0m) gpa4 = 1.5m;
                else if (gpa10 >= 4.0m) gpa4 = 1.0m;
                else gpa4 = 0.0m;

                string rank = "Chưa có";
                if (credits > 0)
                {
                    if (gpa10 >= 9.0m) rank = "Xuất sắc";
                    else if (gpa10 >= 8.0m) rank = "Giỏi";
                    else if (gpa10 >= 6.5m) rank = "Khá";
                    else if (gpa10 >= 5.0m) rank = "Trung bình";
                    else rank = "Yếu";
                }

                list.Add(new StudentTranscriptSummaryDTO
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    StudentCode = reader["StudentCode"].ToString() ?? string.Empty,
                    FullName = reader["FullName"].ToString() ?? string.Empty,
                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                    TotalCredits = credits,
                    GPA10 = gpa10,
                    GPA4 = gpa4,
                    OverallRank = rank,
                    PassedSubjects = Convert.ToInt32(reader["PassedSubjects"]),
                    FailedSubjects = Convert.ToInt32(reader["FailedSubjects"])
                });
            }

            return list;
        }
    }
}

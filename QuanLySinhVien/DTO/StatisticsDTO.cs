using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Thống kê Dashboard & Báo cáo
    /// </summary>
    public class DashboardSummaryDTO
    {
        public int TotalStudents { get; set; }
        public int TotalClasses { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalSubjects { get; set; }
        public int ActiveStudents { get; set; }
        public int SuspendedStudents { get; set; }
        public int DroppedStudents { get; set; }
        public int GraduatedStudents { get; set; }
        public int TotalEnrollments { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public decimal AverageTotalScore { get; set; }
    }

    public class ChartItemDTO
    {
        public string Category { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Percentage { get; set; }
    }

    public class StudentTranscriptSummaryDTO
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int TotalCredits { get; set; }
        public decimal GPA10 { get; set; }
        public decimal GPA4 { get; set; }
        public string OverallRank { get; set; } = string.Empty;
        public int PassedSubjects { get; set; }
        public int FailedSubjects { get; set; }
    }
}

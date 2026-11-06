using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Học kỳ & Năm học
    /// </summary>
    public class SemesterDTO
    {
        public string SemesterID { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string SchoolYear { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; } = false;

        public string DisplayText => $"{SemesterName} - Năm học {SchoolYear}{(IsCurrent ? " [Hiện tại]" : "")}";
    }
}

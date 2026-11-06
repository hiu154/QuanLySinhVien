using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Đăng ký môn học theo học kỳ
    /// </summary>
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public decimal MidtermWeight { get; set; }
        public decimal FinalWeight { get; set; }

        public string SemesterID { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string SchoolYear { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Đã đăng ký";
    }
}

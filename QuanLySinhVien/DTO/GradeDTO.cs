using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Điểm số và Kết quả học tập
    /// </summary>
    public class GradeDTO
    {
        public int GradeID { get; set; }
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string ClassID { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;

        public int SubjectID { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public int Credits { get; set; } = 3;
        public decimal MidtermWeight { get; set; } = 0.40m;
        public decimal FinalWeight { get; set; } = 0.60m;

        public string SemesterID { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string SchoolYear { get; set; } = string.Empty;

        // Điểm thành phần & tổng kết
        public decimal? MidtermScore { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? TotalScore { get; set; }

        public string? LetterGrade { get; set; }  // A+, A, B+, B, C+, C, D+, D, F
        public string? AcademicRank { get; set; } // Xuất sắc, Giỏi, Khá, Trung bình, Yếu
        public bool? IsPassed { get; set; }
        public string? Notes { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Điểm hệ 4 quy đổi từ TotalScore
        public decimal? GradePoint4
        {
            get
            {
                if (!TotalScore.HasValue) return null;
                var t = TotalScore.Value;
                if (t >= 8.5m) return 4.0m; // A / A+
                if (t >= 8.0m) return 3.5m; // B+
                if (t >= 7.0m) return 3.0m; // B
                if (t >= 6.5m) return 2.5m; // C+
                if (t >= 5.5m) return 2.0m; // C
                if (t >= 5.0m) return 1.5m; // D+
                if (t >= 4.0m) return 1.0m; // D
                return 0.0m;                // F
            }
        }
    }
}

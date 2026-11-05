using System;

namespace QuanLySinhVien.DTO
{
    /// <summary>
    /// DTO Môn học
    /// </summary>
    public class SubjectDTO
    {
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public int Credits { get; set; } = 3;
        public decimal MidtermWeight { get; set; } = 0.40m; // 40% quá trình
        public decimal FinalWeight { get; set; } = 0.60m;   // 60% thi
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string DisplayText => $"{SubjectCode} - {SubjectName} ({Credits} TC)";
    }
}

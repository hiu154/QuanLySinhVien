using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class GradeBLL
    {
        private readonly GradeDAL _dal;

        public GradeBLL(GradeDAL? dal = null)
        {
            _dal = dal ?? new GradeDAL();
        }

        public List<GradeDTO> GetGrades(int? studentId = null, int? subjectId = null, string? semesterId = null, string? classId = null)
        {
            return _dal.GetGrades(studentId, subjectId, semesterId, classId);
        }

        public GradeDTO? GetByEnrollmentId(int enrollmentId)
        {
            if (enrollmentId <= 0) return null;
            return _dal.GetByEnrollmentId(enrollmentId);
        }

        public bool SaveGrade(GradeDTO grade, string? operatorUsername = null)
        {
            if (grade == null) throw new ArgumentNullException(nameof(grade));
            if (grade.EnrollmentID <= 0)
                throw new ArgumentException("Bản ghi đăng ký không hợp lệ.");

            // 1. Kiểm tra giới hạn điểm hợp lệ (0.0 đến 10.0)
            if (grade.MidtermScore.HasValue)
            {
                if (grade.MidtermScore.Value < 0.0m || grade.MidtermScore.Value > 10.0m)
                    throw new ArgumentException("Điểm quá trình/giữa kỳ phải nằm trong thang điểm từ 0.0 đến 10.0.");
            }

            if (grade.FinalScore.HasValue)
            {
                if (grade.FinalScore.Value < 0.0m || grade.FinalScore.Value > 10.0m)
                    throw new ArgumentException("Điểm thi kết thúc học phần phải nằm trong thang điểm từ 0.0 đến 10.0.");
            }

            // 2. Tự động tính điểm tổng kết theo trọng số nếu cả hai điểm đã có
            CalculateTotalAndRank(grade);

            int affected = _dal.SaveOrUpdate(grade);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("GRADE_SAVE", $"Lưu kết quả điểm môn {grade.SubjectCode} cho SV {grade.StudentCode}: QT={grade.MidtermScore}, Thi={grade.FinalScore}, Tổng={grade.TotalScore} ({grade.AcademicRank})", operatorUsername);
            }
            return success;
        }

        public List<GradeDTO> GetStudentTranscript(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Vui lòng chọn sinh viên.");
            return _dal.GetStudentTranscript(studentId);
        }

        public List<GradeDTO> GetLowScoreStudents(decimal threshold = 5.0m, string? semesterId = null)
        {
            return _dal.GetLowScoreStudents(threshold, semesterId);
        }

        /// <summary>
        /// Tính điểm tổng kết theo trọng số, điểm chữ và xếp loại học lực theo quy chế đào tạo
        /// </summary>
        public static void CalculateTotalAndRank(GradeDTO g)
        {
            if (g.MidtermScore.HasValue && g.FinalScore.HasValue)
            {
                decimal mw = g.MidtermWeight > 0 ? g.MidtermWeight : 0.40m;
                decimal fw = g.FinalWeight > 0 ? g.FinalWeight : 0.60m;

                decimal total = (g.MidtermScore.Value * mw) + (g.FinalScore.Value * fw);
                g.TotalScore = Math.Round(total, 2);

                // Xác định đạt hay không đạt (thường điểm tổng kết >= 4.0 và điểm thi >= 3.0 là qua môn)
                bool passed = g.TotalScore.Value >= 4.0m && g.FinalScore.Value >= 3.0m;
                g.IsPassed = passed;

                // Xếp loại học lực & Điểm chữ
                if (g.TotalScore.Value >= 9.0m)
                {
                    g.LetterGrade = "A+";
                    g.AcademicRank = "Xuất sắc";
                }
                else if (g.TotalScore.Value >= 8.5m)
                {
                    g.LetterGrade = "A";
                    g.AcademicRank = "Giỏi";
                }
                else if (g.TotalScore.Value >= 8.0m)
                {
                    g.LetterGrade = "B+";
                    g.AcademicRank = "Khá giỏi";
                }
                else if (g.TotalScore.Value >= 7.0m)
                {
                    g.LetterGrade = "B";
                    g.AcademicRank = "Khá";
                }
                else if (g.TotalScore.Value >= 6.5m)
                {
                    g.LetterGrade = "C+";
                    g.AcademicRank = "Trung bình khá";
                }
                else if (g.TotalScore.Value >= 5.5m)
                {
                    g.LetterGrade = "C";
                    g.AcademicRank = "Trung bình";
                }
                else if (g.TotalScore.Value >= 5.0m)
                {
                    g.LetterGrade = "D+";
                    g.AcademicRank = "Trung bình yếu";
                }
                else if (g.TotalScore.Value >= 4.0m)
                {
                    g.LetterGrade = "D";
                    g.AcademicRank = "Yếu";
                }
                else
                {
                    g.LetterGrade = "F";
                    g.AcademicRank = "Kém (Học lại)";
                }
            }
            else
            {
                g.TotalScore = null;
                g.LetterGrade = null;
                g.AcademicRank = "Chưa hoàn thành";
                g.IsPassed = null;
            }
        }
    }
}

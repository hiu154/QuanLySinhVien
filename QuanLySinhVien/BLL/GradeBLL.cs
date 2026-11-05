using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;

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
            return _dal.SaveOrUpdate(grade) > 0;
        }

        public List<GradeDTO> GetStudentTranscript(int studentId)
        {
            return _dal.GetStudentTranscript(studentId);
        }
    }
}

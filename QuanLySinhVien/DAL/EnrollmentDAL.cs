using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class EnrollmentDAL
    {
        public List<EnrollmentDTO> GetEnrollments(int? studentId = null, int? subjectId = null, string? semesterId = null, string? classId = null)
        {
            var list = new List<EnrollmentDTO>();
            var whereClauses = new List<string>();

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            if (studentId.HasValue && studentId.Value > 0)
            {
                whereClauses.Add("e.StudentID = @StudentID");
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentId.Value;
            }

            if (subjectId.HasValue && subjectId.Value > 0)
            {
                whereClauses.Add("e.SubjectID = @SubjectID");
                cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectId.Value;
            }

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
                SELECT e.EnrollmentID, e.StudentID, s.StudentCode, s.FullName AS StudentName, c.ClassName,
                       e.SubjectID, sub.SubjectCode, sub.SubjectName, sub.Credits, sub.MidtermWeight, sub.FinalWeight,
                       e.SemesterID, sem.SemesterName, sem.SchoolYear, e.EnrollmentDate, e.Status
                FROM Enrollments e
                INNER JOIN Students s ON e.StudentID = s.StudentID
                INNER JOIN Classes c ON s.ClassID = c.ClassID
                INNER JOIN Subjects sub ON e.SubjectID = sub.SubjectID
                INNER JOIN Semesters sem ON e.SemesterID = sem.SemesterID";

            if (whereClauses.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", whereClauses);
            }
            sql += " ORDER BY sem.SchoolYear DESC, sub.SubjectCode, s.StudentCode;";

            cmd.CommandText = sql;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new EnrollmentDTO
                {
                    EnrollmentID = Convert.ToInt32(reader["EnrollmentID"]),
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    StudentCode = reader["StudentCode"].ToString() ?? string.Empty,
                    StudentName = reader["StudentName"].ToString() ?? string.Empty,
                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                    SubjectCode = reader["SubjectCode"].ToString() ?? string.Empty,
                    SubjectName = reader["SubjectName"].ToString() ?? string.Empty,
                    Credits = Convert.ToInt32(reader["Credits"]),
                    MidtermWeight = Convert.ToDecimal(reader["MidtermWeight"]),
                    FinalWeight = Convert.ToDecimal(reader["FinalWeight"]),
                    SemesterID = reader["SemesterID"].ToString() ?? string.Empty,
                    SemesterName = reader["SemesterName"].ToString() ?? string.Empty,
                    SchoolYear = reader["SchoolYear"].ToString() ?? string.Empty,
                    EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"]),
                    Status = reader["Status"].ToString() ?? "Đã đăng ký"
                });
            }
            return list;
        }

        public int Enroll(int studentId, int subjectId, string semesterId)
        {
            const string sql = @"
                INSERT INTO Enrollments (StudentID, SubjectID, SemesterID, EnrollmentDate, Status)
                VALUES (@StudentID, @SubjectID, @SemesterID, GETDATE(), N'Đã đăng ký');
                SELECT SCOPE_IDENTITY();";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectId;
            cmd.Parameters.Add("@SemesterID", SqlDbType.NVarChar, 20).Value = semesterId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool IsEnrolled(int studentId, int subjectId, string semesterId)
        {
            const string sql = "SELECT COUNT(1) FROM Enrollments WHERE StudentID = @StudentID AND SubjectID = @SubjectID AND SemesterID = @SemesterID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectId;
            cmd.Parameters.Add("@SemesterID", SqlDbType.NVarChar, 20).Value = semesterId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public int Delete(int enrollmentId)
        {
            const string sql = "DELETE FROM Enrollments WHERE EnrollmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = enrollmentId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}

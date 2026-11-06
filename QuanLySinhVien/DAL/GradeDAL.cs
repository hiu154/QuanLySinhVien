using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class GradeDAL
    {
        private const string SelectBaseSql = @"
            SELECT g.GradeID, e.EnrollmentID, e.StudentID, s.StudentCode, s.FullName AS StudentName,
                   s.ClassID, c.ClassName, e.SubjectID, sub.SubjectCode, sub.SubjectName, sub.Credits,
                   sub.MidtermWeight, sub.FinalWeight, e.SemesterID, sem.SemesterName, sem.SchoolYear,
                   g.MidtermScore, g.FinalScore, g.TotalScore, g.LetterGrade, g.AcademicRank, g.IsPassed,
                   g.Notes, g.UpdatedAt
            FROM Enrollments e
            INNER JOIN Students s ON e.StudentID = s.StudentID
            INNER JOIN Classes c ON s.ClassID = c.ClassID
            INNER JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            INNER JOIN Semesters sem ON e.SemesterID = sem.SemesterID
            LEFT JOIN Grades g ON e.EnrollmentID = g.EnrollmentID";

        public List<GradeDTO> GetGrades(int? studentId = null, int? subjectId = null, string? semesterId = null, string? classId = null)
        {
            var list = new List<GradeDTO>();
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

            string sql = SelectBaseSql;
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
                list.Add(MapGradeFromReader(reader));
            }
            return list;
        }

        public GradeDTO? GetByEnrollmentId(int enrollmentId)
        {
            string sql = $"{SelectBaseSql} WHERE e.EnrollmentID = @EnrollmentID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = enrollmentId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapGradeFromReader(reader);
            }
            return null;
        }

        public int SaveOrUpdate(GradeDTO g)
        {
            // Kiểm tra xem đã có bản ghi trong bảng Grades cho Enrollment này chưa
            const string checkSql = "SELECT GradeID FROM Grades WHERE EnrollmentID = @EnrollmentID;";
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Open();

            using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = g.EnrollmentID;
            object? existingId = checkCmd.ExecuteScalar();

            if (existingId != null && existingId != DBNull.Value)
            {
                // Update
                const string updateSql = @"
                    UPDATE Grades
                    SET MidtermScore = @Midterm,
                        FinalScore = @Final,
                        TotalScore = @Total,
                        LetterGrade = @Letter,
                        AcademicRank = @Rank,
                        IsPassed = @Passed,
                        Notes = @Notes,
                        UpdatedAt = GETDATE()
                    WHERE EnrollmentID = @EnrollmentID;";

                using var updateCmd = new SqlCommand(updateSql, conn);
                AddGradeParams(updateCmd, g);
                return updateCmd.ExecuteNonQuery();
            }
            else
            {
                // Insert
                const string insertSql = @"
                    INSERT INTO Grades 
                        (EnrollmentID, MidtermScore, FinalScore, TotalScore, LetterGrade, AcademicRank, IsPassed, Notes, UpdatedAt)
                    VALUES 
                        (@EnrollmentID, @Midterm, @Final, @Total, @Letter, @Rank, @Passed, @Notes, GETDATE());";

                using var insertCmd = new SqlCommand(insertSql, conn);
                AddGradeParams(insertCmd, g);
                return insertCmd.ExecuteNonQuery();
            }
        }

        public List<GradeDTO> GetStudentTranscript(int studentId)
        {
            return GetGrades(studentId: studentId);
        }

        public List<GradeDTO> GetLowScoreStudents(decimal threshold = 5.0m, string? semesterId = null)
        {
            var list = new List<GradeDTO>();
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            string sql = $"{SelectBaseSql} WHERE (g.TotalScore IS NOT NULL AND g.TotalScore < @Threshold)";
            cmd.Parameters.Add("@Threshold", SqlDbType.Decimal).Value = threshold;

            if (!string.IsNullOrWhiteSpace(semesterId))
            {
                sql += " AND e.SemesterID = @SemesterID";
                cmd.Parameters.Add("@SemesterID", SqlDbType.NVarChar, 20).Value = semesterId;
            }

            sql += " ORDER BY g.TotalScore ASC, s.StudentCode;";
            cmd.CommandText = sql;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapGradeFromReader(reader));
            }
            return list;
        }

        private static void AddGradeParams(SqlCommand cmd, GradeDTO g)
        {
            cmd.Parameters.Add("@EnrollmentID", SqlDbType.Int).Value = g.EnrollmentID;
            cmd.Parameters.Add("@Midterm", SqlDbType.Decimal).Value = DbConnectionFactory.DbValue(g.MidtermScore);
            cmd.Parameters.Add("@Final", SqlDbType.Decimal).Value = DbConnectionFactory.DbValue(g.FinalScore);
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = DbConnectionFactory.DbValue(g.TotalScore);
            cmd.Parameters.Add("@Letter", SqlDbType.NVarChar, 5).Value = DbConnectionFactory.DbValue(g.LetterGrade);
            cmd.Parameters.Add("@Rank", SqlDbType.NVarChar, 30).Value = DbConnectionFactory.DbValue(g.AcademicRank);
            cmd.Parameters.Add("@Passed", SqlDbType.Bit).Value = DbConnectionFactory.DbValue(g.IsPassed);
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 255).Value = DbConnectionFactory.DbValue(g.Notes);
        }

        private static GradeDTO MapGradeFromReader(SqlDataReader reader)
        {
            return new GradeDTO
            {
                GradeID = reader["GradeID"] != DBNull.Value ? Convert.ToInt32(reader["GradeID"]) : 0,
                EnrollmentID = Convert.ToInt32(reader["EnrollmentID"]),
                StudentID = Convert.ToInt32(reader["StudentID"]),
                StudentCode = reader["StudentCode"].ToString() ?? string.Empty,
                StudentName = reader["StudentName"].ToString() ?? string.Empty,
                ClassID = reader["ClassID"].ToString() ?? string.Empty,
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
                MidtermScore = reader["MidtermScore"] != DBNull.Value ? Convert.ToDecimal(reader["MidtermScore"]) : null,
                FinalScore = reader["FinalScore"] != DBNull.Value ? Convert.ToDecimal(reader["FinalScore"]) : null,
                TotalScore = reader["TotalScore"] != DBNull.Value ? Convert.ToDecimal(reader["TotalScore"]) : null,
                LetterGrade = reader["LetterGrade"] != DBNull.Value ? reader["LetterGrade"].ToString() : null,
                AcademicRank = reader["AcademicRank"] != DBNull.Value ? reader["AcademicRank"].ToString() : null,
                IsPassed = reader["IsPassed"] != DBNull.Value ? Convert.ToBoolean(reader["IsPassed"]) : null,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedAt"]) : DateTime.Now
            };
        }
    }
}

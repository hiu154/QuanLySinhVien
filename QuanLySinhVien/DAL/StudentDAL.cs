using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class StudentDAL
    {
        private const string SelectBaseSql = @"
            SELECT s.StudentID, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, 
                   s.Email, s.PhoneNumber, s.Address, s.ClassID, c.ClassName, 
                   c.DepartmentID, d.DepartmentName, s.AdmissionDate, s.Status, s.CreatedAt
            FROM Students s
            INNER JOIN Classes c ON s.ClassID = c.ClassID
            INNER JOIN Departments d ON c.DepartmentID = d.DepartmentID";

        public List<StudentDTO> GetAll()
        {
            var list = new List<StudentDTO>();
            string sql = $"{SelectBaseSql} ORDER BY s.StudentID DESC;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapStudentFromReader(reader));
            }
            return list;
        }

        public StudentDTO? GetById(int studentId)
        {
            string sql = $"{SelectBaseSql} WHERE s.StudentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = studentId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapStudentFromReader(reader);
            }
            return null;
        }

        public StudentDTO? GetByCode(string studentCode)
        {
            string sql = $"{SelectBaseSql} WHERE s.StudentCode = @Code;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 20).Value = studentCode;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapStudentFromReader(reader);
            }
            return null;
        }

        public List<StudentDTO> Search(string? keyword, string? classId = null, string? departmentId = null, string? status = null)
        {
            var list = new List<StudentDTO>();
            var whereClauses = new List<string>();
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                whereClauses.Add("(s.StudentCode LIKE @Keyword OR s.FullName LIKE @Keyword OR c.ClassName LIKE @Keyword OR d.DepartmentName LIKE @Keyword)");
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 100).Value = "%" + keyword.Trim() + "%";
            }

            if (!string.IsNullOrWhiteSpace(classId))
            {
                whereClauses.Add("s.ClassID = @ClassID");
                cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar, 20).Value = classId;
            }

            if (!string.IsNullOrWhiteSpace(departmentId))
            {
                whereClauses.Add("c.DepartmentID = @DeptID");
                cmd.Parameters.Add("@DeptID", SqlDbType.NVarChar, 20).Value = departmentId;
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                whereClauses.Add("s.Status = @Status");
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = status;
            }

            string sql = SelectBaseSql;
            if (whereClauses.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", whereClauses);
            }
            sql += " ORDER BY s.StudentID DESC;";

            cmd.CommandText = sql;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapStudentFromReader(reader));
            }
            return list;
        }

        public int Insert(StudentDTO s)
        {
            const string sql = @"
                INSERT INTO Students 
                    (StudentCode, FullName, DateOfBirth, Gender, Email, PhoneNumber, Address, ClassID, AdmissionDate, Status)
                VALUES 
                    (@Code, @Name, @DOB, @Gender, @Email, @Phone, @Address, @ClassID, @AdmissionDate, @Status);
                SELECT SCOPE_IDENTITY();";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            AddStudentParameters(cmd, s);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int Update(StudentDTO s)
        {
            const string sql = @"
                UPDATE Students 
                SET FullName = @Name,
                    DateOfBirth = @DOB,
                    Gender = @Gender,
                    Email = @Email,
                    PhoneNumber = @Phone,
                    Address = @Address,
                    ClassID = @ClassID,
                    AdmissionDate = @AdmissionDate,
                    Status = @Status
                WHERE StudentID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = s.StudentID;
            AddStudentParameters(cmd, s);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(int studentId)
        {
            const string sql = "DELETE FROM Students WHERE StudentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = studentId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Students WHERE StudentCode = @Code AND StudentID <> @ExcludeId;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 20).Value = code;
            cmd.Parameters.Add("@ExcludeId", SqlDbType.Int).Value = excludeId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool IsEmailExists(string email, int excludeId = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Students WHERE Email = @Email AND StudentID <> @ExcludeId;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
            cmd.Parameters.Add("@ExcludeId", SqlDbType.Int).Value = excludeId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool HasEnrollments(int studentId)
        {
            const string sql = "SELECT COUNT(1) FROM Enrollments WHERE StudentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = studentId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public int UpdateClassForStudent(int studentId, string newClassId)
        {
            const string sql = "UPDATE Students SET ClassID = @ClassID WHERE StudentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar, 20).Value = newClassId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        private static void AddStudentParameters(SqlCommand cmd, StudentDTO s)
        {
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 20).Value = s.StudentCode;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = s.FullName;
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = s.DateOfBirth;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = s.Gender;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = s.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = DbConnectionFactory.DbValue(s.PhoneNumber);
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = DbConnectionFactory.DbValue(s.Address);
            cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar, 20).Value = s.ClassID;
            cmd.Parameters.Add("@AdmissionDate", SqlDbType.Date).Value = s.AdmissionDate;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = s.Status;
        }

        private static StudentDTO MapStudentFromReader(SqlDataReader reader)
        {
            return new StudentDTO
            {
                StudentID = Convert.ToInt32(reader["StudentID"]),
                StudentCode = reader["StudentCode"].ToString() ?? string.Empty,
                FullName = reader["FullName"].ToString() ?? string.Empty,
                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                Gender = reader["Gender"].ToString() ?? "Nam",
                Email = reader["Email"].ToString() ?? string.Empty,
                PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                ClassID = reader["ClassID"].ToString() ?? string.Empty,
                ClassName = reader["ClassName"] != DBNull.Value ? reader["ClassName"].ToString() : null,
                DepartmentID = reader["DepartmentID"] != DBNull.Value ? reader["DepartmentID"].ToString() : null,
                DepartmentName = reader["DepartmentName"] != DBNull.Value ? reader["DepartmentName"].ToString() : null,
                AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]),
                Status = reader["Status"].ToString() ?? "Đang học",
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
    }
}

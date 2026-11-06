using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class ClassDAL
    {
        public List<ClassDTO> GetAll()
        {
            var list = new List<ClassDTO>();
            const string sql = @"
                SELECT c.ClassID, c.ClassName, c.DepartmentID, d.DepartmentName, 
                       c.AcademicYear, c.HeadTeacher, c.CreatedAt,
                       COUNT(s.StudentID) AS TotalStudents
                FROM Classes c
                INNER JOIN Departments d ON c.DepartmentID = d.DepartmentID
                LEFT JOIN Students s ON c.ClassID = s.ClassID
                GROUP BY c.ClassID, c.ClassName, c.DepartmentID, d.DepartmentName, c.AcademicYear, c.HeadTeacher, c.CreatedAt
                ORDER BY c.ClassID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassDTO
                {
                    ClassID = reader["ClassID"].ToString() ?? string.Empty,
                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                    DepartmentID = reader["DepartmentID"].ToString() ?? string.Empty,
                    DepartmentName = reader["DepartmentName"].ToString(),
                    AcademicYear = reader["AcademicYear"] != DBNull.Value ? reader["AcademicYear"].ToString() : null,
                    HeadTeacher = reader["HeadTeacher"] != DBNull.Value ? reader["HeadTeacher"].ToString() : null,
                    CreatedAt = (DateTime)reader["CreatedAt"],
                    TotalStudents = Convert.ToInt32(reader["TotalStudents"])
                });
            }
            return list;
        }

        public List<ClassDTO> GetByDepartment(string departmentId)
        {
            var list = new List<ClassDTO>();
            const string sql = @"
                SELECT c.ClassID, c.ClassName, c.DepartmentID, d.DepartmentName, 
                       c.AcademicYear, c.HeadTeacher, c.CreatedAt,
                       COUNT(s.StudentID) AS TotalStudents
                FROM Classes c
                INNER JOIN Departments d ON c.DepartmentID = d.DepartmentID
                LEFT JOIN Students s ON c.ClassID = s.ClassID
                WHERE c.DepartmentID = @DeptID
                GROUP BY c.ClassID, c.ClassName, c.DepartmentID, d.DepartmentName, c.AcademicYear, c.HeadTeacher, c.CreatedAt
                ORDER BY c.ClassID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@DeptID", SqlDbType.NVarChar, 20).Value = departmentId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ClassDTO
                {
                    ClassID = reader["ClassID"].ToString() ?? string.Empty,
                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                    DepartmentID = reader["DepartmentID"].ToString() ?? string.Empty,
                    DepartmentName = reader["DepartmentName"].ToString(),
                    AcademicYear = reader["AcademicYear"] != DBNull.Value ? reader["AcademicYear"].ToString() : null,
                    HeadTeacher = reader["HeadTeacher"] != DBNull.Value ? reader["HeadTeacher"].ToString() : null,
                    CreatedAt = (DateTime)reader["CreatedAt"],
                    TotalStudents = Convert.ToInt32(reader["TotalStudents"])
                });
            }
            return list;
        }

        public ClassDTO? GetById(string classId)
        {
            const string sql = @"
                SELECT c.ClassID, c.ClassName, c.DepartmentID, d.DepartmentName, 
                       c.AcademicYear, c.HeadTeacher, c.CreatedAt
                FROM Classes c
                INNER JOIN Departments d ON c.DepartmentID = d.DepartmentID
                WHERE c.ClassID = @ClassID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar, 20).Value = classId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new ClassDTO
                {
                    ClassID = reader["ClassID"].ToString() ?? string.Empty,
                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                    DepartmentID = reader["DepartmentID"].ToString() ?? string.Empty,
                    DepartmentName = reader["DepartmentName"].ToString(),
                    AcademicYear = reader["AcademicYear"] != DBNull.Value ? reader["AcademicYear"].ToString() : null,
                    HeadTeacher = reader["HeadTeacher"] != DBNull.Value ? reader["HeadTeacher"].ToString() : null,
                    CreatedAt = (DateTime)reader["CreatedAt"]
                };
            }
            return null;
        }

        public int Insert(ClassDTO cls)
        {
            const string sql = @"
                INSERT INTO Classes (ClassID, ClassName, DepartmentID, AcademicYear, HeadTeacher)
                VALUES (@ID, @Name, @DeptID, @Year, @Teacher);";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = cls.ClassID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = cls.ClassName;
            cmd.Parameters.Add("@DeptID", SqlDbType.NVarChar, 20).Value = cls.DepartmentID;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 20).Value = DbConnectionFactory.DbValue(cls.AcademicYear);
            cmd.Parameters.Add("@Teacher", SqlDbType.NVarChar, 100).Value = DbConnectionFactory.DbValue(cls.HeadTeacher);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Update(ClassDTO cls)
        {
            const string sql = @"
                UPDATE Classes 
                SET ClassName = @Name, DepartmentID = @DeptID, AcademicYear = @Year, HeadTeacher = @Teacher
                WHERE ClassID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = cls.ClassID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = cls.ClassName;
            cmd.Parameters.Add("@DeptID", SqlDbType.NVarChar, 20).Value = cls.DepartmentID;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 20).Value = DbConnectionFactory.DbValue(cls.AcademicYear);
            cmd.Parameters.Add("@Teacher", SqlDbType.NVarChar, 100).Value = DbConnectionFactory.DbValue(cls.HeadTeacher);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(string classId)
        {
            const string sql = "DELETE FROM Classes WHERE ClassID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = classId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool HasStudents(string classId)
        {
            const string sql = "SELECT COUNT(1) FROM Students WHERE ClassID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = classId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool IsIdExists(string classId)
        {
            const string sql = "SELECT COUNT(1) FROM Classes WHERE ClassID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = classId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class StudentDAL
    {
        public List<StudentDTO> GetAll()
        {
            var list = new List<StudentDTO>();
            const string sql = @"
                SELECT s.StudentID, s.StudentCode, s.FullName, s.DateOfBirth, s.Gender, 
                       s.Email, s.PhoneNumber, s.Address, s.ClassID, c.ClassName, 
                       c.DepartmentID, d.DepartmentName, s.EnrollmentDate, s.Status
                FROM Students s
                LEFT JOIN Classes c ON s.ClassID = c.ClassID
                LEFT JOIN Departments d ON c.DepartmentID = d.DepartmentID
                ORDER BY s.StudentCode;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapStudent(reader));
            }
            return list;
        }

        public StudentDTO? GetById(int id)
        {
            const string sql = "SELECT * FROM Students WHERE StudentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapStudent(reader) : null;
        }

        private static StudentDTO MapStudent(SqlDataReader r)
        {
            return new StudentDTO
            {
                StudentID = Convert.ToInt32(r["StudentID"]),
                StudentCode = r["StudentCode"].ToString() ?? string.Empty,
                FullName = r["FullName"].ToString() ?? string.Empty,
                DateOfBirth = Convert.ToDateTime(r["DateOfBirth"]),
                Gender = r["Gender"].ToString() ?? "Nam",
                Email = r["Email"] != DBNull.Value ? r["Email"].ToString() : null,
                PhoneNumber = r["PhoneNumber"] != DBNull.Value ? r["PhoneNumber"].ToString() : null,
                Address = r["Address"] != DBNull.Value ? r["Address"].ToString() : null,
                ClassID = r["ClassID"] != DBNull.Value ? r["ClassID"].ToString() : null,
                Status = r["Status"].ToString() ?? "Đang học"
            };
        }
    }
}

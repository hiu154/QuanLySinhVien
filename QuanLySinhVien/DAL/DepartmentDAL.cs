using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class DepartmentDAL
    {
        public List<DepartmentDTO> GetAll()
        {
            var list = new List<DepartmentDTO>();
            const string sql = @"
                SELECT d.DepartmentID, d.DepartmentName, d.Description, d.CreatedAt,
                       COUNT(DISTINCT c.ClassID) AS TotalClasses,
                       COUNT(DISTINCT s.StudentID) AS TotalStudents
                FROM Departments d
                LEFT JOIN Classes c ON d.DepartmentID = c.DepartmentID
                LEFT JOIN Students s ON c.ClassID = s.ClassID
                GROUP BY d.DepartmentID, d.DepartmentName, d.Description, d.CreatedAt
                ORDER BY d.DepartmentID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DepartmentDTO
                {
                    DepartmentID = reader["DepartmentID"].ToString() ?? string.Empty,
                    DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                    CreatedAt = (DateTime)reader["CreatedAt"],
                    TotalClasses = Convert.ToInt32(reader["TotalClasses"]),
                    TotalStudents = Convert.ToInt32(reader["TotalStudents"])
                });
            }
            return list;
        }

        public DepartmentDTO? GetById(string departmentId)
        {
            const string sql = "SELECT DepartmentID, DepartmentName, Description, CreatedAt FROM Departments WHERE DepartmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = departmentId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new DepartmentDTO
                {
                    DepartmentID = reader["DepartmentID"].ToString() ?? string.Empty,
                    DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                    CreatedAt = (DateTime)reader["CreatedAt"]
                };
            }
            return null;
        }

        public int Insert(DepartmentDTO dept)
        {
            const string sql = "INSERT INTO Departments (DepartmentID, DepartmentName, Description) VALUES (@ID, @Name, @Desc);";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = dept.DepartmentID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = dept.DepartmentName;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 255).Value = DbConnectionFactory.DbValue(dept.Description);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Update(DepartmentDTO dept)
        {
            const string sql = "UPDATE Departments SET DepartmentName = @Name, Description = @Desc WHERE DepartmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = dept.DepartmentID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = dept.DepartmentName;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 255).Value = DbConnectionFactory.DbValue(dept.Description);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(string departmentId)
        {
            const string sql = "DELETE FROM Departments WHERE DepartmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = departmentId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool HasClasses(string departmentId)
        {
            const string sql = "SELECT COUNT(1) FROM Classes WHERE DepartmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = departmentId;
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public bool IsIdExists(string departmentId)
        {
            const string sql = "SELECT COUNT(1) FROM Departments WHERE DepartmentID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = departmentId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}

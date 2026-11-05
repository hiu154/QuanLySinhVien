using System;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class UserDAL
    {
        public (UserDTO? User, string PasswordHash, string Salt) GetAuthInfoByUsername(string username)
        {
            const string sql = @"
                SELECT u.UserID, u.Username, u.PasswordHash, u.Salt, u.FullName, u.Role, 
                       u.Email, u.PhoneNumber, u.StudentID, s.StudentCode, u.IsActive, u.LastLogin, u.CreatedAt
                FROM Users u
                LEFT JOIN Students s ON u.StudentID = s.StudentID
                WHERE u.Username = @Username;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var user = new UserDTO
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"].ToString() ?? string.Empty,
                    FullName = reader["FullName"].ToString() ?? string.Empty,
                    Role = reader["Role"].ToString() ?? "Student",
                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                    StudentID = reader["StudentID"] != DBNull.Value ? Convert.ToInt32(reader["StudentID"]) : null,
                    StudentCode = reader["StudentCode"] != DBNull.Value ? reader["StudentCode"].ToString() : null,
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    LastLogin = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : null,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                };
                string hash = reader["PasswordHash"].ToString() ?? string.Empty;
                string salt = reader["Salt"].ToString() ?? string.Empty;
                return (user, hash, salt);
            }
            return (null, string.Empty, string.Empty);
        }

        public bool UpdateLastLogin(int userId)
        {
            const string sql = "UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @UserID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool ChangePassword(int userId, string newHash, string newSalt)
        {
            const string sql = "UPDATE Users SET PasswordHash = @Hash, Salt = @Salt WHERE UserID = @UserID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 255).Value = newHash;
            cmd.Parameters.Add("@Salt", SqlDbType.NVarChar, 100).Value = newSalt;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}

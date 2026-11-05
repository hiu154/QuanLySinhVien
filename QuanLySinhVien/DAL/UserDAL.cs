using System;
using System.Collections.Generic;
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

        public List<UserDTO> GetAll()
        {
            var list = new List<UserDTO>();
            const string sql = @"
                SELECT u.UserID, u.Username, u.FullName, u.Role, u.Email, u.PhoneNumber, 
                       u.StudentID, s.StudentCode, u.IsActive, u.LastLogin, u.CreatedAt
                FROM Users u
                LEFT JOIN Students s ON u.StudentID = s.StudentID
                ORDER BY u.UserID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new UserDTO
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
                });
            }
            return list;
        }

        public int Insert(UserDTO u, string passwordHash, string salt)
        {
            const string sql = @"
                INSERT INTO Users 
                    (Username, PasswordHash, Salt, FullName, Role, Email, PhoneNumber, StudentID, IsActive, CreatedAt)
                VALUES 
                    (@Username, @Hash, @Salt, @FullName, @Role, @Email, @Phone, @StudentID, @Active, GETDATE());
                SELECT SCOPE_IDENTITY();";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = u.Username;
            cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 255).Value = passwordHash;
            cmd.Parameters.Add("@Salt", SqlDbType.NVarChar, 100).Value = salt;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = u.FullName;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 30).Value = u.Role;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = DbConnectionFactory.DbValue(u.Email);
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = DbConnectionFactory.DbValue(u.PhoneNumber);
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = DbConnectionFactory.DbValue(u.StudentID);
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = u.IsActive;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int Update(UserDTO u)
        {
            const string sql = @"
                UPDATE Users 
                SET FullName = @FullName, Role = @Role, Email = @Email, 
                    PhoneNumber = @Phone, StudentID = @StudentID, IsActive = @Active
                WHERE UserID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = u.UserID;
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = u.FullName;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 30).Value = u.Role;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = DbConnectionFactory.DbValue(u.Email);
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = DbConnectionFactory.DbValue(u.PhoneNumber);
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = DbConnectionFactory.DbValue(u.StudentID);
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = u.IsActive;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int ChangePassword(int userId, string newHash, string newSalt)
        {
            const string sql = "UPDATE Users SET PasswordHash = @Hash, Salt = @Salt WHERE UserID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = userId;
            cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 255).Value = newHash;
            cmd.Parameters.Add("@Salt", SqlDbType.NVarChar, 100).Value = newSalt;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public void UpdateLastLogin(int userId)
        {
            const string sql = "UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = userId;
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public int Delete(int userId)
        {
            const string sql = "DELETE FROM Users WHERE UserID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = userId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool IsUsernameExists(string username, int excludeId = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND UserID <> @ExcludeId;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
            cmd.Parameters.Add("@ExcludeId", SqlDbType.Int).Value = excludeId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}

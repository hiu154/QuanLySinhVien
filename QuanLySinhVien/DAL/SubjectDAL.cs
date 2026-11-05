using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class SubjectDAL
    {
        public List<SubjectDTO> GetAll()
        {
            var list = new List<SubjectDTO>();
            const string sql = "SELECT SubjectID, SubjectCode, SubjectName, Credits, MidtermWeight, FinalWeight, Description, CreatedAt FROM Subjects ORDER BY SubjectCode;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SubjectDTO
                {
                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                    SubjectCode = reader["SubjectCode"].ToString() ?? string.Empty,
                    SubjectName = reader["SubjectName"].ToString() ?? string.Empty,
                    Credits = Convert.ToInt32(reader["Credits"]),
                    MidtermWeight = Convert.ToDecimal(reader["MidtermWeight"]),
                    FinalWeight = Convert.ToDecimal(reader["FinalWeight"]),
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                });
            }
            return list;
        }

        public SubjectDTO? GetById(int subjectId)
        {
            const string sql = "SELECT SubjectID, SubjectCode, SubjectName, Credits, MidtermWeight, FinalWeight, Description, CreatedAt FROM Subjects WHERE SubjectID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = subjectId;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new SubjectDTO
                {
                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                    SubjectCode = reader["SubjectCode"].ToString() ?? string.Empty,
                    SubjectName = reader["SubjectName"].ToString() ?? string.Empty,
                    Credits = Convert.ToInt32(reader["Credits"]),
                    MidtermWeight = Convert.ToDecimal(reader["MidtermWeight"]),
                    FinalWeight = Convert.ToDecimal(reader["FinalWeight"]),
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                };
            }
            return null;
        }

        public int Insert(SubjectDTO s)
        {
            const string sql = @"
                INSERT INTO Subjects (SubjectCode, SubjectName, Credits, MidtermWeight, FinalWeight, Description)
                VALUES (@Code, @Name, @Credits, @MidWeight, @FinWeight, @Desc);
                SELECT SCOPE_IDENTITY();";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 20).Value = s.SubjectCode;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = s.SubjectName;
            cmd.Parameters.Add("@Credits", SqlDbType.Int).Value = s.Credits;
            cmd.Parameters.Add("@MidWeight", SqlDbType.Decimal).Value = s.MidtermWeight;
            cmd.Parameters.Add("@FinWeight", SqlDbType.Decimal).Value = s.FinalWeight;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 255).Value = DbConnectionFactory.DbValue(s.Description);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int Update(SubjectDTO s)
        {
            const string sql = @"
                UPDATE Subjects 
                SET SubjectName = @Name, Credits = @Credits, MidtermWeight = @MidWeight, 
                    FinalWeight = @FinWeight, Description = @Desc
                WHERE SubjectID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = s.SubjectID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = s.SubjectName;
            cmd.Parameters.Add("@Credits", SqlDbType.Int).Value = s.Credits;
            cmd.Parameters.Add("@MidWeight", SqlDbType.Decimal).Value = s.MidtermWeight;
            cmd.Parameters.Add("@FinWeight", SqlDbType.Decimal).Value = s.FinalWeight;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 255).Value = DbConnectionFactory.DbValue(s.Description);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(int subjectId)
        {
            const string sql = "DELETE FROM Subjects WHERE SubjectID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = subjectId;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool HasEnrollments(int subjectId)
        {
            const string sql = "SELECT COUNT(1) FROM Enrollments WHERE SubjectID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = subjectId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Subjects WHERE SubjectCode = @Code AND SubjectID <> @ExcludeId;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 20).Value = code;
            cmd.Parameters.Add("@ExcludeId", SqlDbType.Int).Value = excludeId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}

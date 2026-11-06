using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class SemesterDAL
    {
        public List<SemesterDTO> GetAll()
        {
            var list = new List<SemesterDTO>();
            const string sql = "SELECT SemesterID, SemesterName, SchoolYear, StartDate, EndDate, IsCurrent FROM Semesters ORDER BY SchoolYear DESC, SemesterName DESC;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SemesterDTO
                {
                    SemesterID = reader["SemesterID"].ToString() ?? string.Empty,
                    SemesterName = reader["SemesterName"].ToString() ?? string.Empty,
                    SchoolYear = reader["SchoolYear"].ToString() ?? string.Empty,
                    StartDate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : null,
                    EndDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : null,
                    IsCurrent = Convert.ToBoolean(reader["IsCurrent"])
                });
            }
            return list;
        }

        public SemesterDTO? GetCurrent()
        {
            const string sql = "SELECT TOP 1 SemesterID, SemesterName, SchoolYear, StartDate, EndDate, IsCurrent FROM Semesters WHERE IsCurrent = 1;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new SemesterDTO
                {
                    SemesterID = reader["SemesterID"].ToString() ?? string.Empty,
                    SemesterName = reader["SemesterName"].ToString() ?? string.Empty,
                    SchoolYear = reader["SchoolYear"].ToString() ?? string.Empty,
                    StartDate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : null,
                    EndDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : null,
                    IsCurrent = true
                };
            }
            return null;
        }

        public int Insert(SemesterDTO sem)
        {
            const string sql = @"
                INSERT INTO Semesters (SemesterID, SemesterName, SchoolYear, StartDate, EndDate, IsCurrent)
                VALUES (@ID, @Name, @Year, @Start, @End, @Current);";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = sem.SemesterID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = sem.SemesterName;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 20).Value = sem.SchoolYear;
            cmd.Parameters.Add("@Start", SqlDbType.Date).Value = DbConnectionFactory.DbValue(sem.StartDate);
            cmd.Parameters.Add("@End", SqlDbType.Date).Value = DbConnectionFactory.DbValue(sem.EndDate);
            cmd.Parameters.Add("@Current", SqlDbType.Bit).Value = sem.IsCurrent;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Update(SemesterDTO sem)
        {
            const string sql = @"
                UPDATE Semesters 
                SET SemesterName = @Name, SchoolYear = @Year, StartDate = @Start, EndDate = @End, IsCurrent = @Current
                WHERE SemesterID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = sem.SemesterID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = sem.SemesterName;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 20).Value = sem.SchoolYear;
            cmd.Parameters.Add("@Start", SqlDbType.Date).Value = DbConnectionFactory.DbValue(sem.StartDate);
            cmd.Parameters.Add("@End", SqlDbType.Date).Value = DbConnectionFactory.DbValue(sem.EndDate);
            cmd.Parameters.Add("@Current", SqlDbType.Bit).Value = sem.IsCurrent;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public void SetCurrentSemester(string semesterId)
        {
            const string sql = @"
                UPDATE Semesters SET IsCurrent = 0;
                UPDATE Semesters SET IsCurrent = 1 WHERE SemesterID = @ID;";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = semesterId;
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public bool IsIdExists(string semesterId)
        {
            const string sql = "SELECT COUNT(1) FROM Semesters WHERE SemesterID = @ID;";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = semesterId;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}

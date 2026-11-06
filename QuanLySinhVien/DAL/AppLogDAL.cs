using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class AppLogDAL
    {
        public int Insert(AppLogDTO log)
        {
            const string sql = @"
                INSERT INTO SystemLogs (Timestamp, LogLevel, Username, Action, Message, ExceptionDetails)
                VALUES (@Timestamp, @Level, @Username, @Action, @Message, @Ex);";

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Timestamp", SqlDbType.DateTime).Value = log.Timestamp;
            cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 20).Value = log.LogLevel;
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = DbConnectionFactory.DbValue(log.Username);
            cmd.Parameters.Add("@Action", SqlDbType.NVarChar, 100).Value = log.Action;
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar, -1).Value = log.Message;
            cmd.Parameters.Add("@Ex", SqlDbType.NVarChar, -1).Value = DbConnectionFactory.DbValue(log.ExceptionDetails);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public List<AppLogDTO> GetLogs(string? level = null, string? username = null, DateTime? fromDate = null, DateTime? toDate = null, int limit = 200)
        {
            var list = new List<AppLogDTO>();
            var whereClauses = new List<string>();

            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            if (!string.IsNullOrWhiteSpace(level) && !string.Equals(level, "Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                whereClauses.Add("LogLevel = @Level");
                cmd.Parameters.Add("@Level", SqlDbType.NVarChar, 20).Value = level;
            }

            if (!string.IsNullOrWhiteSpace(username))
            {
                whereClauses.Add("Username LIKE @Username");
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = "%" + username.Trim() + "%";
            }

            if (fromDate.HasValue)
            {
                whereClauses.Add("Timestamp >= @FromDate");
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate.Value.Date;
            }

            if (toDate.HasValue)
            {
                whereClauses.Add("Timestamp <= @ToDate");
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate.Value.Date.AddDays(1).AddSeconds(-1);
            }

            string sql = $"SELECT TOP ({limit}) LogID, Timestamp, LogLevel, Username, Action, Message, ExceptionDetails FROM SystemLogs";
            if (whereClauses.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", whereClauses);
            }
            sql += " ORDER BY LogID DESC;";

            cmd.CommandText = sql;
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AppLogDTO
                {
                    LogID = Convert.ToInt32(reader["LogID"]),
                    Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    LogLevel = reader["LogLevel"].ToString() ?? "Information",
                    Username = reader["Username"] != DBNull.Value ? reader["Username"].ToString() : null,
                    Action = reader["Action"].ToString() ?? string.Empty,
                    Message = reader["Message"].ToString() ?? string.Empty,
                    ExceptionDetails = reader["ExceptionDetails"] != DBNull.Value ? reader["ExceptionDetails"].ToString() : null
                });
            }
            return list;
        }

        public int ClearOldLogs(int daysToKeep = 30)
        {
            const string sql = "DELETE FROM SystemLogs WHERE Timestamp < DATEADD(day, -@Days, GETDATE());";
            using var conn = DbConnectionFactory.CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Days", SqlDbType.Int).Value = daysToKeep;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}

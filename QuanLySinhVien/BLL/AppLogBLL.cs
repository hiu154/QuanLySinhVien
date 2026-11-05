using System;
using System.Collections.Generic;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class AppLogBLL
    {
        private readonly AppLogDAL _dal;

        public AppLogBLL(AppLogDAL? dal = null)
        {
            _dal = dal ?? new AppLogDAL();
        }

        public static void InitializeDatabaseLogging()
        {
            var dal = new AppLogDAL();
            AppLogger.DatabaseLogHandler = (log) =>
            {
                try
                {
                    dal.Insert(log);
                }
                catch
                {
                    // Tránh crash ứng dụng nếu DB gặp sự cố
                }
            };
        }

        public List<AppLogDTO> GetLogs(string? level = null, string? username = null, DateTime? fromDate = null, DateTime? toDate = null, int limit = 200)
        {
            return _dal.GetLogs(level, username, fromDate, toDate, limit);
        }

        public bool ClearOldLogs(int daysToKeep = 30)
        {
            int affected = _dal.ClearOldLogs(daysToKeep);
            AppLogger.LogInformation("CLEAR_LOGS", $"Đã xóa {affected} bản ghi log cũ hơn {daysToKeep} ngày", AuthBLL.CurrentUser?.Username);
            return affected >= 0;
        }
    }
}

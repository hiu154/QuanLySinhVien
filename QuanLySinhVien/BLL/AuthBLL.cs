using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.BLL
{
    public class AuthBLL
    {
        private readonly UserDAL _dal;

        // Phiên đăng nhập người dùng hiện tại
        public static UserDTO? CurrentUser { get; private set; }

        public AuthBLL(UserDAL? dal = null)
        {
            _dal = dal ?? new UserDAL();
        }

        public static void SetCurrentUser(UserDTO? user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            if (CurrentUser != null)
            {
                AppLogger.LogInformation("LOGOUT", $"Người dùng '{CurrentUser.Username}' ({CurrentUser.Role}) đã đăng xuất", CurrentUser.Username);
            }
            CurrentUser = null;
        }

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Mật khẩu không được để trống.");

            username = username.Trim();

            var authInfo = _dal.GetAuthInfoByUsername(username);
            if (authInfo.User == null)
            {
                AppLogger.LogWarning("LOGIN_FAIL", $"Đăng nhập thất bại: Tài khoản '{username}' không tồn tại");
                throw new ArgumentException("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            if (!authInfo.User.IsActive)
            {
                AppLogger.LogWarning("LOGIN_FAIL", $"Đăng nhập thất bại: Tài khoản '{username}' đang bị khóa");
                throw new InvalidOperationException("Tài khoản này hiện đang bị khóa. Vui lòng liên hệ Quản trị viên.");
            }

            // Kiểm tra mật khẩu băm
            string computedHash = HashPassword(password, authInfo.Salt);
            if (!string.Equals(computedHash, authInfo.PasswordHash, StringComparison.OrdinalIgnoreCase))
            {
                AppLogger.LogWarning("LOGIN_FAIL", $"Đăng nhập thất bại: Sai mật khẩu cho tài khoản '{username}'");
                throw new ArgumentException("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            // Đăng nhập thành công
            _dal.UpdateLastLogin(authInfo.User.UserID);
            CurrentUser = authInfo.User;
            AppLogger.LogInformation("LOGIN_SUCCESS", $"Đăng nhập thành công: {authInfo.User.Username} [{authInfo.User.Role}] - {authInfo.User.FullName}", authInfo.User.Username);

            return authInfo.User;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword, string? username = null)
        {
            if (userId <= 0)
                throw new ArgumentException("Người dùng không hợp lệ.");

            if (string.IsNullOrWhiteSpace(oldPassword))
                throw new ArgumentException("Vui lòng nhập mật khẩu cũ.");

            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("Vui lòng nhập mật khẩu mới.");

            if (newPassword.Length < 6)
                throw new ArgumentException("Mật khẩu mới phải có ít nhất 6 ký tự.");

            if (oldPassword == newPassword)
                throw new ArgumentException("Mật khẩu mới không được trùng với mật khẩu cũ.");

            // Lấy thông tin xác thực hiện tại
            var user = CurrentUser;
            if (user == null || user.UserID != userId)
            {
                // Tìm theo ID hoặc username
                var all = _dal.GetAll();
                user = all.Find(u => u.UserID == userId);
            }

            if (user == null)
                throw new ArgumentException("Không tìm thấy người dùng.");

            var authInfo = _dal.GetAuthInfoByUsername(user.Username);
            string oldHash = HashPassword(oldPassword, authInfo.Salt);
            if (!string.Equals(oldHash, authInfo.PasswordHash, StringComparison.OrdinalIgnoreCase))
            {
                AppLogger.LogWarning("PASSWORD_CHANGE_FAIL", $"Đổi mật khẩu thất bại: Mật khẩu cũ không đúng cho {user.Username}", user.Username);
                throw new ArgumentException("Mật khẩu cũ không chính xác.");
            }

            string newSalt = GenerateSalt();
            string newHash = HashPassword(newPassword, newSalt);

            int affected = _dal.ChangePassword(userId, newHash, newSalt);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("PASSWORD_CHANGE_SUCCESS", $"Đổi mật khẩu thành công cho tài khoản {user.Username}", user.Username);
            }
            return success;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _dal.GetAll();
        }

        public int AddUser(UserDTO u, string password, string? operatorUsername = null)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            u.Username = u.Username.Trim();
            u.FullName = u.FullName.Trim();

            if (string.IsNullOrWhiteSpace(u.Username))
                throw new ArgumentException("Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Mật khẩu khởi tạo phải từ 6 ký tự trở lên.");

            if (_dal.IsUsernameExists(u.Username))
            {
                AppLogger.LogWarning("USER_ADD", $"Tên đăng nhập đã tồn tại: {u.Username}", operatorUsername);
                throw new ArgumentException($"Tên đăng nhập '{u.Username}' đã tồn tại.");
            }

            string salt = GenerateSalt();
            string hash = HashPassword(password, salt);

            int newId = _dal.Insert(u, hash, salt);
            AppLogger.LogInformation("USER_ADD", $"Tạo tài khoản mới thành công: {u.Username} [{u.Role}]", operatorUsername);
            return newId;
        }

        public bool UpdateUser(UserDTO u, string? operatorUsername = null)
        {
            if (u.UserID <= 0)
                throw new ArgumentException("Hãy chọn tài khoản cần cập nhật.");

            int affected = _dal.Update(u);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("USER_UPDATE", $"Cập nhật tài khoản: {u.Username} (Role: {u.Role}, Active: {u.IsActive})", operatorUsername);
            }
            return success;
        }

        public bool ResetPassword(int userId, string newPassword, string? operatorUsername = null)
        {
            if (userId <= 0)
                throw new ArgumentException("Hãy chọn tài khoản cần đặt lại mật khẩu.");

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                throw new ArgumentException("Mật khẩu mới phải có ít nhất 6 ký tự.");

            string newSalt = GenerateSalt();
            string newHash = HashPassword(newPassword, newSalt);

            int affected = _dal.ChangePassword(userId, newHash, newSalt);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("USER_RESET_PASSWORD", $"Đặt lại mật khẩu cho tài khoản ID {userId}", operatorUsername);
            }
            return success;
        }

        public bool DeleteUser(int userId, string? operatorUsername = null)
        {
            if (userId <= 0)
                throw new ArgumentException("Hãy chọn tài khoản cần xóa.");

            if (CurrentUser != null && CurrentUser.UserID == userId)
                throw new InvalidOperationException("Bạn không thể xóa chính tài khoản đang đăng nhập hiện tại.");

            int affected = _dal.Delete(userId);
            bool success = affected > 0;
            if (success)
            {
                AppLogger.LogInformation("USER_DELETE", $"Đã xóa tài khoản ID {userId}", operatorUsername);
            }
            return success;
        }

        #region Helpers Hashing & Security
        public static string GenerateSalt(int length = 16)
        {
            byte[] bytes = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);
            
            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region Role-based Permission Checks
        public static bool CanManageStudents()
        {
            if (CurrentUser == null) return false;
            return CurrentUser.IsAdmin;
        }

        public static bool CanManageClassesAndDepartments()
        {
            if (CurrentUser == null) return false;
            return CurrentUser.IsAdmin;
        }

        public static bool CanManageSubjectsAndSemesters()
        {
            if (CurrentUser == null) return false;
            return CurrentUser.IsAdmin;
        }

        public static bool CanEditGrades()
        {
            if (CurrentUser == null) return false;
            // Admin hoặc Giảng viên đều được nhập điểm
            return CurrentUser.IsAdmin || CurrentUser.IsTeacher;
        }

        public static bool CanManageUsers()
        {
            if (CurrentUser == null) return false;
            return CurrentUser.IsAdmin;
        }

        public static bool CanViewSystemLogs()
        {
            if (CurrentUser == null) return false;
            return CurrentUser.IsAdmin;
        }
        #endregion
    }
}

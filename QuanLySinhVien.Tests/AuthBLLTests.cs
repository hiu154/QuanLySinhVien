using System;
using QuanLySinhVien.BLL;
using Xunit;

namespace QuanLySinhVien.Tests
{
    public class AuthBLLTests
    {
        [Fact]
        public void HashPassword_ShouldReturnValid64CharHex()
        {
            // Arrange
            string password = "SecretPassword123";
            string salt = AuthBLL.GenerateSalt();

            // Act
            string hash = AuthBLL.HashPassword(password, salt);

            // Assert
            Assert.NotNull(hash);
            Assert.Equal(64, hash.Length); // SHA-256 hex length
        }

        [Fact]
        public void HashPassword_SameInput_ShouldProduceIdenticalHash()
        {
            // Arrange
            string password = "AdminPassword2026";
            string salt = "FixedSaltStringForTest123=";

            // Act
            string hash1 = AuthBLL.HashPassword(password, salt);
            string hash2 = AuthBLL.HashPassword(password, salt);

            // Assert
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void HashPassword_DifferentSalt_ShouldProduceDifferentHash()
        {
            // Arrange
            string password = "SamePassword";
            string salt1 = AuthBLL.GenerateSalt();
            string salt2 = AuthBLL.GenerateSalt();

            // Act
            string hash1 = AuthBLL.HashPassword(password, salt1);
            string hash2 = AuthBLL.HashPassword(password, salt2);

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        [Theory]
        [InlineData(null, "password123")]
        [InlineData("", "password123")]
        [InlineData("   ", "password123")]
        public void Login_EmptyUsername_ShouldThrowArgumentException(string? username, string password)
        {
            // Arrange
            var authBll = new AuthBLL();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => authBll.Login(username!, password));
            Assert.Contains("Tên đăng nhập không được để trống", ex.Message);
        }

        [Theory]
        [InlineData("admin", null)]
        [InlineData("admin", "")]
        [InlineData("admin", "   ")]
        public void Login_EmptyPassword_ShouldThrowArgumentException(string username, string? password)
        {
            // Arrange
            var authBll = new AuthBLL();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => authBll.Login(username, password!));
            Assert.Contains("Mật khẩu không được để trống", ex.Message);
        }
    }
}

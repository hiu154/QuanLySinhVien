using System;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;
using Xunit;

namespace QuanLySinhVien.Tests
{
    public class StudentBLLTests
    {
        private readonly StudentBLL _studentBLL;

        public StudentBLLTests()
        {
            _studentBLL = new StudentBLL();
        }

        [Fact]
        public void AddStudent_NullStudent_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _studentBLL.AddStudent(null!));
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("NV001")]
        [InlineData("STUDENT01")]
        [InlineData("HS123")]
        public void AddStudent_StudentCodeNotStartingWithSV_ShouldThrowArgumentException(string invalidCode)
        {
            // Arrange
            var student = new StudentDTO
            {
                StudentCode = invalidCode,
                FullName = "Nguyễn Văn An",
                Email = "an.nguyen@example.com",
                ClassID = "CNTT01",
                DateOfBirth = new DateTime(2004, 5, 10),
                PhoneNumber = "0912345678"
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _studentBLL.AddStudent(student));
            Assert.Contains("bắt đầu bằng 'SV'", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void AddStudent_EmptyFullName_ShouldThrowArgumentException(string? invalidName)
        {
            // Arrange
            var student = new StudentDTO
            {
                StudentCode = "SV001",
                FullName = invalidName!,
                Email = "an.nguyen@example.com",
                ClassID = "CNTT01",
                DateOfBirth = new DateTime(2004, 5, 10)
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _studentBLL.AddStudent(student));
            Assert.Contains("Họ và tên", ex.Message);
        }

        [Theory]
        [InlineData("invalid-email")]
        [InlineData("test@")]
        [InlineData("@domain.com")]
        [InlineData("test@domain")]
        public void AddStudent_InvalidEmailFormat_ShouldThrowArgumentException(string invalidEmail)
        {
            // Arrange
            var student = new StudentDTO
            {
                StudentCode = "SV001",
                FullName = "Nguyễn Văn An",
                Email = invalidEmail,
                ClassID = "CNTT01",
                DateOfBirth = new DateTime(2004, 5, 10)
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _studentBLL.AddStudent(student));
            Assert.Contains("Email", ex.Message);
        }

        [Fact]
        public void AddStudent_UnderAge_ShouldThrowArgumentException()
        {
            // Arrange: Sinh viên dưới 15 tuổi
            var student = new StudentDTO
            {
                StudentCode = "SV001",
                FullName = "Nguyễn Văn Bé",
                Email = "be.nguyen@example.com",
                ClassID = "CNTT01",
                DateOfBirth = DateTime.Today.AddYears(-10) // 10 tuổi
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _studentBLL.AddStudent(student));
            Assert.Contains("Ngày sinh không hợp lệ", ex.Message);
        }

        [Fact]
        public void AddStudent_InvalidPhoneFormat_ShouldThrowArgumentException()
        {
            // Arrange
            var student = new StudentDTO
            {
                StudentCode = "SV001",
                FullName = "Nguyễn Văn An",
                Email = "an.nguyen@example.com",
                ClassID = "CNTT01",
                DateOfBirth = new DateTime(2004, 5, 10),
                PhoneNumber = "abc123xyz"
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _studentBLL.AddStudent(student));
            Assert.Contains("Số điện thoại không hợp lệ", ex.Message);
        }
    }
}

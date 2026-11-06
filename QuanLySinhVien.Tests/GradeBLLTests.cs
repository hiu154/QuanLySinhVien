using System;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;
using Xunit;

namespace QuanLySinhVien.Tests
{
    public class GradeBLLTests
    {
        [Fact]
        public void CalculateTotalAndRank_StandardWeights_CalculatesAccurately()
        {
            // Arrange: QT 8.0 (40%), Cuối kỳ 9.0 (60%) -> 8.0*0.4 + 9.0*0.6 = 3.2 + 5.4 = 8.60
            var grade = new GradeDTO
            {
                MidtermScore = 8.0m,
                FinalScore = 9.0m,
                MidtermWeight = 0.40m,
                FinalWeight = 0.60m
            };

            // Act
            GradeBLL.CalculateTotalAndRank(grade);

            // Assert
            Assert.Equal(8.60m, grade.TotalScore);
            Assert.Equal("A", grade.LetterGrade);
            Assert.Equal("Giỏi", grade.AcademicRank);
            Assert.True(grade.IsPassed);
        }

        [Theory]
        [InlineData(9.5, 9.5, "A+", "Xuất sắc", true)]
        [InlineData(8.5, 8.5, "A", "Giỏi", true)]
        [InlineData(8.0, 8.0, "B+", "Khá giỏi", true)]
        [InlineData(7.0, 7.0, "B", "Khá", true)]
        [InlineData(6.5, 6.5, "C+", "Trung bình khá", true)]
        [InlineData(5.5, 5.5, "C", "Trung bình", true)]
        [InlineData(5.0, 5.0, "D+", "Trung bình yếu", true)]
        [InlineData(4.0, 4.0, "D", "Yếu", true)]
        [InlineData(3.5, 3.5, "F", "Kém (Học lại)", false)]
        public void CalculateTotalAndRank_GradeScaleMappings_ShouldMatchAcademicStandard(
            decimal midterm, decimal final, string expectedLetter, string expectedRank, bool expectedPassed)
        {
            // Arrange
            var grade = new GradeDTO
            {
                MidtermScore = midterm,
                FinalScore = final,
                MidtermWeight = 0.50m,
                FinalWeight = 0.50m
            };

            // Act
            GradeBLL.CalculateTotalAndRank(grade);

            // Assert
            Assert.Equal(expectedLetter, grade.LetterGrade);
            Assert.Equal(expectedRank, grade.AcademicRank);
            Assert.Equal(expectedPassed, grade.IsPassed);
        }

        [Fact]
        public void CalculateTotalAndRank_FinalScoreUnder3_ShouldFailEvenIfTotalAbove4()
        {
            // Arrange: QT 10.0 (40%) = 4.0, Cuối kỳ 2.0 (60%) = 1.2 -> Tổng = 5.2 (nhưng thi < 3.0 nên trượt)
            var grade = new GradeDTO
            {
                MidtermScore = 10.0m,
                FinalScore = 2.0m,
                MidtermWeight = 0.40m,
                FinalWeight = 0.60m
            };

            // Act
            GradeBLL.CalculateTotalAndRank(grade);

            // Assert
            Assert.Equal(5.20m, grade.TotalScore);
            Assert.False(grade.IsPassed); // Trượt vì điểm thi < 3.0
        }

        [Fact]
        public void CalculateTotalAndRank_MissingOneScore_ShouldBeIncomplete()
        {
            // Arrange: Chỉ có điểm giữa kỳ, chưa có điểm thi
            var grade = new GradeDTO
            {
                MidtermScore = 8.0m,
                FinalScore = null
            };

            // Act
            GradeBLL.CalculateTotalAndRank(grade);

            // Assert
            Assert.Null(grade.TotalScore);
            Assert.Null(grade.LetterGrade);
            Assert.Equal("Chưa hoàn thành", grade.AcademicRank);
            Assert.Null(grade.IsPassed);
        }

        [Theory]
        [InlineData(-1.0, 8.0)]
        [InlineData(11.0, 8.0)]
        [InlineData(8.0, -0.5)]
        [InlineData(8.0, 10.5)]
        public void SaveGrade_ScoreOutOfRange_ShouldThrowArgumentException(decimal midterm, decimal final)
        {
            // Arrange
            var gradeBll = new GradeBLL();
            var grade = new GradeDTO
            {
                EnrollmentID = 1,
                MidtermScore = midterm,
                FinalScore = final
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => gradeBll.SaveGrade(grade));
            Assert.Contains("thang điểm từ 0.0 đến 10.0", ex.Message);
        }
    }
}

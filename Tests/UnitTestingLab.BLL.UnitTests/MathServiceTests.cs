using UnitTestingLab.BLL.Services;
using FluentAssertions;
using UnitTestingLab.BLL.Exceptions;

namespace UnitTestingLab.BLL.UnitTests
{
    public class MathServiceTests
    {
        private readonly MathService _service;

        public MathServiceTests()
        {
            _service = new MathService();
        }

        [Fact]
        public void Add_6And3_Return9()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var expectedValue = 9;

            // Act
            var actualValue = _service.Add(num1, num2);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Add_6And6_Return12()
            => _service.Add(6, 6)
            .Should().Be(12);

        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(2, 2, 4)]
        public void Add_TwoNumbers_ReturnSumOfTwoNumbers(int num1, int num2, int expectedValue)
        {
            // Act
            var actualValue = _service.Add(num1, num2);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Subtract_6And3_Return3()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var expectedValue = 3;

            // Act
            var actualValue = _service.Subtract(num1, num2);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Multiply_6And3_Return18()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var expectedValue = 18;

            // Act
            var actualValue = _service.Multiply(num1, num2);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Divide_6And3_Return2()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var expectedValue = 2;

            // Act
            var actualValue = _service.Divide(num1, num2);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Divide_6And0_ThrowNum2ZeroException()
        {
            // Arrange
            var num1 = 6;
            var num2 = 0;

            // Act
            Action action = () => _service.Divide(num1, num2);

            // Assert
            Assert.Throws<Num2ZeroException>(action);
        }
    }
}
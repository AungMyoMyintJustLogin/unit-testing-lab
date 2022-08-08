using UnitTestingLab.BLL.Services;
using FluentAssertions;
using UnitTestingLab.BLL.Exceptions;

namespace UnitTestingLab.BLL.UnitTests
{
    public class MathServiceTests
    {
        private readonly MathService _mathService;

        public MathServiceTests()
        {
            _mathService = new MathService();
        }

        [Fact]
        public void Add_6And3_Return9()
        {
            // Arrange
            var num1 = 6;
            var num2 = 3;
            var expectedValue = 9;

            // Add
            var actualValue = _mathService.Add(num1, num2);

            // Assert
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Add_3And3_Return6() => 
            _mathService.Add(3,3)
            .Should().Be(6);

        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(2, 2, 4)]
        public void Add_TwoNumbers_ReturnSumOfTwoNumbers(int num1, int num2 , int expectedValue)
        {
            //Act
            var actualValue = _mathService.Add(num1, num2);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Subtract_4And2_Return2()
        {
            // Arrange
            var num1 = 4;
            var num2 = 2;
            var expectedResult = 2;

            // Add
            var actualResult = _mathService.Subtract(num1, num2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Multiply_4And2_Return8()
        {
            // Arrange
            var num1 = 4;
            var num2 = 2;
            var expectedResult = 8;

            // Add
            var actualResult = _mathService.Multiply(num1, num2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void Divide_2And2_Return1()
        {
            // Arrange
            var num1 = 2;
            var num2 = 2;
            var expectedResult = 1;

            // Add
            var actualResult = _mathService.Divide(num1, num2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Divide_6and0_ThrowNum2ZeroException()
        {
            // Arrange
            var num1 = 6;
            var num2 = 0;

            // Add
            Action action = () => _mathService.Divide(num1, num2);

            // Assert
            Assert.Throws<Num2ZeroException>(action);
        }
    }
}
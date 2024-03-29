using AdventOfCode.Lib.Days._2023;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests._2023
{
    [TestClass]
    public class DaysTests
    {
        private readonly bool _useExampleInput = true;

        [TestMethod]
        public void Day01_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "142";
            var dayToTest = new _2023Day01(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day01_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "281";
            var dayToTest = new _2023Day01(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day02_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "8";
            var dayToTest = new _2023Day02(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day02_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "2286";
            var dayToTest = new _2023Day02(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day03_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "4361";
            var dayToTest = new _2023Day03(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day03_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "467835";
            var dayToTest = new _2023Day03(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}

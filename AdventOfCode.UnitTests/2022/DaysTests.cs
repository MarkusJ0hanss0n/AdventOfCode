using AdventOfCode.Lib.Days._2022;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests._2022
{
    [TestClass]
    public class DaysTests
    {
        private readonly bool _useExampleInput = true;


        [TestMethod]
        public void Day01_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "24000";
            var dayToTest = new _2022Day01(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day01_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "45000";
            var dayToTest = new _2022Day01(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day02_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "15";
            var dayToTest = new _2022Day02(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day02_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "12";
            var dayToTest = new _2022Day02(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day03_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "157";
            var dayToTest = new _2022Day03(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day03_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "70";
            var dayToTest = new _2022Day03(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day04_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "2";
            var dayToTest = new _2022Day04(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day04_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "4";
            var dayToTest = new _2022Day04(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day05_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "CMZ";
            var dayToTest = new _2022Day05(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day05_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "MCD";
            var dayToTest = new _2022Day05(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day06_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "7";
            var dayToTest = new _2022Day06(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day06_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "19";
            var dayToTest = new _2022Day06(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day07_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "95437";
            var dayToTest = new _2022Day07(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day07_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "24933642";
            var dayToTest = new _2022Day07(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day08_FirstPuzzle()
        {
            // Arrange
            var expectedResult = "21";
            var dayToTest = new _2022Day08(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestMethod]
        public void Day08_SecondPuzzle()
        {
            // Arrange
            var expectedResult = "8";
            var dayToTest = new _2022Day08(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

    }
}

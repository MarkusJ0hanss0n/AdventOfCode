using AdventOfCode.Lib.Days._2021;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests._2021
{
    [TestClass]
    public class DaysTests
    {
        private readonly bool _useExampleInput = true;

        [TestMethod]
        public void Day1_Puzzle1()
        {
            // Arrange
            var expectedResult = "7";
            var dayToTest = new _2021Day01(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day1_Puzzle2()
        {
            // Arrange
            var expectedResult = "5";
            var dayToTest = new _2021Day01(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day2_Puzzle1()
        {
            // Arrange
            var expectedResult = "150";
            var dayToTest = new _2021Day02(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day2_Puzzle2()
        {
            // Arrange
            var expectedResult = "900";
            var dayToTest = new _2021Day02(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day3_Puzzle1()
        {
            // Arrange
            var expectedResult = "198";
            var dayToTest = new _2021Day03(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day3_Puzzle2()
        {
            // Arrange
            var expectedResult = "230";
            var dayToTest = new _2021Day03(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day4_Puzzle1()
        {
            // Arrange
            var expectedResult = "4512";
            var dayToTest = new _2021Day04(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day4_Puzzle2()
        {
            // Arrange
            var expectedResult = "1924";
            var dayToTest = new _2021Day04(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day5_Puzzle1()
        {
            // Arrange
            var expectedResult = "5";
            var dayToTest = new _2021Day05(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day5_Puzzle2()
        {
            // Arrange
            var expectedResult = "12";
            var dayToTest = new _2021Day05(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day6_Puzzle1()
        {
            // Arrange
            var expectedResult = "5934";
            var dayToTest = new _2021Day06(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day6_Puzzle2()
        {
            // Arrange
            var expectedResult = "26984457539";
            var dayToTest = new _2021Day06(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day7_Puzzle1()
        {
            // Arrange
            var expectedResult = "37";
            var dayToTest = new _2021Day07(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day7_Puzzle2()
        {
            // Arrange
            var expectedResult = "168";
            var dayToTest = new _2021Day07(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day8_Puzzle1()
        {
            // Arrange
            var expectedResult = "26";
            var dayToTest = new _2021Day08(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day8_Puzzle2()
        {
            // Arrange
            var expectedResult = "61229";
            var dayToTest = new _2021Day08(_useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Day8_Puzzle9()
        {
            // Arrange
            var expectedResult = "15";
            var dayToTest = new _2021Day09(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}

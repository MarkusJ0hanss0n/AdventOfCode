using AdventOfCode.Lib.Days._2021;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class DaysTests
    {
        private readonly int _year = 2021;
        private readonly bool _useExampleInput = true;

        [TestMethod]
        public void Day1_Puzzle1()
        {
            // Arrange
            var expectedResult = "7";
            var dayToTest = new _2021Day1(_year, 1, _useExampleInput);

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
            var dayToTest = new _2021Day1(_year, 1, _useExampleInput);

            // Act
            var result = dayToTest.SecondPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}

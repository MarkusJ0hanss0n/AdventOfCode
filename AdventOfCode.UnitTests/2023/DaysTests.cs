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
            var expectedResult = "";
            var dayToTest = new _2023Day01(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

        //[TestMethod]
        //public void Day01_SecondPuzzle()
        //{
        //    // Arrange
        //    var expectedResult = "";
        //    var dayToTest = new _2023Day01(_useExampleInput);

        //    // Act
        //    var result = dayToTest.SecondPuzzle();

        //    // Assert
        //    result.Should().Be(expectedResult);
        //}
    }
}

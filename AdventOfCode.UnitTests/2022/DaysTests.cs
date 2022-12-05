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
            var expectedResult = "";
            var dayToTest = new _2022Day01(_useExampleInput);

            // Act
            var result = dayToTest.FirstPuzzle();

            // Assert
            result.Should().Be(expectedResult);
        }

    }
}

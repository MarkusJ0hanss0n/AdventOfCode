using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Lib
{
    public static class YearDayFilePathMapper
    {
        private static string _basePath = @"..\..\..\..\AdventOfCode.Lib\InputFiles";
        private static string _inputDir => @"PuzzleInputFiles";
        private static string _exampleDir => @"ExampleInputFiles";
        private static string _fileExtension => "txt";

        public static string GetInputFilePath(int year, int day)
        {
            return Path.Combine(_basePath, _inputDir, year.ToString(), $"Day{day}.{_fileExtension}");
        }

        public static string GetExampleFilePath(int year, int day)
        {
            return Path.Combine(_basePath, _exampleDir, year.ToString(), $"Day{day}.{_fileExtension}");
        }
    }
}

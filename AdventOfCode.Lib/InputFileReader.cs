using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Lib
{
    public static class InputFileReader
    {
        public static string GetInputFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Failed to find file with path '{path}'.");
            }
            return File.ReadAllText(path);
        }
    }
}

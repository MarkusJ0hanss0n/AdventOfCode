using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib
{
    public static class StringParser
    {
        public static string[] GetStrArrayBySplittingOnRows(this string input, string separator = "")
        {
            if (separator != "")
            {
                return input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                return input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static int[] GetIntArrayBySplittingOnRows(this string input, string separator = "")
        {
            return input.GetStrArrayBySplittingOnRows(separator).Select(int.Parse).ToArray();
        }
    }
}

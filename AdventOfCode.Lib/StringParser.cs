using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib
{
    public static class StringParser
    {
        public static string[] GetStrArrayBySplittingOnRows(this string input)
        {
            return input.Split(new string[] {"\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static int[] GetIntArrayBySplittingOnRows(this string input)
        {
            return input.GetStrArrayBySplittingOnRows().Select(int.Parse).ToArray();
        }
    }
}

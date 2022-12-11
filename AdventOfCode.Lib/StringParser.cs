using System;
using System.Linq;

namespace AdventOfCode.Lib
{
    public static class StringParser
    {
        public static string[] ToStrArrayBySplittingRowsAndRemovingEmptyEntries(this string input)
        {
            return input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] ToStrArrayBySplittingAndRemovingEmptyEntries(this string input, string separator)
        {
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int[] ToIntArrayBySplittingRowsAndRemovingEmptyEntries(this string input)
        {
            return input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries().Select(int.Parse).ToArray();
        }

        public static int[] ToIntArrayBySplittingAndRemovingEmptyEntries(this string input, string separator)
        {
            return input.ToStrArrayBySplittingAndRemovingEmptyEntries(separator).Select(int.Parse).ToArray();
        }
    }
}

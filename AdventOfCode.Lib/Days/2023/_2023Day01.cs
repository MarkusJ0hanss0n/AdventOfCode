using System.Collections.Generic;

namespace AdventOfCode.Lib.Days._2023
{
    public class _2023Day01 : BaseDay, IDay
    {
        public _2023Day01(bool useExampleInput = false) : base(2023, 01, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();

            int firstDigit = 0;
            int lastDigit = 0;
            int totalSum = 0;

            foreach (var line in inputLines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out firstDigit))
                    {
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(line[i].ToString(), out lastDigit))
                    {
                        break;
                    }
                }
                totalSum += int.Parse($"{firstDigit}{lastDigit}");
            }

            return totalSum.ToString();
        }

        public string SecondPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();

            int firstDigit = 0;
            int lastDigit = 0;
            int totalSum = 0;
            var threeLetterNumbers = new Dictionary<string, int>
            {
                { "one", 1},
                { "two", 2},
                { "six", 6},
            };

            var fourLetterNumbers = new Dictionary<string, int>
            {
                { "four", 4},
                { "five", 5},
                { "nine", 9},
            };

            var fiveLetterNumbers = new Dictionary<string, int>
            {
                { "three", 3},
                { "seven", 7},
                { "eight", 8},
            };

            foreach (var line in inputLines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if ((int.TryParse(line[i].ToString(), out firstDigit)) ||
                        ((i + 2) < line.Length) && threeLetterNumbers.TryGetValue(line.Substring(i, 3), out firstDigit) ||
                        ((i + 3) < line.Length) && fourLetterNumbers.TryGetValue(line.Substring(i, 4), out firstDigit) ||
                        ((i + 4) < line.Length) && fiveLetterNumbers.TryGetValue(line.Substring(i, 5), out firstDigit))
                    {
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if ((int.TryParse(line[i].ToString(), out lastDigit)) ||
                        ((i - 2) >= 0) && threeLetterNumbers.TryGetValue(line.Substring(i - 2, 3), out lastDigit) ||
                        ((i - 3) >= 0) && fourLetterNumbers.TryGetValue(line.Substring(i - 3, 4), out lastDigit) ||
                        ((i - 4) >= 0) && fiveLetterNumbers.TryGetValue(line.Substring(i - 4, 5), out lastDigit))
                    {
                        break;
                    }
                }
                totalSum += int.Parse($"{firstDigit}{lastDigit}");
            }

            return totalSum.ToString();
        }
    }
}

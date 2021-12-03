using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day3 : BaseDay, IDay
    {
        public _2021Day3(int year, int day, bool useExampleInput = false) : base(year, day, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.GetStrArrayBySplittingOnRows();
            var binaryLength = inputLines[0].Length;
            var rowCount = inputLines.Length;

            var binaryNumbers = inputLines.Select(x => Convert.ToInt32(x, 2));
            var bitCounts = new int[binaryLength];

            foreach (var binaryNumber in binaryNumbers)
            {
                for (int i = 0; i < binaryLength; i++)
                {
                    if( (binaryNumber & (1 << i)) != 0)
                    {
                        bitCounts[i] += 1;
                    }
                }
            }

            var gammaRateStr = "";
            var epsilonRateStr = "";

            for (int i = binaryLength - 1; i >= 0; i--)
            {
                var bitSetIsMostCommon = (bitCounts[i] > (rowCount / 2));
                gammaRateStr += bitSetIsMostCommon ? 1: 0;
                epsilonRateStr += bitSetIsMostCommon ? 0 : 1;
            }

            var gammaRate = Convert.ToInt32(gammaRateStr, 2);
            var epsilonRate = Convert.ToInt32(epsilonRateStr, 2);


            return (gammaRate * epsilonRate).ToString();
        }

        public string SecondPuzzle()
        {
            throw new NotImplementedException();
        }
    }
}

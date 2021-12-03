using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day21 : BaseDay, IDay
    {
        public _2021Day21(int year, int day, bool useExampleInput = false) : base(year, day, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            int[] inputLines = _input.GetIntArrayBySplittingOnRows();

            var noOfIncreaseCases = 0;

            for (int i = 1; i < inputLines.Length; i++)
            {
                if (inputLines[i] > inputLines[i - 1])
                {
                    noOfIncreaseCases++;
                }
            }
            return noOfIncreaseCases.ToString();
        }

        public string SecondPuzzle()
        {
            throw new NotImplementedException();
        }
    }
}

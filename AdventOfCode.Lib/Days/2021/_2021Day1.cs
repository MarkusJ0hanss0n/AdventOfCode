using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day1 : BaseDay, IDay
    {
        public _2021Day1(int year, int day, bool useExampleInput = false) : base(year, day, useExampleInput)
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
            int[] inputLines = _input.GetIntArrayBySplittingOnRows();

            var numberOfThreeList = new List<int>();
            var firstSum = 0;
            var secondSum = 0;
            var thirdSum = 0;

            for (int i = 0; i < inputLines.Length; i++)
            {
                firstSum += inputLines[i];

                if (i > 0)
                {
                    secondSum += inputLines[i];
                }

                if (i > 1)
                {
                    thirdSum += inputLines[i];
                }

                if ((i > 1) && (i + 1) % 3 == 0)
                {
                    numberOfThreeList.Add(firstSum);
                    firstSum = 0;
                }

                if ((i > 2) && i % 3 == 0)
                {
                    numberOfThreeList.Add(secondSum);
                    secondSum = 0;
                }

                if ((i > 3) && (i - 1) % 3 == 0)
                {
                    numberOfThreeList.Add(thirdSum);
                    thirdSum = 0;
                }
            }

            var noOfIncreaseCases = 0;

            for (int i = 1; i < numberOfThreeList.Count; i++)
            {
                if (numberOfThreeList[i] > numberOfThreeList[i - 1])
                {
                    noOfIncreaseCases++;
                }
            }

            return noOfIncreaseCases.ToString();
        }
    }
}

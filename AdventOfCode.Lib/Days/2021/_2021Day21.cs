﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day21 : BaseDay, IDay
    {
        public _2021Day21(bool useExampleInput = false) : base(2021, 21, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.ToIntArrayBySplittingRowsAndRemovingEmptyEntries();

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

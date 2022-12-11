using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day06 : BaseDay, IDay
    {
        public _2022Day06(bool useExampleInput = false) : base(2022, 06, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var result = "";
            var noOfDistinctChars = 4;

            for (int i = 0; i < _input.Length - noOfDistinctChars; i++)
            {
                var currentSequence = _input.Substring(i, noOfDistinctChars);
                if (AllDisctinctCharsAreDifferent(currentSequence, noOfDistinctChars))
                {
                    result = (i + noOfDistinctChars).ToString();
                    break;
                }
            }

            return result;
        }


        public string SecondPuzzle()
        {
            var result = "";
            var noOfDistinctChars = 14;

            for (int i = 0; i < _input.Length - noOfDistinctChars; i++)
            {
                var currentSequence = _input.Substring(i, noOfDistinctChars);
                if (AllDisctinctCharsAreDifferent(currentSequence, noOfDistinctChars))
                {
                    result = (i + noOfDistinctChars).ToString();
                    break;
                }
            }

            return result;
        }

        private bool AllDisctinctCharsAreDifferent(string currentSequence, int noOfDistinctChars)
        {
            var result = true;

            for (int i = 0; i < noOfDistinctChars; i++)
            {
                if (currentSequence.LastIndexOf(currentSequence[i]) != i)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

    }
}

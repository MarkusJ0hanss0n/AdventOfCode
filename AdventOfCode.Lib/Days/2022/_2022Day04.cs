using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day04 : BaseDay, IDay
    {
        public _2022Day04(bool useExampleInput = false) : base(2022, 04, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            string[] elfSectionPairs = _input.GetStrArrayBySplittingOnRows();
            var noOfPairsWhereOneFullyContainTheOther = 0;

            foreach (var elfSectionPair in elfSectionPairs)
            {
                var pairParts = elfSectionPair.GetStrArrayBySplittingOnRows(",");

                if (IsOnePairFullyContainedByTheOther(pairParts[0], pairParts[1]))
                {
                    noOfPairsWhereOneFullyContainTheOther++;
                }
            }

            return noOfPairsWhereOneFullyContainTheOther.ToString();
        }

        public string SecondPuzzle()
        {
            string[] elfSectionPairs = _input.GetStrArrayBySplittingOnRows();
            var noOfPairsWhereOneFullyContainTheOther = 0;

            foreach (var elfSectionPair in elfSectionPairs)
            {
                var pairParts = elfSectionPair.GetStrArrayBySplittingOnRows(",");

                if (DoesOnePairPartlyOverlapTheOther(pairParts[0], pairParts[1]))
                {
                    noOfPairsWhereOneFullyContainTheOther++;
                }
            }

            return noOfPairsWhereOneFullyContainTheOther.ToString();
        }

        private bool IsOnePairFullyContainedByTheOther(string firstRange, string secondRange)
        {
            var firstRangeParts = firstRange.GetIntArrayBySplittingOnRows("-");
            var secondRangeParts = secondRange.GetIntArrayBySplittingOnRows("-");

            var firstContainedBySecond = firstRangeParts[0] >= secondRangeParts[0] && firstRangeParts[1] <= secondRangeParts[1];

            if (firstContainedBySecond)
            {
                return true;
            }

            var secondContainedBySecond = secondRangeParts[0] >= firstRangeParts[0] && secondRangeParts[1] <= firstRangeParts[1];

            return secondContainedBySecond;
        }

        private bool DoesOnePairPartlyOverlapTheOther(string firstRange, string secondRange)
        {
            var firstRangeParts = firstRange.GetIntArrayBySplittingOnRows("-");
            var secondRangeParts = secondRange.GetIntArrayBySplittingOnRows("-");
                        
            return (firstRangeParts[1] >= secondRangeParts[0] && firstRangeParts[0] <= secondRangeParts[1]) ||
                (secondRangeParts[1] >= firstRangeParts[0] && secondRangeParts[0] <= firstRangeParts[1]);
        }
    }

}

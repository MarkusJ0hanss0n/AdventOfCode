using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day03 : BaseDay, IDay
    {
        public _2021Day03(bool useExampleInput = false) : base(2021, 3, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var binaryLength = inputLines[0].Length;
            var rowCount = inputLines.Length;

            var binaryNumbers = inputLines.Select(x => Convert.ToInt32(x, 2));
            var bitCounts = GetBitCounts(binaryNumbers, binaryLength);

            var gammaRateStr = "";
            var epsilonRateStr = "";

            for (int i = binaryLength - 1; i >= 0; i--)
            {
                var bitSetIsMostCommon = (bitCounts[i] > (rowCount / 2));
                gammaRateStr += bitSetIsMostCommon ? 1 : 0;
                epsilonRateStr += bitSetIsMostCommon ? 0 : 1;
            }

            var gammaRate = Convert.ToInt32(gammaRateStr, 2);
            var epsilonRate = Convert.ToInt32(epsilonRateStr, 2);


            return (gammaRate * epsilonRate).ToString();
        }

        public string SecondPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var binaryLength = inputLines[0].Length;

            var binaryNumbers = inputLines.Select(x => Convert.ToInt32(x, 2));
            var bitCountsOxygen = GetBitCounts(binaryNumbers, binaryLength);
            var bitCountsCo2 = GetBitCounts(binaryNumbers, binaryLength);

            var oxygenGeneratorRatingNumbers = binaryNumbers.ToList();

            var co2ScrubberRatingNumbers = binaryNumbers.ToList();

            for (int i = binaryLength - 1; i >= 0; i--)
            {
                if (oxygenGeneratorRatingNumbers.Count() != 1)
                {
                    var bitSetIsMostCommonForOxygenGen = ((double)bitCountsOxygen[i] / oxygenGeneratorRatingNumbers.Count()) >= 0.5;

                    if (bitSetIsMostCommonForOxygenGen)
                    {
                        oxygenGeneratorRatingNumbers = oxygenGeneratorRatingNumbers.Where(x => IsBitSet(x, i)).ToList();
                    }
                    else
                    {
                        oxygenGeneratorRatingNumbers = oxygenGeneratorRatingNumbers.Where(x => !IsBitSet(x, i)).ToList();

                    }

                    bitCountsOxygen = GetBitCounts(oxygenGeneratorRatingNumbers, binaryLength);
                }

                if (co2ScrubberRatingNumbers.Count() != 1)
                {
                    var bitSetIsMostCommonForCo2Scrubber = ((double)bitCountsCo2[i] / co2ScrubberRatingNumbers.Count()) >= 0.5;

                    if (bitSetIsMostCommonForCo2Scrubber)
                    {
                        co2ScrubberRatingNumbers = co2ScrubberRatingNumbers.Where(x => !IsBitSet(x, i)).ToList();
                    }
                    else
                    {
                        co2ScrubberRatingNumbers = co2ScrubberRatingNumbers.Where(x => IsBitSet(x, i)).ToList();

                    }

                    bitCountsCo2 = GetBitCounts(co2ScrubberRatingNumbers, binaryLength);
                }
            }

            return (oxygenGeneratorRatingNumbers[0] * co2ScrubberRatingNumbers[0]).ToString();
        }

        private int[] GetBitCounts(IEnumerable<int> binaryNumbers, int binaryLength)
        {
            var bitCounts = new int[binaryLength];

            foreach (var binaryNumber in binaryNumbers)
            {
                for (int i = binaryLength - 1; i >= 0; i--)
                {
                    if (IsBitSet(binaryNumber, i))
                    {
                        bitCounts[i] += 1;
                    }
                }
            }

            return bitCounts;
        }

        private bool IsBitSet(int binaryNumber, int position)
        {
            return (binaryNumber & (1 << position)) != 0;
        }
    }
}

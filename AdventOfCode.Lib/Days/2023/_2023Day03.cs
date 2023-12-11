using System;
using System.Collections.Generic;

namespace AdventOfCode.Lib.Days._2023
{
    public class _2023Day03 : BaseDay, IDay
    {
        public _2023Day03(bool useExampleInput = false) : base(2023, 03, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var potentialPartNumbers = GetPotentialPartNumbersFromInput(inputLines);
            var partNumberSum = 0;

            foreach (var potentialPartNumber in potentialPartNumbers)
            {
                if (potentialPartNumber.IsPartNumber(inputLines))
                {
                    partNumberSum += potentialPartNumber.Number;
                }
            }

            return partNumberSum.ToString();
        }

        public string SecondPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();

            throw new NotImplementedException();
        }

        private List<PotentialPartNumber> GetPotentialPartNumbersFromInput(string[] inputLines)
        {
            var potentialPartNumbers = new List<PotentialPartNumber>();

            for (int i = 0; i < inputLines.Length; i++)
            {
                var inputLine = inputLines[i];
                var digitFound = false;
                var xFirstIndex = 0;
                var xLastIndex = 0;
                var number = "";

                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (int.TryParse(inputLine[j].ToString(), out _))
                    {
                        number += inputLine[j];

                        if (!digitFound)
                        {
                            xFirstIndex = j;
                            digitFound = true;
                        }
                        else if (j == inputLine.Length - 1)
                        {
                            xLastIndex = j;
                            potentialPartNumbers.Add(new PotentialPartNumber(i, xFirstIndex, xLastIndex, int.Parse(number)));
                        }
                    }
                    else if (digitFound)
                    {
                        xLastIndex = j - 1;
                        potentialPartNumbers.Add(new PotentialPartNumber(i, xFirstIndex, xLastIndex, int.Parse(number)));
                        digitFound = false;
                        number = "";
                    }
                }
            }

            return potentialPartNumbers;
        }
    }

    public class PotentialPartNumber
    {
        public int YIndex { get; set; }
        public int XFirstIndex { get; set; }
        public int XLastIndex { get; set; }
        public int Number { get; set; }

        public PotentialPartNumber(int yIndex, int xFirstIndex, int xLastIndex, int number)
        {
            YIndex = yIndex;
            XFirstIndex = xFirstIndex;
            XLastIndex = xLastIndex;
            Number = number;
        }

        public bool IsPartNumber(string[] engineSchemantic)
        {
            if (HasSymbolLeftFromNumber(engineSchemantic) ||
                HasSymbolRightFromNumber(engineSchemantic) ||
                HasSymbolOverNumber(engineSchemantic) ||
                HasSymbolUnderNumber(engineSchemantic))
            {
                return true;
            }

            return false;
        }

        private bool HasSymbolLeftFromNumber(string[] engineSchemantic)
        {
            return XFirstIndex != 0 && engineSchemantic[YIndex][XFirstIndex - 1] != '.';
        }

        private bool HasSymbolRightFromNumber(string[] engineSchemantic)
        {
            return (XLastIndex != engineSchemantic[YIndex].Length - 1) &&
                engineSchemantic[YIndex][XLastIndex + 1] != '.';
        }

        private bool HasSymbolOverNumber(string[] engineSchemantic)
        {
            if (YIndex != 0)
            {
                var numberLength = XLastIndex - XFirstIndex + 1;
                var rowAbove = engineSchemantic[YIndex - 1];
                int xIndexToCheck;

                for (int i = 0; i < numberLength + 2; i++)
                {
                    xIndexToCheck = XFirstIndex - 1 + i;
                    if (xIndexToCheck >= 0 &&
                        xIndexToCheck <= rowAbove.Length - 1 &&
                        rowAbove[xIndexToCheck] != '.' &&
                        !int.TryParse(rowAbove[xIndexToCheck].ToString(), out _))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasSymbolUnderNumber(string[] engineSchemantic)
        {
            if (YIndex != engineSchemantic.Length - 1)
            {
                var numberLength = XLastIndex - XFirstIndex + 1;
                var rowUnder = engineSchemantic[YIndex + 1];
                int xIndexToCheck;

                for (int i = 0; i < numberLength + 2; i++)
                {
                    xIndexToCheck = XFirstIndex - 1 + i;
                    if (xIndexToCheck >= 0 &&
                        xIndexToCheck <= rowUnder.Length - 1 &&
                        rowUnder[xIndexToCheck] != '.' &&
                        !int.TryParse(rowUnder[xIndexToCheck].ToString(), out _))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

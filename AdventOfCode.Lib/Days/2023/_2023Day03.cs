using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
                if (potentialPartNumber.IsPartNumberPuzzleOne(inputLines))
                {
                    partNumberSum += potentialPartNumber.Number;
                }
            }

            return partNumberSum.ToString();
        }

        public string SecondPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var potentialPartNumbers = GetPotentialPartNumbersFromInput(inputLines);
            var gearRatioSum = 0;
            Point? gearPoint;
            List<int> numberList;

            var potentialGearDict = new Dictionary<Point, List<int>>();
            
            foreach (var potentialPartNumber in potentialPartNumbers)
            {
                if (potentialPartNumber.TryFindGear(inputLines, out gearPoint))
                {
                    if (potentialGearDict.TryGetValue(gearPoint.Value, out numberList))
                    {
                        numberList.Add(potentialPartNumber.Number);
                    }
                    else
                    {
                        potentialGearDict.Add(new Point(gearPoint.Value.X, gearPoint.Value.Y), new List<int> { potentialPartNumber.Number });
                    }
                }
            }
            
            foreach (var gear in potentialGearDict.Where(gd => gd.Value.Count == 2))
            {
                gearRatioSum += gear.Value[0] * gear.Value[1];
            }

            return gearRatioSum.ToString();
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

        public bool IsPartNumberPuzzleOne(string[] engineSchemantic)
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

        public bool TryFindGear(string[] engineSchemantic, out Point? gearPoint)
        {
            if (TryGetGearFromLeftOfNumber(engineSchemantic, out gearPoint) ||
                TryGetGearFromRightOfNumber(engineSchemantic, out gearPoint) ||
                TryGetGearFromOverNumber(engineSchemantic, out gearPoint) ||
                TryGetGearFromUnderNumber(engineSchemantic, out gearPoint))
            {
                return true;
            }

            gearPoint = null;
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

        private bool TryGetGearFromLeftOfNumber(string[] engineSchemantic, out Point? point)
        {
            if (XFirstIndex != 0 && engineSchemantic[YIndex][XFirstIndex - 1] == '*')
            {
                point = new Point(XFirstIndex - 1, YIndex);
                return true;
            }

            point = null;
            return false;
        }

        private bool TryGetGearFromRightOfNumber(string[] engineSchemantic, out Point? point)
        {
            if ((XLastIndex != engineSchemantic[YIndex].Length - 1) &&
                engineSchemantic[YIndex][XLastIndex + 1] == '*')
            {
                point = new Point(XLastIndex + 1, YIndex);
                return true;
            }

            point = null;
            return false;
        }

        private bool TryGetGearFromOverNumber(string[] engineSchemantic, out Point? point)
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
                        rowAbove[xIndexToCheck] == '*')
                    {
                        point = new Point(xIndexToCheck, YIndex - 1);
                        return true;
                    }
                }
            }

            point = null;
            return false;
        }

        private bool TryGetGearFromUnderNumber(string[] engineSchemantic, out Point? point)
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
                        rowUnder[xIndexToCheck] == '*')
                    {
                        point = new Point(xIndexToCheck, YIndex + 1);
                        return true;
                    }
                }
            }
            point = null;
            return false;
        }
    }
}

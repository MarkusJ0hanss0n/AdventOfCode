using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public delegate int CalculateFuelForPosition(int[] currentPositions, int moveToPosition);

    public class _2021Day07 : BaseDay, IDay
    {
        public _2021Day07(bool useExampleInput = false) : base(2021, 7, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var positions = _input.GetIntArrayBySplittingOnRows(",");

            var minFuelUsed = CalculateMinFuelUsed(positions, CalculateFuelUsedForPositionWithConstantRate);

            return minFuelUsed.ToString();
        }

        public string SecondPuzzle()
        {
            var positions = _input.GetIntArrayBySplittingOnRows(",");

            var minFuelUsed = CalculateMinFuelUsed(positions, CalculateFuelUsedForPosition);

            return minFuelUsed.ToString();
        }

        public int CalculateMinFuelUsed(int[] positions, CalculateFuelForPosition calculateFuelForPosition)
        {
            var minPositions = positions.Min();
            var maxPositions = positions.Max();

            var minFuelUsed = calculateFuelForPosition(positions, minPositions);

            for (int i = minPositions + 1; i < maxPositions; i++)
            {
                var fuelUsed = calculateFuelForPosition(positions, i);
                if (fuelUsed < minFuelUsed)
                {
                    minFuelUsed = fuelUsed;
                }
            }

            return minFuelUsed;
        }

        public int CalculateFuelUsedForPositionWithConstantRate(int[] currentPositions, int moveToPosition)
        {
            var fuelUsed = 0;

            for (int i = 0; i < currentPositions.Length; i++)
            {
                fuelUsed += Math.Abs(currentPositions[i] - moveToPosition);
            }
            return fuelUsed;
        }

        public int CalculateFuelUsedForPosition(int[] currentPositions, int moveToPosition)
        {
            var fuelUsed = 0;

            for (int i = 0; i < currentPositions.Length; i++)
            {
                fuelUsed += GetFuelConsumtion(Math.Abs(currentPositions[i] - moveToPosition));
            }
            return fuelUsed;
        }

        public int GetFuelConsumtion(int movedPositions)
        {
            var fuelConsumed = 0;

            for (int i = 1; i <= movedPositions; i++)
            {
                fuelConsumed += i;
            }
            return fuelConsumed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day01 : BaseDay, IDay
    {
        public _2022Day01(bool useExampleInput = false) : base(2022, 01, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var elfSupplies = GetElfSupplies();
            var highestElfFoodCalories = 0;

            foreach (string elfSupply in elfSupplies)
            {
                var totalElfCalories = GetTotalElfCalories(elfSupply);

                if (totalElfCalories > highestElfFoodCalories)
                {
                    highestElfFoodCalories = totalElfCalories;
                }
            }

            return highestElfFoodCalories.ToString();
        }

        public string SecondPuzzle()
        {
            var elfSupplies = GetElfSupplies();
            var elfCalories = new List<int>();
            var topThreeElfFoodCalories = 0;

            foreach (string elfSupply in elfSupplies)
            {
                elfCalories.Add(GetTotalElfCalories(elfSupply));
            }

            elfCalories = elfCalories.OrderByDescending(x => x).ToList();

            topThreeElfFoodCalories = elfCalories[0] + elfCalories[1] + elfCalories[2];

            return topThreeElfFoodCalories.ToString();
        }

        private string[] GetElfSupplies()
        {
            return _input.ToStrArrayBySplittingAndRemovingEmptyEntries("\r\n\r\n");
        }

        private int GetTotalElfCalories(string elfSupply)
        {
            var totalElfCalories = 0;

            foreach (var food in elfSupply.ToStrArrayBySplittingRowsAndRemovingEmptyEntries())
            {
                totalElfCalories += int.Parse(food);
            }

            return totalElfCalories;
        }
    }

}

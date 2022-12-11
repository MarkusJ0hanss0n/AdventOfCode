using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day03 : BaseDay, IDay
    {

        public _2022Day03(bool useExampleInput = false) : base(2022, 03, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var ruckSacks = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var totalPriorityPoints = 0;

            foreach (var item in ruckSacks)
            {
                var compartments = GetCompartments(item);
                var commonItem = GetCommonItems(compartments[0], compartments[1]).First();
                totalPriorityPoints += GetPriorityPointFromItem(commonItem);
            }

            return totalPriorityPoints.ToString();
        }

        public string SecondPuzzle()
        {
            var ruckSacks = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var totalPriorityPoints = 0;

            for (int i = 0; i < ruckSacks.Length - 2; i++)
            {
                if (i % 3 != 0)
                {
                    continue;
                }

                var firstCommonItems = GetCommonItems(ruckSacks[i].ToList(), ruckSacks[i + 1].ToList());
                var secondCommonItems = GetCommonItems(firstCommonItems.ToList(), ruckSacks[i + 2].ToList());

                totalPriorityPoints += GetPriorityPointFromItem(secondCommonItems.First());
            }

            return totalPriorityPoints.ToString();
        }

        private List<List<char>> GetCompartments(string item)
        {
            var compartments = new List<List<char>>();
            compartments.Add(item.Substring(0, item.Length / 2).ToList());
            compartments.Add(item.Substring(item.Length / 2).ToList());

            return compartments;
        }

        private IEnumerable<char> GetCommonItems(List<char> firstItem, List<char> secondItem)
        {
            return firstItem.Intersect(secondItem); 
        }

        private int GetPriorityPointFromItem(char commonItem)
        {
            // Makes sense when looking at an UTF-8 table. A-Z has index 65-90, a-z has index 97-122

            var utf8Index = (int)commonItem;

            if (utf8Index <= 90)
            {
                utf8Index = utf8Index - 38;
            }
            else
            {
                utf8Index = utf8Index - 96;
            }

            return utf8Index;

        }
    }
}

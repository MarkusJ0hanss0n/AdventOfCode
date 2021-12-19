using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day9 : BaseDay, IDay
    {
        public _2021Day9(bool useExampleInput = false) : base(2021, 9, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputRows = _input.GetStrArrayBySplittingOnRows();
            int[][] map = new int[inputRows.Length][];

            for (int i = 0; i < inputRows.Length; i++)
            {
                map[i] = inputRows[i].ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            }

            var totalSum = 0;

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (map.IsLowPoint(i, j))
                    {
                        totalSum += map[i][j] + 1;
                    }
                }
            }

            return totalSum.ToString();
        }

        public string SecondPuzzle()
        {
            throw new NotImplementedException();
        }

    }

    public static class HelperClass
    {
        public static bool IsLowPoint(this int[][] array, int x, int y)
        {
            var comparingPoint = array[x][y];
            var xMax = array.Length - 1;
            var yMax = array[0].Length - 1;

            var result = (y == 0 || array[x][y - 1] > comparingPoint) &&
                (y == yMax || array[x][y + 1] > comparingPoint) &&
                (x == 0 || array[x - 1][y] > comparingPoint) &&
                (x == xMax || array[x + 1][y] > comparingPoint);

            return result;
        }
    }
}

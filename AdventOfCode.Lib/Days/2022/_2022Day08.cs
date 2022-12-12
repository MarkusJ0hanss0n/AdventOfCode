using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day08 : BaseDay, IDay
    {
        public _2022Day08(bool useExampleInput = false) : base(2022, 08, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var treeGrid = GetTreeGridFromInput();
            var noOfVisibleTrees = CalculateNoOfVisibleTrees(treeGrid);
            return noOfVisibleTrees.ToString();
        }

        public string SecondPuzzle()
        {
            var treeGrid = GetTreeGridFromInput();
            var highestScenicScore = GetHighestScenicScore(treeGrid);
            return highestScenicScore.ToString();
        }

        private int[,] GetTreeGridFromInput()
        {
            var treeHeightRows = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var gridYSize = treeHeightRows.Length;
            var gridXSize = treeHeightRows[0].Length;
            var grid = new int[gridXSize, gridYSize];

            for (var i = 0; i < gridXSize; i++)
            {
                for (int j = 0; j < gridYSize; j++)
                {
                    grid[i, j] = treeHeightRows[j][i] - '0'; // a way to get int from char
                }
            }

            return grid;
        }

        private int CalculateNoOfVisibleTrees(int[,] treeGrid)
        {
            var gridYSize = treeGrid.GetLength(0);
            var gridXSize = treeGrid.GetLength(1);

            var noOfVisibleTrees = gridXSize * 2 + (gridYSize - 2) * 2; // all edges are visible

            for (var i = 1; i < gridXSize - 1; i++)
            {
                for (int j = 1; j < gridYSize - 1; j++)
                {
                    if (TreeIsVisible(treeGrid, i, j))
                    {
                        noOfVisibleTrees++;
                    }
                }
            }
            return noOfVisibleTrees;
        }

        private bool TreeIsVisible(int[,] treeGrid, int x, int y)
        {
            var gridYSize = treeGrid.GetLength(0);
            var gridXSize = treeGrid.GetLength(1);

            var treeIsPotentiallyVisible = true;
            
            for (int i = y - 1; i >= 0; i--) // checking up
            {
                if (treeGrid[x, i] >= treeGrid[x, y]) // not visible
                {
                    treeIsPotentiallyVisible = false;
                    break;
                }
            }

            if (treeIsPotentiallyVisible)
            {
                return true;
            }
            treeIsPotentiallyVisible = true;

            for (int i = y + 1; i < gridYSize; i++) // checking down
            {
                if (treeGrid[x, i] >= treeGrid[x, y]) // not visible
                {
                    treeIsPotentiallyVisible = false;
                    break;
                }
            }

            if (treeIsPotentiallyVisible)
            {
                return true;
            }
            treeIsPotentiallyVisible = true;

            for (int i = x - 1; i >= 0; i--) // checking left
            {
                if (treeGrid[i, y] >= treeGrid[x, y]) // not visible
                {
                    treeIsPotentiallyVisible = false;
                    break;
                }
            }

            if (treeIsPotentiallyVisible)
            {
                return true;
            }
            treeIsPotentiallyVisible = true;

            for (int i = x + 1; i < gridXSize; i++) // checking right
            {
                if (treeGrid[i, y] >= treeGrid[x, y]) // not visible
                {
                    treeIsPotentiallyVisible = false;
                    break;
                }
            }

            return treeIsPotentiallyVisible;
        }

        private int GetHighestScenicScore(int[,] treeGrid)
        {
            var gridYSize = treeGrid.GetLength(0);
            var gridXSize = treeGrid.GetLength(1);

            var highestScenicScore = 0;

            for (var i = 1; i < gridXSize - 1; i++)
            {
                for (int j = 1; j < gridYSize - 1; j++)
                {
                    var treeScenicScore = GetTreeScenicScore(treeGrid, i, j);
                    if (treeScenicScore > highestScenicScore)
                    {
                        highestScenicScore = treeScenicScore;
                    }
                }
            }
            return highestScenicScore;
        }

        private int GetTreeScenicScore(int[,] treeGrid, int x, int y)
        {
            var gridYSize = treeGrid.GetLength(0);
            var gridXSize = treeGrid.GetLength(1);

            var visibleTreesLookingUp = 0;
            var visibleTreesLookingDown = 0;
            var visibleTreesLookingLeft = 0;
            var visibleTreesLookingRight = 0;

            for (int i = y - 1; i >= 0; i--) // checking up
            {
                visibleTreesLookingUp++;
                if (treeGrid[x, i] >= treeGrid[x, y]) // not visible
                {
                    break;
                }
            }

            for (int i = y + 1; i < gridYSize; i++) // checking down
            {
                visibleTreesLookingDown++;
                if (treeGrid[x, i] >= treeGrid[x, y]) // not visible
                {
                    break;
                }
            }

            for (int i = x - 1; i >= 0; i--) // checking left
            {
                visibleTreesLookingLeft++;
                if (treeGrid[i, y] >= treeGrid[x, y]) // not visible
                {
                    break;
                }
            }

            for (int i = x + 1; i < gridXSize; i++) // checking right
            {
                visibleTreesLookingRight++;
                if (treeGrid[i, y] >= treeGrid[x, y]) // not visible
                {
                    break;
                }
            }

            return visibleTreesLookingUp * visibleTreesLookingDown * visibleTreesLookingLeft * visibleTreesLookingRight;
        }
    }

}

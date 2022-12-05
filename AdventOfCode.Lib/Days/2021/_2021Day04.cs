using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day04 : BaseDay, IDay
    {
        public _2021Day04(bool useExampleInput = false) : base(2021, 4, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputRows = _input.GetStrArrayBySplittingOnRows();
            var instructions = inputRows[0].GetIntArrayBySplittingOnRows(",");
            var bingoBoards = CreateBingoBoards(inputRows);

            int horizontalRowNumber = 0;
            int verticalRowNumber = 0;

            var result = "";

            foreach (var instruction in instructions)
            {
                foreach (var board in bingoBoards)
                {
                    board.MarkNumber(instruction);

                    if (board.HorizontalRowIsMarked(out horizontalRowNumber) ||
                        board.VerticalRowIsMarked(out verticalRowNumber))
                    {
                        result = (board.GetUnmarkedSum() * instruction).ToString();
                        return result;
                    }
                }
            }

            return result;
        }

        public string SecondPuzzle()
        {
            var inputRows = _input.GetStrArrayBySplittingOnRows();
            var instructions = inputRows[0].GetIntArrayBySplittingOnRows(",");
            var bingoBoards = CreateBingoBoards(inputRows);

            int horizontalRowNumber = 0;
            int verticalRowNumber = 0;

            var result = "";

            foreach (var instruction in instructions)
            {
                foreach (var board in bingoBoards)
                {
                    board.MarkNumber(instruction);

                    if (board.HorizontalRowIsMarked(out horizontalRowNumber) ||
                        board.VerticalRowIsMarked(out verticalRowNumber))
                    {
                        board.IsFinished = true;
                        if (AllBoardsAreFinished(bingoBoards))
                        {
                            result = (board.GetUnmarkedSum() * instruction).ToString();
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        public List<BingoBoard> CreateBingoBoards(string[] inputRows)
        {
            var bingoRows = new List<int[]>();
            var bingoBoards = new List<BingoBoard>();

            for (int i = 1; i < inputRows.Length; i++)
            {
                var bingoRow = inputRows[i].GetIntArrayBySplittingOnRows(" ");
                bingoRows.Add(bingoRow);

                if (i % 5 == 0)
                {
                    bingoBoards.Add(new BingoBoard(bingoRows));
                    bingoRows.Clear();
                }
            }

            return bingoBoards;
        } 

        public bool AllBoardsAreFinished(List<BingoBoard> boards)
        {
            foreach (var board in boards)
            {
                if (!board.IsFinished)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class BingoBoard
    {
        private readonly int _boardSize = 5;
        private BingoNumber[,] bingoNumbers;
        public bool IsFinished { get; set; }

        public BingoBoard(List<int[]> boardRows)
        {
            SetBingoBoard(boardRows);
            IsFinished = false;
        }

        private void SetBingoBoard(List<int[]> boardRows)
        {
            bingoNumbers = new BingoNumber[_boardSize, _boardSize];

            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    bingoNumbers[i, j] = new BingoNumber(boardRows[i][j]);
                }
            }
        }

        public void MarkNumber(int number)
        {
            foreach (var bingoNumber in bingoNumbers)
            {
                if (bingoNumber.Number == number)
                {
                    bingoNumber.IsMarked = true;
                }
            }
        }

        public bool HorizontalRowIsMarked(out int rowNumber)
        {
            var result = false;
            rowNumber = 0;

            int i = 0;
            int j = 0;

            for (i = 0; i < _boardSize; i++)
            {
                for (j = 0; j < _boardSize; j++)
                {
                    if (!bingoNumbers[i, j].IsMarked)
                    {
                        break;
                    }
                }

                if (j == _boardSize)
                {
                    result = true;
                    rowNumber = i;
                }
            }

            return result;
        }

        public int GetUnmarkedSum()
        {
            var sum = 0;

            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (!bingoNumbers[i, j].IsMarked)
                    {
                        sum += bingoNumbers[i, j].Number;
                    }
                }
            }

            return sum;
        }

        public bool VerticalRowIsMarked(out int rowNumber)
        {
            var result = false;
            rowNumber = 0;

            int i = 0;
            int j = 0;

            for (i = 0; i < _boardSize; i++)
            {
                for (j = 0; j < _boardSize; j++)
                {
                    if (!bingoNumbers[j, i].IsMarked)
                    {
                        break;
                    }
                }

                if (j == _boardSize)
                {
                    result = true;
                    rowNumber = i;
                }
            }

            return result;
        }
    }

    public class BingoNumber
    {
        public int Number { get; set; }
        public bool IsMarked;

        public BingoNumber(int number)
        {
            Number = number;
            IsMarked = false;
        }

        public void Mark()
        {
            IsMarked = true;
        }
    }
}

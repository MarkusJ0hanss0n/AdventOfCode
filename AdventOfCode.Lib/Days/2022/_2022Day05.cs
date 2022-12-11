using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day05 : BaseDay, IDay
    {
        public _2022Day05(bool useExampleInput = false) : base(2022, 05, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputParts = _input.ToStrArrayBySplittingAndRemovingEmptyEntries("\r\n\r\n");
            var stackPart = inputParts[0];
            var rearrangemnetPart = inputParts[1];

            var stacks = CreateAndFillStacks(stackPart);
            stacks = RearrangeStacksAccordingToFirstPuzzle(rearrangemnetPart, stacks);

            return GetResultString(stacks);
                        
        }

        public string SecondPuzzle()
        {
            var inputParts = _input.ToStrArrayBySplittingAndRemovingEmptyEntries("\r\n\r\n");
            var stackPart = inputParts[0];
            var rearrangemnetPart = inputParts[1];

            var stacks = CreateAndFillStacks(stackPart);
            stacks = RearrangeStacksAccordingToSecondPuzzle(rearrangemnetPart, stacks);

            return GetResultString(stacks);
        }

        private Dictionary<int, Stack<char>> CreateAndFillStacks(string stackInput)
        {
            var stackLines = stackInput.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var stacks = new Dictionary<int, Stack<char>>();

            foreach (var item in stackLines[stackLines.Length - 1].Split("   "))
            {
                stacks.Add(int.Parse(item.Trim()), new Stack<char>());
            }

            for (int i = stackLines.Length - 2; i >= 0; i--)
            {
                var stackNo = 1;
                var emptySpaceCount = 0;

                var stackRow = stackLines[i].Split(" ");

                foreach (var potentialStackItem in stackRow)
                {
                    if (string.IsNullOrEmpty(potentialStackItem))
                    {
                        emptySpaceCount++;
                        if (emptySpaceCount == 4)
                        {
                            stackNo++;
                            emptySpaceCount = 0;
                        }
                    }
                    else
                    {
                        stacks[stackNo].Push(potentialStackItem[1]);
                        stackNo++;
                    }
                }
            }

            return stacks;
        }

        private Dictionary<int, Stack<char>> RearrangeStacksAccordingToFirstPuzzle(string rearrangements, Dictionary<int, Stack<char>> stacks)
        {
            foreach (var move in rearrangements.ToStrArrayBySplittingRowsAndRemovingEmptyEntries())
            {
                var moveParts = move.Split(" ");
                var noOfMoves = int.Parse(moveParts[1]);
                var moveFromStack = int.Parse(moveParts[3]);
                var moveToStack = int.Parse(moveParts[5]);
                for (int i = 0; i < noOfMoves; i++)
                {
                    if (stacks[moveFromStack].TryPop(out var item))
                    {
                        stacks[moveToStack].Push(item);
                    }
                }
            }

            return stacks;
        }

        private Dictionary<int, Stack<char>> RearrangeStacksAccordingToSecondPuzzle(string rearrangements, Dictionary<int, Stack<char>> stacks)
        {
            foreach (var move in rearrangements.ToStrArrayBySplittingRowsAndRemovingEmptyEntries())
            {
                var moveParts = move.Split(" ");
                var noOfMoves = int.Parse(moveParts[1]);
                var moveFromStack = int.Parse(moveParts[3]);
                var moveToStack = int.Parse(moveParts[5]);

                var tempStack = new Stack<char>();

                for (int i = 0; i < noOfMoves; i++)
                {
                    if (stacks[moveFromStack].TryPop(out var item))
                    {
                        tempStack.Push(item);
                    }
                }

                foreach (var item in tempStack)
                {
                    stacks[moveToStack].Push(item);
                }
            }

            return stacks;
        }

        private string GetResultString(Dictionary<int, Stack<char>> stacks)
        {
            var resultString = "";

            foreach (var stack in stacks)
            {
                resultString += stack.Value.Pop();
            }

            return resultString;
        }
    }

}

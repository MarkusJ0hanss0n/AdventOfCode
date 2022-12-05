using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2022
{

    public class _2022Day02 : BaseDay, IDay
    {
        public _2022Day02(bool useExampleInput = false) : base(2022, 02, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var totalScore = 0;
            foreach (var instructionRow in _input.GetStrArrayBySplittingOnRows())
            {
                var splittedInstruction = instructionRow.GetStrArrayBySplittingOnRows(" ");
                var opponentsChoice = splittedInstruction[0];
                var myChoice = splittedInstruction[1];

                totalScore += CalculateScoreForFirstPuzzle(opponentsChoice, myChoice);
            }

            return totalScore.ToString();
        }

        public string SecondPuzzle()
        {
            var totalScore = 0;
            foreach (var instructionRow in _input.GetStrArrayBySplittingOnRows())
            {
                var splittedInstruction = instructionRow.GetStrArrayBySplittingOnRows(" ");
                var opponentsChoice = splittedInstruction[0];
                var myChoice = splittedInstruction[1];

                totalScore += CalculateScoreForSecondPuzzle(opponentsChoice, myChoice);
            }

            return totalScore.ToString();
        }

        private int CalculateScoreForFirstPuzzle(string opponentsChoice, string myChoice)
        {
            var totalScore = 0;

            switch (myChoice)
            {
                case "X": // Rock
                    totalScore += 1;
                    if (opponentsChoice == "A")
                    {
                        totalScore += 3;
                    }
                    else if (opponentsChoice == "C")
                    {
                        totalScore += 6;
                    }
                    break;
                case "Y":  // Paper
                    totalScore += 2;
                    if (opponentsChoice == "B")
                    {
                        totalScore += 3;
                    }
                    else if (opponentsChoice == "A")
                    {
                        totalScore += 6;
                    }
                    break;
                case "Z":  // Scissors
                    totalScore += 3;
                    if (opponentsChoice == "C")
                    {
                        totalScore += 3;
                    }
                    else if (opponentsChoice == "B")
                    {
                        totalScore += 6;
                    }
                    break;
                default:
                    break;
            }

            return totalScore;
        }

        private int CalculateScoreForSecondPuzzle(string opponentsChoice, string myChoice)
        {
            var totalScore = 0;

            switch (myChoice)
            {
                case "X": // Loose
                    if (opponentsChoice == "A")
                    {
                        totalScore += 3;
                    }
                    else if (opponentsChoice == "B")
                    {
                        totalScore += 1;
                    }
                    else
                    {
                        totalScore += 2;
                    }
                    break;
                case "Y":  // Draw
                    totalScore += 3;
                    if (opponentsChoice == "A")
                    {
                        totalScore += 1;
                    }
                    else if (opponentsChoice == "B")
                    {
                        totalScore += 2;
                    }
                    else
                    {
                        totalScore += 3;
                    }
                    break;
                case "Z":  // Win
                    totalScore += 6;
                    if (opponentsChoice == "A")
                    {
                        totalScore += 2;
                    }
                    else if (opponentsChoice == "C")
                    {
                        totalScore += 1;
                    }
                    else
                    {
                        totalScore += 3;
                    }
                    break;
                default:
                    break;
            }

            return totalScore;
        }
    }

}

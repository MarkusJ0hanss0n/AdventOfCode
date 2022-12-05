using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    enum Direction {Forward, Up, Down};

    public class _2021Day02 : BaseDay, IDay
    {
        public _2021Day02(bool useExampleInput = false) : base(2021, 2, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var instructions = GetInstructions(_input);

            var horizontalPosition = 0;
            var depth = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Key)
                {
                    case Direction.Forward:
                        horizontalPosition += instruction.Value;
                        break;
                    case Direction.Up:
                        depth -= instruction.Value;
                        break;
                    case Direction.Down:
                        depth += instruction.Value;
                        break;
                    default:
                        break;
                }
            }

            return (horizontalPosition * depth).ToString();
        }

        public string SecondPuzzle()
        {
            var instructions = GetInstructions(_input);

            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Key)
                {
                    case Direction.Forward:
                        horizontalPosition += instruction.Value;
                        depth += aim * instruction.Value;
                        break;
                    case Direction.Up:
                        aim -= instruction.Value;
                        break;
                    case Direction.Down:
                        aim += instruction.Value;
                        break;
                    default:
                        break;
                }
            }

            return (horizontalPosition * depth).ToString();
        }

        private List<KeyValuePair<Direction, int>> GetInstructions(string input)
        {
            var lines = input.GetStrArrayBySplittingOnRows();
            var instructions = new List<KeyValuePair<Direction, int>>();

            foreach (var line in lines)
            {
                var lineParts = line.Split(' ');
                var direction = GetDirectionType(lineParts[0]);
                var amount = int.Parse(lineParts[1]);
                instructions.Add(
                    new KeyValuePair<Direction, int>(direction, amount));
            }

            return instructions;
        }

        private Direction GetDirectionType(string direction)
        {
            switch (direction.ToLower())
            {
                case "forward":
                    return Direction.Forward;
                case "up":
                    return Direction.Up;
                case "down":
                    return Direction.Down;
                default:
                    throw new Exception($"Unknown direction '{direction}'.");
            }
        }
    }
}

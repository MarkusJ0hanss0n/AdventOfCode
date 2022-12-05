using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day05 : BaseDay, IDay
    {
        public _2021Day05(bool useExampleInput = false) : base(2021, 5, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var diagram = new Diagram(1000, 1000);

            var entries = InputToEntries(_input);

            foreach (var entry in entries)
            {
                var xMatches = entry[0].X == entry[1].X;
                var yMatches = (entry[0].Y == entry[1].Y);

                if (xMatches && !yMatches)
                {
                    diagram.DrawVerticalLine(entry[0].X, entry[0].Y, entry[1].Y);
                }
                else if (yMatches && !xMatches)
                {
                    diagram.DrawHorizontalLine(entry[0].Y, entry[0].X, entry[1].X);
                }
            }

            return diagram.AtLeastTwoLinesCrossesCount().ToString();
        }

        public string SecondPuzzle()
        {
            var diagram = new Diagram(1000, 1000);

            var entries = InputToEntries(_input);

            foreach (var entry in entries)
            {
                var xMatches = entry[0].X == entry[1].X;
                var yMatches = (entry[0].Y == entry[1].Y);

                if (xMatches && !yMatches)
                {
                    diagram.DrawVerticalLine(entry[0].X, entry[0].Y, entry[1].Y);
                }
                else if (yMatches && !xMatches)
                {
                    diagram.DrawHorizontalLine(entry[0].Y, entry[0].X, entry[1].X);
                }
                else
                {
                    diagram.DrawDiagonalLine(entry[0].X, entry[1].X, entry[0].Y, entry[1].Y);
                }
            }
            return diagram.AtLeastTwoLinesCrossesCount().ToString();
        }

        public List<Coordinate[]> InputToEntries(string input)
        {
            var inputRows = _input.GetStrArrayBySplittingOnRows();
            var entries = new List<Coordinate[]>();

            foreach (var row in inputRows)
            {
                var rowCoordinates = row.Split(" -> ");

                if (rowCoordinates.Length != 2)
                {
                    throw new Exception("Row coordinates is not 2.");
                }

                var firstCoordinate = rowCoordinates[0].Split(",").Select(int.Parse).ToArray();
                var secondCoordinate = rowCoordinates[1].Split(",").Select(int.Parse).ToArray();

                entries.Add(new Coordinate[] {
                    new Coordinate(firstCoordinate[0], firstCoordinate[1]),
                    new Coordinate(secondCoordinate[0], secondCoordinate[1])
                });
            }

            return entries;
        }

        public class Diagram
        {
            private Point[,] points;

            public Diagram(int XSize, int YSize)
            {
                points = new Point[XSize, YSize];

                for (int i = 0; i < XSize; i++)
                {
                    for (int j = 0; j < YSize; j++)
                    {
                        points[i, j] = new Point();
                    }
                }
            }

            public void DrawHorizontalLine(int y, int x1, int x2)
            {
                var loopStart = x1 < x2 ? x1 : x2;
                var loopUntil = x1 > x2 ? x1 : x2;

                for (int i = loopStart; i <= loopUntil; i++)
                {
                    points[i, y].Crossing();
                }
            }

            public void DrawVerticalLine(int x, int y1, int y2)
            {
                var loopStart = y1 < y2 ? y1 : y2;
                var loopUntil = y1 > y2 ? y1 : y2;

                for (int i = loopStart; i <= loopUntil; i++)
                {
                    points[x, i].Crossing();
                }
            }

            public void DrawDiagonalLine(int x1, int x2, int y1, int y2)
            {
                var xAdjuster = x1 < x2 ? 1 : -1;
                var yAdjuster = y1 < y2 ? 1 : -1;

                var xVal = x1;
                var yVal = y1;

                while (true)
                {
                    points[xVal, yVal].Crossing();

                    if (xVal == x2)
                    {
                        break;
                    }

                    xVal += xAdjuster;
                    yVal += yAdjuster;
                }
            }

            public int AtLeastTwoLinesCrossesCount()
            {
                var count = 0;
                foreach (var point in points)
                {
                    if (point.NumberOfCrossingLines >= 2)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public class Point
        {
            public int NumberOfCrossingLines { get; set; }

            public Point()
            {
                NumberOfCrossingLines = 0;
            }

            public void Crossing()
            {
                NumberOfCrossingLines++;
            }
        }

        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}

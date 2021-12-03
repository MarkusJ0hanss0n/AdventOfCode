using AdventOfCode.Lib.Days._2021;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Lib
{
    public static class DayFactory
    {
        public static IDay GetDay(int year, int day, bool useExampleInput = false)
        {
            switch (year)
            {
                case 2021:
                    switch (day)
                    {
                        case 1:
                            return new _2021Day1(year, day, useExampleInput);
                        case 2:
                            return new _2021Day2(year, day, useExampleInput);
                        case 3:
                            return new _2021Day3(year, day, useExampleInput);
                        case 4:
                            return new _2021Day4(year, day, useExampleInput);
                        case 5:
                            return new _2021Day5(year, day, useExampleInput);
                        case 6:
                            return new _2021Day6(year, day, useExampleInput);
                        case 7:
                            return new _2021Day7(year, day, useExampleInput);
                        case 8:
                            return new _2021Day8(year, day, useExampleInput);
                        case 9:
                            return new _2021Day9(year, day, useExampleInput);
                        case 10:
                            return new _2021Day10(year, day, useExampleInput);
                        case 11:
                            return new _2021Day11(year, day, useExampleInput);
                        case 12:
                            return new _2021Day12(year, day, useExampleInput);
                        case 13:
                            return new _2021Day13(year, day, useExampleInput);
                        case 14:
                            return new _2021Day14(year, day, useExampleInput);
                        case 15:
                            return new _2021Day15(year, day, useExampleInput);
                        case 16:
                            return new _2021Day16(year, day, useExampleInput);
                        case 17:
                            return new _2021Day17(year, day, useExampleInput);
                        case 18:
                            return new _2021Day18(year, day, useExampleInput);
                        case 19:
                            return new _2021Day19(year, day, useExampleInput);
                        case 20:
                            return new _2021Day20(year, day, useExampleInput);
                        case 21:
                            return new _2021Day21(year, day, useExampleInput);
                        case 22:
                            return new _2021Day22(year, day, useExampleInput);
                        case 23:
                            return new _2021Day23(year, day, useExampleInput);
                        case 24:
                            return new _2021Day24(year, day, useExampleInput);
                        case 25:
                            return new _2021Day25(year, day, useExampleInput);
                        default:
                            throw new ArgumentOutOfRangeException($"Day '{day}' is invalid.");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Year '{year}' is invalid.");
            }
        }
    }
}

using AdventOfCode.Lib.Days._2021;
using AdventOfCode.Lib.Days._2022;
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
                            return new _2021Day01(useExampleInput);
                        case 2:
                            return new _2021Day02(useExampleInput);
                        case 3:
                            return new _2021Day03(useExampleInput);
                        case 4:
                            return new _2021Day04(useExampleInput);
                        case 5:
                            return new _2021Day05(useExampleInput);
                        case 6:
                            return new _2021Day06(useExampleInput);
                        case 7:
                            return new _2021Day07(useExampleInput);
                        case 8:
                            return new _2021Day08(useExampleInput);
                        case 9:
                            return new _2021Day09(useExampleInput);
                        case 10:
                            return new _2021Day10(useExampleInput);
                        case 11:
                            return new _2021Day11(useExampleInput);
                        case 12:
                            return new _2021Day12(useExampleInput);
                        case 13:
                            return new _2021Day13(useExampleInput);
                        case 14:
                            return new _2021Day14(useExampleInput);
                        case 15:
                            return new _2021Day15(useExampleInput);
                        case 16:
                            return new _2021Day16(useExampleInput);
                        case 17:
                            return new _2021Day17(useExampleInput);
                        case 18:
                            return new _2021Day18(useExampleInput);
                        case 19:
                            return new _2021Day19(useExampleInput);
                        case 20:
                            return new _2021Day20(useExampleInput);
                        case 21:
                            return new _2021Day21(useExampleInput);
                        case 22:
                            return new _2021Day22(useExampleInput);
                        case 23:
                            return new _2021Day23(useExampleInput);
                        case 24:
                            return new _2021Day24(useExampleInput);
                        case 25:
                            return new _2021Day25(useExampleInput);
                        default:
                            throw new ArgumentOutOfRangeException($"Day '{day}' is invalid.");
                    }
                case 2022:
                    switch (day)
                    {
                        case 1:
                            return new _2022Day01(useExampleInput);
                        default:
                            throw new ArgumentOutOfRangeException($"Day '{day}' is invalid.");
                    }
                default:
                    throw new ArgumentOutOfRangeException($"Year '{year}' is invalid.");
            }
        }
    }
}

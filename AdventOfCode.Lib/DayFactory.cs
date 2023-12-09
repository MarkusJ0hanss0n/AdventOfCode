using AdventOfCode.Lib.Days._2021;
using AdventOfCode.Lib.Days._2022;
using AdventOfCode.Lib.Days._2023;
using System;

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
                        case 2:
                            return new _2022Day02(useExampleInput);
                        case 3:
                            return new _2022Day03(useExampleInput);
                        case 4:
                            return new _2022Day04(useExampleInput);
                        case 5:
                            return new _2022Day05(useExampleInput);
                        case 6:
                            return new _2022Day06(useExampleInput);
                        case 7:
                            return new _2022Day07(useExampleInput);
                        case 8:
                            return new _2022Day08(useExampleInput);
                        case 9:
                            return new _2022Day09(useExampleInput);
                        case 10:
                            return new _2022Day10(useExampleInput);
                        case 11:
                            return new _2022Day11(useExampleInput);
                        case 12:
                            return new _2022Day12(useExampleInput);
                        case 13:
                            return new _2022Day13(useExampleInput);
                        case 14:
                            return new _2022Day14(useExampleInput);
                        case 15:
                            return new _2022Day15(useExampleInput);
                        case 16:
                            return new _2022Day16(useExampleInput);
                        case 17:
                            return new _2022Day17(useExampleInput);
                        case 18:
                            return new _2022Day18(useExampleInput);
                        case 19:
                            return new _2022Day19(useExampleInput);
                        case 20:
                            return new _2022Day20(useExampleInput);
                        case 21:
                            return new _2022Day21(useExampleInput);
                        case 22:
                            return new _2022Day22(useExampleInput);
                        case 23:
                            return new _2022Day23(useExampleInput);
                        case 24:
                            return new _2022Day24(useExampleInput);
                        case 25:
                            return new _2022Day25(useExampleInput);
                        default:
                            throw new ArgumentOutOfRangeException($"Day '{day}' is invalid.");
                    }
                case 2023:
                    switch (day)
                    {
                        case 1:
                            return new _2023Day01(useExampleInput);
                        case 2:
                            return new _2023Day02(useExampleInput);
                        case 3:
                            return new _2023Day03(useExampleInput);
                        case 4:
                            return new _2023Day04(useExampleInput);
                        case 5:
                            return new _2023Day05(useExampleInput);
                        case 6:
                            return new _2023Day06(useExampleInput);
                        case 7:
                            return new _2023Day07(useExampleInput);
                        case 8:
                            return new _2023Day08(useExampleInput);
                        case 9:
                            return new _2023Day09(useExampleInput);
                        case 10:
                            return new _2023Day10(useExampleInput);
                        case 11:
                            return new _2023Day11(useExampleInput);
                        case 12:
                            return new _2023Day12(useExampleInput);
                        case 13:
                            return new _2023Day13(useExampleInput);
                        case 14:
                            return new _2023Day14(useExampleInput);
                        case 15:
                            return new _2023Day15(useExampleInput);
                        case 16:
                            return new _2023Day16(useExampleInput);
                        case 17:
                            return new _2023Day17(useExampleInput);
                        case 18:
                            return new _2023Day18(useExampleInput);
                        case 19:
                            return new _2023Day19(useExampleInput);
                        case 20:
                            return new _2023Day20(useExampleInput);
                        case 21:
                            return new _2023Day21(useExampleInput);
                        case 22:
                            return new _2023Day22(useExampleInput);
                        case 23:
                            return new _2023Day23(useExampleInput);
                        case 24:
                            return new _2023Day24(useExampleInput);
                        case 25:
                            return new _2023Day25(useExampleInput);
                        default:
                            throw new ArgumentOutOfRangeException($"Day '{day}' is invalid.");
                    }
                default:
                    throw new ArgumentOutOfRangeException($"Year '{year}' is invalid.");
            }
        }
    }
}

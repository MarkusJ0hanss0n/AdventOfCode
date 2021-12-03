using AdventOfCode.Lib;
using AdventOfCode.Lib.Days._2021;
using System;
using System.Reflection;

namespace AdventOfCode.UI
{
    class Program
    {
        private static string _readLine;
        private static string _lastResult = "";
        private static int _year;
        private static int _day;
        private static int _puzzleNumber;

        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                PrintHead();
                PrintHelp();
                PrintLastResult();

                _readLine = Console.ReadLine();

                if (_readLine.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    ParseArguments(_readLine);
                    PrintPuzzleResult();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    _lastResult = e.Message + " Please try again.";
                }
            }
        }

        private static void PrintHead()
        {
            Console.WriteLine("===============================");
            Console.WriteLine(" *   *   *   *   *   *   *   * ");
            Console.WriteLine("   *   *  ADVENT OF CODE   *   ");
            Console.WriteLine(" *   *   *   *   *   *   *   * ");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Enter a year, a day, and a puzzle number using the pattern below.");
            Console.WriteLine();
            Console.WriteLine("'<year> <day> <puzzle number>' e.g. '2021 1 1'");
            Console.WriteLine();
            Console.WriteLine("Or type Q to quit.");
            Console.WriteLine();
        }

        private static void PrintLastResult()
        {
            if (_lastResult != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_lastResult);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
            }
        }

        private static void ParseArguments(string argumentLine)
        {
            var argumentParts = argumentLine.Split(' ');

            if (!(argumentParts.Length == 3 &&
                int.TryParse(argumentParts[0], out _year) &&
                int.TryParse(argumentParts[1], out _day) &&
                int.TryParse(argumentParts[2], out _puzzleNumber)))
            {
                throw new Exception("Failed to parse arguments.");
            }
        }

        private static void PrintPuzzleResult()
        {
            IDay day = DayFactory.GetDay(_year, _day);
            string result;

            if (_puzzleNumber == 1)
            {
                result = day.FirstPuzzle();
            }
            else if (_puzzleNumber == 2)
            {
                result = day.SecondPuzzle();
            }
            else
            {
                throw new Exception($"Unknown puzzle number '{_puzzleNumber}'.");
            }

            Console.WriteLine($"Result: '{result}'");
        }
    }
}

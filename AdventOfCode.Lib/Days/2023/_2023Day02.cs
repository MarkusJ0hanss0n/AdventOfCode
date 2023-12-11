using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Lib.Days._2023
{
    public class _2023Day02 : BaseDay, IDay
    {
        public _2023Day02(bool useExampleInput = false) : base(2023, 02, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var games = CreateGamesFromInput(inputLines);
            var sumOfGameIds = 0;

            foreach (var game in games)
            {
                if (game.GetHighestNoOfRedInSet() <= 12 &&
                    game.GetHighestNoOfGreenInSet() <= 13 &&
                    game.GetHighestNoOfBlueInSet() <= 14)
                {
                    sumOfGameIds += game.Id;
                }
            }

            return sumOfGameIds.ToString();
        }

        public string SecondPuzzle()
        {
            var inputLines = _input.ToStrArrayBySplittingRowsAndRemovingEmptyEntries();
            var games = CreateGamesFromInput(inputLines);

            int highestRedCountInSet;
            int highestGreenCountInSet;
            int highestBlueCountInSet;

            var sumOfLowestPossibleColorCount = 0;

            foreach (var game in games)
            {
                highestRedCountInSet = game.GetHighestNoOfRedInSet();
                highestGreenCountInSet = game.GetHighestNoOfGreenInSet();
                highestBlueCountInSet = game.GetHighestNoOfBlueInSet();
                {
                    sumOfLowestPossibleColorCount += highestRedCountInSet * highestGreenCountInSet * highestBlueCountInSet;
                }
            }

            return sumOfLowestPossibleColorCount.ToString();
        }

        private List<Game> CreateGamesFromInput(string[] inputLines)
        {
            var games = new List<Game>();
            int noOfBlue;
            int noOfRed;
            int noOfGreen;
            Group group;
            Match match;

            var regexBlue = new Regex(@" (?<blue>\d+) blue");
            var regexRed = new Regex(@" (?<red>\d+) red");
            var regexGreen = new Regex(@" (?<green>\d+) green");

            foreach (var line in inputLines)
            {
                var semiColonIndex = line.IndexOf(':');

                var gameId = int.Parse(line.Substring(5, (semiColonIndex - 5)));
                var game = new Game(gameId);

                foreach (var setLine in line.Substring(semiColonIndex + 1, line.Length - semiColonIndex - 1).Split(";"))
                {
                    match = regexBlue.Match(setLine);
                    noOfBlue = match.Success && match.Groups.TryGetValue("blue", out group) ? int.Parse(group.Value) : 0;

                    match = regexRed.Match(setLine);
                    noOfRed = match.Success && match.Groups.TryGetValue("red", out group) ? int.Parse(group.Value) : 0;

                    match = regexGreen.Match(setLine);
                    noOfGreen = match.Success && match.Groups.TryGetValue("green", out group) ? int.Parse(group.Value) : 0;

                    game.Sets.Add(new Set { NoOfBlue = noOfBlue, NoOfRed = noOfRed, NoOfGreen = noOfGreen });
                }

                games.Add(game);
            }
            return games;
        }
    }

    public class Game
    {
        public int Id { get; set; }
        public List<Set> Sets { get; set; }

        public Game(int id)
        {
            Id = id;
            Sets = new List<Set>();
        }

        public int GetHighestNoOfBlueInSet()
        {
            return Sets.Max(s => s.NoOfBlue);
        }

        public int GetHighestNoOfRedInSet()
        {
            return Sets.Max(s => s.NoOfRed);
        }

        public int GetHighestNoOfGreenInSet()
        {
            return Sets.Max(s => s.NoOfGreen);
        }
    }

    public class Set
    {
        public int NoOfBlue { get; set; }
        public int NoOfRed { get; set; }
        public int NoOfGreen { get; set; }
    }
}

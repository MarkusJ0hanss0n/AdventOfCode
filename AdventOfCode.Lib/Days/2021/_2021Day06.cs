using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day06 : BaseDay, IDay
    {
        public _2021Day06(bool useExampleInput = false) : base(2021, 6, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var DaysBetweenBirths = 7;
            var DaysUntilFirstBirth = 9;
            var NoOfDays = 80;

            var lanternFishes = new List<LanternFish>();

            var inputTimers = _input.GetIntArrayBySplittingOnRows(",");

            foreach (var inputTimer in inputTimers)
            {
                lanternFishes.Add(new LanternFish(inputTimer));
            }

            for (int i = 0; i < NoOfDays; i++)
            {
                var newFishes = new List<LanternFish>();

                foreach (var lanternFish in lanternFishes)
                {
                    if (lanternFish.GivesBirth(DaysBetweenBirths))
                    {
                        newFishes.Add(new LanternFish(DaysUntilFirstBirth - 1));
                    }
                }
                lanternFishes.AddRange(newFishes);
            }

            return lanternFishes.Count.ToString();
        }

        public string SecondPuzzle()
        {
            throw new NotImplementedException();
        }
    }

    public class LanternFish
    {
        private int _internalTimer;

        public LanternFish(int daysUntilFirstBirth)
        {
            _internalTimer = daysUntilFirstBirth;
        }

        public bool GivesBirth(int daysBetweenBirths)
        {
            if (_internalTimer == 0)
            {
                _internalTimer = daysBetweenBirths - 1;
                return true;
            }
            else
            {
                _internalTimer--;
                return false;
            }
        }
    }
}

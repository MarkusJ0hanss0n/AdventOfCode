using System;

namespace AdventOfCode.Lib
{

    public abstract class BaseDay
    {
        private readonly int _year;
        private readonly int _day;
        protected readonly string _input;
        private int[] ValidYears = { 2021, 2022 };

        public BaseDay(int year, int day, bool useExampleInput = false)
        {
            _year = year;
            _day = day;

            ValidateInput();

            string inputFilePath;

            if (useExampleInput)
            {
                inputFilePath = YearDayFilePathMapper.GetExampleFilePath(_year, _day);
            }
            else
            {
                inputFilePath = YearDayFilePathMapper.GetInputFilePath(_year, _day);
            }

            _input = InputFileReader.GetInputFromFile(inputFilePath);
        }

        private void ValidateInput()
        {
            ValidateYear();
            ValidateDay();
        }

        private void ValidateYear()
        {
            foreach (var year in ValidYears)
            {
                if (_year == year)
                {
                    return;
                }
            }

            throw new ArgumentOutOfRangeException($"Year '{_year}' is not valid");
        }

        private void ValidateDay()
        {
            if (_day < 1 || _day > 25)
            {
                throw new ArgumentOutOfRangeException($"Day '{_day}' is not valid");
            }
        }
    }
}

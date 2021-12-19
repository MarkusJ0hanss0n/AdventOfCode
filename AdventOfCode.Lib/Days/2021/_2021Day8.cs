using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Lib.Days._2021
{
    public class _2021Day8 : BaseDay, IDay
    {
        public _2021Day8(bool useExampleInput = false) : base(2021, 8, useExampleInput)
        {
        }

        public string FirstPuzzle()
        {
            var totalNoOfUniqueOutputValues = 0;

            var inputRows = _input.GetStrArrayBySplittingOnRows();

            foreach (var inputRow in inputRows)
            {
                var entry = new Entry(inputRow);
                totalNoOfUniqueOutputValues += entry.GetNoOfUniqueOutputValues();
            }

            return totalNoOfUniqueOutputValues.ToString();
        }

        public string SecondPuzzle()
        {
            var totalSumOfOutputValues = 0;

            var inputRows = _input.GetStrArrayBySplittingOnRows();

            foreach (var inputRow in inputRows)
            {
                var entry = new Entry(inputRow);
                totalSumOfOutputValues += entry.GetOutputValue();
            }

            return totalSumOfOutputValues.ToString();
        }

    }

    public class Entry
    {
        public string[] UniqueSignalPatterns { get; set; }
        public string[] FourDigitOutputValue { get; set; }

        private int[] uniqueDigitLengths = new int[] { 2, 3, 4, 7 };


        public Entry(string input)
        {
            var inputParts = input.Split(" | ");
            UniqueSignalPatterns = inputParts[0].Split(" ");
            FourDigitOutputValue = inputParts[1].Split(" ");
            SortArrays();
        }

        private void SortArrays()
        {
            for (int i = 0; i < UniqueSignalPatterns.Length; i++)
            {
                UniqueSignalPatterns[i] = SortString(UniqueSignalPatterns[i]);
            }

            for (int i = 0; i < FourDigitOutputValue.Length; i++)
            {
                FourDigitOutputValue[i] = SortString(FourDigitOutputValue[i]);
            }
        }

        private string SortString(string stringToSort)
        {
            var stringChars = stringToSort.ToArray();
            Array.Sort(stringChars);
            return new string(stringChars);
        }

        public int GetNoOfUniqueOutputValues()
        {
            var noOfUniqueOutputValues = 0;

            foreach (var outputValue in FourDigitOutputValue)
            {
                if (uniqueDigitLengths.Contains(outputValue.Length))
                {
                    noOfUniqueOutputValues++;
                }
            }

            return noOfUniqueOutputValues;
        }

        public int GetOutputValue()
        {
            var patternMapping = new Dictionary<string, int>();
            var patterns = UniqueSignalPatterns.ToList();

            patternMapping.Add(
                patterns.FirstOrDefault(p => p.Length == 2), 1);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => p.Length == 3), 7);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => p.Length == 4), 4);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => p.Length == 7), 8);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => StringContainOneOfEachComparingStringChars(p,
                    patternMapping.FirstOrDefault(pm => pm.Value == 4).Key)), 9);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p =>
                p.Length == 6 &&
                StringContainOneOfEachComparingStringChars(p,
                    patternMapping.FirstOrDefault(pm => pm.Value == 1).Key)), 0);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => StringContainOneOfEachComparingStringChars(p,
                    patternMapping.FirstOrDefault(pm => pm.Value == 1).Key)), 3);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => p.Length == 6), 6);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(p => StringContainOneOfEachComparingStringChars(
                    patternMapping.FirstOrDefault(pm => pm.Value == 9).Key, p)), 5);
            patterns.Remove(patternMapping.Last().Key);

            patternMapping.Add(
                patterns.FirstOrDefault(), 2);
            patterns.Remove(patternMapping.Last().Key);

            var resultOutputValue = "";

            foreach (var outputValue in FourDigitOutputValue)
            {
                resultOutputValue += patternMapping[outputValue].ToString();
            }

            return int.Parse(resultOutputValue);
        }

        private bool StringContainOneOfEachComparingStringChars(string shouldContain, string compareChars)
        {
            foreach (var compareChar in compareChars)
            {
                if (!shouldContain.Contains(compareChar))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            var delimiterAndNumbersString = GetDelimiterAndNumbersString(numbers);
            numbers = delimiterAndNumbersString.Item2;

            var maxNumber = 1000;

            var numbersList = numbers.Split(delimiterAndNumbersString.Item1, StringSplitOptions.RemoveEmptyEntries)
                                     .Where(number => Convert.ToInt32(number) <= maxNumber)
                                     .Select(number => Convert.ToInt32(number));

            ValidateNumbers(numbersList);

            return numbersList.Sum();
        }

        public (string[], string) GetDelimiterAndNumbersString(string numbers)
        {
            var pattern = @"\/\/(?<delimiter>.*)\n(?<numbers>.*)|\/\/\[(?<delimiter>.*)\]\n(?<numbers>.*)";
            var match = new Regex(pattern).Match(numbers);

            if (match.Success)
            {
                var delimiterString = match.Groups["delimiter"].Value;
                var numbersString = match.Groups["numbers"].Value;

                if(delimiterString.Contains("[") && delimiterString.Contains("]"))
                {
                    return (delimiterString.Replace("[", ",").Replace("]", ",").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), numbersString);
                }

                return (new string[] { delimiterString }, numbersString);
            }

            return (new string[] { ",", "\n" }, numbers);
        }

        public void ValidateNumbers(IEnumerable<int> numbersList)
        {
            var negativeNumbersList = numbersList.Where(number => number < 0)
                                                 .Select(number => number);

            if(negativeNumbersList.Any())
            {
                throw new ArgumentException($"negatives not allowed: {string.Join(", ", negativeNumbersList)}");
            }
                                                 
        }
    }
}

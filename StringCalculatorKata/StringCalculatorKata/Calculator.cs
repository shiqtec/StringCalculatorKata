using System;
using System.Collections.Generic;
using System.Linq;

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

            var numbersList = numbers.Split(delimiterAndNumbersString.Item1, StringSplitOptions.None)
                                     .Where(number => Convert.ToInt32(number) <= maxNumber)
                                     .Select(number => Convert.ToInt32(number));

            ValidateNumbers(numbersList);

            return numbersList.Sum();
        }

        public (string[], string) GetDelimiterAndNumbersString(string numbers)
        {
            if(numbers.StartsWith("//"))
            {
                var indexOfDelimterEnd = numbers.IndexOf("\n") - 2;
                var delimiterData = numbers.Substring(2, indexOfDelimterEnd);

                if(numbers.Contains("[") && numbers.Contains("]"))
                {
                    delimiterData = delimiterData.Substring(1, delimiterData.Length - 2);
                    var numbersString = numbers.Substring(indexOfDelimterEnd + 3);
                    return (delimiterData.Replace("][", ",").Split(new string[] { "," }, StringSplitOptions.None), numbersString);
                }

                return (new string[] { numbers.Substring(2, 1) }, numbers[(numbers.IndexOf("\n") + 1)..]);
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

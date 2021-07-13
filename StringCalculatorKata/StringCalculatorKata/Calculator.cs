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

            var numbersList = numbers.Split(delimiterAndNumbersString.Item1)
                                     .Select(number => Convert.ToInt32(number));

            ValidateNumbers(numbersList);

            return numbersList.Sum();
        }

        public (char[], string) GetDelimiterAndNumbersString(string numbers)
        {
            if(numbers.StartsWith("//"))
            {
                return (numbers.Substring(2, 1).ToCharArray(), numbers[(numbers.IndexOf("\n") + 1)..]);
            }

            return (new char[] { ',', '\n' }, numbers);
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

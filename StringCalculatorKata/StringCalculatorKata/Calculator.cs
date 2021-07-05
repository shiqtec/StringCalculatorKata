using System;
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

            return numbers.Split(delimiterAndNumbersString.Item1)
                          .Select(number => Convert.ToInt32(number))
                          .Sum();
        }

        public (char[], string) GetDelimiterAndNumbersString(string numbers)
        {
            if(numbers.StartsWith("//"))
            {
                var numbersStartPosition = numbers.IndexOf("\n") + 1;
                return (numbers.Substring(2, 1).ToCharArray(), numbers.Substring(numbersStartPosition));
            }

            return (new char[] { ',', '\n' }, numbers);
        }
    }
}

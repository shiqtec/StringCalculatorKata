using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers is not { Length: > 0 })
            {
                return 0;
            }

            var delimiters = Array.Empty<char>();

            if(numbers.StartsWith("//"))
            {
                delimiters = numbers.Substring(2, 1).ToCharArray();

                var numbersStartPosition = numbers.IndexOf("\n") + 1;
                numbers = numbers.Substring(numbersStartPosition);
            } else
            {
                delimiters = new char[] { ',', '\n' };
            }

            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                          .Select(number => Convert.ToInt32(number))
                          .Sum();
        }
    }
}

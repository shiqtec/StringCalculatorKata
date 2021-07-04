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

            var delimiters = new char[] { ',', '\n' };

            return numbers.Split(delimiters)
                          .Select(number => Convert.ToInt32(number))
                          .Sum();
        }
    }
}

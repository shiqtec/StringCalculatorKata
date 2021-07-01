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

            return numbers.Split(",")
                          .Select(number => Convert.ToInt32(number))
                          .Sum();
        }
    }
}

using System;

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

            return Convert.ToInt32(numbers);
        }
    }
}

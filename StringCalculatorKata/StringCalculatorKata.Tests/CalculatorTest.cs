using System;
using System.Linq;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class CalculatorTest
    {

        private readonly Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void EmptyStringReturns0()
        {
            Assert.Equal(0, _calculator.Add(""));
        }

        [Fact]
        public void OneNumberReturnsNumber()
        {
            Assert.Equal(1, _calculator.Add("1"));
        }

        [Fact]
        public void TwoNumbersReturnsSum()
        {
            Assert.Equal(3, _calculator.Add("1,2"));
        }

        [Fact]
        public void UnknownAmountNumbersReturnsSum()
        {
            var numbersArray = Enumerable.Range(0, 30);
            var numbersString = String.Join(",", numbersArray);
            var expectedSum = numbersArray.Sum();

            Assert.Equal(expectedSum, _calculator.Add(numbersString));
        }

        [Fact]
        public void AllowNewLineDelimiterReturnsSum()
        {
            Assert.Equal(6, _calculator.Add("1\n2,3"));
        }
    }
}

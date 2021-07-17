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

        [Fact]
        public void SupportCustomDelimiter()
        {
            Assert.Equal(3, _calculator.Add("//;\n1;2"));
        }

        [Fact]
        public void NegativeNumberReturnsThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add("-1,2"));
            Assert.Equal("negatives not allowed: -1", ex.Message);
        }

        [Fact]
        public void NegativeNumbersReturnsThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add("//;\n-1;2;-3;-4"));
            Assert.Equal("negatives not allowed: -1, -3, -4", ex.Message);
        }

        [Fact]
        public void NumbersGreaterThanMaxShouldNotBeAdded()
        {
            Assert.Equal(2, _calculator.Add("2,1001"));
        }

        [Fact]
        public void DelimitersOfAnyLength()
        {
            Assert.Equal(6, _calculator.Add("//[***]\n1***2***3"));
        }

        [Fact]
        public void AllowMultipleDelimiters()
        {
            Assert.Equal(6, _calculator.Add("//[*][%]\n1*2%3"));
        }
    }
}

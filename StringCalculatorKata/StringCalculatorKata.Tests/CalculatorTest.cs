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
    }
}

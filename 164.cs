using Xunit;
using CalculatorApp;
using System;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            int result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            int result = _calculator.Multiply(6, 7);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            int result = _calculator.Divide(20, 4);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
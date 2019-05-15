using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Logic;
using Exchange.Types;
using FluentAssertions;
using Xunit;

namespace Exchange.Tests
{
    public class AmmountCalculatorTests
    {
        [Theory]
        [InlineData(7.4394, 1, 7.4394)]
        [InlineData(7.4394, 2, 7.4394 * 2)]
        [InlineData(1.0000, 1, 1.0000)]
        public void AmmountCalculator_Calculate_ShouldCalculate(decimal rate, decimal ammount, decimal expected)
        {
            var calculator = new AmmountCalculator();
            var actual = calculator.Calculate(ammount, rate);

            actual.Should().Be(expected);
        }

    }
}

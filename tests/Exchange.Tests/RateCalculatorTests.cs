using System;
using Exchange.Logic;
using Exchange.Types;
using FluentAssertions;
using Xunit;

namespace Exchange.Tests
{
    public class RateCalculatorTests
    {
        [Theory]
        [InlineData(7.3333, 1.0000, 7.3333)]
        [InlineData(1.0000, 7.3333, 0.1364)]
        [InlineData(7.3333, 7.3333, 1.0000)]
        [InlineData(7.4394, 6.6311, 1.1219)]
        public void RateCalculator_Calculate_ShouldCalculateRate(decimal baseRate, decimal quoteRate, decimal expected)
        {
            var rateCalculator = new RateCalculator();
            var baseCurrency = new Currency { Rate = baseRate };
            var quoteCurrency  = new Currency { Rate = quoteRate };

            var actual = rateCalculator.CalculateRate(baseCurrency, quoteCurrency);

            actual.Should().Be(expected);
        }
    }
}

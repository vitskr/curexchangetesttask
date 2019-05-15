using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Types;

namespace Exchange.Logic
{
    public class RateCalculator
    {
        /// <summary>
        /// Calculates rate for currency pair. 
        /// In current implementation all currencies in repository have 
        /// rate to DKK set as base.
        /// In real life repository would have to contain all possible currency pairs with established rates
        /// </summary>
        public decimal CalculateRate(Currency baseCurrency, Currency quoteCurrency)
            => Math.Round(baseCurrency.Rate / quoteCurrency.Rate, 4);
    }
}

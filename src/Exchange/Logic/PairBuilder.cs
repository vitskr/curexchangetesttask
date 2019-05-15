using Exchange.Repository;
using Exchange.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Logic
{
    public class PairBuilder : IPairBuilder
    {
        private readonly ICurrencyRepository repository;
        private readonly RateCalculator rateCalculator;

        private Currency baseCurrency;
        private Currency quoteCurrency;

        public PairBuilder(ICurrencyRepository repository, RateCalculator rateCalculator)
        {
            this.repository = repository;
            this.rateCalculator = rateCalculator;
        }


        public PairBuilder WithBaseCurrency(Currency baseCurrency)
        {
            this.baseCurrency = baseCurrency;
            return this;
        }

        public PairBuilder WithQuoteCurrency(Currency quoteCurrency)
        {
            this.quoteCurrency = quoteCurrency;
            return this;
        }

        public CurrencyPair BuildPair()
        {
            var rate = rateCalculator.CalculateRate(baseCurrency, quoteCurrency);

            return new CurrencyPair
            {
                BaseCurrency = baseCurrency,
                QuoteCurrency = quoteCurrency,
                Rate = rate
            };
        }
    }
}

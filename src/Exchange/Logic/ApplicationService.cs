using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Exchange.Repository;
using Exchange.Types;

namespace Exchange.Logic
{
    public class ApplicationService
    {
        private readonly ICurrencyRepository repository;
        private readonly IPairBuilder pairBulder;
        private readonly IAmmountCalculator ammountCalculator;


        public ApplicationService(ICurrencyRepository repository, IPairBuilder pairBulder, IAmmountCalculator ammountCalculator)
        {
            this.repository = repository;
            this.pairBulder = pairBulder;
            this.ammountCalculator = ammountCalculator;
        }

        public void Run(string baseIsoCode, string quoteIsoCode, decimal ammount)
        {
            bool TryGetCurrency(string code, out Currency currency)
            {
                currency = null;

                if (!repository.TryGetCurrency(code, out currency))
                {
                    Console.WriteLine($"Uknown currency code {code}");
                    return false;
                }

                return true;

            }

            if (!TryGetCurrency(baseIsoCode, out var baseCurrency) ||
                !TryGetCurrency(quoteIsoCode, out var quoteCurrency))
            {
                return;
            }

            var pair = pairBulder
                .WithBaseCurrency(baseCurrency)
                .WithQuoteCurrency(quoteCurrency)
                .BuildPair();

            Console.WriteLine($"{ammountCalculator.Calculate(ammount, pair.Rate).ToString("N4")}");
        }
    }
}

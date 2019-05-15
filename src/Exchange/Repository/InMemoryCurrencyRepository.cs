using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exchange.Types;

namespace Exchange.Repository
{
    public class InMemoryCurrencyRepository : ICurrencyRepository
    {
        private readonly Lazy<Dictionary<string, Currency>> currencies;

        public InMemoryCurrencyRepository(IRepositoryReader reader)
        {
            currencies = new Lazy<Dictionary<string, Currency>>(
            () =>
            {
                return
                    reader
                    .GetCurrencies()
                    .ToDictionary(currency => currency.ISO);
            });
        }

        /// <summary>
        /// Returns Currency for ISO code
        /// </summary>
        /// <param name="iso">ISO code of currency to return</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Unknown currency</exception>
        public Currency GetCurrency(string iso) => currencies.Value[iso];
    }
}

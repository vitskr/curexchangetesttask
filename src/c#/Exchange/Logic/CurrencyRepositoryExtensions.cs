using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Repository;
using Exchange.Types;

namespace Exchange.Logic
{
    public static class CurrencyRepositoryExtensions
    {
        public static bool TryGetCurrency(this ICurrencyRepository repository, string currencyIsoCode, out Currency currency)
        {
            try
            {
                currency = repository.GetCurrency(currencyIsoCode);
                return true;
            }
            catch
            {
                currency = null;
                return false;
            }
        }
    }
}

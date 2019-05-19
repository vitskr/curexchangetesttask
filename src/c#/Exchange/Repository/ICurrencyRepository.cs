using System;
using System.Collections.Generic;
using System.Text;

using Exchange.Types;

namespace Exchange.Repository
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(string name);
    }
}

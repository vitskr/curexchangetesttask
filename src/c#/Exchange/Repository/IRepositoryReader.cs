using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Types;

namespace Exchange.Repository
{
    public interface IRepositoryReader
    {
        IEnumerable<Currency> GetCurrencies();
    }
}

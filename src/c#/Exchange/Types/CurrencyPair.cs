using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Types
{
    public class CurrencyPair
    {
        public Currency BaseCurrency { get; set; }

        public Currency QuoteCurrency { get; set; }

        public decimal Rate { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Types
{
    public class Currency
    {
        public string Name { get; set; }

        public string ISO { get; set; }

        public decimal Rate { get; set; }
    }
}

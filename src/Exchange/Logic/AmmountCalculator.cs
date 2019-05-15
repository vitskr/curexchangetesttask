using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Types;

namespace Exchange.Logic
{
    public class AmmountCalculator : IAmmountCalculator
    {
        public decimal Calculate(decimal ammount, decimal rate)
        {
            return ammount * rate;
        }
    }
}

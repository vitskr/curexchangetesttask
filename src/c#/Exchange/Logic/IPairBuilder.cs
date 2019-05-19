using Exchange.Types;

namespace Exchange.Logic
{
    public interface IPairBuilder
    {
        CurrencyPair BuildPair();

        PairBuilder WithBaseCurrency(Currency baseCurrency);

        PairBuilder WithQuoteCurrency(Currency quoteCurrency);
    }
}
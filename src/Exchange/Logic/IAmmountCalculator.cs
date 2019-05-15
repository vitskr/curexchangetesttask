namespace Exchange.Logic
{
    public interface IAmmountCalculator
    {
        decimal Calculate(decimal ammount, decimal rate);
    }
}
using Exchange.Logic;
using Exchange.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Exchange
{
    class Program
    {
        public static void Main(string[] args)
        {
            var arguments = ParseCommandLine(args);
            if (!arguments.HasValue)
            {
                PrintUsage();
                return;
            }

            var container = RegisterComponents();
            var appService = container.GetService<ApplicationService>();

            appService.Run(arguments.Value.baseISO, arguments.Value.quoteISO, arguments.Value.ammount);
        }

        private static IServiceProvider RegisterComponents()
        {
            var services = new ServiceCollection()
                .AddSingleton<IRepositoryReader, JsonRepositoryReader>()
                .AddSingleton<ICurrencyRepository, InMemoryCurrencyRepository>()
                .AddTransient<IPairBuilder, PairBuilder>()
                .AddTransient<IAmmountCalculator, AmmountCalculator>()
                .AddTransient<RateCalculator>()
                .AddTransient<ApplicationService>();

            return services.BuildServiceProvider();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: Exchange.exe <currency pair> <ammount to exchange>");
            Console.WriteLine();
        }

        private static (string baseISO, string quoteISO, decimal ammount)? ParseCommandLine(string[] args)
        {
            if (args.Length != 2)
            {
                return null;
            }

            var pair = args[0].Split('/');
            if (pair.Length != 2)
            {
                return null;
            }

            if (!decimal.TryParse(args[1], out var ammount))
            {
                return null;
            }

            return (pair[0], pair[1], ammount);
        }
    }
}

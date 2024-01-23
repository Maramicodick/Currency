using Domain;
using Domain.DbModels;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedGraph(DataContext context)
        {
            if (context.GraphCurrencies.Any()) return;

            var seed = new List<GraphCurrency>
            {
                new GraphCurrency
                {
                   ExchangeRate = "45879.63000000",
                   Date = DateTime.Parse("2024-01-08"),
                },
                new GraphCurrency
                {
                    ExchangeRate = "45279.63000000",
                    Date = DateTime.Parse("2024-01-07"),
                }
            };

            await context.GraphCurrencies.AddRangeAsync(seed);
            await context.SaveChangesAsync();
        }

        public static async Task SeedCurrencies(DataContext context)
        {
            if(context.Currencies.Any()) return;

            var seed = new List<Currency>
            {
                new Currency
                {
                    CurrencyName = "Bitcoin",
                    CurrencyCode = "BTC",
                },
                new Currency 
                {
                    CurrencyName = "Ethereum",
                    CurrencyCode = "ETH",
                },
                new Currency
                {
                    CurrencyName = "Tether",
                    CurrencyCode = "USDT",
                },
                new Currency
                {
                    CurrencyName = "Binance-Coin",
                    CurrencyCode = "BNB",
                },
                new Currency
                {
                    CurrencyName = "Solana",
                    CurrencyCode = "SOL",
                },
                new Currency
                {
                    CurrencyName = "Ripple",
                    CurrencyCode = "XRP",
                },
                new Currency
                {
                    CurrencyName = "Cardano",
                    CurrencyCode = "ADA",
                },
                new Currency
                {
                    CurrencyName = "Dogecoin",
                    CurrencyCode = "DOGE",
                },
                new Currency
                {
                    CurrencyName = "Avalanche",
                    CurrencyCode = "AVAX",
                },
                new Currency
                {
                    CurrencyName = "Tronix",
                    CurrencyCode = "TRX",
                }
            };

            await context.AddRangeAsync(seed);
            await context.SaveChangesAsync();
        }
    }
}

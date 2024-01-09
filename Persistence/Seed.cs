using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.BTCToUSDLiveCurrency.Any()) return;

            var btcTousdLive = new List<BTCToUSD>
            {
                new BTCToUSD
                {
                   ExchangeRate = "45879.63000000",
                   RefreshedTime = DateTime.Parse("2024-01-08"),
                },
                new BTCToUSD
                {
                    ExchangeRate = "45279.63000000",
                    RefreshedTime = DateTime.Parse("2024-01-07"),
                }
            };

            await context.BTCToUSDLiveCurrency.AddRangeAsync(btcTousdLive);
            await context.SaveChangesAsync();
        }
    }
}

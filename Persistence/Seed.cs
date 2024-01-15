using Domain;
using Domain.DbModels;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
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
    }
}

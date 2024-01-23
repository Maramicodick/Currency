using Domain;
using Domain.DbModels;
using Domain.Deserialized;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<GraphCurrency> GraphCurrencies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}

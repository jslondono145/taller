using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelConfigurationBuilder)
        {
            base.OnModelCreating(modelConfigurationBuilder);
            modelConfigurationBuilder.Entity<Country>().HasIndex(countryEntity => countryEntity.CountryName).IsUnique();
            modelConfigurationBuilder.Entity<State>().HasIndex("StateName", "AssociatedCountryId").IsUnique();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}

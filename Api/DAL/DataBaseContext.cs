using Microsoft.EntityFrameworkCore;
using Api.DAL.Entities;

namespace Api.DAL
{
    public class DataBaseContext : DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); 

        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }

        #endregion
    }
}

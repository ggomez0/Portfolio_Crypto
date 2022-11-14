using System;
using Portfolio_GasparG.Models.ModelsCoin;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_GasparG.ServicesCoin
{
    public class DataContext : DbContext
    {
        private string _dbPath;
        public DataContext(string path)
        {
            _dbPath = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<CoinsHodle> CoinsHodles { get; set; }
        public DbSet<Transactions> Transactions { get; set; }


        public void init()
        {
            Database.EnsureCreated();   // Create database if not there. This will also ensure the data seeding will happen.
        }
    }
}

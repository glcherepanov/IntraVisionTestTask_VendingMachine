using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework
{
    public class VendingMachineDBContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Coin> Coins { get; set; }

        public VendingMachineDBContext(DbContextOptions<VendingMachineDBContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VendingMachine;Trusted_Connection=True;");
        }
    }
}

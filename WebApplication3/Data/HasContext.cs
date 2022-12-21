using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication3.Data
{
    public class HasContext : DbContext
    {
        public DbSet<Market> Markets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=20824245;Database=Medical");
        public HasContext()
        {

        }
    }
}

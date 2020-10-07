using Getter_Seeder.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Getter_Seeder.Data
{
    public class SeedContext : DbContext
    {
        public DbSet<Reading> Readings { get; set; }
        public SeedContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Data Source=.\\SQLSERVERFORIIS;Database=aspnet-CoreSight2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using Getter_Seeder.Domain;

namespace Getter_Seeder.Data
{
    public class GetContext : DbContext
    {

        public DbSet<Stuff> Stuff { get; set; }
        public GetContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer(
                "Data Source=.\\SQLSERVERFORIIS; AttachDbFilename=Z:\\Web\\App_Data\\Original.mdf; Integrated Security=false; User = fred; password = Chainsaw1; MultipleActiveResultSets=True;" 
              //  "Data Source=.\\SQLSERVERFORIIS;Database=Z:\\WEB\\APP_DATA\\ORIGINAL;Integrated Security=false; User = fred; password = Chainsaw1; MultipleActiveResultSets=True; App=EntityFramework" 
                );
        }
    }
}

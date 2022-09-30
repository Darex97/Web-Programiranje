using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

          public DbSet<Cvece> Cvece {get; set;}

          public DbSet<Pretraga> Pretrage {get; set;}

          public DbSet<Prodavnica> Prodavnice {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

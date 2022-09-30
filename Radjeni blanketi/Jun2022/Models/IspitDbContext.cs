using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

          public DbSet<Prodavnica> Prodavnice {get; set;}

          public DbSet<Automobil> Automobili {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

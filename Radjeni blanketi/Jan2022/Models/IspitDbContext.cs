using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

          public DbSet<Film> Filmovi {get; set;}

          public DbSet<ProdukcijskaKuca> ProdukcijskeKuce {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

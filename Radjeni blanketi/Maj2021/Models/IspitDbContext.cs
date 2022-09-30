using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

          public DbSet<Fabrika> Fabrike {get; set;}

          public DbSet<Silos>   Silosi  {get;set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

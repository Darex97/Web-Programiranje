using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

        public DbSet<Merac> Meraci {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

          public DbSet<Igrac> Igraci {get; set;}

           public DbSet<Mec> Mecevi {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

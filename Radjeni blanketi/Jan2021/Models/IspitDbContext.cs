using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...

        //  public DbSet<NESSTO> NESTO {get; set;}

        public DbSet<Grad> Gradovi {get; set;}

        public DbSet<MeteoroloskiPodaci> MeteoroloskiPodaci {get; set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

          
        }
    }
}

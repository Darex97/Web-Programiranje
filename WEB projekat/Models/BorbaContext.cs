using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class BorbaContext : DbContext
    {   // za svaku klasu
        public DbSet<Ratnik> Ratnici {get;set;}

        public DbSet<Borba> Borbe {get;set;}

        public DbSet<Galaksija> Galaksije {get; set;}

       public DbSet<Planeta> Planete {get;set;}


        public BorbaContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
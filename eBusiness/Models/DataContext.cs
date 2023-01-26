using Microsoft.EntityFrameworkCore;

namespace eBusiness.Models
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        
        public  DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
 

    }
}

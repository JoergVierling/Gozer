using Microsoft.EntityFrameworkCore;

namespace DbShelterImplementation
{
    public class ShelterContext : DbContext
    {
        public ShelterContext(DbContextOptions<ShelterContext> options)
            : base(options)
        { }

        public DbSet<Service> Service { get; set; }
    }
}

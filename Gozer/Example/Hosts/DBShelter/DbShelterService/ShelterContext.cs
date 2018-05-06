using Microsoft.EntityFrameworkCore;

namespace DbShelterService
{
    public class ShelterContext : DbContext
    {
        public ShelterContext(DbContextOptions<ShelterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Service>(config => { config.HasKey(x => x.Guid); });
        }

        public DbSet<Service> Service { get; set; }
    }
}
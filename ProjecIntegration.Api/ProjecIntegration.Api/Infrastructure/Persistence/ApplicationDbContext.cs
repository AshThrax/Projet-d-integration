using Microsoft.EntityFrameworkCore;

namespace ProjecIntegration.Api.infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base()
        { }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Complexe> Complexe { get; set; }
        public DbSet<Representation> Representations { get; set; }
        public DbSet<SalleDeTheatre> SalleDeTheatres { get; set; }
        public DbSet<Prix> Prix { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //put the configuration class inside
            base.OnModelCreating(modelBuilder);

        }
    }
}

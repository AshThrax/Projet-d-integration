using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.infrastructure.Persistence.Configuration;

namespace ProjecIntegration.Api.infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Complexe> Complexe { get; set; }
        public DbSet<Representation> Representations { get; set; }
        public DbSet<SalleDeTheatre> SalleDeTheatres { get; set; }
        public DbSet<Prix> Prix { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //put the configuration class inside
            modelBuilder.ApplyConfiguration(new CatalogueConfiguration());
            modelBuilder.ApplyConfiguration(new SalleDeTheatreConfiguration());
            modelBuilder.ApplyConfiguration(new PrixConfiguration());
            modelBuilder.ApplyConfiguration(new CommandConfiguration());
            modelBuilder.ApplyConfiguration(new ComplexeConfiguration());
            modelBuilder.ApplyConfiguration(new RepresentationConfiguration());
            modelBuilder.ApplyConfiguration(new TicketsConfiguration());
            modelBuilder.ApplyConfiguration(new EntrepriseConfiguration());
            //----------------------------end Config
            base.OnModelCreating(modelBuilder);

        }
    }
}

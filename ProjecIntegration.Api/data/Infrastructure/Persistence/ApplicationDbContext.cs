using Domain.Entity.TheatherEntity;

namespace dataInfraTheather.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Complexe> Complexe { get; set; }
        public DbSet<Representation> Representations { get; set; }
        public DbSet<SalleDeTheatre> SalleDeTheatres { get; set; }
        public DbSet<CataloguePiece> cataloguePieces { get; set; }  
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Theme> Theme {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //put the configuration class inside
            //modelBuilder.Entity<Entreprise>().HasKey();

            //modelBuilder.Entity<Complexe>()
            //.HasOne(x =>x.Entreprise)
            //.WithMany(x =>x.Complexes)
            //.HasForeignKey(x=>x.EntrepriseID).
            // OnDelete(DeleteBehavior.Restrict);


            //complexe Configuration
            modelBuilder.Entity<Complexe>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Complexe>()
                .Property(x => x.CreatedDate)
                .IsRequired(false);

            // salle Configuration
            modelBuilder.Entity<SalleDeTheatre>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<SalleDeTheatre>()
              .Property(x => x.CreatedDate)
              .IsRequired(false);
            modelBuilder.Entity<SalleDeTheatre>()
                .HasOne(x => x.Complexe)
                .WithMany(x => x.SalleDeTheatres)
                .HasForeignKey(x => x.ComplexeId)
                .OnDelete(DeleteBehavior.Restrict);

            // representation Configuration
            modelBuilder.Entity<Representation>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Representation>()
              .Property(x => x.CreatedDate)
              .IsRequired(false);

            modelBuilder.Entity<Representation>()
                .HasOne(x => x.Piece)
                .WithMany(x => x.Representations)
                .HasForeignKey(x => x.IdPiece)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Representation>()
                .HasOne(x => x.SalleDeTheatre)
                .WithMany(x => x.Representations)
                .HasForeignKey(x => x.IdSalledeTheatre)
                .OnDelete(DeleteBehavior.Restrict);
            //--piece Configuration
            modelBuilder.Entity<Piece>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Piece>()
              .Property(x => x.CreatedDate)
              .IsRequired(false);

            modelBuilder.Entity<Piece>()
                .HasOne(x => x.Theme);
            //--command Configuration
            modelBuilder.Entity<Command>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Command>()
              .Property(x => x.CreatedDate)
              .IsRequired(false);
            modelBuilder.Entity<Command>()
                .HasOne(x => x.Representation)
                .WithMany(x => x.Commands)
                .HasForeignKey(x => x.IdRepresentation)
                .OnDelete(DeleteBehavior.Restrict);
            //-----Theme
            modelBuilder.Entity<Theme>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Catalogue>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Catalogue>()
                        .HasOne(x=>x.Complexe)
                        .WithMany(x=>x.Catalogue)
                        .HasForeignKey(x=>x.ComplexeId);

            modelBuilder.Entity<CataloguePiece>()
                         .HasKey(CataloguePiece => new { CataloguePiece.PieceId, CataloguePiece.CatalogueId });

            //-----Image

            //----------------------------end Config
            base.OnModelCreating(modelBuilder);

        }
    }
}

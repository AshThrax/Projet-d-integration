using Domain.Entity.TheatherEntity;

namespace dataInfraTheather.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Command> Commands =>Set<Command>();
        public DbSet<Complexe> Complexe => Set<Complexe>();
        public DbSet<Representation> Representations => Set<Representation>();
        public DbSet<SalleDeTheatre> SalleDeTheatres => Set<SalleDeTheatre>();
        public DbSet<CataloguePiece> CataloguePiece => Set<CataloguePiece>();  
        public DbSet<Catalogue> Catalogue => Set<Catalogue>();
        public DbSet<Piece> Pieces => Set<Piece>();
        public DbSet<Theme> Theme => Set<Theme>();
        public DbSet<Siege> Siege => Set<Siege>();
        public DbSet<Image> Image => Set<Image>();
        public DbSet<Favoris> Favoris => Set<Favoris>();

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
                        .HasForeignKey(x => x.PieceId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Representation>()
                        .HasOne(x => x.SalleDeTheatre)
                        .WithMany(x => x.Representations)
                        .HasForeignKey(x => x.SalledeTheatreId)
                        .OnDelete(DeleteBehavior.Restrict);

            //--piece Configuration
            modelBuilder.Entity<Piece>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Piece>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);

            modelBuilder.Entity<Piece>()
                        .HasOne(x => x.Theme);

            modelBuilder.Entity<Piece>()
                        .HasOne(x => x.Image)
                        .WithMany()
                        .HasForeignKey(x=>x.ImageId)
                        .IsRequired(false);
                         

            //----command Configuration
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
            modelBuilder.Entity<Image>()
                      .Property(x => x.CreatedDate)
                      .IsRequired(false);

            modelBuilder.Entity<Image>()
                        .HasKey(x => x.Id);
            modelBuilder.Entity<Image>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);
            //-----Catalogue
            modelBuilder.Entity<Catalogue>()
                        .HasKey(x => x.Id);
            modelBuilder.Entity<Catalogue>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);
            modelBuilder.Entity<Catalogue>()
                        .HasOne(x=>x.Complexe)
                        .WithMany(x=>x.Catalogue)
                        .HasForeignKey(x=>x.ComplexeId);
            //------CataloguePiece----------------------

            modelBuilder.Entity<CataloguePiece>()
                         .HasKey(x=>x.Id);

            modelBuilder.Entity<CataloguePiece>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);

            modelBuilder.Entity<CataloguePiece>().HasOne(x =>x.Piece)
                                                 .WithMany()
                                                 .HasForeignKey(x=>x.PieceId);

            modelBuilder.Entity<CataloguePiece>().HasOne(c => c.Catalogue)
                                                .WithMany()
                                                .HasForeignKey(x => x.CatalogueId);
            //-----Siege

            modelBuilder.Entity<Siege>().HasKey(x => x.Id);

            modelBuilder.Entity<Siege>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);

            modelBuilder.Entity<Siege>()
                        .HasOne(x=>x.SalleDeTheatre)
                        .WithMany(x=>x.sieges)
                        .HasForeignKey(x=>x.SalleId)
                        .OnDelete(DeleteBehavior.NoAction);

            //-------SiegeCommand

            modelBuilder.Entity<SiegeCommand>().HasKey(x => new { x.SiegeId,x.CommandId });

            modelBuilder.Entity<SiegeCommand>()
                        .Property(x => x.CreatedDate)
                        .IsRequired(false);

            modelBuilder.Entity<SiegeCommand>().HasOne(x=>x.Siege).WithMany()
                                               .HasForeignKey(x=>x.SiegeId);

            modelBuilder.Entity<SiegeCommand>().HasOne(x => x.Command).WithMany()
                                              .HasForeignKey(x => x.CommandId);

            //-----------image

            //----------------------------end Config
            //----------------------Favorites--------------
            modelBuilder.Entity<Favoris>()
                        .HasKey(c => c.Id);
            
            base.OnModelCreating(modelBuilder);

        }
    }
}

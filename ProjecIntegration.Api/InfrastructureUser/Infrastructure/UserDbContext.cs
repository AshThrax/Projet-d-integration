using Domain.Entity.PublicationEntity.Modération;
using Domain.Entity.UserEntity;
using Domain.Entity.UserEntity.FeedBack;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureUser.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> option): base(option) 
        { 
        }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Feedback> FeedBacks { get; set; }
        public DbSet<SignalementType> signalementTypes { get; set; }
        public DbSet<Signalement> Signalements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //----------------------Follows----------------
            modelBuilder.Entity<Follow>()
                        .HasKey(Follow => new { Follow.FollowerId, Follow.FollowId });
           //----------------------Banner------------
           modelBuilder.Entity<Banner>().HasKey(x=>x.Id);

  

           //----------------------Feedbacks-------------
            modelBuilder.Entity<Feedback>()
                        .HasKey(c => c.Id);
            //---------------------Signalement-----------
            modelBuilder.Entity<Signalement>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Signalement>()
                .HasOne(x => x.SignalementType)
                .WithMany()
                .HasForeignKey(c => c.SignalementTypeId);
            //---------------------SignalementType-------
            modelBuilder.Entity<SignalementType>().HasKey(c => c.Id);
        }
    }
}

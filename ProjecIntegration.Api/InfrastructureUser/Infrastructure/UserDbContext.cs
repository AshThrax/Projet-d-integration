using Domain.Entity.PublicationEntity.Modération;
using Domain.Entity.UserEntity;
using Domain.Entity.UserEntity.FeedBack;
using Domain.Entity.UserEntity.UserDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> option): base(option) 
        { 
        }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Favorit> Favorits { get; set; }
        public DbSet<Feedback> FeedBacks { get; set; }
        public DbSet<SignalementType> signalementTypes { get; set; }
        public DbSet<Signalement> Signalements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //----------------------Follows----------------
            modelBuilder.Entity<Follow>()
                        .HasKey(Follow => new { Follow.FollowerId, Follow.FollwedId });
           //----------------------UserDetails------------
            modelBuilder.Entity<UserDetails>()
                        .HasKey(c=>c.Id);
           //----------------------Favorites--------------
            modelBuilder.Entity<Favorit>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Favorit>()
                        .HasOne(x => x.UserDetail)
                        .WithOne(cd => cd.Favoris)
                        .HasForeignKey<Favorit>(xc => xc.UserDetailId);
           //----------------------Feedbacks-------------
            modelBuilder.Entity<Feedback>()
                        .HasKey(c => c.Id);
            //---------------------Signalement-----------
            modelBuilder.Entity<Signalement>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Signalement>()
                        .HasOne(c => c.UserDetails)
                        .WithMany(x => x.HasSignalements);
        
            //---------------------SignalementType-------
            modelBuilder.Entity<SignalementType>().HasKey(c => c.Id);
        }
    }
}

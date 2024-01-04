using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class RepresentationConfiguration : IEntityTypeConfiguration<Representation>
    {
        public void Configure(EntityTypeBuilder<Representation> builder)
        {
            builder.HasKey(e => e.Id);
            //----salle de theatre foereignKey
            builder.HasOne(e => e.SalleDeTheatre)
                .WithMany(e => e.representations)
                 .HasForeignKey(e => e.IdSalledeTheatre);
            //-----
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

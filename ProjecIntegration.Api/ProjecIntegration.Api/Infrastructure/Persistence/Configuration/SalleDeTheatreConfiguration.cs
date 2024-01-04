using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class SalleDeTheatreConfiguration : IEntityTypeConfiguration<SalleDeTheatre>
    {
        public void Configure(EntityTypeBuilder<SalleDeTheatre> builder)
        {
            builder.HasKey(e => e.Id);
            //-----
            builder.HasOne(e => e.Complexe)
                .WithMany(e =>e.SalleDeTheatres)
                .HasForeignKey(e => e.Complexe.Id);

            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

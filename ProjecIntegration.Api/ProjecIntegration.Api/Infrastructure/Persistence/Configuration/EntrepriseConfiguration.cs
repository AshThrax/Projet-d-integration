using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class EntrepriseConfiguration : IEntityTypeConfiguration<Entreprise>
    {
        public void Configure(EntityTypeBuilder<Entreprise> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

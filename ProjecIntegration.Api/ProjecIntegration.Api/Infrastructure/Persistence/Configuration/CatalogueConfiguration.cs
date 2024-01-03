using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class CatalogueConfiguration : IEntityTypeConfiguration<Catalogue>
    {
        public void Configure(EntityTypeBuilder<Catalogue> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

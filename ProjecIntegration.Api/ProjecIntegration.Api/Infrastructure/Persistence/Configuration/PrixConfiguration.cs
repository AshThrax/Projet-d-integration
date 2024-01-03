using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class PrixConfiguration : IEntityTypeConfiguration<Prix>
    {
        public void Configure(EntityTypeBuilder<Prix> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

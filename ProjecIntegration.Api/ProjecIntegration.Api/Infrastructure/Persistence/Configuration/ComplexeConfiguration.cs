using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class ComplexeConfiguration : IEntityTypeConfiguration<Complexe>
    {
        public void Configure(EntityTypeBuilder<Complexe> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

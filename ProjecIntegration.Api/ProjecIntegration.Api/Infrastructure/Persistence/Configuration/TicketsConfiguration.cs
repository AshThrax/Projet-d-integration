using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class TicketsConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

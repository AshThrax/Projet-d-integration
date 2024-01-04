using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class TicketsConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);
            //---foreignkey command
            builder.HasOne(e =>e.Command)
                .WithMany(c =>c.Tickets)
                .HasForeignKey(e => e.Id);
            //---foereignKey prix
            builder.HasOne(e => e.Prix)
                .WithOne()
                .HasForeignKey<Ticket>(e => e.IdPrix);

            //---
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

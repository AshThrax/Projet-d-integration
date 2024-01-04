using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjecIntegration.Api.infrastructure.Persistence.Configuration
{
    public class CatalogueConfiguration : IEntityTypeConfiguration<Catalogue>
    {
        public void Configure(EntityTypeBuilder<Catalogue> builder)
        {
            //-----PrimaryKeys
            builder.HasKey(e => e.Id);
            //-----foreignKeys
            builder.HasOne(e=>e.Complexe)
                .WithMany(e=> e.Catalogues)
                .HasForeignKey(e=> e.ComplexeId);
            //----property
            builder.Property(t => t.AddedTime)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}

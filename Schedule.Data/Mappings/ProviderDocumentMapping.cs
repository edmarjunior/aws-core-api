using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class ProviderDocumentMapping : IEntityTypeConfiguration<ProviderDocument>
    {
        public void Configure(EntityTypeBuilder<ProviderDocument> builder)
        {
            builder.ToTable("ProvidersDocuments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(80).IsRequired();
            builder.Property(x => x.ProviderId).IsRequired();
            builder.HasAlternateKey(x => new { x.Name, x.ProviderId });
        }
    }
}

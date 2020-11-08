using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class ProviderPhoneMapping : IEntityTypeConfiguration<ProviderPhone>
    {
        public void Configure(EntityTypeBuilder<ProviderPhone> builder)
        {
            builder.ToTable("ProvidersPhones");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.PhoneId, x.ProviderId });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class ClientPhoneMapping : IEntityTypeConfiguration<ClientPhone>
    {
        public void Configure(EntityTypeBuilder<ClientPhone> builder)
        {
            builder.ToTable("ClientsPhones");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.PhoneId, x.ClientId });
        }
    }
}

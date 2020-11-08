using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.HasIndex(x => x.Name).HasName("idx_client_name");

            //builder
            //    .HasMany(x => x.Phones)
            //    .WithOne(x => x.Client)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            // .HasMany(x => x.Appointments)
            // .WithOne(x => x.Client)
            // .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

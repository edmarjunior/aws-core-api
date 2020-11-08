using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class ProviderMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.HasIndex(x => x.Name).HasName("idx_provider_name");

            //builder
            //    .HasMany(x => x.Phones)
            //    .WithOne(x => x.Provider)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            // .HasMany(x => x.Appointments)
            // .WithOne(x => x.Provider)
            // .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

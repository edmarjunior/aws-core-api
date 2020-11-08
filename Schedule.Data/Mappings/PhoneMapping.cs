using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phones");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number).HasColumnType("CHAR(11)").IsRequired();
            builder.HasIndex(x => x.Number).HasName("idx_phone_number");
        }
    }
}

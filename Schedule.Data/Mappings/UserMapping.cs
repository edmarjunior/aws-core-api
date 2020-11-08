using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR(100)").IsRequired();

            builder.HasAlternateKey(x => x.Email);
            builder.HasIndex(x => x.Name).HasName("idx_user_name");
            builder.HasIndex(x => x.Email).HasName("idx_user_email");
        }
    }
}

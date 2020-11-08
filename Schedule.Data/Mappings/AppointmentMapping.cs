using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Business.Models;

namespace Schedule.Data.Mappings
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.InitialDate).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired(false);
            builder.Property(x => x.CreatedUserId).IsRequired();
        }
    }
}

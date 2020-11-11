using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Schedule.Business.Models;

namespace Schedule.Data
{
    public class ApplicationContext: DbContext
    {
        public static readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Schedule.Business.Helpers;
using Schedule.Business.Interfaces.Repositories;
using Schedule.Business.Interfaces.Services;
using Schedule.Business.Services;
using Schedule.Data.Repositories;

namespace Schedule.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Notification>();

            // services
            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IProviderDocumentService, ProviderDocumentService>();

            // repositories
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IProviderDocumentRepository, ProviderDocumentRepository>();

            return services;
        }
    }
}


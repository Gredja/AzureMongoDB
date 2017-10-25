using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzureMongoDB.Services.Providers
{
    public static class DbProvider
    {
        public static void AddDbService(this IServiceCollection services)
        {
            services.AddTransient<IDbRepository, DbRepository>();
        }
    }
}

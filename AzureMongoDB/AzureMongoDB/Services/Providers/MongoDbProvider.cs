using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzureMongoDB.Services.Providers
{
    public static class MongoDbProvider
    {
        public static void AddMongoDbService(this IServiceCollection services)
        {
            services.AddTransient<IMongoDbRepository, MongoDbRepository>();
        }
    }
}

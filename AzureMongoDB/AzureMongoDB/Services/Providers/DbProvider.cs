using AzureMongoDB.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzureMongoDB.Services.Providers
{
    public static class DebtorDbProvider
    {
        public static void AddDebtorDbService(this IServiceCollection services)
        {
            services.AddTransient<IDebtorDbRepository, DebtorDbRepository>();
        }
    }
}

using Customers.Data.Repositories;
using Customers.Data.Repositories.Interfaces;

namespace Customers.Data
{
    public static class ConfigureServices
    {
        public static MauiAppBuilder AddData(this MauiAppBuilder builder, string dbPath)
        {
            builder.Services.AddSingleton<ICustomerRepository>(s => ActivatorUtilities.CreateInstance<CustomerRepository>(s, dbPath));
            return builder;
        }
    }
}
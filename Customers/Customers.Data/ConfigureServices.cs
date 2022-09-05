using Customers.Data.Repositories;
using Customers.Data.Repositories.Interfaces;
using SQLite;

namespace Customers.Data
{
    public static class ConfigureServices
    {
        public static MauiAppBuilder AddData(this MauiAppBuilder builder, string dbPath)
        {
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<SQLiteConnection>(s, dbPath));
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            return builder;
        }
    }
}
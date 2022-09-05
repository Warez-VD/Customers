using Customers.Data.Entities;
using SQLite;

namespace Customers.Tests.Base
{
    public class DatabaseFixture : SQLiteConnection
    {
        public DatabaseFixture(string dbPath)
            : base(dbPath)
        {
            CreateTable<Customer>();
        }
    }
}

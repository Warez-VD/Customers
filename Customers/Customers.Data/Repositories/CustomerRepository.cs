using Customers.Data.Entities;
using Customers.Data.Repositories.Interfaces;
using SQLite;

namespace Customers.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SQLiteConnection _connection;

        public CustomerRepository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Customer>();
        }

        public IList<Customer> GetAll()
        {
            var customers = _connection.Table<Customer>().ToList();
            return customers;
        }

        public Customer Create(Customer customer)
        {
            _connection.Insert(customer);
            return customer;
        }
    }
}

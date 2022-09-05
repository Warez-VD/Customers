using Customers.Data.Entities;
using Customers.Data.Repositories.Interfaces;
using SQLite;

namespace Customers.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SQLiteConnection _connection;

        public CustomerRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Customer>();
        }

        public Customer Get(int id)
        {
            var customer = _connection.Find<Customer>(id);
            return customer;
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

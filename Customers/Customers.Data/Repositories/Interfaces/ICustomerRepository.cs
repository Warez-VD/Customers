using Customers.Data.Entities;

namespace Customers.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer Get(int id);

        IList<Customer> GetAll();

        Customer Create(Customer customer);
    }
}

using Customers.Data.Entities;

namespace Customers.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAll();

        Customer Create(Customer customer);
    }
}

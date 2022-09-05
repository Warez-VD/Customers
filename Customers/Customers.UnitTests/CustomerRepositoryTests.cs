using Customers.Data.Entities;
using Customers.Data.Repositories;
using Customers.Tests.Base;

namespace Customers.Tests
{
    public class CustomerRepositoryTests
    {
        private string _dbPath;

        public CustomerRepositoryTests()
        {
            _dbPath = Path.Combine(Environment.CurrentDirectory, "CustomersTest.db3");
        }

        [Fact]
        public void GetAll_Called_ReturnAllCustomers()
        {
            var db = new DatabaseFixture(_dbPath);
            InsertCustomers(db);
            var repo = new CustomerRepository(db);

            var customers = repo.GetAll();

            Assert.NotNull(customers);
            Assert.NotEmpty(customers);
            Assert.Equal(2, customers.Count());

            db.DropTable<Customer>();
            db.Close();
        }

        [Fact]
        public void Create_Called_InsertNewRecord()
        {
            var expectedName = "SampleName";
            var expectedPhoneNumber = "0887323344";
            var db = new DatabaseFixture(_dbPath);
            var repo = new CustomerRepository(db);
            var customer = new Customer()
            {
                Name = expectedName,
                PhoneNumber = expectedPhoneNumber
            };

            var createdCustomer = repo.Create(customer);

            Assert.NotNull(createdCustomer);
            Assert.True(createdCustomer.Id > 0);
            Assert.Equal(expectedName, createdCustomer.Name);
            Assert.Equal(expectedPhoneNumber, createdCustomer.PhoneNumber);

            db.DropTable<Customer>();
            db.Close();
        }

        [Fact]
        public void Get_Called_ReturnExpectedCustomer()
        {
            var db = new DatabaseFixture(_dbPath);
            var expectedName = "SampleName";
            var expectedPhoneNumber = "0887323344";
            var customer = new Customer()
            {
                Name = expectedName,
                PhoneNumber = expectedPhoneNumber
            };
            var repo = new CustomerRepository(db);
            repo.Create(customer);

            var actualCustomer = repo.Get(customer.Id);

            Assert.NotNull(actualCustomer);
            Assert.Equal(customer.Id, actualCustomer.Id);
            Assert.Equal(expectedName, actualCustomer.Name);
            Assert.Equal(expectedPhoneNumber, actualCustomer.PhoneNumber);

            db.DropTable<Customer>();
            db.Close();
        }

        private void InsertCustomers(DatabaseFixture db)
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Test1",
                    PhoneNumber = "0887263176"
                },
                new Customer()
                {
                    Name = "Test2",
                    PhoneNumber = "0882263176"
                }
            };
            foreach (var customer in customers)
            {
                db.Insert(customer);
            }
        }
    }
}
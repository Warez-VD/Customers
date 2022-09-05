using SQLite;

namespace Customers.Data.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}

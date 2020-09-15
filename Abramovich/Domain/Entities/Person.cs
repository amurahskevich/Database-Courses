using System.Collections.Generic;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Order> Orders { get; set; }
    }
}

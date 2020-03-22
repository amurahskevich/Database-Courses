using System.Collections.Generic;

namespace Data.Contracts.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public int? RateId { get; set; }

        public Rate Rate { get; set; }

        public ICollection<Bonus> Bonuses { get; set; }

        public ICollection<HobbyClient> Hobbies { get; set; }
    }
}

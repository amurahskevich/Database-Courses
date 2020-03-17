using System.Collections.Generic;

namespace Data.Contracts.Entities
{
    public class Hobby
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<HobbyClient> Clients { get; set; }
    }
}

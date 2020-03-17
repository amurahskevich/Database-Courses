using System.Collections.Generic;

namespace Data.Contracts.Entities
{
    public class Rate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Call Call { get; set; }

        public Sms Sms { get; set; }

        public Internet Internet { get; set; }

        public Roaming Roaming { get; set; }

        public HomeInternet HomeInternet { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}

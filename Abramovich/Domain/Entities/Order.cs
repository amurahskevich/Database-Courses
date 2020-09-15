using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public bool InProgress { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public IList<BookOrder> BookOrders { get; set; }
    }
}

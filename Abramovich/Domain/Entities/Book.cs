using System.Collections.Generic;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public IList<BookOrder> BookOrders { get; set; }
    }
}

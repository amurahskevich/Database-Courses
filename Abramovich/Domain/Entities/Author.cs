using System.Collections.Generic;

namespace Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}

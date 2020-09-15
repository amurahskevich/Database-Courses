namespace Domain.Entities
{
    public class BookOrder
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}

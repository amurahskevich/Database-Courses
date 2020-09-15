using Domain.Entities;
using Domain.EntityFramework;

namespace Domain.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public void CreateBookOrder(BookOrder bookOrder)
        {
            this.context.BookOrders.Add(bookOrder);
            this.context.SaveChanges();
        }
    }
}

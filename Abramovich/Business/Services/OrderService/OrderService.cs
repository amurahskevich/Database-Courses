using Domain;
using Domain.Entities;
using Domain.EntityFramework;

namespace Business.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;

        public OrderService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public void CreateOrder(int bookId, int studentId)
        {
            var order = new Order()
            {
                PersonId = bookId,
            };
            unitOfWork.Orders.Create(order);

            var bookOrder = new BookOrder
            {
                BookId = bookId,
                OrderId = order.Id,
            };
            unitOfWork.Orders.CreateBookOrder(bookOrder);
        }
    }
}

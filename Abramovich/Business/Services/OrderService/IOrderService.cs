namespace Business.Services.OrderService
{
    public interface IOrderService
    {
        void CreateOrder(int bookId, int studentId);
    }
}

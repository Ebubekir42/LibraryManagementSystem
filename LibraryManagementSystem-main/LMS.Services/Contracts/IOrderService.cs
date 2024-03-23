using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> GetAllOrders(bool trackChanges);
        Order? GetOrder(int id, bool trackChanges);
        void CreateOrder(Order order);
        void BuyOrder(int orderId, string kuryeId);
        void DeliverOrder(int orderId);

    }
}

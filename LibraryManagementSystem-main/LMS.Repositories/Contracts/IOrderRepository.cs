using LMS.Entities.Models;
namespace LMS.Repositories.Contracts
{
    public interface IOrderRepository : IRepostioryBase<Order>
    {
        IQueryable<Order> GetAllOrders(bool trackChanges);
        Order? GetOrder(int id,bool trackChanges);
        void CreateOrder(Order order);
    }
}

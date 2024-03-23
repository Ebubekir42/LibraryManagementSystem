using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> GetAllOrders(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Order? GetOrder(int id, bool trackChanges)
        {
            return FindByCondition(b => b.OrderId.Equals(id),trackChanges);
        }
        public void CreateOrder(Order order) => Create(order);
    }
}

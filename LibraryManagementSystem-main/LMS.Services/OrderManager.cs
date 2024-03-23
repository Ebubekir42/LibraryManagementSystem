using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;
        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IQueryable<Order> GetAllOrders(bool trackChanges)
        {
            return _manager.Order.GetAllOrders(trackChanges);
        }

        public Order? GetOrder(int id, bool trackChanges)
        {
            return _manager.Order.GetOrder(id, trackChanges);
        }
        public void CreateOrder(Order order)
        {
            _manager.Order.CreateOrder(order);
            _manager.Save();
        }
        public void BuyOrder(int orderId, string kuryeId)
        {
            var order = _manager.Order.GetOrder(orderId, true);
            order.ApplicationUserId = kuryeId;
            _manager.Save();
        }
        public void DeliverOrder(int orderId)
        {
            var order = _manager.Order.GetOrder(orderId, true);
            order.IsDeliver = true;
            var loan = _manager.Loan.GetLoan(order.LoanId, true);
            loan.LoanDate = DateTime.Now.ToString("dd/MM/yyyy");
            loan.LastReturnDate = DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
            _manager.Save();
        }
    }
}

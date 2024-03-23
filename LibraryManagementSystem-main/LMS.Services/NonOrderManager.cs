using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Models;

namespace LMS.Services
{
    public class NonOrderManager : INonOrderService
    {
        private readonly IRepositoryManager _manager;
        public NonOrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IQueryable<NonOrder> GetAllNonOrders(bool trackChanges)
        {
            return _manager.NonOrder.GetAllNonOrders(trackChanges);
        }

        public NonOrder GetNonOrder(int id, bool trackChanges)
        {
            return _manager.NonOrder.GetNonOrder(id, trackChanges);
        }
        public void CreateNonOrder(NonOrder nonOrder)
        {
            _manager.NonOrder.CreateNonOrder(nonOrder);
            _manager.Save();
        }
        public void DeliverOrder(int orderId, ApplicationUser per)
        {
            var order = _manager.NonOrder.GetNonOrder(orderId, true);
            order.IsDeliver = true;
            order.ApplicationUserId = per.Id;
            var loan = _manager.Loan.GetLoan(order.LoanId, true);
            loan.LoanDate = DateTime.Now.ToString("dd/MM/yyyy");
            loan.LastReturnDate = DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
            _manager.Save();
        }
        public void BuyOrder(int orderId, ApplicationUser per)
        {
            var order = GetNonOrder(orderId, true);
            order.ApplicationUserId = per.Id;
            _manager.Save();
        }
    }
}

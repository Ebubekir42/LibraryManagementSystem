using LMS.Entities.Models;
namespace LMS.Services.Contracts
{
    public interface INonOrderService
    {
        NonOrder GetNonOrder(int id,bool trackChanges);
        IQueryable<NonOrder> GetAllNonOrders(bool trackChanges);
        void CreateNonOrder(NonOrder nonOrder);
        void DeliverOrder(int orderId,ApplicationUser per);
        void BuyOrder(int orderId, ApplicationUser per);
    }
}

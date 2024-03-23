using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface INonOrderRepository : IRepostioryBase<NonOrder>
    {
        NonOrder GetNonOrder(int id,bool trackChanges);
        IQueryable<NonOrder> GetAllNonOrders(bool trackChanges);
        void CreateNonOrder(NonOrder nonOrder);
    }
}

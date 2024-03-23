using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class NonOrderRepository : RepositoryBase<NonOrder>, INonOrderRepository
    {
        public NonOrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<NonOrder> GetAllNonOrders(bool trackChanges) => FindAll(trackChanges);

        public NonOrder GetNonOrder(int id, bool trackChanges)
        {
            return FindByCondition(n => n.NonOrderId.Equals(id), trackChanges);
        }
        public void CreateNonOrder(NonOrder nonOrder) => Create(nonOrder);
    }
}

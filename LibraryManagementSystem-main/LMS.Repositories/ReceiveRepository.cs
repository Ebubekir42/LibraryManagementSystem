using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class ReceiveRepository : RepositoryBase<Receive>, IReceiveRepository
    {
        public ReceiveRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Receive> GetAllReceives(bool trackChanges) => FindAll(trackChanges);

        public Receive GetReceive(int id, bool trackChanges)
        {
            return FindByCondition(r => r.ReceiveId.Equals(id), trackChanges);
        }
        public void CreateReceive(Receive receive) => Create(receive);
    }
}

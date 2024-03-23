using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IReceiveRepository : IRepostioryBase<Receive>
    {
        Receive GetReceive(int id,bool trackChanges);
        IQueryable<Receive> GetAllReceives(bool trackChanges);
        void CreateReceive(Receive receive);
    }
}

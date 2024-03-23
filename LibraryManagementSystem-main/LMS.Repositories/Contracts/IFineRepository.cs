using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IFineRepository : IRepostioryBase<Fine>
    {
        Fine? GetFine(string id,bool trackChanges);
        IQueryable<Fine> GetAllFines(bool trackChanges);
        void CreateFine(Fine fine);
        void UpdateFine(Fine fine);
        void DeleteFine(Fine fine);
        void AddQuantity(string userId, int quantity);

    }
}

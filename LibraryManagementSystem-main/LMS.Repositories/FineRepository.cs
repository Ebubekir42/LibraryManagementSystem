using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class FineRepository : RepositoryBase<Fine>, IFineRepository
    {
        public FineRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateFine(Fine fine) => Create(fine);

        public void DeleteFine(Fine fine) => Remove(fine);

        public IQueryable<Fine> GetAllFines(bool trackChanges) => FindAll(trackChanges);

        public Fine? GetFine(string userId, bool trackChanges)
        {
            return FindByCondition(f => f.ApplicationUserId.Equals(userId), trackChanges);
        }
        public void AddQuantity(string userId, int quantity)
        {
            var fine = GetFine(userId, true);
            fine.Quantity += quantity;

        }
        public void UpdateFine(Fine fine) => Update(fine);
    }
}

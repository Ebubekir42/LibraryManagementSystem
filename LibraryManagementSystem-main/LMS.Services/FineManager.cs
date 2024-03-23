using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class FineManager : IFineService
    {
        private readonly IRepositoryManager _manager;
        public FineManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateFine(Fine fine)
        {
            _manager.Fine.CreateFine(fine);
            _manager.Save();
        }

        public void DeleteFine(Fine fine)
        {
            _manager.Fine.DeleteFine(fine);
            _manager.Save();
        }

        public IEnumerable<Fine> GetAllFines(bool trackChanges)
        {
            return _manager.Fine.GetAllFines(trackChanges);
        }

        public Fine? GetFine(string userId, bool trackChanges)
        {
            return _manager.Fine.GetFine(userId, trackChanges);
        }

        public void UpdateFine(Fine fine)
        {
            _manager.Fine.UpdateFine(fine);
            _manager.Save();
        }
        public void AddQuantity(string userId,int quantity)
        {
            var fine = _manager.Fine.GetFine(userId,true);
            fine.Quantity += quantity;
            _manager.Save();
        }

    }
}

using LMS.Entities.Models;
namespace LMS.Services.Contracts
{
    public interface IFineService
    {
        Fine GetFine(string id,bool trackChanges);
        IEnumerable<Fine> GetAllFines(bool trackChanges);
        void CreateFine(Fine fine);
        void UpdateFine(Fine fine);
        void DeleteFine(Fine fine);
        void AddQuantity(string userId, int quantity);


    }
}

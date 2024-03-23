using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface ICarrierTypeRepository : IRepostioryBase<CarrierType>
    {
        IQueryable<CarrierType> GetAllCarrierTypes(bool trackChanges);
        CarrierType GetCarrierType(int id, bool trackChanges);
    }
}

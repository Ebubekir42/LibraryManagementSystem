using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface ICarrierTypeService
    {
        IEnumerable<CarrierType> GetAllCarrierTypes(bool trackChanges);
        CarrierType GetCarrierType(int id, bool trackChanges);
    }
}

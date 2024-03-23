using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class CarrierTypeManager : ICarrierTypeService
    {
        private readonly IRepositoryManager _manager;
        public CarrierTypeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IEnumerable<CarrierType> GetAllCarrierTypes(bool trackChanges)
        {
            return _manager.CarrierType.GetAllCarrierTypes(trackChanges);
        }
        public CarrierType GetCarrierType(int id,bool trackChanges)
        {
            return _manager.CarrierType.GetCarrierType(id,trackChanges);
        }
    }
}

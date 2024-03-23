using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class DistrictManager : IDistrictService
    {
        private readonly IRepositoryManager _manager;
        public DistrictManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IQueryable<District> GetAllDistricts(bool trackChanges)
        {
            return _manager.District.GetAllDistricts(trackChanges);
        }

        public District? GetDistrict(int id, bool trackChanges)
        {
            return _manager.District.GetDistrict(id, trackChanges);
        }
    }
}

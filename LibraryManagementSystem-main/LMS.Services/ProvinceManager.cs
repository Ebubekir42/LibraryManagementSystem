using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class ProvinceManager : IProvinceService
    {
        private readonly IRepositoryManager _manager;
        public ProvinceManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IQueryable<Province> GetAllProvinces(bool trackChanges)
        {
            return _manager.Province.GetAllProvinces(trackChanges);
        }

        public Province? GetProvince(int id, bool trackChanges)
        {
            return _manager.Province.GetProvince(id, trackChanges);
        }
    }
}

using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IDistrictRepository : IRepostioryBase<District>
    {
        IQueryable<District> GetAllDistricts(bool trackChanges);
        District? GetDistrict(int id, bool trackChanges);
    }
}

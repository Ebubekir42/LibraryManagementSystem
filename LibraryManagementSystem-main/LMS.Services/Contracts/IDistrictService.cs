using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IDistrictService
    {
        IQueryable<District> GetAllDistricts(bool trackChanges);
        District? GetDistrict(int id, bool trackChanges);
    }
}

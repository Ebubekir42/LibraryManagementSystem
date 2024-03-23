using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IProvinceService
    {
        IQueryable<Province> GetAllProvinces(bool trackChanges);
        Province? GetProvince(int id, bool trackChanges);
    }
}

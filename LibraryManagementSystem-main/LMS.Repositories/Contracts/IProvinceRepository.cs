using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface IProvinceRepository : IRepostioryBase<Province>
    {
        IQueryable<Province> GetAllProvinces(bool trackChanges);
        Province? GetProvince(int id,bool trackChanges);
    }
}

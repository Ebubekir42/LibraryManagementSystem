using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Province> GetAllProvinces(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Province? GetProvince(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProvinceId.Equals(id), trackChanges);
        }
    }
}

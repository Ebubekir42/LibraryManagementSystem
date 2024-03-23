using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<District> GetAllDistricts(bool trackChanges) => FindAll(trackChanges);

        public District? GetDistrict(int id, bool trackChanges)
        {
            return FindByCondition(d => d.DistrictId.Equals(id), trackChanges);
        }
    }
}

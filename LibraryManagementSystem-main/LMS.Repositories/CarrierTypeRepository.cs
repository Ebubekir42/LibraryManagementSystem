using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class CarrierTypeRepository : RepositoryBase<CarrierType>, ICarrierTypeRepository
    {
        public CarrierTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<CarrierType> GetAllCarrierTypes(bool trackChanges) => FindAll(trackChanges);
        public CarrierType GetCarrierType(int id, bool trackChanges)
        {
            return FindByCondition(x => x.CarrierTypeId.Equals(id), trackChanges);
        }
    }
}

using System.Linq.Expressions;

namespace LMS.Repositories.Contracts
{
    public interface IRepostioryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}

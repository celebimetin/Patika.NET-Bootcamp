using Core.Model;
using System.Linq.Expressions;

namespace Data.Repository.Base
{
    public interface IRepository<T> : IQuery<T> where T : IEntity
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        List<T> GetList();
        Task<IEnumerable<T>> GetListAsync();
        IEnumerable<T> GetAllWithInclude(params string[] includes);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IEnumerable<T> WhereWithInclude(Expression<Func<T, bool>> expression, params string[] includes);
        T GetByIdWithInclude(int id, params string[] includes);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        Task<T> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        T Remove(T entity);
        T RemoveRange(T entity);
        T DeleteById(int id);
    }
}
using Core.Model;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository.Base
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext context;

        public EfRepositoryBase(AppDbContext context)
        {
            this.context = context;
        }

        public TEntity Get(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            return entity;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public List<TEntity> GetList()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            return (TEntity)entities;
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public TEntity RemoveRange(TEntity entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return entity;
        }

        public TEntity DeleteById(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IEnumerable<TEntity> GetAllWithInclude(params string[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }

        public IEnumerable<TEntity> WhereWithInclude(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();
            query.Where(expression);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }

        public TEntity GetByIdWithInclude(int id, params string[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.FirstOrDefault(x => x.Id == id);
        }
    }
}
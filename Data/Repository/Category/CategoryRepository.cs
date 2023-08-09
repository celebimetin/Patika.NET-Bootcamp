using Data.Context;
using Data.Domain;
using Data.Repository.Base;

namespace Data.Repository;

public class CategoryRepository : EfRepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
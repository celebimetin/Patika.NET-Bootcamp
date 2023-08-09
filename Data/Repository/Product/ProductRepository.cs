using Data.Context;
using Data.Domain;
using Data.Repository.Base;

namespace Data.Repository;

public class ProductRepository : EfRepositoryBase<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
using Core.Model;
using Data.Context;
using Data.Repository;
using Data.Repository.Base;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private bool disposed;

        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IDigitalWalletRepository DigitalWalletRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;

            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context);
            DigitalWalletRepository = new DigitalWalletRepository(context);
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new EfRepositoryBase<T>(context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && context is not null)
                {
                    context.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }
    }
}
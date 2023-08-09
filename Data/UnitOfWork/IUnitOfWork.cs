using Core.Model;
using Data.Repository;
using Data.Repository.Base;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IDigitalWalletRepository DigitalWalletRepository { get; }
        IRepository<T> Repository<T>() where T : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
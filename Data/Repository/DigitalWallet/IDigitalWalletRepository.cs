using Core.SharedLibrary.Dtos;
using Data.Domain;
using Data.Repository.Base;

namespace Data.Repository;

public interface IDigitalWalletRepository : IRepository<DigitalWallet>
{
    DigitalWallet GetBalance(string userId);
    Response<DigitalWallet> AddFunds(DigitalWallet digitalWallet);
    void RemoveFunds(string userId, decimal amount);
}
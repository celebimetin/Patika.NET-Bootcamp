using Core.SharedLibrary.Dtos;
using Data.Domain;

namespace Operation;

public interface IDigitalWalletService
{
    Response<DigitalWallet> GetBalance(string userId);
    Response<DigitalWallet> AddFunds(DigitalWallet digitalWallet);
    Response<NoDataDto> RemoveFunds(string userId, decimal amount);
}
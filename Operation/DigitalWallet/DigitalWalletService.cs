using Core.SharedLibrary.Dtos;
using Data.Domain;
using Data.UnitOfWork;

namespace Operation;

public class DigitalWalletService : IDigitalWalletService
{
    private readonly IUnitOfWork unitOfWork;

    public DigitalWalletService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Response<DigitalWallet> GetBalance(string userId)
    {
        var result = unitOfWork.DigitalWalletRepository.GetBalance(userId);
        if (result == null) { return Response<DigitalWallet>.Fail($"{userId} not found", 404, true); }
        return Response<DigitalWallet>.Success(result, 200);
    }

    public Response<DigitalWallet> AddFunds(DigitalWallet digitalWallet)
    {
        var result = unitOfWork.DigitalWalletRepository.AddFunds(digitalWallet);
        return result;
    }

    public Response<NoDataDto> RemoveFunds(string userId, decimal amount)
    {
        var result = unitOfWork.DigitalWalletRepository.GetBalance(userId);
        if (result == null) { return Response<NoDataDto>.Fail($"{userId} not found", 404, true); }
        if (result.Balance >= amount)
        {
            unitOfWork.DigitalWalletRepository.RemoveFunds(userId, amount);
            return Response<NoDataDto>.Success(200);
        }
        return Response<NoDataDto>.Fail("Insufficient balance", 400, true);
    }
}
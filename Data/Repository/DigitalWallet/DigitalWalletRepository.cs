using Core.SharedLibrary.Dtos;
using Data.Context;
using Data.Domain;
using Data.Repository.Base;

namespace Data.Repository;

public class DigitalWalletRepository : EfRepositoryBase<DigitalWallet>, IDigitalWalletRepository
{
    public DigitalWalletRepository(AppDbContext context) : base(context)
    {
    }

    public DigitalWallet GetBalance(string userId)
    {
        var entity = context.DigitalWallet.Where(x => x.UserId == userId).FirstOrDefault();
        return entity;
    }

    public Response<DigitalWallet> AddFunds(DigitalWallet digitalWallett)
    {
        if (digitalWallett.Id == 0)
        {
            try
            {
                var entity = context.Set<DigitalWallet>().Add(digitalWallett);
                context.SaveChanges();
                return Response<DigitalWallet>.Success(entity.Entity, 200);
            }
            catch (Exception ex)
            {
                return Response<DigitalWallet>.Fail(ex.Message, 500, true);
            }
        }
        var result = context.DigitalWallet.Where(x => x.Id == digitalWallett.Id).FirstOrDefault();
        if (result == null && result.UserId != digitalWallett.UserId) { Response<DigitalWallet>.Fail("Invalid account", 404, true); }

        result.Balance += digitalWallett.Balance;
        context.Set<DigitalWallet>().Update(result);
        context.SaveChanges();
        return Response<DigitalWallet>.Success(result, 200);
    }

    public void RemoveFunds(string userId, decimal amount)
    {
        var entity = context.DigitalWallet.Where(x => x.UserId == userId).FirstOrDefault();
        entity.Balance -= amount;
        context.DigitalWallet.Update(entity);
        context.SaveChanges();
    }
}
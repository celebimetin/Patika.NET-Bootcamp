using Core.SharedLibrary.Dtos;
using Schema;

namespace Operation.Basket
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasketAsync(string userId);
        Task<Response<bool>> CreateOrUpdateAsync(BasketDto basketDto);
        Task<Response<bool>> DeleteAsync(string userId);
    }
}
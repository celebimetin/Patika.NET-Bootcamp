using Core.SharedLibrary.Dtos;
using Operation.Redis;
using Schema;
using System.Text.Json;

namespace Operation.Basket
{
    public class BasketService : IBasketService
    {
        private readonly RedisService redisService;
        private readonly IUserService userService;

        public BasketService(RedisService redisService, IUserService userService)
        {
            this.redisService = redisService;
            this.userService = userService;
        }

        public async Task<Response<BasketDto>> GetBasketAsync(string userId)
        {
            var existBasket = await redisService.GetDatabase().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket)) return Response<BasketDto>.Fail("Basket not found", 404, true);

            var basketDto = JsonSerializer.Deserialize<BasketDto>(existBasket);
            return Response<BasketDto>.Success(basketDto, 200);
        }

        public async Task<Response<bool>> CreateOrUpdateAsync(BasketDto basketDto)
        {
            var status = await redisService.GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500, true);
        }

        public async Task<Response<bool>> DeleteAsync(string userId)
        {
            var status = await redisService.GetDatabase().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404, true);
        }
    }
}
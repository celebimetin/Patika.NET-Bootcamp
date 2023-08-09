using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation.Basket;
using Schema;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class BasketsController : BaseController
    {
        private readonly IBasketService basketService;

        public BasketsController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return ActionResultInstance(await basketService.GetBasketAsync(UserId()));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(BasketDto basketDto)
        {
            var response = await basketService.CreateOrUpdateAsync(basketDto);
            return ActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return ActionResultInstance(await basketService.DeleteAsync(UserId()));
        }
    }
}
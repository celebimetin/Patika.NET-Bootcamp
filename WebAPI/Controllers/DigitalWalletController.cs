using Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class DigitalWalletController : BaseController
    {
        private readonly IDigitalWalletService digitalWalletService;

        public DigitalWalletController(IDigitalWalletService digitalWalletService)
        {
            this.digitalWalletService = digitalWalletService;
        }

        [HttpGet]
        public IActionResult GetBalance(string userId)
        {
            return ActionResultInstance(digitalWalletService.GetBalance(userId));
        }

        [HttpPost]
        public IActionResult AddFunds(DigitalWallet digitalWallet)
        {
            return ActionResultInstance(digitalWalletService.AddFunds(digitalWallet));
        }

        [HttpPost]
        public IActionResult RemoveFunds(string userId, decimal amount)
        {
            return ActionResultInstance(digitalWalletService.RemoveFunds(userId, amount));
        }
    }
}
using Core.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation.Token;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginDto)
        {
            var result = await authenticationService.CreateTokenAsync(loginDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefresh([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var result = await authenticationService.CreateTokenByRefreshAsync(refreshTokenDto.Token);
            return ActionResultInstance(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var result = await authenticationService.RevokeRefreshTokenAsync(refreshTokenDto.Token);
            return ActionResultInstance(result);
        }
    }
}
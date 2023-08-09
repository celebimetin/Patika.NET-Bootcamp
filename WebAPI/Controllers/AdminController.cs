using Core.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {
        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            return ActionResultInstance(await userService.CreateUserAsync(createUserDto));
        }

        [HttpPost("{userName}")]
        public async Task<IActionResult> CreateUserRoles(string userName)
        {
            return ActionResultInstance(await userService.CreateAdminRoles(userName));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return ActionResultInstance(await userService.GetAllUserAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto, string userId)
        {
            return ActionResultInstance(await userService.UpdateUserAsync(updateUserDto, userId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            return ActionResultInstance(await userService.DeleteUser(userId));
        }

        [HttpPut]
        public async Task<IActionResult> ChangePasswordAsync(string oldPassword, string newPassword, string userId)
        {
            return ActionResultInstance(await userService.ChangePasswordAsync(oldPassword, newPassword, userId));
        }
    }
}
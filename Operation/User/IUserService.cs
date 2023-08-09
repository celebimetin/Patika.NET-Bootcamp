using Core.DtoModels;
using Core.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Operation;

public interface IUserService
{
    Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
    Task<Response<UserDto>> UpdateUserAsync(UpdateUserDto updateUserDto, string userId);
    Task<Response<NoContentResult>> ChangePasswordAsync(string oldPassword, string newPassword, string userId);
    Task<Response<NoContentResult>> CreateUserRoles(string userName);
    Task<Response<NoContentResult>> CreateAdminRoles(string userName);
    Task<Response<UserDto>> GetUserByNameAsync(string userName);
    Task<Response<List<UserDto>>> GetAllUserAsync();
    Task<Response<NoContentResult>> DeleteUser(string userId);
}
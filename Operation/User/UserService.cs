using Core.DtoModels;
using Core.SharedLibrary.Dtos;
using Core.SharedLibrary.Messages;
using Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schema.Mapper;

namespace Operation;

public class UserService : IUserService
{
    private readonly UserManager<UserApp> userManager;
    private readonly RoleManager<RoleApp> roleManager;

    public UserService(UserManager<UserApp> userManager, RoleManager<RoleApp> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new UserApp
        {
            Email = createUserDto.Email,
            UserName = createUserDto.UserName,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
        };

        var result = await userManager.CreateAsync(user, createUserDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);
        }
        return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
    }

    public async Task<Response<UserDto>> UpdateUserAsync(UpdateUserDto updateUserDto, string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.UserName = updateUserDto.UserName;
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
        }
        return Response<UserDto>.Fail("User not found", 404, true);
    }

    public async Task<Response<NoContentResult>> CreateUserRoles(string userName)
    {
        if (!await roleManager.RoleExistsAsync("user"))
            await roleManager.CreateAsync(new() { Name = "user" });

        var user = await userManager.FindByNameAsync(userName);
        await userManager.AddToRoleAsync(user, "user");

        return Response<NoContentResult>.Success(200);
    }

    public async Task<Response<NoContentResult>> CreateAdminRoles(string userName)
    {
        if (!await roleManager.RoleExistsAsync("admin"))
            await roleManager.CreateAsync(new() { Name = "admin" });

        var user = await userManager.FindByNameAsync(userName);
        await userManager.AddToRoleAsync(user, "admin");

        return Response<NoContentResult>.Success(200);
    }

    public async Task<Response<UserDto>> GetUserByNameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        if (user == null) return Response<UserDto>.Fail(Message.UserNotFound, 404, true);
        return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
    }

    public async Task<Response<List<UserDto>>> GetAllUserAsync()
    {
        var users = await userManager.Users.ToListAsync();
        var mapped = ObjectMapper.Mapper.Map<List<UserDto>>(users);
        return Response<List<UserDto>>.Success(mapped, 200);
    }

    public async Task<Response<NoContentResult>> DeleteUser(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user != null)
        {
            await userManager.DeleteAsync(user);
            return Response<NoContentResult>.Success(200);
        }
        return Response<NoContentResult>.Fail("User not found", 404, true);
    }

    public async Task<Response<NoContentResult>> ChangePasswordAsync(string oldPassword, string newPassword, string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user != null)
        {
            await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return Response<NoContentResult>.Success(200);
        }
        return Response<NoContentResult>.Fail("User not found", 404, true);
    }
}
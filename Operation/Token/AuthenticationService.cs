using Core.DtoModels;
using Core.SharedLibrary.Dtos;
using Core.SharedLibrary.Messages;
using Data.Domain;
using Data.Repository.Base;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Operation.Token
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService tokenService;
        private readonly UserManager<UserApp> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<UserRefreshToken> userRefreshToken;

        public AuthenticationService(ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IRepository<UserRefreshToken> userRefreshToken)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.userRefreshToken = userRefreshToken;
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentException(nameof(loginDto));
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Response<TokenDto>.Fail(Message.EmailOrPasswordIsWrong, 400, true);
            if (!await userManager.CheckPasswordAsync(user, loginDto.Password)) return Response<TokenDto>.Fail(Message.EmailOrPasswordIsWrong, 400, true);

            var token = tokenService.CreateToken(user);
            var _userRefreshToken = await userRefreshToken.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (_userRefreshToken == null)
            {
                await userRefreshToken.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expriraiton = token.RefreshTokenExpiration });
            }
            else
            {
                _userRefreshToken.Code = token.RefreshToken;
                _userRefreshToken.Expriraiton = token.RefreshTokenExpiration;
            }
            await unitOfWork.SaveChangesAsync();
            return Response<TokenDto>.Success(token, 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshAsync(string refreshToken)
        {
            var existRefreshToken = await userRefreshToken.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) return Response<TokenDto>.Fail(Message.RefreshTokenNotFound, 404, true);
            var user = await userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) return Response<TokenDto>.Fail(Message.UserIdNotFound, 404, true);
            var tokenDto = tokenService.CreateToken(user);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expriraiton = tokenDto.RefreshTokenExpiration;
            await unitOfWork.SaveChangesAsync();
            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await userRefreshToken.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) return Response<NoDataDto>.Fail(Message.RefreshTokenNotFound, 404, true);
            userRefreshToken.Remove(existRefreshToken);
            await unitOfWork.SaveChangesAsync();
            return Response<NoDataDto>.Success(200);
        }
    }
}
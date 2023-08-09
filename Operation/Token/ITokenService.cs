using Core.DtoModels;
using Data.Domain;

namespace Operation.Token
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp user);
    }
}
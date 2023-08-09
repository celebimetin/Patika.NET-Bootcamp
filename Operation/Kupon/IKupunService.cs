using Core.SharedLibrary.Dtos;
using Data.Domain;
using Operation.BaseService;
using Schema;

namespace Operation;

public interface IKupunService : IBaseService<Kupon, KuponRequest, KuponResponse>
{
    Response<List<KuponResponse>> GetAllByUserId(string userId);
    Response<KuponResponse> GetByCode(string code);
}
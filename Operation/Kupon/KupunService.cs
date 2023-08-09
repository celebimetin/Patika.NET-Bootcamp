using AutoMapper;
using Core.SharedLibrary.Dtos;
using Data.Domain;
using Data.UnitOfWork;
using Operation.BaseService;
using Schema;
using Schema.Mapper;

namespace Operation;

public class KupunService : BaseService<Kupon, KuponRequest, KuponResponse>, IKupunService
{
    public KupunService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public Response<List<KuponResponse>> GetAllByUserId(string userId)
    {
        var entities = unitOfWork.Repository<Kupon>().Where(x => x.UserId == userId).ToList();
        var mapped = ObjectMapper.Mapper.Map<List<KuponResponse>>(entities);
        return Response<List<KuponResponse>>.Success(mapped, 200);

    }
    public Response<KuponResponse> GetByCode(string code)
    {
        var entity = unitOfWork.Repository<Kupon>().Where(x => x.Code == code).FirstOrDefault();
        var mapped = ObjectMapper.Mapper.Map<KuponResponse>(entity);
        return Response<KuponResponse>.Success(mapped, 200);
    }
}
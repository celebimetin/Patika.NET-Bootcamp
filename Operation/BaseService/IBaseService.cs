using Core.Model;
using Core.SharedLibrary.Dtos;

namespace Operation.BaseService
{
    public interface IBaseService<TEntity, TRequest, TResponse>
        where TEntity : BaseEntity
        where TRequest : class
        where TResponse : class
    {
        Response<List<TResponse>> GetAll();
        Task<Response<IEnumerable<TResponse>>> GetAllAsync();
        Response<TResponse> GetById(int id);
        Task<Response<TResponse>> GetByIdAsync(int id);
        Response<TResponse> Add(TRequest request);
        Task<Response<TResponse>> AddAsync(TRequest request);
        Response<NoDataDto> Update(TRequest request, int id);
        Response<NoDataDto> RemoveRange(TRequest request, int id);
        Response<NoDataDto> DeleteById(int id);
    }
}
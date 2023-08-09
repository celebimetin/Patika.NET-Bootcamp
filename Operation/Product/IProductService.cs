using Core.SharedLibrary.Dtos;
using Data.Domain;
using Operation.BaseService;
using Schema;

namespace Operation;

public interface IProductService : IBaseService<Product, ProductRequest, ProductResponse>
{
    Response<NoDataDto> Update(ProductUpdateRequest request, int id);
}
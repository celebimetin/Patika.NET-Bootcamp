using AutoMapper;
using Core.SharedLibrary.Dtos;
using Data.Domain;
using Data.UnitOfWork;
using Operation.BaseService;
using Schema;
using Schema.Mapper;

namespace Operation;

public class ProductService : BaseService<Product, ProductRequest, ProductResponse>, IProductService
{
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public virtual Response<NoDataDto> Update(ProductUpdateRequest request, int id)
    {
        try
        {
            var entity = ObjectMapper.Mapper.Map<ProductUpdateRequest, Product>(request);
            entity.Id = id;
            var updateEntity = unitOfWork.Repository<Product>().Update(entity);
            unitOfWork.SaveChanges();
            var mapped = ObjectMapper.Mapper.Map<Product, ProductResponse>(updateEntity);
            return new Response<NoDataDto>();
        }
        catch (Exception ex)
        {
            return Response<NoDataDto>.Fail(ex.Message, 500, true);
        }
    }
}
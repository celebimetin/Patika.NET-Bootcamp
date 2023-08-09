using AutoMapper;
using Core.SharedLibrary.Dtos;
using Core.SharedLibrary.Messages;
using Data.Domain;
using Data.UnitOfWork;
using Operation.BaseService;
using Schema;
using Schema.Mapper;

namespace Operation;

public class CategoryService : BaseService<Category, CategoryRequest, CategoryResponse>, ICategoryService
{
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public virtual Response<NoDataDto> Update(CategoryUpdateRequest request, int id)
    {
        try
        {
            var checkEntity = unitOfWork.Repository<Category>().Get(id);
            if (checkEntity is null)
                return Response<NoDataDto>.Fail(Message.NotFound, 404, true);

            var entity = ObjectMapper.Mapper.Map<CategoryUpdateRequest, Category>(request);
            entity.Id = id;
            var updateEntity = unitOfWork.Repository<Category>().Update(entity);
            unitOfWork.SaveChanges();
            var mapped = ObjectMapper.Mapper.Map<Category, CategoryResponse>(updateEntity);
            return Response<NoDataDto>.Success(204);
        }
        catch (Exception ex)
        {
            return Response<NoDataDto>.Fail(ex.Message, 500, true);
        }
    }

    public virtual Response<NoDataDto> DeleteById(int id)
    {
        try
        {
            var checkEntity = unitOfWork.Repository<Category>().Get(id);
            if (checkEntity is null)
                return Response<NoDataDto>.Fail(Message.NotFound, 404, true);

            var category = unitOfWork.Repository<Category>().GetByIdWithInclude(id, "Products");
            if (category.Products.Count > 0)
            {
                return Response<NoDataDto>.Fail("There are products belonging to the category cannot be deleted", 400, true);
            }

            var deleteEntity = unitOfWork.Repository<Category>().DeleteById(id);
            unitOfWork.SaveChanges();
            return Response<NoDataDto>.Success(204);
        }
        catch (Exception ex)
        {
            return Response<NoDataDto>.Fail(ex.Message, 500, true);
        }
    }

    public async Task<Response<CategoryResponse>> AddCategoryWithProductsAsync(CategoryRequest request, IEnumerable<int> productsId)
    {
        var category = ObjectMapper.Mapper.Map<CategoryRequest, Category>(request);
        await unitOfWork.CategoryRepository.AddAsync(category);

        foreach (var item in productsId)
        {
            var product = await unitOfWork.ProductRepository.GetAsync(item);
            if (product != null)
                await unitOfWork.Repository<CategoryProduct>().AddAsync(new CategoryProduct { ProductId = product.Id, CategoryId = category.Id });
        }
        await unitOfWork.SaveChangesAsync();

        return Response<CategoryResponse>.Success(200);
    }

    public async Task<Response<CategoryResponse>> GetProductsByCategoryId(int categoryId)
    {
        var entity = unitOfWork.Repository<Category>().GetByIdWithInclude(categoryId, "Products");
        if (entity is null)
            return Response<CategoryResponse>.Fail(Message.NotFound, 404, true);

        var mapped = ObjectMapper.Mapper.Map<CategoryResponse>(entity);
        return Response<CategoryResponse>.Success(mapped, 200);
    }
}
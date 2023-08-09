using Core.SharedLibrary.Dtos;
using Data.Domain;
using Operation.BaseService;
using Schema;

namespace Operation;

public interface ICategoryService : IBaseService<Category, CategoryRequest, CategoryResponse>
{
    Task<Response<CategoryResponse>> AddCategoryWithProductsAsync(CategoryRequest request, IEnumerable<int> productsId);
    Response<NoDataDto> Update(CategoryUpdateRequest request, int id);
    Task<Response<CategoryResponse>> GetProductsByCategoryId(int categoryId);
}
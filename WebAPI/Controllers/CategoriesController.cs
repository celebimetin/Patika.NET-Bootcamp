using Core.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Operation;
using Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService service;
        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public async Task<Response<IEnumerable<CategoryResponse>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return result;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}")]
        public async Task<Response<CategoryResponse>> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}")]
        public async Task<Response<CategoryResponse>> GetProductsByCategoryId(int id)
        {
            var result = await service.GetProductsByCategoryId(id);
            return result;
        }

        [HttpPost]
        public async Task<Response<CategoryResponse>> Add([FromBody] CategoryRequest request)
        {
            var result = await service.AddAsync(request);
            return result;
        }

        [HttpPut("{id}")]
        public Response<NoDataDto> Update([FromBody] CategoryUpdateRequest request, int id)
        {
            var result = service.Update(request, id);
            return result;
        }

        [HttpDelete("{id}")]
        public Response<NoDataDto> Delete(int id)
        {
            var result = service.DeleteById(id);
            return result;
        }

        [HttpPost("{productsId}")]
        public async Task<Response<CategoryResponse>> AddCategoryWithProducts([FromBody] CategoryRequest request, [FromRoute] IEnumerable<int> productsId)
        {
            var result = await service.AddCategoryWithProductsAsync(request, productsId);
            return result;
        }
    }
}
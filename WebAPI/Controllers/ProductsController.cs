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
    public class ProductsController : BaseController
    {
        private readonly IProductService service;
        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public async Task<Response<IEnumerable<ProductResponse>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return result;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}")]
        public async Task<Response<ProductResponse>> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<Response<ProductResponse>> Add([FromBody] ProductRequest request)
        {
            var result = await service.AddAsync(request);
            return result;
        }

        [HttpPut("{id}")]
        public Response<NoDataDto> Update([FromBody] ProductUpdateRequest request, int id)
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
    }
}
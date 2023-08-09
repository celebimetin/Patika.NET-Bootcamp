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
    public class KuponController : BaseController
    {
        private readonly IKupunService service;
        public KuponController(IKupunService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<KuponResponse>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Response<KuponResponse>> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<Response<KuponResponse>> Add([FromBody] KuponRequest request)
        {
            var result = await service.AddAsync(request);
            return result;
        }

        [HttpPut("{id}")]
        public Response<NoDataDto> Update([FromBody] KuponRequest request, int id)
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

        [HttpGet]
        public Response<List<KuponResponse>> GetAllByUserId(string userId)
        {
            var result = service.GetAllByUserId(userId);
            return result;
        }

        [HttpGet]
        public Response<KuponResponse> GetByCode(string code)
        {
            var result = service.GetByCode(code);
            return result;
        }
    }
}
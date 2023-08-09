using Core.SharedLibrary.Dtos;
using MediatR;
using Schema;

namespace Operation.Order.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
using Core.SharedLibrary.Dtos;
using MediatR;
using Schema;

namespace Operation.Order.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
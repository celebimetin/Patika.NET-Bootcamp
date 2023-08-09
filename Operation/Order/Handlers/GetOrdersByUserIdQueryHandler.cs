using Core.SharedLibrary.Dtos;
using Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Operation.Order.Queries;
using Schema;
using Schema.Mapper;

namespace Operation.Order.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly AppDbContext dbContext;

        public GetOrdersByUserIdQueryHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                .Include(x => x.OrderItems)
                .Where(x => x.BuyerId == request.UserId).ToListAsync();

            if (!orders.Any()) return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}
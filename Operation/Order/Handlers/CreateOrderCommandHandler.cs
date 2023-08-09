using Core.SharedLibrary.Dtos;
using Data.Context;
using Data.Domain;
using MediatR;
using Operation.Order.Commands;
using Schema;

namespace Operation.Order.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly AppDbContext dbContext;

        public CreateOrderCommandHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

            Data.Domain.Order newOrder = new Data.Domain.Order(newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price);
            });

            await dbContext.Orders.AddAsync(newOrder);
            await dbContext.SaveChangesAsync();
            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
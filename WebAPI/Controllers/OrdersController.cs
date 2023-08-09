using MediatR;
using Microsoft.AspNetCore.Mvc;
using Operation.Order.Commands;
using Operation.Order.Queries;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await mediator.Send(new GetOrdersByUserIdQuery { UserId = UserId() });
            return ActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await mediator.Send(createOrderCommand);
            return ActionResultInstance(response);
        }
    }
}
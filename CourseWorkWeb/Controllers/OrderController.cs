using CourseWorkWeb.Core.CQRS.Orders.Commands.Add;
using CourseWorkWeb.Core.CQRS.Orders.Commands.Delete;
using CourseWorkWeb.Core.CQRS.Orders.Commands.Update;
using CourseWorkWeb.Core.CQRS.Orders.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Entity.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class OrderController(ISender sender) : Controller
    {
        private readonly ISender _sender = sender;
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult> GetAllOrders()
        {
            var order = await _sender.Send(new GetOrdersQuery());
            return View(order);
        }
        [HttpGet("{Id:long}", Name = "GetSingle")]
        public async Task<ActionResult> GetSingleOrder([FromBody] long Id)
        {
            var order = await _sender.Send(new GetOrderByIdQuery(Id));
            return View(order);
        }
        [HttpPost]
        public async Task<ActionResult> AddOrder(Order order)
        {
            var result = await _sender.Send(new AddOrderCommand(order));
            return View(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            var result = await _sender.Send(new UpdateOrderCommand(order));
            return View(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(long Id)
        {
            var result = await _sender.Send(new DeleteOrderCommand(Id));
            return View(result);
        }
    }
}

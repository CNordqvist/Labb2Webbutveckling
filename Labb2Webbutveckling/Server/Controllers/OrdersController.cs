using DataAccess.Model;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb2Webbutveckling.Server.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
            return Ok(orders);
        }
    }
}

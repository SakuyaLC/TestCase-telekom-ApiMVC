using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Data.Interfaces;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/orders")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public IActionResult GetOrders()
        {
            var orders = _repository.GetOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(orders);
        }

        [HttpGet("/orders-relation")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public IActionResult GetRelationOrders()
        {
            var relationOrders = _repository.GetRelationOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(relationOrders);
        }

    }
}

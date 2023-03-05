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

        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;

        public OrdersController(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        //Посмотреть все заказы
        [HttpGet("/orders")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(orders);
        }

        //Посмотреть все заказы из таблицы отношения
        [HttpGet("/orders-relation")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public IActionResult GetRelationOrders()
        {
            var relationOrders = _orderRepository.GetRelationOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(relationOrders);
        }

        //Посмотреть детали определенного заказа
        [HttpGet("/order-info/{order_id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<RelationOrder>))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderInfo(int order_id)
        {
            var relationOrders = _orderRepository.GetRelationOrders().Where(ro => ro.order_id == order_id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(relationOrders);
        }

        //Посмотреть детали заказов определенного пользователя
        [HttpGet("/orders/{user_id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        [ProducesResponseType(400)]
        public IActionResult GetOrdersForSpecifiedUser(int user_id)
        {
            List<OrderInfo> ordersInfo = new List<OrderInfo>();

            List<Order> orders = _orderRepository.GetOrders().Where(o => o.user_id == user_id).ToList();

            double cost = 0;
            int quantity = 0;

            foreach (Order order in orders)
            {

                List<RelationOrder> relationalOrders = _orderRepository.GetRelationOrders().Where(ro => ro.order_id == order.order_id).ToList();
                foreach (RelationOrder relationOrder in relationalOrders)
                {
                    quantity += relationOrder.quantity;
                    Item item = _itemRepository.GetItems().Where(i => i.item_id == relationOrder.item_id).Single();
                    cost += (relationOrder.quantity*item.item_cost);
                }

                OrderInfo orderInfo = new OrderInfo()
                {
                    order_id = order.order_id,
                    orderDate = order.date,
                    orderCost = cost,
                    itemsQuantity = quantity,
                };

                ordersInfo.Add(orderInfo);
                cost = 0;
                quantity = 0;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ordersInfo);
        }

            
    }

}

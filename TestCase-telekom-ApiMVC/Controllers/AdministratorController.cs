using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestCase_telekom_ApiMVC.Data.Interfaces;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : Controller
    {

        private readonly IAdminRepository _adminRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;

        public AdministratorController(IAdminRepository adminRepository, IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _adminRepository = adminRepository;
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        /*
         * Метод админа - посмотреть информацию о пользователе +
         * Сколько у пользователя заказов и на какую общую сумму они вышли
        */
        [HttpGet("/admin/get-user/{user_id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        [ProducesResponseType(400)]
        public IActionResult AdminGetUserInfo(int user_id)
        {
            var user = _adminRepository.GetUser(user_id);

            var orders = _orderRepository.GetOrders().Where(o => o.user_id == user_id).ToList();

            double cost = 0;
            int orderQuantity = orders.Where(o => o.user_id == user_id).Count();

            foreach (Order order in orders)
            {

                List<RelationOrder> relationalOrders = _orderRepository.GetRelationOrders().Where(ro => ro.order_id == order.order_id).ToList();
                foreach (RelationOrder relationOrder in relationalOrders)
                {
                    Item item = _itemRepository.GetItems().Where(i => i.item_id == relationOrder.item_id).Single();
                    cost += (relationOrder.quantity * item.item_cost);
                }
            }

            UserOrdersSummary userOrdersSummary = new UserOrdersSummary()
            {
                orderCost = cost,
                ordersQuantity = orderQuantity,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(userOrdersSummary);
        }

    }
}

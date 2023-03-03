using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Controllers
{
    public class OrdersController
    {

        [HttpGet("/orders")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public string GetOrders()
        {
            return "Success";
        }

        [HttpGet("/orders/1")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public string GetOrderInfo()
        {
            return "Success";
        }
    }
}

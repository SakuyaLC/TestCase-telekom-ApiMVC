using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class OrderInfo
    {
        public int order_id { get; set; }
        public DateTime orderDate {get; set;}
        public double orderCost { get; set; }
        public int itemsQuantity { get; set; }
    }
}

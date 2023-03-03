using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class Order
    {
        private int order_id { get; set; }
        private int user_id { get; set; }
        private Item item { get; set; }
        public DateTime date { get; set; }
    }
}

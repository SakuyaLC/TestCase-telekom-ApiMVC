using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class RelationOrder
    {
        [Required]
        [Key]
        public int relation_order_id { get; set; }
        public int order_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
    }
}

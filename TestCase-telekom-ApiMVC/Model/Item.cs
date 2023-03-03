using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class Item
    {
        [Required]
        [Key]
        public int item_id { get; set; }
        public string item_title { get; set; }
        public float item_cost { get; set; }
    }
}

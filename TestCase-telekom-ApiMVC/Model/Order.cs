﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class Order
    {
        [Required]
        [Key]
        public int order_id { get; set; }
        public int user_id { get; set; }
        public DateTime date { get; set; }
    }
}

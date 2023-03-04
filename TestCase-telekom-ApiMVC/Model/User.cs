using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Model
{
    public class User
    {
        [Required]
        [Key]
        public int user_id {get;set;}
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
        // 0 - default, 1 - admin
        public bool role { get; set; }
    }
}

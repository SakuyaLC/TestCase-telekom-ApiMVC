using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Controllers
{
    public class AdministratorController
    {

        [HttpGet("/admin")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public string Admin()
        {
            return "Success";
        }

        [HttpGet("/admin/check-user")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public string CheckUser()
        {
            return "Success";
        }
    }
}

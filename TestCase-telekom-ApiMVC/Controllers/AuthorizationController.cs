using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase_telekom_ApiMVC.Controllers
{
    public class AuthorizationController
    {

        [HttpGet("/registration")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public string Register()
        {
            return "Success";
        }

        [HttpGet("/login")]
        [ProducesResponseType(200,Type = typeof(string))]
        [ProducesResponseType(400)]
        public string Login()
        {
            return "Success";
        }
    }
}

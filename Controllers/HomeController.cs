using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetMenu")]
        [Route("GetMenu")]
        public IActionResult GetMenu()
        {
            var isAuth = User;

            isAuth.Claims.Where(q => q.Type == "BusinessItem").ToList().ForEach(t =>
            {
                Console.WriteLine(t);
            });

            var m1 = new MenuModel {
                id = 1,
                text = "asd",
                componentUrl = "/views/About.vue",
                typeId = 2,
                url = "/about"
            };

            var m2 = new MenuModel
            {
                id = 2,
                text = "asd 213",
                componentUrl = "/views/About.vue",
                typeId = 2,
                url = "/about2"
            };

            var response = JsonSerializer.Serialize(new List<MenuModel> { m1, m2 } );
            return new OkObjectResult(response);
        }
    }

    public class MenuModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public int typeId { get; set; }
        public string url { get; set; }
        public string componentUrl { get; set; }

    }
}

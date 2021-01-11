using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;



namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        [HttpPost("GetByLocaleKey")]
        [Route("GetByLocaleKey")]
        public IActionResult GetByLocaleKey(LocalizationRequest request)
        {



            var data = new Dictionary<string, string>();



            if (request.locale == "en")
            {
                data = new Dictionary<string, string>{
                    { "key_a", "val_en"},
                    { "key_b", "val_en"}
                };
            }
            else
            {
                data = new Dictionary<string, string>{
                    { "key_a", "val_tr"},
                    { "key_b", "val_tr"}
                };
            }




            var a = JsonSerializer.Serialize(data);
            return new OkObjectResult(a);
        }



        [HttpPost("GetAvailableLanguages")]
        [Route("GetAvailableLanguages")]
        public IActionResult GetAvailableLanguages()
        {



            var data = new Dictionary<string, string>
            {
                {"en", "en-English" },
                {"tr", "tr-Türkçe" },
                {"fr", "tr-France" },
            };

            var a = JsonSerializer.Serialize(data);
            return new OkObjectResult(a);
        }
    }




    public class LocalizationRequest
    {
        public string locale { get; set; }
    }



}

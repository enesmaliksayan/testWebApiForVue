﻿using Microsoft.AspNetCore.Mvc;
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
                    { "404", "Page Not Found!"},
                    { "404_Button", "Go To Home"},
                    { "login", "Login"},
                    { "logout", "Logout"}
                };
            }
            else
            {
                data = new Dictionary<string, string>{
                    { "404", "Sayfa Bulunamadı!"},
                    { "404_Button", "Anasayfaya Git"},
                    { "login", "Giriş Yap"},
                    { "logout", "Çıkış Yap"}
                };
            }


            var a = JsonSerializer.Serialize(data);
            return new OkObjectResult(a);
        }

        [HttpPost("GetAvailableLocales")]
        [Route("GetAvailableLocales")]
        public IActionResult GetAvailableLocales()
        {
            var data = new List<LocaleItemModel>
            {
                new LocaleItemModel{ localeKey = "en", localeName= "en-English"},
                new LocaleItemModel{ localeKey = "tr", localeName= "tr-Turkçe"},
                new LocaleItemModel{ localeKey = "fr", localeName= "fr-France"}
            };


            return new OkObjectResult(data);
        }

        [HttpPost("AddTranslation")]
        [Route("AddTranslation")]
        public IActionResult AddTranslation(TranslationModel translationModel)
        {
            return new OkObjectResult(true);
        }

        [HttpPost("AddLocale")]
        [Route("AddLocale")]
        public IActionResult AddLocale(LocaleItemModel localeModel)
        {
            return new OkObjectResult(true);
        }

        [HttpGet("GetAllTranslations")]
        [Route("GetAllTranslations")]
        public IActionResult GetAllTranslations()
        {
            var data = new List<TranslationModel>
            {
                new TranslationModel("en", "404","Page Not Found!"),
                new TranslationModel("en", "404_Button", "Go to Home"),
                new TranslationModel("tr", "404","Sayfa Bulunamadı!"),
                new TranslationModel("tr", "404_Button", "Anasayfaya Git")
            };

            var json = JsonSerializer.Serialize(data);
            return new OkObjectResult(json);
        }


        [HttpPost("RemoveLocale")]
        [Route("RemoveLocale")]
        public IActionResult RemoveLocale(string localeKey)
        {
            return new OkObjectResult(true);
        }


        [HttpPost("RemoveTranslation")]
        [Route("RemoveTranslation")]
        public IActionResult RemoveTranslation(TranslationModel translation)
        {
            return new OkObjectResult(true);
        }


    }


    public class LocalizationRequest
    {
        public string locale { get; set; }
    }

    public class TranslationModel
    {
        public TranslationModel(string locale, string key, string value)
        {
            this.locale = locale;
            this.translationKey = key;
            this.translationValue = value;
        }

        public TranslationModel()
        {

        }
        public string locale { get; set; }

        public string translationKey { get; set; }

        public string translationValue { get; set; }
    }

    public class LocaleItemModel
    {
        public string localeKey { get; set; }
        public string localeName { get; set; }
    }

}

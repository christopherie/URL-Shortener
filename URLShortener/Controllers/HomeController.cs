using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(URL url)
        {
            if (ModelState.IsValid)
            {
                /*
                 * The Google URL shortener API is a public API which means we don’t need 
                 * to worry about authentication we can access it directly using a public API key.
                 * We now have a URLshortenerService we can use to access the api.
                 */
                UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
                {
                    ApiKey = ConfigurationManager.AppSettings["urlShortenerAPIKey"],
                    ApplicationName = "Get Shorty"
                });

                var m = new Google.Apis.Urlshortener.v1.Data.Url();
                m.LongUrl = url.UrlString;
                ViewBag.Shorty = service.Url.Insert(m).Execute().Id;
                return View("Url");
            }
            else return View("Index", url);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Models;
using MobiliNew.Web.Service.Interface;

namespace MobiliNew.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEmailService _emailService;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer, IEmailService emailService) : base(logger)
        {
            _emailService = emailService;
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append(
                   CookieRequestCultureProvider.DefaultCookieName,
                   CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("it-IT")),
                   new CookieOptions
                   {
                       Expires = DateTimeOffset.UtcNow.AddYears(1),
                       IsEssential = true,  //critical settings to apply new culture
                       Path = "/",
                       HttpOnly = false,
                   });
            return View();
        }
   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

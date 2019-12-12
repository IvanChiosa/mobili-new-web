using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Models.ReturnModels;
using MobiliNew.Web.service.Interface;
using MobiliNew.Web.Service.Interface;

namespace MobiliNew.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService, IProductService productService, 
            ILogger<CategoriesController> logger, IEmailService emailService) : base(logger)
        {
            _logger = logger;
            _categoriesService = categoriesService;
            _productService = productService;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var user = CategoriesReturnModels.Cast(_categoriesService.GetCategories());
            
            return View(user);
        }
        //return View(result);
        //try
        //{
        //    var emailData = new EmailQueue()
        //    {
        //        //Name = user.,
        //        //Surname = user.Cognome,
        //        //FromAddress = user.Email,
        //        //MailBody = "your promotional code is",
        //        //AttemptsRemaining = 5,
        //        //DateLoading = DateTime.Now,
        //        //DateProcessed = null,
        //        //Company = "amilon",
        //        //BccAddress = user.Email,
        //        //IsSent = false,
        //        //MailObject = "promotional code from...",
        //        //ToAddress = user.Email,
        //        //Status = "In Process",
        //    };
        //    _emailService.AddMailToQueue(emailData);
        //}
        //catch(Exception)
        //{
        //    return View("Errore...");
        //}
        public IActionResult GetSingleCategories(Guid id)
        {
            //var Cat = ProductReturnModels.Cast(_productService.GetBy(c => c.Id == id));
            //return View(Cat);

            var cat = _categoriesService.Category(id);
            return View(ProductReturnModels.Cast(cat));
        }
    }
}
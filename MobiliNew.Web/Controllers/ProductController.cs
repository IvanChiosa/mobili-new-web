using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobiliNew.Web.Models.ReturnModels;
using MobiliNew.Web.service.Interface;

namespace MobiliNew.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICategoriesService _categoriesService;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ICategoriesService categoriesService, ILogger<ProductController> logger) : base(logger)
        {
            _logger = logger;
            _productService = productService;
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var result = ProductReturnModels.Cast(_productService.Get());
            return View(result);
        }

        [HttpGet]
        public ActionResult ProductsByCategory(Guid id)
        {
            var castRes = ProductReturnModels.Cast(_productService.GetBy(x => x.IdCategories == id));
            return View(castRes);
        }
        //[HttpGet]
        //public ActionResult SingleProduct()
        //{
        //    var castRest = ProductReturnModels.Cast(_productService.Get(x => x.IdCategories == id));
        //    return ViewBag();
        //}
    }
}
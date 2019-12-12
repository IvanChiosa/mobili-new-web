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

        public ActionResult Index()
        {
            var result = ProductReturnModels.Cast(_productService.Get());
            //ViewData["MobiliNew.Web"] = Mobili;
            return View(result);
        }

        [HttpGet]
        public ActionResult ProductsByCategory(Guid id)
        {
            var castRes = ProductReturnModels.Cast(_productService.GetBy(x => x.IdCategories == id));
            return View(castRes);
        }


        // sospeso 
        [HttpGet]
        public IActionResult ProductCat(Guid id)
        {
            var prCat = ProductReturnModels.Cast(_productService.QueryableIncluding(x => x.Id == id));
            return View(prCat);
        }




        [HttpGet]
        public IActionResult ProductById(Guid id)
        {
            var prod = ProductReturnModels.Cast(_productService.GetBy(x => x.Id == id));
            return View(prod);
        }

        [HttpGet]
        public ActionResult SearchProduct(string searchKey = null)
        {
            if (searchKey == null || searchKey.Length > 0 && searchKey.Length < 3) return View("SearchProduct", new List<ProductReturnModels>());
            else
            {
                var result = ProductReturnModels.Cast(_productService.SearchProd(searchKey));
                return View("SearchProduct", result);
            }
        }
    }
}
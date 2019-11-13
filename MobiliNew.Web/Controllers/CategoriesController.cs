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
    public class CategoriesController : BaseController
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService, IProductService productService, ILogger<CategoriesController> logger ) : base(logger)
        {
            _logger = logger;
            _categoriesService = categoriesService;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = CategoriesReturnModels.Cast(_categoriesService.GetCategories());
            return View(result);
        }
    }
}
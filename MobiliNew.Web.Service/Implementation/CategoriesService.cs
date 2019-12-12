using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Repository.Interfaces;
using MobiliNew.Web.service.Interface;
using MobiliNew.Web.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiliNew.Web.service.Implementation
{
    public class CategoriesService : Service<Categories>, ICategoriesService
    {
        private readonly IProductService _productService;
        private readonly IRepository<Categories> _repository;
        public CategoriesService(IRepository<Categories> repository, IProductService productService) : base(repository)
        {
            _productService = productService;
            _repository = repository;
        }
        public IEnumerable<Product> Category(Guid id)
        {
            var res = _productService.GetBy(c => c.IdCategories == id).ToList();
            return res;
            
        }
        public IEnumerable<Categories> GetCategories()
        {
            return _repository.Get().ToList();
        }
    }
}

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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository) : base(repository)
        {
            _repository = repository;
        }
        public List<Product> GetActiveProduct()
        {
            return _repository.GetBy(p => p.Available).ToList();
        }

        public IEnumerable<Product> GetBy(Guid id, string name)
        {
            return _repository.GetBy(p => p.Available).ToList();
        }
    }
}

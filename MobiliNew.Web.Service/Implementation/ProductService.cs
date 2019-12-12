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

        public IEnumerable<Product> GetBy(Guid id)
        {
            return _repository.GetBy(p => p.Available).ToList();
        }

        public IEnumerable<Product> QueryableIncluding(Guid id)
        {
            return _repository.QueryableIncluding(p => p.Id);
        }

        public IEnumerable<Product> SearchProd(string searchKey)
        {
            var Search = _repository.QueryableIncluding().Where(r => r.Name.Contains(searchKey) || r.Description.Contains(searchKey) );
            return Search;            
        }
    }
}

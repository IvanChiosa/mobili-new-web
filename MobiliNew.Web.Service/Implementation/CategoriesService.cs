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
        private readonly IRepository<Categories> _repository;
        public CategoriesService(IRepository<Categories> repository) : base(repository)
        {
            _repository = repository;
        }

        public Categories Category(Guid id)
        {
            return _repository.FindIncluding(c => c.Id == id);
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _repository.Get().ToList();
        }
    }
}

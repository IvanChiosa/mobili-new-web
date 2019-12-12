using MobiliNew.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiliNew.Web.service.Interface
{
    public interface ICategoriesService : IService<Categories>
    {
        IEnumerable<Product> Category(Guid id);
        IEnumerable<Categories> GetCategories();
    }
}

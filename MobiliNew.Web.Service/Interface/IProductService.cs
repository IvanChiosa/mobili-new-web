using MobiliNew.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiliNew.Web.service.Interface
{
    public interface IProductService : IService<Product>
    {
        List<Product> GetActiveProduct();
        IEnumerable<Product> GetBy(Guid id);
        IEnumerable<Product> SearchProd(string searchKey);
        IEnumerable<Product> Get();
        IEnumerable<Product> QueryableIncluding(Guid id);
    }

}

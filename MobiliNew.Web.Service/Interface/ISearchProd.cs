using MobiliNew.Web.Data.Models;
using MobiliNew.Web.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiliNew.Web.Service.Interface
{
    public interface ISearchProd : IService<Product>
    {
        Product SearchProd(string search);
    }
}

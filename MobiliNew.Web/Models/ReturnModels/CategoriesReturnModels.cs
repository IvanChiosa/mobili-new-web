using MobiliNew.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiliNew.Web.Models.ReturnModels
{
    public class CategoriesReturnModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public static explicit operator Categories(CategoriesReturnModels c)
        {
            return new Categories()
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image
            };
        }
        public static explicit operator CategoriesReturnModels(Categories c)
        {
            return new CategoriesReturnModels()
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image
            };
        }
        public static IEnumerable<Categories> Cast(IEnumerable<CategoriesReturnModels> list)
        {
            return list.Select(x => (Categories)x);
        }
        public static IEnumerable<CategoriesReturnModels> Cast(IEnumerable<Categories> list)
        {
            return list.Select(x => (CategoriesReturnModels)x);
        }
    }
}

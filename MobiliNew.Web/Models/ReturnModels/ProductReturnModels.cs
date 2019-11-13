using MobiliNew.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiliNew.Web.Models.ReturnModels
{
    public class ProductReturnModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public Guid IdCategories { get; set; }

        public virtual Categories IdCategoriesNavigation { get; set; }

        public static explicit operator Product(ProductReturnModels p)
        {
            return new Product()
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Description = p.Description,
                Available = p.Available,
            };
        }
        public static explicit operator ProductReturnModels(Product p)
        {
            return new ProductReturnModels()
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Description = p.Description,
                Available = p.Available
            };
        }
        public static IEnumerable<Product> Cast(IEnumerable<ProductReturnModels> list)
        {
            return list.Select(x => (Product)x);
        }
        public static IEnumerable<ProductReturnModels> Cast(IEnumerable<Product> list)
        {
            return list.Select(x => (ProductReturnModels)x);
        }
    }
}

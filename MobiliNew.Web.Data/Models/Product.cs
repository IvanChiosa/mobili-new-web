using System;
using System.Collections.Generic;

namespace MobiliNew.Web.Data.Models
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public Guid IdCategories { get; set; }

        public virtual Categories IdCategoriesNavigation { get; set; }
    }
}

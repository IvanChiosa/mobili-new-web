using System;
using System.Collections.Generic;

namespace MobiliNew.Web.Data.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Product = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}

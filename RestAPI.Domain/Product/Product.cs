using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Product
{
    internal class Product : IProduct
    {
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }

        public Product(ProductDto product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }
    }
}

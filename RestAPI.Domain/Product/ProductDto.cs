using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Product
{
    internal class ProductDto
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal double Price { get; set; }
    }
}

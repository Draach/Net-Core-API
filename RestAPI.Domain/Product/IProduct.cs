using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Product
{
    internal interface IProduct
    {
        string Name { get; }
        string Description { get; }
        double Price { get; }
    }
}

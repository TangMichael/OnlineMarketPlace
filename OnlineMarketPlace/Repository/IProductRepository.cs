using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMarketPlace.Models;

namespace OnlineMarketPlace
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> getProducts();
        Product getOneProduct();
        IEnumerable<Product> GetAvailableProducts();
    }
}

using Newtonsoft.Json;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Service
{
    public class ProductService
    {
        private string path = Path.Combine(Environment.CurrentDirectory, "products.json");
        /// <summary>
        /// update count and write to json file, return new product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public Product UpdateInventoryCount(Product product, List<Product> products)
        {
            if (product.inventory_count > 0)
            {
                product.inventory_count--;
                foreach (Product obj in products)
                {
                    if (obj.id == product.id)
                    {
                        obj.inventory_count = obj.inventory_count--;
                        break;
                    }
                }
                try
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(products));
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e);
                }
            }
            return product;
        }
    }
}

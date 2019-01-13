using Newtonsoft.Json;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OnlineMarketPlace.Service;
using System.Reflection;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Repository
{
    public class ProductRepository
    {
        private string path = Path.Combine(Environment.CurrentDirectory, "products.json");
        public List<Product> products = new List<Product>();
        private ProductService service;

        /// <summary>
        /// initialise the class with all the objects from the database (json file)
        /// </summary>
        public ProductRepository()
        {
            service = new ProductService();
            var json = File.ReadAllText(path);
            var res = JsonConvert.DeserializeObject<Product[]>(json);
            products.AddRange(res);
        }

        /// <summary>
        /// Displays all products after reading the file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> getProducts()
        {
            if (File.Exists(path))
            {
                try
                {
                    return products;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the product bought with the new inventory count
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product getProductById(int id)
        {
            if (File.Exists(path))
            {
                return service.UpdateInventoryCount(products.Single(z => z.id == id), products);
            }
            else
            {
                throw new EmptyProductException("Invenotry is empty, Cannot buy");
            }
        }

        /// <summary>
        /// returns product with inventory count higher than 0
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> getAvailableProducts()
        {
            if (File.Exists(path))
            {
                try
                {
                    products = products.Where(element => element.inventory_count > 0).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return products;
            }

            return null;
        }
    }
}

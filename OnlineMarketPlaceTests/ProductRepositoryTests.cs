using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineMarketPlace.Models;
using OnlineMarketPlace.Repository;
using System.Collections.Generic;

namespace OnlineMarketPlaceTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void TestGetProducts()
        {
            ProductRepository repo = new ProductRepository();
            List<Product> x = new List<Product>();
            x.Add(new Product(1, "cards", 5, 2));
            x.Add(new Product(2, "cards", 5, 2));
            x.Add(new Product(3, "cards", 5, 2));
            x.Add(new Product(4, "cards", 5, 2));
            x.Add(new Product(5, "cards", 5, 2));
            x.Add(new Product(6, "cards", 5, 2));
            x.Add(new Product(7, "cards", 5, 2));
            x.Add(new Product(8, "cards", 5, 2));
            x.Add(new Product(9, "cards", 5, 2));
            x.Add(new Product(10, "cards", 5, 2));
            x.Add(new Product(11, "cards", 5, 2));
            CollectionAssert.AreEqual(x, repo.getProducts());

        }
    }
}

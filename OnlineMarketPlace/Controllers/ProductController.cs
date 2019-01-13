using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Models;
using OnlineMarketPlace.Repository;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineMarketPlace.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository repo;
        public ProductController()
        {
            repo = new ProductRepository();
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/product/viewAll")]
        public IEnumerable<Product> Get()
        {
            return repo.getProducts();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/product/buy/{id}")]
        public Product GetProductById(int id)
        {
            try
            {
                return repo.getProductById(id);
            } catch(EmptyProductException e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/product/viewAvailable")]
        public IEnumerable<Product> GetAvailableProduct()
        {
            return repo.getAvailableProducts();
        }


    }
}
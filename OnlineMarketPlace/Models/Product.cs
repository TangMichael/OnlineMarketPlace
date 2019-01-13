using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int inventory_count { get; set; }

        public Product(int id, string title, int price, int inventory_count)
        {
            this.id = id;
            this.title = title;
            this.price = price;
            this.inventory_count = inventory_count;
        }

    }
}

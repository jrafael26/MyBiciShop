using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Products
    {
        [Key]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public Brands Brands { get; set; }
        public int category_id { get; set; }
        public Categories Categories { get; set; }
        public int model_year { get; set; }
        public double list_price { get; set; }

        public string description { get; set; }

        public Stocks Stocks { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
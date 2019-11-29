using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class OrderItems
    {
        [Key]

        public int orderItem_id { get; set; }
        public int order_id { get; set; }
        public Orders Orders { get; set; }
        public int product_id { get; set; }
        public ICollection<Products> Products { get; set; }
        public double list_price { get; set; }
        public double discount { get; set; }
    }
}
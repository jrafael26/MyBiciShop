using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Stocks
    {
        [Key]
        [ForeignKey("Stores")]
        public int stock_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }

        public Stores Stores { get; set; }
    }
}
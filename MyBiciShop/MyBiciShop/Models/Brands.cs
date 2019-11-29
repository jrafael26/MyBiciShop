using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Brands
    {
        [Key]
        public int brand_id { get; set; }
        public string brand_name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
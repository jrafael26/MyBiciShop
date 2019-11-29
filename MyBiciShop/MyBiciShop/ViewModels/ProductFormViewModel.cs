using MyBiciShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBiciShop.ViewModels
{
    public class ProductFormViewModel
    {
        public Products Products { get; set; }
        public Stocks Stocks { get; set; }
    }
}
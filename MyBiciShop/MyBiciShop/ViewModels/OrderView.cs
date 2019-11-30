using MyBiciShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBiciShop.ViewModels
{
    public class OrderView
    {
        public Customers Customers { get; set; }

        //Solo para pintar nombres en las vistas
        public ProductOrderViewModel Product { get; set; }
        public List<ProductOrderViewModel> Products { get; set; }
        
    }
}
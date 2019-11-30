using MyBiciShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.ViewModels
{
    public class ProductOrderViewModel: Products
    {
        public List<Products> Products { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int quantity { get; set; }

        public float Valor { get { return (float)(quantity * list_price); } }
    }
}
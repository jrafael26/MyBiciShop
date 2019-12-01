using MyBiciShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBiciShop.ViewModels
{
    public class OrderFormViewModel
    {
        public Orders Order { get; set; }
        public List<OrderItems> OrderDetails { get; set; }
        public Staffs Staffs { get; set; }
        public Stores Stores { get; set; }
    }
}
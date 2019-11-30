using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public Customers Customers { get; set; }
        public OrderStatus order_status { get; set; }
        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }
        public DateTime shipped_date { get; set; }
        public int store_id { get; set; }
        public Stores Stores { get; set; }
        public int staff_id { get; set; }
        public Staffs Staffs { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
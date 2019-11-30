using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public enum OrderStatus
    {
        Created,
        InProgress,
        Shipping,
        Delivered
    }
}
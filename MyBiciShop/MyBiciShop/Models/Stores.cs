using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Stores
    {
        [Key]
        public int store_id { get; set; }
        public string store_name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip_code { get; set; }

        public ICollection<Stocks> Stocks { get; set; }
        public ICollection<Staffs> Staffs { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
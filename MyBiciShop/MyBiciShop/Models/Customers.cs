using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace MyBiciShop.Models
{
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip_code { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
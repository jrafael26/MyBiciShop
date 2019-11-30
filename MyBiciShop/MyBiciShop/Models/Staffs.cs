using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBiciShop.Models
{
    public class Staffs
    {
        [Key]
        public int staff_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public bool active { get; set; }
        public int store_id { get; set; }

        public Stores Stores { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
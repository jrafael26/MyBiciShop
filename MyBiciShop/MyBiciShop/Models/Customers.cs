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
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string first_name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string last_name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [StringLength(50)]
        [Display(Name = "Calle")]
        public string street { get; set; }
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string city { get; set; }
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string state { get; set; }

        [Display(Name = "Código postal")]
        public int zip_code { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
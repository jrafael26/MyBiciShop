using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string full_name { get { return string.Format("{0} {1}", first_name, last_name); } }
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
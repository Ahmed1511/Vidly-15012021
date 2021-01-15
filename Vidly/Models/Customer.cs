using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "this Field is Required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "this Field is Required.")]

        public DateTime DateofBirth { get; set; }
        public bool Issubscribed { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public int MembershipTypeID { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOS
{
    public class CustomerDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18ifAmember]
        public DateTime? DateofBirth { get; set; }
        public bool Issubscribed { get; set; }

        public MemberShipDto MemberShipDto { get; set; }
        public int MembershipDtoID { get; set; }
    }
}
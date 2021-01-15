using System;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public bool Issubscribed { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public int MembershipTypeID { get; set; }
    }
}
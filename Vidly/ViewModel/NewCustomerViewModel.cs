using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class NewCustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<MemberShipType> MemberShipTypes { get; set; }
    }
}
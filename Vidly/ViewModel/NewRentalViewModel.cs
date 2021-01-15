using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModel
{
    public class NewRentalViewModel
    {
        public int CustomerID { get; set; }
        public List<int> MoviesID { get; set; }
    }
}
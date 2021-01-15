using System.Collections.Generic;

namespace Vidly.DTOS
{
    public class NewRentalDto
    {
        public int CustomerID { get; set; }
        public List<int> MoviesID { get; set; }
    }
}
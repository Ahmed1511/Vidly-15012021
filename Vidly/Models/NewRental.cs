using System;

namespace Vidly.Models
{
    public class NewRental
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
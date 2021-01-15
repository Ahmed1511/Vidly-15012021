using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Movie Name Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select the Genre.")]
        public Genre Genre { get; set; }
        public int GenreID { get; set; }

        public int NumberInStock { get; set; }
        public int NumberAvilable { get; set; }
    }
}
using System;
using System.Linq;
using System.Web.Http;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult NewRental(NewRentalDto newrentaldto)
        {
            var customer = db.Customers.Single(c =>c.ID == newrentaldto.CustomerID);

            var movies = db.Movies.Where(m => newrentaldto.MoviesID.Contains(m.ID));

            
            foreach (var movie in movies)
            {
                if (movie.NumberAvilable == 0)
                {
                    return BadRequest("There is No Vedios Avilable.");
                }

                movie.NumberAvilable--;
                var newrental = new NewRental
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now
                };

                db.NewRentals.Add(newrental);
            }
            db.SaveChanges();
            return Ok();
        }
    }
}

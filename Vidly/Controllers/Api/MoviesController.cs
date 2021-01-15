using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IHttpActionResult Get(string query=null)
        {
            var movies = db.Movies.Include("Genre").ToList();
            return Ok(movies);
        }

        public Movie Get(int id)
        {
            var movie = db.Movies.Include("Genre").SingleOrDefault(c => c.ID == id);
            return movie;
        }

        public void Delete(int id)
        {
            var movieindb = Get(id);
            db.Movies.Remove(movieindb);
            db.SaveChanges();

        }


    }
}

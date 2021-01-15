using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Manager) || (User.IsInRole(RoleName.Admin)))
            {
                return View("index");
            }

            return View("ReadOnly");
        }


        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var Movie = new Movie();
            var Genres = db.Genres.ToList();
            NewMovieViewModel newMovieView = new NewMovieViewModel
            {
                Movie = Movie,
                Genres = Genres
            };
            return View("Create", newMovieView);
        }
        [HttpPost]
        public ActionResult Create(NewMovieViewModel newMovieView)
        {
            Movie movie = new Movie
            {
                ID = newMovieView.Movie.ID,
                Name = newMovieView.Movie.Name,
                Genre = newMovieView.Movie.Genre,
                GenreID = newMovieView.Movie.GenreID
            };
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return View("index");
            }
            return View(newMovieView);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.ID == id);
            var GenreInDB = db.Genres.ToList();
            var movieviewmodel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = GenreInDB
            };
            return View("Create", movieviewmodel);
        }
        [HttpPost]
        public ActionResult Edit(NewMovieViewModel newMovieView)
        {
            Movie movie = new Movie
            {
                ID = newMovieView.Movie.ID,
                Name = newMovieView.Movie.Name,
                GenreID = newMovieView.Movie.GenreID,
                Genre = newMovieView.Movie.Genre
            };
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(newMovieView);
        }
    }
}
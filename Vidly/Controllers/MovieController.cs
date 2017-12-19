using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> listMovies = new List<Movie>();
            listMovies.Add(new Movie() { Id = 1, Name = "Star Wars" });
            listMovies.Add(new Movie() { Id = 2, Name = "V for Vendetta" });

            return View(listMovies);
        }


    }
}
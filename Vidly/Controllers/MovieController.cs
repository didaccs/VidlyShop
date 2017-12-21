using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Linq;
using Vidly.ViewModels;
using System;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> listMovies = _context.Movies.Include(m => m.Genre).ToList();

            return View(listMovies);
        }

        public ActionResult Details(int Id)
        {
            Movie movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        public ActionResult New(Movie movie)
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };

            return View("Edit", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            Movie movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("Edit", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };

                return View("Edit", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else
            {
                var movieUpdate = _context.Movies.Single(c => c.Id == movie.Id);

                movieUpdate.Name = movie.Name;
                movieUpdate.GenreId = movie.GenreId;
                movieUpdate.DateAdded = movie.DateAdded;
                movieUpdate.ReleaseDate = movie.ReleaseDate;
                movieUpdate.NumberInStock = movie.NumberInStock;                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }


    }
}
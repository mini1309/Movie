using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMvcApp.Models;
using System.Data.Entity;
using MovieRentalMvcApp.ViewModels;

namespace MovieRentalMvcApp.Controllers
{
    public class MovGenController : Controller
    {
        ApplicationDbContext context;
        // GET: MovGen
        public ActionResult Index()
        {
            var movie = context.Movies.Include(context => context.Genre).ToList();
            return View(movie);
        }
        public MovGenController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Details(int id)
        {
            var movies = context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movies);
        }
        
        public ActionResult New()
        {
            var genres = context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)

                context.Movies.Add(movie);
            //context.movie.Add(movie);
            else
            {
                var customerInDb = context.Movies.Single(c => c.Id == movie.Id);//link to entity.
                customerInDb.MovieName = movie.MovieName;
                customerInDb.ReleaseDate = movie.ReleaseDate;
                customerInDb.DateAdded = movie.DateAdded;
                customerInDb.CdStock = movie.CdStock;

            }
            context.SaveChanges();
            return RedirectToAction("Index", "movie");
        }



    }

    }

            
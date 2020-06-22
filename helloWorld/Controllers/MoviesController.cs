using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWorld.Models;
using helloWorld.ViewModels;

namespace helloWorld.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "TEO" };

            // return Content("Hello World");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "teo"});

            //ViewData["RandomMovie"] = movie;
            //ViewBag.RandomMovie = movie; 

            var customer = new List<Customer>
            {
                new Customer { Name = "TEO1"},
                new Customer { Name = "TEO2"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };


            return View(viewModel);
        }
        public ActionResult Edit(int movieIda)
        {
            return Content("movieId=" + movieIda);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
               pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
               sortBy = "teo";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        /*
         * public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        */

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month) 
        {
            return Content(year + "/" + month);
        }
    }
}
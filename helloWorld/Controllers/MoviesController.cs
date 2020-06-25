using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWorld.Models;

namespace helloWorld.Controllers
{
    public class MoviesController : Controller
    {
        PGDbContext _context;
        public MoviesController()
        {
            _context = new PGDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            var movieList = _context.Movies.ToList();

            return View(movieList);
        }
       
        public ActionResult Edit(int movieIda)
        {
            return Content("movieId=" + movieIda);
        }
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
               pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
               sortBy = "teo";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        /*

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
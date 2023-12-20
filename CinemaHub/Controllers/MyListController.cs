using CinemaHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using CinemaHub.ViewModels;

namespace CinemaHub.Controllers
{
    [Authorize(Roles = "User,!Admin")]
    public class MyListController : Controller
    {

        private ApplicationDbContext _context;
        public MyListController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: MyList
        public ActionResult Index()
        {
            TempData["MyList"] = "active";

            var userId = User.Identity.GetUserId();


            var FavMovies = _context.UserMovies.Include(c => c.Movie).Where(x => x.UserId == userId).ToList();

            List<Movie> Movies = new List<Movie>();

            foreach (var movie in FavMovies)
            {
                var Fav = _context.movies.SingleOrDefault(c => c.Id == movie.MovieId);
                Movies.Add(Fav);
            }



            var FavSer = _context.UserSeries.Include(c => c.series).Where(x => x.UserId == userId).ToList();

            List<Series> Series = new List<Series>();

            foreach (var ser in FavSer)
            {
                var Fav = _context.series.SingleOrDefault(c => c.Id == ser.SeriesId);
                Series.Add(Fav);
            }

            var ViewModel = new MovieSeriesListViewModel
            {
                movies = Movies,
                series = Series,
            };






            return View(ViewModel);
        }


        
        public JsonResult DeleteFavMovie(int id) {

            var userId = User.Identity.GetUserId();




            UserMovie userMovie =_context.UserMovies.SingleOrDefault(c=>c.MovieId==id&&c.UserId==userId);
        
            _context.UserMovies.Remove(userMovie);

            _context.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);


        }

        public JsonResult DeleteFavSeries(int id)
        {

            var userId = User.Identity.GetUserId();




            UserSeries userSeries = _context.UserSeries.SingleOrDefault(c => c.SeriesId == id && c.UserId == userId);

            _context.UserSeries.Remove(userSeries);

            _context.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);


        }




    }
}
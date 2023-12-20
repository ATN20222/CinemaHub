using CinemaHub.Models;
using CinemaHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CinemaHub.Controllers
{
    [Authorize(Roles = "User,!Admin")]

    public class SeriesController : Controller
    {


        private ApplicationDbContext _context;
        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Series
        public ActionResult Index()
        {
            TempData["Series"] = "active";




            var userId = User.Identity.GetUserId();

            var series = _context.series.Include(c => c.Genre).ToList();
            var FavSer = _context.UserSeries.Include(c => c.series).Where(x => x.UserId == userId).ToList();

            List<Series> Series = new List<Series>();

            foreach (var ser in FavSer)
            {
                var Fav = _context.series.SingleOrDefault(c => c.Id == ser.SeriesId);
                Series.Add(Fav);
            }


            foreach (var item in series)
            {

                if (Series.Contains(item))
                {
                    item.IsFavourite = true;
                }

            }




            return View(series);
        }

        public ActionResult WatchingEpisode(int id )
        {

            var ser = _context.series.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            var episode = _context.episodes.Where(c => c.SeriesId == ser.Id).ToList();

            var ViewModel = new SeriesEpisodeViewModel
            {
                series = ser,
                episodes = episode

            };


            return View(ViewModel);
        }






        [HttpPost]
        public JsonResult AddToFavorites(int id)
        {

            var series = _context.series.SingleOrDefault(c => c.Id == id);


            if (series != null)
            {
                var IdUser = User.Identity.GetUserId();
                var ConUser = _context.Users.Single(c => c.Id == IdUser);
                UserSeries userSeries = new UserSeries()
                {
                    SeriesId = series.Id,
                    series = series,
                    UserId = IdUser,
                    User = ConUser


                };
                _context.UserSeries.Add(userSeries);
                _context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }

        }


        [HttpPost]
        public JsonResult DeleteFav(int id)
        {

            var userId = User.Identity.GetUserId();




            UserSeries userSeries = _context.UserSeries.SingleOrDefault(c => c.SeriesId == id && c.UserId == userId);



            _context.UserSeries.Remove(userSeries);


            _context.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);


        }




    }
}
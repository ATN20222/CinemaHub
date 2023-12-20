using CinemaHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaHub.Controllers
{
    public class AddToFavController : Controller
    {
        private ApplicationDbContext _context;
        public AddToFavController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: AddToFav
        public ActionResult Index()
        {
            return View();
        }

        

        public JsonResult AddToFav(int id)
        {
            var Movie = _context.movies.SingleOrDefault(c => c.Id == id);


            if (Movie != null)
            {
                var IdUser = User.Identity.GetUserId();
                var ConUser = _context.Users.Single(c => c.Id == IdUser);
                UserMovie userMovie = new UserMovie()
                {
                    MovieId = Movie.Id,
                    Movie = Movie,
                    UserId = IdUser,
                    User = ConUser


                };


                _context.UserMovies.Add(userMovie);
                _context.SaveChanges();
                return Json( "true" , JsonRequestBehavior.AllowGet );
            }
            else
            {
                return Json( "false" );
            }



        }


    }
}
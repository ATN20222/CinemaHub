using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using CinemaHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace CinemaHub.Controllers
{

    public class MoviseController : Controller
    {
        private ApplicationDbContext _context;
        public MoviseController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movise
        public ActionResult Index()
        {
            TempData["Movie"] = "active";



            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "DashBoard");
            }

            var userId = User.Identity.GetUserId();

            var movie =_context.movies.Include(c=>c.Genre).ToList();
            var FavMovies = _context.UserMovies.Include(c => c.Movie).Where(x => x.UserId == userId).ToList();

            List<Movie> Movies = new List<Movie>();

            foreach (var mov in FavMovies)
            {
                var Fav = _context.movies.SingleOrDefault(c => c.Id == mov.MovieId);
                Movies.Add(Fav);
            }


            foreach (var item in movie)
            {

                if (Movies.Contains(item))
                {
                    item.IsFavourite= true;
                }

            }



            return View(movie);
        }



        [HttpPost]
        public JsonResult DeleteFav(int id)
        {

            var userId = User.Identity.GetUserId();




            UserMovie userMovie = _context.UserMovies.SingleOrDefault(c => c.MovieId == id && c.UserId == userId);



            _context.UserMovies.Remove(userMovie);
            

            _context.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
           
            
        }



        public ActionResult MoviesForm()
        {
            var Genre = _context.genres.ToList();

            var viewModel = new MovieGenreViewModel
            {
                movie = new Movie(),
                genre = Genre,
            };

            return View(viewModel);
        }


        public ActionResult Create(Movie movie)
        {


            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel
                {
                    movie = movie,
                    genre = _context.genres.ToList()
                };
                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.movies.Add(movie);

            }

            else
            {
                var oldMovie = _context.movies.SingleOrDefault(c => c.Id == movie.Id);
                oldMovie.GenreId = movie.GenreId;
                oldMovie.Name = movie.Name;
                oldMovie.ReleaseDate = movie.ReleaseDate;
                oldMovie.Description = movie.Description;
                oldMovie.ImgSrc = movie.ImgSrc;
                oldMovie.VidSrc = movie.VidSrc;
            }

            _context.SaveChanges();


            return RedirectToAction("MoviesForm", "Movise");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieGenreViewModel
            {
                movie = movie,
                genre = _context.genres.ToList(),
            };
            return View("MoviesForm", viewModel);
        }

        //to search
        //.Where(c=>c.Name==)




        [HttpPost]
        public JsonResult AddToFavorites(int id)
        {

            var Movie=_context.movies.SingleOrDefault(c=>c.Id== id);

            
            if (Movie != null)
            {
                var IdUser = User.Identity.GetUserId();
                var ConUser = _context.Users.Single(c => c.Id == IdUser);
                UserMovie userMovie = new UserMovie() {
                    MovieId = Movie.Id,
                    Movie = Movie,
                    UserId = IdUser,
                    User = ConUser
                    
                   
            };
                _context.UserMovies.Add(userMovie);
                _context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }

        }





      



    }



    







}
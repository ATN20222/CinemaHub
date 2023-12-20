using CinemaHub.Models;
using CinemaHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace CinemaHub.Controllers
{
    [Authorize(Roles = "Admin")]
    //[AllowAnonymous]
    public class DashBoardController : Controller
    {

        private ApplicationDbContext _context;
        public DashBoardController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: DashBoard
        public ActionResult Index()
        {

            var movie=_context.movies.Include(c=>c.Genre).ToList();


            return View(movie);
        }



        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult ManageMovies()
        {
            return View();
        }




        public ActionResult ManageSeries()
        {
            return View();
        }

        public ActionResult SeriesForm()
        {
            var Genre = _context.genres.ToList();

            var viewModel = new SeriesGenreViewModel
            {
               series  = new Series(),
                genre = Genre,
            };

            return View(viewModel);
        }


        public ActionResult CreateSeries(Series series)
        {


            if (!ModelState.IsValid)
            {
                var viewModel = new SeriesGenreViewModel
                {
                    series = series,
                    genre = _context.genres.ToList()
                };
                return View("SeriesForm", viewModel);
            }

            if (series.Id == 0)
            {
                _context.series.Add(series);

            }

            else
            {
                var oldMovie = _context.series.SingleOrDefault(c => c.Id == series.Id);
                oldMovie.GenreId = series.GenreId;
                oldMovie.Name = series.Name;
                oldMovie.ReleaseDate = series.ReleaseDate;
                oldMovie.Description = series.Description;
                oldMovie.ImgSrc = series.ImgSrc;

            }

            _context.SaveChanges();


            return RedirectToAction("SeriesForm", "Dashboard");
        }



        public ActionResult EditSeries(int id)
        {
            var series = _context.series.SingleOrDefault(c => c.Id == id);
            if (series == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SeriesGenreViewModel
            {
                series = series,
                genre = _context.genres.ToList(),
            };

            
            return View("SeriesForm", viewModel);
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


            return RedirectToAction("MoviesForm", "Dashboard");
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




        public ActionResult GetUser()
        {

            
           

            var userManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var users = userManager.Users.ToList();
            var viewModel = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = userManager.GetRoles(user.Id);
                var userViewModel = new UserRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email= user.Email,
                    PhoneNumber= user.PhoneNumber,
                    Roles = string.Join(", ", roles)
                };
                viewModel.Add(userViewModel);
            }

            return View(viewModel);


        }
  













    }
}